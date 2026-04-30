using OGAData;
using Xunit;

namespace OGATests
{
    public class StudentDataTests
    {
        [Fact]
        public void ImportFromCsv_FichierValide_ImporteEtudiants()
        {
            string csv = "E01;Potter;Harry\nE02;Granger;Hermione";
            string path = Path.GetTempFileName();
            File.WriteAllText(path, csv);
            string jsonPath = Path.Combine(Path.GetDirectoryName(path)!, "students.json");

            try
            {
                var data = new StudentData(Path.GetDirectoryName(path)!);
                data.ImportFromCsv(path);
                var students = data.ListStudent();

                Assert.Equal(2, students.Count);
                Assert.Contains(students, s => s.Code == "001" && s.LastName == "Potter");
                Assert.Contains(students, s => s.Code == "002" && s.LastName == "Granger");
            }
            finally
            {
                File.Delete(path);
                if (File.Exists(jsonPath)) File.Delete(jsonPath);
            }
        }

        [Fact]
        public void ImportFromCsv_LigneAvecChampsSupplementaires_Ignoree()
        {
            string csv = "E01;Potter;Harry;extra;data";
            string path = Path.GetTempFileName();
            File.WriteAllText(path, csv);
            string jsonPath = Path.Combine(Path.GetDirectoryName(path)!, "students.json");

            try
            {
                var data = new StudentData(Path.GetDirectoryName(path)!);
                data.ImportFromCsv(path);
                var students = data.ListStudent();

                Assert.Single(students);
                Assert.Equal("001", students[0].Code);
            }
            finally
            {
                File.Delete(path);
                if (File.Exists(jsonPath)) File.Delete(jsonPath);
            }
        }
    }
}

using OGAData;
using OGAShared.Models;
using System.Collections.ObjectModel;
using Xunit;

namespace OGATests
{
    public class StudentDataTests
    {
        [Fact]
        public void ImportFromCsv_FichierValide_ImporteEtudiants()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            string csv = "001;Potter;Harry\n002;Granger;Hermione";
            string path = Path.Combine(tempDir, "students.csv");
            File.WriteAllText(path, csv);
            string jsonPath = Path.Combine(tempDir, "students.json");

            try
            {
                StudentData? data = new StudentData(tempDir);
                data.ImportFromCsv(path);
                ObservableCollection<Student> students = data.ListStudent();

                Assert.Equal(2, students.Count);
                Assert.Contains(students, s => s.Code == "001" && s.LastName == "Potter");
                Assert.Contains(students, s => s.Code == "002" && s.LastName == "Granger");
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        [Fact]
        public void ImportFromCsv_LigneAvecChampsSupplementaires_Ignoree()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            string csv = "001;Potter;Harry;extra;data";
            string path = Path.Combine(tempDir, "students.csv");
            File.WriteAllText(path, csv);

            try
            {
                StudentData? data = new StudentData(tempDir);
                data.ImportFromCsv(path);
                ObservableCollection<Student> students = data.ListStudent();

                Assert.Single(students);
                Assert.Equal("001", students[0].Code);
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        [Fact]
        public void SaveStudents_PuisListStudent_RetourneEtudiants()
        {
            string jsonPath = Path.Combine(Path.GetTempPath(), $"students_test_{Guid.NewGuid()}.json");

            try
            {
                StudentData? data = new StudentData(Path.GetDirectoryName(jsonPath)!);
                List<Student> students = new List<Student>
                {
                    new Student("001", "Potter", "Harry"),
                    new Student("002", "Granger", "Hermione")
                };

                data.SaveStudents(students);
                ObservableCollection<Student>? loaded = data.ListStudent();

                Assert.Equal(2, loaded.Count);
                Assert.Contains(loaded, s => s.Code == "001" && s.LastName == "Potter");
                Assert.Contains(loaded, s => s.Code == "002" && s.LastName == "Granger");
            }
            finally
            {
                if (File.Exists(jsonPath)) File.Delete(jsonPath);
            }
        }

        [Fact]
        public void ListStudent_FichierIntrouvable_CreeListe()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            try
            {
                StudentData data = new StudentData(tempDir);
                var result = data.ListStudent();

                Assert.NotNull(result);
                Assert.Empty(result);
                Assert.True(File.Exists(Path.Combine(tempDir, "students.json")));
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }
    }
}

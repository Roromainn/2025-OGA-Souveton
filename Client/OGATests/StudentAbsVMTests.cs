using OGAShared.Models;
using OGAVM.ViewModel;
using Xunit;

namespace OGATests
{
    public class StudentAbsVMTests
    {
        private static Course Cours(string matiere, string prof, int duree, DateTime date, params string[] absents) => new Course
        {
            CourseName = matiere,
            TeacherName = prof,
            Duration = duree,
            DateDetail = date,
            AbsentStudentsCodes = absents
        };

        [Fact]
        public void Absences_EtudiantAbsentDeuxCours_DeuxLignes()
        {
            Student etudiant = new Student("001", "Potter", "Harry");
            Course[]? cours = new[]
            {
                Cours("Maths", "Mme Serrier", 120, new DateTime(2025, 2, 17, 10, 0, 0), "001"),
                Cours("Algo", "Mr. Simonet", 60, new DateTime(2025, 2, 20, 8, 0, 0), "001")
            };

            StudentAbsVM vm = new StudentAbsVM(etudiant, cours);

            Assert.Equal(2, vm.Absences.Count);
        }

        [Fact]
        public void Absences_EtudiantPresent_ListeVide()
        {
            Student etudiant = new Student("001", "Potter", "Harry");
            Course[]? cours = new[] { Cours("Maths", "Mme Serrier", 120, DateTime.Today, "002") };

            StudentAbsVM vm = new StudentAbsVM(etudiant, cours);

            Assert.Empty(vm.Absences);
        }

        [Fact]
        public void Absences_FormatCorrect()
        {
            Student etudiant = new Student("001", "Potter", "Harry");
            Course[]? cours = new[] { Cours("Maths", "Mme Serrier", 120, new DateTime(2025, 2, 17, 10, 0, 0), "001") };

            StudentAbsVM vm = new StudentAbsVM(etudiant, cours);

            StudentAbsenceDetail abs = vm.Absences[0];
            Assert.Equal("17/02/2025", abs.FormattedDate);
            Assert.Equal("10:00", abs.FormattedTime);
            Assert.Equal("Maths", abs.CourseName);
            Assert.Equal("Mme Serrier", abs.TeacherName);
            Assert.Equal(120, abs.Duration);
        }

        [Fact]
        public void Absences_TrieeParDateDecroissante()
        {
            Student etudiant = new Student("001", "Potter", "Harry");
            Course[]? cours = new[]
            {
                Cours("Algo", "Prof", 60, new DateTime(2025, 2, 20), "001"),
                Cours("Maths", "Prof", 120, new DateTime(2025, 2, 17), "001")
            };

            StudentAbsVM vm = new StudentAbsVM(etudiant, cours);

            Assert.Equal("20/02/2025", vm.Absences[0].FormattedDate);
            Assert.Equal("17/02/2025", vm.Absences[1].FormattedDate);
        }

        [Fact]
        public void StudentFullName_NomComplet()
        {
            Student etudiant = new Student("001", "Potter", "Harry");

            StudentAbsVM vm = new StudentAbsVM(etudiant, Array.Empty<Course>());

            Assert.Equal("Harry Potter", vm.StudentFullName);
        }
    }
}

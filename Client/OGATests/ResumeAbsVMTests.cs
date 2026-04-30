using OGAMetier.Models;
using OGAVM.ViewModel;
using Xunit;

namespace OGATests
{
    public class ResumeAbsVMTests
    {
        private static Student Etudiant(string code) => new Student(code, "Nom", "Prénom");
        private static Course Cours(int duree, params string[] absents) => new Course
        {
            DateDetail = DateTime.Today,
            CourseName = "Matière",
            TeacherName = "Prof",
            Duration = duree,
            AbsentStudentsCodes = absents
        };

        [Fact]
        public void Stats_EtudiantAbsentUnCours_TotalDurationEgalDureeCours()
        {
            var etudiant = Etudiant("E01");
            var cours = Cours(120, "E01");

            var vm = new ResumeAbsVM(new[] { etudiant }, new[] { cours });

            Assert.Equal(120, vm.Stats[0].TotalDuration);
        }

        [Fact]
        public void Stats_EtudiantAbsentPlusieurssCours_TotalDurationEgalSomme()
        {
            var etudiant = Etudiant("E01");
            var cours1 = Cours(60, "E01");
            var cours2 = Cours(90, "E01");

            var vm = new ResumeAbsVM(new[] { etudiant }, new[] { cours1, cours2 });

            Assert.Equal(150, vm.Stats[0].TotalDuration);
        }

        [Fact]
        public void Stats_EtudiantPresent_TotalDurationEgalZero()
        {
            var etudiant = Etudiant("E01");
            var cours = Cours(120, "E02");

            var vm = new ResumeAbsVM(new[] { etudiant }, new[] { cours });

            Assert.Equal(0, vm.Stats[0].TotalDuration);
        }

        [Fact]
        public void Stats_PlusieursEtudiants_ChacunASesPropresStats()
        {
            var e1 = Etudiant("E01");
            var e2 = Etudiant("E02");
            var cours = Cours(60, "E01");

            var vm = new ResumeAbsVM(new[] { e1, e2 }, new[] { cours });

            Assert.Equal(60, vm.Stats.First(s => s.StudentLastName == "Nom").TotalDuration);
        }
    }
}

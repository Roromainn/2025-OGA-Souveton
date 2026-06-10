using OGAShared.Models;
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
            Student etudiant = Etudiant("001");
            Course cours = Cours(120, "001");

            ResumeAbsVM vm = new ResumeAbsVM(new[] { etudiant }, new[] { cours });

            Assert.Equal(120, vm.Stats[0].TotalDuration);
        }

        [Fact]
        public void Stats_EtudiantAbsentPlusieurssCours_TotalDurationEgalSomme()
        {
            Student etudiant = Etudiant("001");
            Course cours1 = Cours(60, "001");
            Course cours2 = Cours(90, "001");

            ResumeAbsVM vm = new ResumeAbsVM(new[] { etudiant }, new[] { cours1, cours2 });
            Assert.Equal(150, vm.Stats[0].TotalDuration);
        }

        [Fact]
        public void Stats_EtudiantPresent_TotalDurationEgalZero()
        {
            Student etudiant = Etudiant("001");
            Course cours = Cours(120, "002");

            ResumeAbsVM vm = new ResumeAbsVM(new[] { etudiant }, new[] { cours });

            Assert.Equal(0, vm.Stats[0].TotalDuration);
        }

        [Fact]
        public void Stats_PlusieursEtudiants_ChacunASesPropresStats()
        {
            Student e1 = Etudiant("001");
            Student e2 = Etudiant("002");
            Course cours = Cours(60, "001");

            ResumeAbsVM vm = new ResumeAbsVM(new[] { e1, e2 }, new[] { cours });

            Assert.Equal(60, vm.Stats.First(s => s.StudentLastName == "Nom").TotalDuration);
        }
    }
}

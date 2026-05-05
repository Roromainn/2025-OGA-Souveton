using OGAMetier.Models;
using OGAVM.ViewModel;
using OGATests.Fakes;
using Xunit;

namespace OGATests
{
    public class MainVMTests
    {
        private static MainVM BuildVM(IEnumerable<Student>? students = null, IEnumerable<Course>? courses = null)
            => new MainVM(new FakeStudentRepository(students), new FakeCourseRepository(courses));

        [Fact]
        public void AddStudent_AjouteEtudiantALaListe()
        {
            MainVM vm = BuildVM();
            Student etudiant = new Student("001", "Potter", "Harry");

            vm.AddStudent(etudiant);

            Assert.Single(vm.Students);
            Assert.Equal("001", vm.Students[0].Code);
        }

        [Fact]
        public void AddStudent_PlusieursEtudiants_TousPresents()
        {
            MainVM vm = BuildVM();

            vm.AddStudent(new Student("001", "Potter", "Harry"));
            vm.AddStudent(new Student("002", "Granger", "Hermione"));

            Assert.Equal(2, vm.Students.Count);
        }

        [Fact]
        public void ListStudent_ChargeEtudiantsInitiaux()
        {
            Student[]? initial = new[] { new Student("001", "Potter", "Harry") };
            MainVM vm = BuildVM(students: initial);

            Assert.Single(vm.Students);
        }

        [Fact]
        public void AddAbsence_AjouteCours()
        {
            MainVM vm = BuildVM();
            Course cours = new Course { CourseName = "Maths", Duration = 120, AbsentStudentsCodes = new[] { "001" } };

            vm.AddAbsence(cours);

            Assert.Single(vm.ListCourses());
        }

        [Fact]
        public void ListCourses_RetourneLesCoursExistants()
        {
            Course? cours = new Course { CourseName = "Algo", Duration = 60 };
            MainVM vm = BuildVM(courses: new[] { cours });

            List<Course> result = vm.ListCourses();

            Assert.Single(result);
            Assert.Equal("Algo", result[0].CourseName);
        }
    }
}

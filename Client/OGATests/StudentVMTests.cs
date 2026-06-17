using OGAShared.Models;
using OGAVM.ViewModel;
using Xunit;

namespace OGATests
{
    public class StudentVMTests
    {
        [Fact]
        public void FirstName_LecturePropriete()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentVM vm = new StudentVM(student);

            Assert.Equal("Harry", vm.FirstName);
        }

        [Fact]
        public void FirstName_ModificationPropriete()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentVM vm = new StudentVM(student);

            vm.FirstName = "James";

            Assert.Equal("James", vm.FirstName);
            Assert.Equal("James", student.FirstName);
        }

        [Fact]
        public void LastName_LecturePropriete()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentVM vm = new StudentVM(student);

            Assert.Equal("Potter", vm.LastName);
        }

        [Fact]
        public void LastName_ModificationPropriete()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentVM vm = new StudentVM(student);

            vm.LastName = "Evans";

            Assert.Equal("Evans", vm.LastName);
            Assert.Equal("Evans", student.LastName);
        }

        [Fact]
        public void Student_LecturePropriete()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentVM vm = new StudentVM(student);

            Assert.Equal(student, vm.Student);
        }

        [Fact]
        public void PropertyChanged_Declenche()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentVM vm = new StudentVM(student);
            bool propertyChanged = false;

            vm.PropertyChanged += (s, e) => propertyChanged = true;
            vm.FirstName = "James";

            Assert.True(propertyChanged);
        }

        [Fact]
        public void Validate_CodeVide_LevelException()
        {
            Student student = new Student("", "Potter", "Harry");

            var ex = Assert.Throws<ArgumentException>(() => student.Validate());
            Assert.Contains("Code étudiant obligatoire", ex.Message);
        }

        [Fact]
        public void Validate_LastNameVide_LevelException()
        {
            Student student = new Student("001", "", "Harry");

            var ex = Assert.Throws<ArgumentException>(() => student.Validate());
            Assert.Contains("Nom de famille obligatoire", ex.Message);
        }

        [Fact]
        public void Validate_CodeEtLastNameRemplis_NoException()
        {
            Student student = new Student("001", "Potter", "Harry");

            student.Validate();
        }

        [Fact]
        public void Validate_FirstNameVide_NoException()
        {
            Student student = new Student("001", "Potter", null);

            student.Validate();
        }

        [Fact]
        public void TryValidate_StudentValide_ReturnTrue()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentVM vm = new StudentVM(student);

            bool result = vm.TryValidate();

            Assert.True(result);
            Assert.Null(vm.ErrorMessage);
        }

        [Fact]
        public void TryValidate_CodeVide_ReturnFalse()
        {
            Student student = new Student("", "Potter", "Harry");
            StudentVM vm = new StudentVM(student);

            bool result = vm.TryValidate();

            Assert.False(result);
            Assert.NotNull(vm.ErrorMessage);
            Assert.Contains("Code étudiant obligatoire", vm.ErrorMessage);
        }

        [Fact]
        public void TryValidate_LastNameVide_ReturnFalse()
        {
            Student student = new Student("001", "", "Harry");
            StudentVM vm = new StudentVM(student);

            bool result = vm.TryValidate();

            Assert.False(result);
            Assert.NotNull(vm.ErrorMessage);
            Assert.Contains("Nom de famille obligatoire", vm.ErrorMessage);
        }
    }
}

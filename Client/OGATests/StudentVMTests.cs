using OGAMetier.Models;
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
    }
}

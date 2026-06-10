using OGAShared.Models;
using OGAVM.ViewModel;
using Xunit;

namespace OGATests
{
    public class StudentPresenceVMTests
    {
        [Fact]
        public void StudentFullName_FormatCorrect()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentPresenceVM vm = new StudentPresenceVM(student);

            Assert.Equal("Potter Harry", vm.StudentFullName);
        }

        [Fact]
        public void Student_Propriete()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentPresenceVM vm = new StudentPresenceVM(student);

            Assert.Equal(student, vm.Student);
        }

        [Fact]
        public void IsAbsent_Defaut()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentPresenceVM vm = new StudentPresenceVM(student);

            Assert.False(vm.IsAbsent);
        }

        [Fact]
        public void IsAbsent_Modification()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentPresenceVM vm = new StudentPresenceVM(student);

            vm.IsAbsent = true;

            Assert.True(vm.IsAbsent);
        }

        [Fact]
        public void PropertyChanged_Declenche()
        {
            Student student = new Student("001", "Potter", "Harry");
            StudentPresenceVM vm = new StudentPresenceVM(student);
            bool propertyChanged = false;

            vm.PropertyChanged += (s, e) => propertyChanged = true;
            vm.IsAbsent = true;

            Assert.True(propertyChanged);
        }
    }
}

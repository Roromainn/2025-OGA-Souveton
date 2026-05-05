using OGAMetier.Models;
using OGAVM.ViewModel;
using OGATests.Fakes;
using Xunit;

namespace OGATests
{
    public class CourseVMTests
    {
        [Fact]
        public void BuildCourse_RetourneCoursAvecBonnesInfos()
        {
            Student[]? students = new[] { new Student("001", "Potter", "Harry"), new Student("002", "Granger", "Hermione") };
            FakeCourseRepository? repo = new FakeCourseRepository();
            CourseVM? vm = new CourseVM(students, repo);

            vm.CourseName = "Maths";
            vm.TeacherName = "Prof. Smith";
            vm.Duration = 120;
            vm.CourseDate = new System.DateTime(2025, 3, 15);
            vm.SelectedHour = 10;
            vm.SelectedMinute = 30;
            vm.StudentsPresence[0].IsAbsent = true;

            Course? course = vm.BuildCourse();

            Assert.Equal("Maths", course.CourseName);
            Assert.Equal("Prof. Smith", course.TeacherName);
            Assert.Equal(120, course.Duration);
            Assert.Single(course.AbsentStudentsCodes);
            Assert.Equal("001", course.AbsentStudentsCodes[0]);
        }

        [Fact]
        public void BuildCourse_DateComplete()
        {
            Student[] students = new[] { new Student("001", "Potter", "Harry") };
            FakeCourseRepository repo = new FakeCourseRepository();
            CourseVM vm = new CourseVM(students, repo);

            vm.CourseDate = new System.DateTime(2025, 3, 15);
            vm.SelectedHour = 14;
            vm.SelectedMinute = 45;

            Course? course = vm.BuildCourse();

            Assert.Equal(14, course.DateDetail.Hour);
            Assert.Equal(45, course.DateDetail.Minute);
            Assert.Equal(15, course.DateDetail.Day);
            Assert.Equal(3, course.DateDetail.Month);
        }

        [Fact]
        public void ListAbsences_RetourneEtudiantsAbsents()
        {
            Student[] students = new[] { new Student("001", "Potter", "Harry"), new Student("002", "Granger", "Hermione") };
            FakeCourseRepository? repo = new FakeCourseRepository();
            CourseVM? vm = new CourseVM(students, repo);

            Course? course = new Course { CourseName = "Maths", Duration = 120, AbsentStudentsCodes = new[] { "001" } };
            List<Student> absences = vm.ListAbsences(course).ToList();

            Assert.Single(absences);
            Assert.Equal("001", absences.First().Code);
        }

        [Fact]
        public void StudentsPresence_ContientTousLesEtudiants()
        {
            Student[] students = new[] { new Student("001", "Potter", "Harry"), new Student("002", "Granger", "Hermione") };
            FakeCourseRepository? repo = new FakeCourseRepository();
            CourseVM? vm = new CourseVM(students, repo);

            Assert.Equal(2, vm.StudentsPresence.Count);
            Assert.Equal("Harry", vm.StudentsPresence[0].StudentFullName.Split()[1]);
        }

        [Fact]
        public void DefaultValues()
        {
            Student[] students = new[] { new Student("001", "Potter", "Harry") };
            FakeCourseRepository? repo = new FakeCourseRepository();
            CourseVM? vm = new CourseVM(students, repo);

            Assert.Equal(120, vm.Duration);
            Assert.Equal(8, vm.SelectedHour);
            Assert.Equal(0, vm.SelectedMinute);
        }
    }
}

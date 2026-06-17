using OGAMetier.Interfaces;
using OGAShared.Models;

namespace OGATests.Fakes
{
    public class FakeCourseRepository : ICourseRepository
    {
        private List<Course> courses = new();

        public FakeCourseRepository(IEnumerable<Course>? initial = null)
        {
            if (initial != null) courses = new(initial);
        }

        public List<Course> ListCourse() => new(courses);
        public IEnumerable<Student> ListAbsences(Course course, IEnumerable<Student> students) 
            => students.Where(s => course.AbsentStudentsCodes.Contains(s.Code));
        public void SaveCourse(List<Course> c) => courses = new(c);
    }
}

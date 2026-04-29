using OGAMetier.Models;
using System.Collections.Generic;

namespace OGAMetier.Interfaces
{
    public interface ICourseRepository
    {
        List<Course> ListCourse();
        IEnumerable<Student> ListAbsences(Course course, IEnumerable<Student> students);
        void SaveCourse(List<Course> courses);
    }
}

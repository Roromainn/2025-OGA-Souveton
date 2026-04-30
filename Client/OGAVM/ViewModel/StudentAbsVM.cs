using OGAMetier.Models;

namespace OGAVM.ViewModel
{
    public class StudentAbsVM
    {
        public string StudentFullName { get; }
        public List<string> Absences { get; }

        public StudentAbsVM(Student student, IEnumerable<Course> courses)
        {
            StudentFullName = $"{student.FirstName} {student.LastName}";
            Absences = courses
                .Where(c => c.AbsentStudentsCodes.Contains(student.Code))
                .OrderByDescending(c => c.DateDetail)
                .Select(c => $"{c.DateDetail:dd/MM/yyyy}, {c.DateDetail:H:mm}, {c.CourseName} ({c.TeacherName}), {c.Duration} min")
                .ToList();
        }
    }
}

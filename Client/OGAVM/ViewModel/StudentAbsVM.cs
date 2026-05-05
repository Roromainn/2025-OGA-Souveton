using OGAMetier.Models;
using System.Collections.ObjectModel;

namespace OGAVM.ViewModel
{
    public class StudentAbsVM
    {
        #region--Attirbutes--
        private string studentFullName;

        private ObservableCollection<StudentAbsenceDetail> absences;

        private int totalDuration;

        private int totalDurationUnjustified;
        #endregion

        #region--Properties--
        public string StudentFullName { get { return studentFullName; } }
        public ObservableCollection<StudentAbsenceDetail> Absences { get { return absences; } }
        public int TotalDuration { get { return totalDuration; } }
        public int TotalDurationUnjustified { get { return totalDurationUnjustified; } }
        #endregion

        #region--Constructor--
        public StudentAbsVM(Student student, IEnumerable<Course> courses)
        {
            studentFullName = $"{student.FirstName} {student.LastName}";
            absences = new ObservableCollection<StudentAbsenceDetail>();

            List<Course> studentCourses = courses
                .Where(c => c.AbsentStudentsCodes.Contains(student.Code))
                .OrderByDescending(c => c.DateDetail)
                .ToList();

            totalDuration = studentCourses.Sum(c => c.Duration);

            foreach (Course course in studentCourses)
            {
                Absences.Add(new StudentAbsenceDetail
                {
                    Date = course.DateDetail,
                    CourseName = course.CourseName,
                    TeacherName = course.TeacherName,
                    Duration = course.Duration,
                    Justified = false,
                    Justification = string.Empty
                });
            }

            totalDurationUnjustified = Absences.Count(a => !a.Justified) * (TotalDuration / Math.Max(Absences.Count, 1));
        }
        #endregion
    }
}

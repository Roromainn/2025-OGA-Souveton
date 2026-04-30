using OGAMetier.Models;

namespace OGAVM.ViewModel
{
    public class ResumeAbsVM
    {
        public List<StatsAbsences> Stats { get; }

        public ResumeAbsVM(IEnumerable<Student> students, IEnumerable<Course> courses)
        {
            Stats = students
                .Select(s => new StatsAbsences(
                    s,
                    courses.Where(c => c.AbsentStudentsCodes.Contains(s.Code)).Sum(c => c.Duration)
                ))
                .ToList();
        }
    }
}

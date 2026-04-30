using OGAMetier.Interfaces;
using OGAMetier.Models;
using System.Collections.ObjectModel;

namespace OGATests.Fakes
{
    public class FakeStudentRepository : IStudentRepository
    {
        private List<Student> students = new();

        public FakeStudentRepository(IEnumerable<Student>? initial = null)
        {
            if (initial != null) students = new(initial);
        }

        public ObservableCollection<Student> ListStudent() => new(students);
        public void SaveStudents(List<Student> s) => students = new(s);
        public void ImportFromCsv(string path) { }
    }
}

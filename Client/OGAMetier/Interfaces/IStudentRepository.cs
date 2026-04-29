using OGAMetier.Models;
using System.Collections.ObjectModel;

namespace OGAMetier.Interfaces
{
    public interface IStudentRepository
    {
        ObservableCollection<Student> ListStudent();
        void SaveStudents(List<Student> students);
    }
}

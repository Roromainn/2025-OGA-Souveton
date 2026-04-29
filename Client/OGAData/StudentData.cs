using OGAMetier.Interfaces;
using OGAMetier.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace OGAData
{
    public class StudentData : IStudentRepository
    {
        public ObservableCollection<Student> ListStudent()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.json");
            if (!File.Exists(jsonPath))
                throw new FileNotFoundException("Fichier étudiant introuvable", jsonPath);

            string json = File.ReadAllText(jsonPath);
            List<Student> loadedStudents = JsonSerializer.Deserialize<List<Student>>(json)
                ?? throw new InvalidDataException("Le fichier étudiant est vide ou invalide");

            return new ObservableCollection<Student>(loadedStudents);
        }

        public void SaveStudents(List<Student> students)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.json");
            File.WriteAllText(path, JsonSerializer.Serialize(students));
        }
    }
}

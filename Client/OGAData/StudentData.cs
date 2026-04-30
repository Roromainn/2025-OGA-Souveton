using OGAMetier.Interfaces;
using OGAMetier.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace OGAData
{
    public class StudentData : IStudentRepository
    {
        private readonly string basePath;

        public StudentData(string? basePath = null)
        {
            this.basePath = basePath ?? AppDomain.CurrentDomain.BaseDirectory;
        }

        public ObservableCollection<Student> ListStudent()
        {
            string jsonPath = Path.Combine(basePath, "students.json");
            if (!File.Exists(jsonPath))
                throw new FileNotFoundException("Fichier étudiant introuvable", jsonPath);

            string json = File.ReadAllText(jsonPath);
            List<Student> loadedStudents = JsonSerializer.Deserialize<List<Student>>(json)
                ?? throw new InvalidDataException("Le fichier étudiant est vide ou invalide");

            return new ObservableCollection<Student>(loadedStudents);
        }

        public void SaveStudents(List<Student> students)
        {
            string path = Path.Combine(basePath, "students.json");
            File.WriteAllText(path, JsonSerializer.Serialize(students));
        }

        public void ImportFromCsv(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<Student> students = new List<Student>();
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                if (values.Length >= 3)
                    students.Add(new Student(values[0].Trim(), values[1].Trim(), values[2].Trim()));
            }
            SaveStudents(students);
        }
    }
}

using OGAMetier.Interfaces;
using OGAMetier.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OGAData
{
    /// <summary>
    /// Dépôt pour la persistance des étudiants en JSON
    /// </summary>
    public class StudentData : IStudentRepository
    {
        #region--Attributs--
        /// <summary>
        /// Chemin de base pour les fichiers JSON
        /// </summary>
        private readonly string basePath;
        #endregion

        #region--Constructeur--
        /// <summary>
        /// Initialise le dépôt avec un chemin optionnel
        /// </summary>
        public StudentData(string? basePath = null)
        {
            this.basePath = basePath ?? AppDomain.CurrentDomain.BaseDirectory;
        }
        #endregion

        #region--Méthodes--
        public ObservableCollection<Student> ListStudent()
        {
            string jsonPath = Path.Combine(basePath, "students.json");
            if (!File.Exists(jsonPath))
            {
                using (StreamWriter sw = new StreamWriter(jsonPath, false, Encoding.UTF8))
                {
                    sw.WriteLine("[]");
                }
            }

            string json = File.ReadAllText(jsonPath);
            List<Student>? loadedStudents = null;
            try
            {
                loadedStudents = JsonSerializer.Deserialize<List<Student>>(json);
            }
            catch (JsonException)
            {
                File.WriteAllText(jsonPath, "[]");
                loadedStudents = new List<Student>();
            }

            return new ObservableCollection<Student>(loadedStudents ?? new List<Student>());
        }

        public void SaveStudents(List<Student> students)
        {
            string path = Path.Combine(basePath, "students.json");
            File.WriteAllText(path, JsonSerializer.Serialize(students));
        }

        public void ImportFromCsv(string path)
        {
            string[] lines = File.ReadAllLines(path);
            var existingStudents = ListStudent().ToList();
            var existingCodes = existingStudents.Select(s => s.Code).ToHashSet();

            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                if (values.Length >= 3)
                {
                    string code = values[0].Trim();
                    if (!existingCodes.Contains(code))
                    {
                        existingStudents.Add(new Student(code, values[1].Trim(), values[2].Trim()));
                    }
                }
            }
            SaveStudents(existingStudents);
        }
        #endregion
    }
}

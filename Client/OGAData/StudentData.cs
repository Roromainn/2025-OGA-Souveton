using OGAMetier.Interfaces;
using OGAMetier.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OGAData
{
    public class StudentData : IStudentRepository
    {
        public ObservableCollection<Student> ListStudent()
        {
            ObservableCollection<Student> resultat = new ObservableCollection<Student>();

            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.json");
            if (!File.Exists(jsonPath))
                throw new Exception("Fichier étudiant introuvable");

            string json = File.ReadAllText(jsonPath);
            List<Student>? loadedStudents = JsonSerializer.Deserialize<List<Student>>(json);
            if (loadedStudents == null)
                throw new Exception("Liste d'étudiant vide");

            foreach (Student student in loadedStudents)
            {
                resultat.Add(student);
            }
            return resultat;
        }
    }
}

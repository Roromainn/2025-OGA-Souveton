using OGAMetier.Interfaces;
using OGAMetier.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace OGAData
{
    /// <summary>
    /// Dépôt pour la persistance des cours en JSON
    /// </summary>
    public class CourseData : ICourseRepository
    {
        #region--Méthodes--
        public List<Course> ListCourse()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "course.json");
            if (!File.Exists(jsonPath))
                return new List<Course>();

            string json = File.ReadAllText(jsonPath);
            return JsonSerializer.Deserialize<List<Course>>(json) ?? new List<Course>();
        }

        public IEnumerable<Student> ListAbsences(Course course, IEnumerable<Student> students)
        {
            return students.Where(s => course.AbsentStudentsCodes.Contains(s.Code));
        }

        public void SaveCourse(List<Course> courses)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "course.json");
            File.WriteAllText(path, JsonSerializer.Serialize(courses));
        }
        #endregion
    }
}

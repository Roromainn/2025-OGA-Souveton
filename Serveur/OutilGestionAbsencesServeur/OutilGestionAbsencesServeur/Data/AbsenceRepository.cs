using MySql.Data.MySqlClient;
using OGAShared.Models;

namespace OutilGestionAbsencesServeur.Data
{
    /// <summary>
    /// Repository pour gérer les opérations sur les absences en base de données
    /// </summary>
    public class AbsenceRepository
    {
        private readonly DBConnection _db;

        /// <summary>
        /// Initialise le repository avec une connexion à la base de données
        /// </summary>
        public AbsenceRepository(DBConnection db)
        {
            _db = db;
        }

        /// <summary>
        /// Récupère toutes les absences d'un étudiant
        /// </summary>
        /// <param name="studentCode">Code de l'étudiant</param>
        /// <returns>Liste des absences de l'étudiant</returns>
        public List<Absence> ListForStudent(string studentCode)
        {
            List<Absence> absences = new List<Absence>();

            try
            {
                if (_db.IsConnect())
                {
                    string query = @"
                        SELECT a.ID, a.CodeStudent, a.CodeCourse, a.Justification,
                               c.DateCourse, c.CourseName, c.TeacherName, c.Duration
                        FROM Absence a
                        JOIN Course c ON a.CodeCourse = c.ID
                        WHERE a.CodeStudent = @CodeStudent
                        ORDER BY c.DateCourse DESC";

                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@CodeStudent", studentCode);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Absence absence = new Absence
                        {
                            DateDetail = (DateTime)reader["DateCourse"],
                            CourseName = reader["CourseName"].ToString() ?? string.Empty,
                            TeacherName = reader["TeacherName"].ToString() ?? string.Empty,
                            Duration = (int)reader["Duration"],
                            Justification = reader["Justification"].ToString() ?? string.Empty,
                            Justified = !string.IsNullOrEmpty(reader["Justification"].ToString())
                        };
                        absences.Add(absence);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error listing absences for student: {ex.Message}");
            }
            finally
            {
                _db.Close();
            }

            return absences;
        }
    }
}

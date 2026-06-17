using MySql.Data.MySqlClient;
using OGAShared.Models;

namespace OutilGestionAbsencesServeur.Data
{
    /// <summary>
    /// Repository pour gérer les opérations sur les absences en base de données
    /// </summary>
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly IDBConnection _db;

        /// <summary>
        /// Initialise le repository avec une connexion à la base de données
        /// </summary>
        public AbsenceRepository(IDBConnection db)
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

        /// <summary>
        /// Saisit les absences à un cours
        /// </summary>
        /// <param name="course">Cours concerné, avec la liste des codes des étudiants absents</param>
        /// <exception cref="KeyNotFoundException">Si le cours n'existe pas en base de données</exception>
        public void Insert(Course course)
        {
            MySqlTransaction? transaction = null;

            try
            {
                if (_db.IsConnect() && _db.Connection != null)
                {
                    int courseId = GetCourseId(course);

                    transaction = _db.Connection.BeginTransaction();

                    string insertQuery = @"
                        INSERT INTO Absence (CodeStudent, CodeCourse, Justification)
                        SELECT @CodeStudent, @CodeCourse, ''
                        FROM DUAL
                        WHERE NOT EXISTS (
                            SELECT 1 FROM Absence
                            WHERE CodeStudent = @CodeStudent AND CodeCourse = @CodeCourse
                        )";

                    foreach (string studentCode in course.AbsentStudentsCodes)
                    {
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, _db.Connection, transaction);
                        insertCmd.Parameters.AddWithValue("@CodeStudent", studentCode);
                        insertCmd.Parameters.AddWithValue("@CodeCourse", courseId);
                        insertCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine($"Error inserting absences: {ex.Message}");
                throw;
            }
            finally
            {
                _db.Close();
            }
        }

        /// <summary>
        /// Récupère l'identifiant d'un cours à partir de son nom, sa date et son professeur
        /// </summary>
        /// <param name="course">Cours à rechercher</param>
        /// <returns>Identifiant du cours</returns>
        /// <exception cref="KeyNotFoundException">Si le cours n'existe pas en base de données</exception>
        private int GetCourseId(Course course)
        {
            string getCourseQuery = @"
                SELECT ID FROM Course
                WHERE CourseName = @CourseName
                  AND DateCourse = @DateCourse
                  AND TeacherName = @TeacherName
                LIMIT 1";

            MySqlCommand getCourseCmd = new MySqlCommand(getCourseQuery, _db.Connection);
            getCourseCmd.Parameters.AddWithValue("@CourseName", course.CourseName);
            getCourseCmd.Parameters.AddWithValue("@DateCourse", course.DateDetail);
            getCourseCmd.Parameters.AddWithValue("@TeacherName", course.TeacherName);

            object? courseIdObj = getCourseCmd.ExecuteScalar();
            if (courseIdObj == null)
                throw new KeyNotFoundException("Cours introuvable en base de données");

            return Convert.ToInt32(courseIdObj);
        }

        /// <summary>
        /// Calcule les statistiques d'absence par étudiant (durée totale et durée injustifiée)
        /// </summary>
        /// <returns>Liste des statistiques d'absence, une entrée par étudiant ayant au moins une absence</returns>
        public List<StatsAbsences> GetStats()
        {
            List<StatsAbsences> stats = new List<StatsAbsences>();

            try
            {
                if (_db.IsConnect())
                {
                    string query = @"
                        SELECT s.Code, s.LastName, s.FirstName,
                               SUM(c.Duration) AS TotalDuration,
                               SUM(CASE WHEN a.Justification IS NULL OR a.Justification = ''
                                        THEN c.Duration ELSE 0 END) AS TotalUnjustified
                        FROM Absence a
                        JOIN Course c ON a.CodeCourse = c.ID
                        JOIN Students s ON a.CodeStudent = s.Code
                        GROUP BY s.Code, s.LastName, s.FirstName";

                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student student = new Student(
                            reader["Code"].ToString() ?? string.Empty,
                            reader["LastName"].ToString() ?? string.Empty,
                            reader["FirstName"].ToString()
                        );
                        int totalDuration = Convert.ToInt32(reader["TotalDuration"]);
                        int totalUnjustified = Convert.ToInt32(reader["TotalUnjustified"]);
                        stats.Add(new StatsAbsences(student, totalDuration, totalUnjustified));
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting absence stats: {ex.Message}");
            }
            finally
            {
                _db.Close();
            }

            return stats;
        }
    }
}

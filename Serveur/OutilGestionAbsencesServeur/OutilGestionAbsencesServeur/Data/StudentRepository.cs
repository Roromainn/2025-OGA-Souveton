using MySql.Data.MySqlClient;
using OGAShared.Models;

namespace OutilGestionAbsencesServeur.Data
{
    /// <summary>
    /// Repository pour gérer les opérations sur les étudiants en base de données
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly IDBConnection _db;

        /// <summary>
        /// Initialise le repository avec une connexion à la base de données
        /// </summary>
        public StudentRepository(IDBConnection db)
        {
            _db = db;
        }

        /// <summary>
        /// Ajoute un nouvel étudiant à la base de données
        /// </summary>
        /// <param name="student">L'étudiant à ajouter</param>
        /// <returns>true si succès, false sinon</returns>
        /// <exception cref="InvalidOperationException">Si l'étudiant existe déjà</exception>
        public bool AddStudent(Student student)
        {
            bool result = false;

            try
            {
                if (_db.IsConnect())
                {
                    if (StudentExists(student.Code))
                        throw new InvalidOperationException($"Étudiant avec code {student.Code} existe déjà");

                    string query = "INSERT INTO Students (Code, LastName, FirstName) VALUES (@Code, @LastName, @FirstName)";
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@Code", student.Code);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName ?? "");

                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = rowsAffected > 0;
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
                throw;
            }
            finally
            {
                _db.Close();
            }

            return result;
        }

        /// <summary>
        /// Vérifie si un étudiant existe déjà
        /// </summary>
        /// <param name="code">Code de l'étudiant</param>
        /// <returns>true si l'étudiant existe, false sinon</returns>
        private bool StudentExists(string code)
        {
            bool exists = false;

            try
            {
                if (_db.IsConnect())
                {
                    string query = "SELECT COUNT(*) FROM Students WHERE Code = @Code";
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@Code", code);

                    int count = (int)cmd.ExecuteScalar();
                    exists = count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking student existence: {ex.Message}");
            }
            finally
            {
                _db.Close();
            }

            return exists;
        }

        /// <summary>
        /// Récupère tous les étudiants de la base de données
        /// </summary>
        /// <returns>Liste de tous les étudiants</returns>
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            try
            {
                if (_db.IsConnect())
                {
                    string query = "SELECT Code, LastName, FirstName FROM Students";
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student student = new Student(
                            reader["Code"].ToString() ?? string.Empty,
                            reader["LastName"].ToString() ?? string.Empty,
                            reader["FirstName"].ToString()
                        );
                        students.Add(student);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting students: {ex.Message}");
            }
            finally
            {
                _db.Close();
            }

            return students;
        }
    }
}

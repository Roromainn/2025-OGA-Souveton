using Microsoft.AspNetCore.Mvc;
using OutilGestionAbsencesServeur.Data;
using OGAShared.Models;

namespace OutilGestionAbsencesServeur.Controllers
{
    /// <summary>
    /// Contrôleur pour gérer les opérations sur les étudiants
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;

        /// <summary>
        /// Initialise le contrôleur avec le repository des étudiants
        /// </summary>
        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Ajoute un nouvel étudiant
        /// </summary>
        /// <param name="student">L'étudiant à ajouter</param>
        /// <returns>200 si succès, 400 si doublon, 500 en cas d'erreur</returns>
        [HttpPost("Add")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            IActionResult result;

            try
            {
                if (!ModelState.IsValid)
                {
                    result = BadRequest(ModelState);
                }
                else
                {
                    bool success = _studentRepository.AddStudent(student);

                    if (success)
                        result = Ok("Étudiant ajouté avec succès");
                    else
                        result = StatusCode(500, "Erreur lors de l'ajout de l'étudiant");
                }
            }
            catch (InvalidOperationException ex)
            {
                result = BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Erreur serveur : {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Récupère tous les étudiants
        /// </summary>
        /// <returns>Liste de tous les étudiants</returns>
        [HttpGet("All")]
        public IActionResult GetAllStudents()
        {
            IActionResult result;

            try
            {
                List<Student> students = _studentRepository.GetAllStudents();
                result = Ok(students);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Erreur serveur : {ex.Message}");
            }

            return result;
        }
    }
}

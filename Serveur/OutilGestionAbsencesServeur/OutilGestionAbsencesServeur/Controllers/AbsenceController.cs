using Microsoft.AspNetCore.Mvc;
using OutilGestionAbsencesServeur.Data;
using OGAShared.Models;

namespace OutilGestionAbsencesServeur.Controllers
{
    /// <summary>
    /// Contrôleur pour gérer les opérations sur les absences
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AbsenceController : ControllerBase
    {
        private readonly IAbsenceRepository _absenceRepository;

        /// <summary>
        /// Initialise le contrôleur avec le repository des absences
        /// </summary>
        public AbsenceController(IAbsenceRepository absenceRepository)
        {
            _absenceRepository = absenceRepository;
        }

        /// <summary>
        /// Liste les absences d'un étudiant
        /// </summary>
        /// <param name="code">Code de l'étudiant</param>
        /// <returns>Liste des absences</returns>
        [HttpGet("ListForStudent/{code}")]
        public IActionResult ListForStudent(string code)
        {
            IActionResult result;

            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    result = BadRequest("Code étudiant requis");
                }
                else
                {
                    List<Absence> absences = _absenceRepository.ListForStudent(code);
                    result = Ok(absences);
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Erreur serveur : {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Saisit les absences des étudiants à un cours
        /// </summary>
        /// <param name="course">Cours concerné, avec la liste des codes des étudiants absents</param>
        /// <returns>200 si l'insertion réussit</returns>
        [HttpPost("Insert")]
        public IActionResult AddAbsenceCourse([FromBody] Course course)
        {
            IActionResult result;
            try
            {
                if (course == null || course.AbsentStudentsCodes.Length == 0)
                {
                    result = BadRequest("Cours ou étudiants absents requis");
                }
                else
                {
                    _absenceRepository.Insert(course);
                    result = Ok();
                }
            }
            catch (KeyNotFoundException ex)
            {
                result = NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
            return result;
        }

        /// <summary>
        /// Synthétise les absences de tous les étudiants
        /// </summary>
        /// <returns>200 avec un tableau de StatsAbsences</returns>
        [HttpGet("Stats")]
        public IActionResult Stats()
        {
            IActionResult result;

            try
            {
                List<StatsAbsences> stats = _absenceRepository.GetStats();
                result = Ok(stats);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Erreur serveur : {ex.Message}");
            }

            return result;
        }
    }
}

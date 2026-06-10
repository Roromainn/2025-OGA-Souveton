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
        private readonly AbsenceRepository _absenceRepository;

        /// <summary>
        /// Initialise le contrôleur avec le repository des absences
        /// </summary>
        public AbsenceController(AbsenceRepository absenceRepository)
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
    }
}

using Microsoft.AspNetCore.Mvc;
using OutilGestionAbsencesServeur.Data;

namespace OutilGestionAbsencesServeur.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestDbController : ControllerBase
    {
        [HttpGet]
        public IActionResult TestConnection()
        {
            try
            {
                var db = DBConnection.Instance();
                bool connected = db.IsConnect();
                db.Close();

                if (connected)
                    return Ok("Connexion DB réussie.");
                else
                    return StatusCode(500, "Connexion DB échouée : paramètres manquants.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur connexion DB : {ex.Message}");
            }
        }
    }
}

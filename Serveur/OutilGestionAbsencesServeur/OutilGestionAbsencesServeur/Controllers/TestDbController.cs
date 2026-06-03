using Microsoft.AspNetCore.Mvc;
using OutilGestionAbsencesServeur.Data;

namespace OutilGestionAbsencesServeur.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestDbController : ControllerBase
    {
        private DBConnection _db;

        public TestDbController(DBConnection db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult TestConnection()
        {
            try
            {
                bool connected = _db.IsConnect();
                _db.Close();

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

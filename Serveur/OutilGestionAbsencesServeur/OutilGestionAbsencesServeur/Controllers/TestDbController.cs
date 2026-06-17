using Microsoft.AspNetCore.Mvc;
using OutilGestionAbsencesServeur.Data;

namespace OutilGestionAbsencesServeur.Controllers
{
    /// <summary>
    /// Contrôleur pour tester la connexion à la base de données
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestDbController : ControllerBase
    {
        private readonly IDBConnection _db;

        /// <summary>
        /// Initialise le contrôleur avec la connexion à la base de données
        /// </summary>
        public TestDbController(IDBConnection db)
        {
            _db = db;
        }

        /// <summary>
        /// Teste la connexion à la base de données
        /// </summary>
        /// <returns>200 si connecté, 500 sinon</returns>
        [HttpGet]
        public IActionResult TestConnection()
        {
            IActionResult result;

            try
            {
                bool connected = _db.IsConnect();
                _db.Close();

                if (connected)
                    result = Ok("Connexion DB réussie.");
                else
                    result = StatusCode(500, "Connexion DB échouée : paramètres manquants.");
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Erreur connexion DB : {ex.Message}");
            }

            return result;
        }
    }
}

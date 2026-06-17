using MySql.Data.MySqlClient;

namespace OutilGestionAbsencesServeur.Data
{
    /// <summary>
    /// Contrat pour la connexion à la base de données MySQL.
    /// Permet aux repositories de dépendre d'une abstraction (DIP) plutôt que de l'implémentation concrète.
    /// </summary>
    public interface IDBConnection
    {
        /// <summary>
        /// Connexion MySQL active 
        /// </summary>
        MySqlConnection? Connection { get; }

        /// <summary>
        /// Établit la connexion à la base de données si elle n'existe pas
        /// </summary>
        /// <returns>true si connecté, false sinon</returns>
        bool IsConnect();

        /// <summary>
        /// Ferme la connexion à la base de données
        /// </summary>
        void Close();
    }
}

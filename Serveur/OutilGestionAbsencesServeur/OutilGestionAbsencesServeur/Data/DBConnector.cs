using MySql.Data;
using MySql.Data.MySqlClient;

namespace OutilGestionAbsencesServeur.Data
{
    /// <summary>
    /// Gère la connexion MySQL. Le cycle de vie (instance unique) est assuré par l'injection de dépendances.
    /// </summary>
    public class DBConnection : IDBConnection
    {
        #region--Attributs--
        private string server = string.Empty;
        private string databaseName = string.Empty;
        private string userName = string.Empty;
        private string password = string.Empty;
        private MySqlConnection? connection;
        #endregion

        #region--Propriétés--
        /// <summary>
        /// Nom du serveur MySQL
        /// </summary>
        public string Server
        {
            get => server;
            set => server = value;
        }

        /// <summary>
        /// Nom de la base de données
        /// </summary>
        public string DatabaseName
        {
            get => databaseName;
            set => databaseName = value;
        }

        /// <summary>
        /// Nom d'utilisateur MySQL
        /// </summary>
        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        /// <summary>
        /// Mot de passe MySQL
        /// </summary>
        public string Password
        {
            get => password;
            set => password = value;
        }

        /// <summary>
        /// Connexion MySQL active
        /// </summary>
        public MySqlConnection? Connection
        {
            get => connection;
            set => connection = value;
        }
        #endregion

        #region--Méthodes--
        /// <summary>
        /// Établit la connexion à la base de données si elle n'existe pas
        /// </summary>
        /// <returns>true si connecté, false sinon</returns>
        public bool IsConnect()
        {
            bool connected = false;

            if (Connection == null || Connection.State == System.Data.ConnectionState.Closed)
            {
                if (!string.IsNullOrEmpty(databaseName))
                {
                    string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, UserName, Password);
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                    connected = true;
                }
            }
            else
            {
                connected = true;
            }

            return connected;
        }

        /// <summary>
        /// Ferme la connexion à la base de données
        /// </summary>
        public void Close()
        {
            Connection?.Close();
        }
        #endregion
    }
}

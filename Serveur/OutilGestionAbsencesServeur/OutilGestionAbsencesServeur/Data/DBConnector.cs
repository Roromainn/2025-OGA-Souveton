using MySql.Data;
using MySql.Data.MySqlClient;


namespace OutilGestionAbsencesServeur.Data
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        #region--Attributs--
        private string server;

        private string databaseName;

        private string userName;

        private string password;

        private MySqlConnection connection;

        private static DBConnection _instance = null;
        #endregion

        #region--Propriétés--
        public string Server 
        {
            get 
            {
                return server;
            } 
            set
            {
                server = value; 
            }
        }
        public string DatabaseName
        { 
            get
            {
                return databaseName;
            }
            set
            {
                databaseName = value; 
            }
        }
        public string UserName 
        { 
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public string Password 
        { 
            get 
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public MySqlConnection Connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }

        #endregion


            public static DBConnection Instance()
            {
                if (_instance == null)
                    _instance = new DBConnection();
                return _instance;
            }

            public bool IsConnect()
            {
                if (Connection == null || Connection.State == System.Data.ConnectionState.Closed)
                {
                    if (String.IsNullOrEmpty(databaseName))
                        return false;
                    string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, UserName, Password);
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                }

                return true;
            }

            public void Close()
            {
                Connection?.Close();
            }
        }
    }

using System.ComponentModel.DataAnnotations;

namespace OGAShared.Models
{
    /// <summary>
    /// Représente un étudiant
    /// </summary>
    public class Student
    {
        #region--Attributs--
        private string code = string.Empty;
        private string lastName = string.Empty;
        private string? firstName;
        #endregion

        #region--Propriétés--
        /// <summary>
        /// Code de l'étudiant
        /// </summary>
        public string Code
        {
            get
            {
                if (string.IsNullOrEmpty(code)) 
                    throw new ValidationException("Code étudiant obligatoire");
                if (code.Length > 32)
                    throw new ValidationException("Code étudiant doit être inférieur à 32 caractères");
                else 
                return code;
            }
            set
            {
                    code = value;
            }
        }

        /// <summary>
        /// Nom de famille
        /// </summary>
        public string LastName
        {
            get
            {if (string.IsNullOrWhiteSpace(lastName))
                {
                    throw new ValidationException("Nom de famille obligatoire");
                }
                if (lastName.Length > 50)
            {
                    throw new ValidationException("Nom de famille doit être inférieur à 50 caractères");
                }
                return lastName;
            }
            set
            {
                    lastName = value;
            }
        }

        /// <summary>
        /// Prénom (optionnel)
        /// </summary>
        public string? FirstName
        { get
            { if (firstName.Length > 50)
                { throw new ValidationException("Prénom doit être inférieur à 50 caractères"); }
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        #endregion

        #region--Constructeurs--
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Student() { }

        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        public Student(string code, string lastName, string? firstName = null)
        {
            Code = code;
            LastName = lastName;
            FirstName = firstName;
        }
        #endregion
    }
}

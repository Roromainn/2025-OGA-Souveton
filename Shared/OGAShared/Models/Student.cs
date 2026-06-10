using System.ComponentModel.DataAnnotations;

namespace OGAShared.Models
{
    public class Student
    {
        #region--Attributs--
        private string code = string.Empty;
        private string lastName = string.Empty;
        public string? firstName;
        #endregion

        #region--Attributs--
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
        public Student() { }

        public Student(string code, string lastName, string? firstName = null)
        {
            Code = code;
            LastName = lastName;
            FirstName = firstName;
        }
        #endregion
    }
}

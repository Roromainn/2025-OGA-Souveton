namespace OGAMetier.Models
{
    /// <summary>
    /// Représente un étudiant
    /// </summary>
    public class Student
    {
        #region--Attributs--
        /// <summary>
        /// Code de l'étudiant
        /// </summary>
        string code = string.Empty;

        /// <summary>
        /// Nom de famille
        /// </summary>
        string lastName = string.Empty;

        /// <summary>
        /// Prénom (optionnel)
        /// </summary>
        string? firstName;
        #endregion

        #region--Propriétés--
        public string Code { get => code; set => code = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string? FirstName { get => firstName; set => firstName = value; }
        #endregion

        #region--Constructeur--
        public Student() { }

        public Student(string code, string lastName, string? firstName = null)
        {
            this.code = code;
            this.lastName = lastName;
            this.firstName = firstName;
        }
        #endregion

        #region--Méthodes--
        /// <summary>
        /// Valide que les champs obligatoires sont remplis
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Code étudiant obligatoire");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Nom de famille obligatoire");
        }
        #endregion
    }
}

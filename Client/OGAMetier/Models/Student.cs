namespace OGAMetier.Models
{
    /// <summary>
    /// Représente un étudiant
    /// </summary>
    public class Student
    {
        #region--Attributes--
        /// <summary>
        /// Code representing the student
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

        #region--Properties--
        public string Code { get => code; set => code = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string? FirstName { get => firstName; set => firstName = value; }
        #endregion

        #region--Constructor--
        public Student() { }

        public Student(string code, string lastName, string? firstName = null)
        {
            this.code = code;
            this.lastName = lastName;
            this.firstName = firstName;
        }
        #endregion
    }
}

namespace OGAMetier.Models
{
    /// <summary>
    /// Absence d'un étudiant à un cours
    /// </summary>
    public class Absence : CourseDetails
    {
        #region--Attributs--
        /// <summary>
        /// Justification de l'absence
        /// </summary>
        string justification = string.Empty;

        /// <summary>
        /// Indique si l'absence est justifiée
        /// </summary>
        bool justified;
        #endregion

        #region--Propriétés--
        public string Justification { get => justification; set => justification = value; }
        public bool Justified { get => justified; set => justified = value; }
        #endregion
    }
}

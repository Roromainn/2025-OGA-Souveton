namespace OGAShared.Models
{
    /// <summary>
    /// Représente l'absence d'un étudiant à un cours, avec le détail du cours concerné
    /// </summary>
    public class Absence : CourseDetails
    {
        string justification = string.Empty;
        bool justified;

        /// <summary>
        /// Motif de justification de l'absence (vide si non justifiée)
        /// </summary>
        public string Justification { get => justification; set => justification = value; }

        /// <summary>
        /// Indique si l'absence est justifiée
        /// </summary>
        public bool Justified { get => justified; set => justified = value; }
    }
}
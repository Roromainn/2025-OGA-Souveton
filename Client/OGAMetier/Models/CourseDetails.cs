namespace OGAMetier.Models
{
    /// <summary>
    /// Informations générales d'un cours
    /// </summary>
    public class CourseDetails
    {
        #region--Attributs--
        /// <summary>
        /// Date et heure du cours
        /// </summary>
        DateTime dateDetail;

        /// <summary>
        /// Nom du cours
        /// </summary>
        string courseName = string.Empty;

        /// <summary>
        /// Nom de l'enseignant
        /// </summary>
        string teacherName = string.Empty;

        /// <summary>
        /// Durée du cours en minutes
        /// </summary>
        int duration;
        #endregion

        #region--Propriétés--
        public DateTime DateDetail { get => dateDetail; set => dateDetail = value; }
        public string CourseName { get => courseName; set => courseName = value; }
        public string TeacherName { get => teacherName; set => teacherName = value; }
        public int Duration { get => duration; set => duration = value; }
        #endregion

        #region--Méthodes--
        /// <summary>
        /// Valide que les champs obligatoires sont remplis
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("Nom du cours obligatoire");
            if (string.IsNullOrWhiteSpace(teacherName))
                throw new ArgumentException("Nom du professeur obligatoire");
            if (dateDetail == default(DateTime))
                throw new ArgumentException("Date du cours obligatoire");
            if (duration <= 0)
                throw new ArgumentException("Durée du cours doit être supérieure à 0 minutes");
        }
        #endregion
    }
}

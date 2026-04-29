namespace OGAMetier.Models
{
    /// <summary>
    /// Informations générales d'un cours
    /// </summary>
    public class CourseDetails
    {
        #region--Attributes--
        /// <summary>
        /// Date of the course
        /// </summary>
        DateTime dateDetail;

        /// <summary>
        /// Name of the course
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

        #region--Properties--
        public DateTime DateDetail { get => dateDetail; set => dateDetail = value; }
        public string CourseName { get => courseName; set => courseName = value; }
        public string TeacherName { get => teacherName; set => teacherName = value; }
        public int Duration { get => duration; set => duration = value; }
        #endregion
    }
}

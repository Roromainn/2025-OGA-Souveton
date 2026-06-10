namespace OGAShared.Models
{
    /// <summary>
    /// Détails d'un cours
    /// </summary>
    public class CourseDetails
    {
        #region--Attributs--
        private DateTime dateDetail;
        private string courseName = string.Empty;
        private string teacherName = string.Empty;
        private int duration;
        #endregion

        #region--Propriétés--
        /// <summary>
        /// Date et heure du cours doit etre définie
        /// </summary>
        public DateTime DateDetail
        {
            get
            {
                if (dateDetail == default)
                    throw new InvalidOperationException("Date du cours obligatoire");
                return dateDetail;
            }
            set
            {
                dateDetail = value; 
            }
        }

        /// <summary>
        /// Nom du cours
        /// </summary>
        public string CourseName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(courseName))
                    throw new InvalidOperationException("Nom du cours obligatoire");
                if (courseName.Length > 50)
                    throw new InvalidOperationException("Nom du cours doit être ≤ 50 caractères");
                return courseName;
            }
            set
            {
                courseName = value;
            }
        }

        /// <summary>
        /// Nom du professeur ne peut etr null ou vide et doit etre inferieur a 50 caracteres
        /// </summary>
        public string TeacherName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(teacherName))
                    throw new InvalidOperationException("Nom du professeur obligatoire");
                if (teacherName.Length > 50)
                    throw new InvalidOperationException("Nom du professeur doit être ≤ 50 caractères");
                return teacherName;
            }
            set
            {
                    teacherName = value;
            }
        }

        /// <summary>
        /// Durée du cours en minutes doit etre superieur a 0 minutes
        /// </summary>
        public int Duration
        {
            get
            {
                if (duration <= 0)
                    throw new InvalidOperationException("Durée doit être > 0 minutes");
                return duration;
            }
            set 
            {
                duration = value;
            }
        }
        #endregion
    }
}

using System.ComponentModel.DataAnnotations;

namespace OGAShared.Models
{
    public class CourseDetails
    {
        #region--Attributs--
        private DateTime courseDetail;
        private string courseName = string.Empty;
        private string teacherName = string.Empty;
        public int duration;
        #endregion

        #region--Propriétées--
        /// <summary>
        /// Date et heure du cours doit etre définie
        /// </summary>
        public DateTime CourseDetail 
        { 
            get
            {
                if (courseDetail == DateTime.MinValue)
                {
                    throw new ValidationException("La date du cours doit être définie.");
                }
                return courseDetail; 
            } 
            set
            {
                courseDetail = value; 
            }
        }

        /// <summary>
        /// Nom du cours ne peut etr null ou vide et doit etre inferieur a 50 caracteres
        /// </summary>
        private string CourseName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(courseName))
                {
                    throw new ValidationException("Le nom du cours doit être défini.");
                }
                if (courseName.Length > 50)
                {
                    throw new InvalidOperationException("Le nom du cours ne doit pas dépasser 50 caractères.");
                }
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
                {
                    throw new ValidationException("Le nom du professeur doit être défini.");
                }
                if (teacherName.Length > 50)
                {
                    throw new ValidationException("Le nom du professeur ne doit pas dépasser 50 caractères.");
                }
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
                if (duration < 0)
                {
                    throw new ValidationException("La durée du cours doit être supérieure à 0 minutes.");
                }
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

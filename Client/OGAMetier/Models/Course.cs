namespace OGAMetier.Models
{
    /// <summary>
    /// Un cours avec la liste des étudiants absents
    /// </summary>
    public class Course : CourseDetails
    {
        #region--Attributs--
        /// <summary>
        /// Codes des étudiants absents lors de ce cours
        /// </summary>
        string[] absentStudentsCodes = Array.Empty<string>();
        #endregion

        #region--Propriétés--
        public string[] AbsentStudentsCodes { get => absentStudentsCodes; set => absentStudentsCodes = value; }
        #endregion
    }
}

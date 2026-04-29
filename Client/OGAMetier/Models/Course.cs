namespace OGAMetier.Models
{
    /// <summary>
    /// Un cours avec la liste des étudiants absents
    /// </summary>
    public class Course : CourseDetails
    {
        #region--Attributes--
        /// <summary>
        /// Codes des étudiants absents lors de ce cours
        /// </summary>
        string[] absentStudentsCodes = Array.Empty<string>();
        #endregion

        #region--Properties--
        public string[] AbsentStudentsCodes { get => absentStudentsCodes; set => absentStudentsCodes = value; }
        #endregion
    }
}

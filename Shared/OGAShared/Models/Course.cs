namespace OGAShared.Models
{
    /// <summary>
    /// Représente un cours et la liste des codes des étudiants absents à ce cours
    /// </summary>
    public class Course : CourseDetails
    {
        string[] absentStudentsCodes = Array.Empty<string>();

        /// <summary>
        /// Codes des étudiants absents au cours
        /// </summary>
        public string[] AbsentStudentsCodes { get => absentStudentsCodes; set => absentStudentsCodes = value; }
    }
}
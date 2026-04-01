using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMetier
{
    /// <summary>
    /// General details about the course
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
        string courseName;

        /// <summary>
        /// Name of the teacher officiating the course
        /// </summary>
        string teacherName;

        /// <summary>
        /// Duration of the course
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

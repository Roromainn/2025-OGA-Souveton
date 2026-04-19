using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGAMetier.Models
{
    /// <summary>
    /// The course itself
    /// </summary>
    public class Course : CourseDetails
    {
        #region--Attributes--
        /// <summary>
        /// Codes of student that were absent in this course
        /// </summary>
        string[] absentStudentsCodes;
        #endregion

        #region--Properties--
        public string[] AbsentStudentsCodes { get => absentStudentsCodes; set => absentStudentsCodes = value; }
        #endregion
    }
}

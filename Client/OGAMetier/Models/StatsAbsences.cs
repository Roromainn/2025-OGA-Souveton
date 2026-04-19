using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGAMetier.Models
{
    /// <summary>
    /// Statitics of the absences of a student 
    /// </summary>
    public class StatsAbsences
    {
        #region--Attributes--
        /// <summary>
        /// total duration of the absences
        /// </summary>
        int totalDuration;

        /// <summary>
        /// Total duration of the absences that aren't jsutified
        /// </summary>
        int totalDurationUnjustified;

        /// <summary>
        /// The student
        /// </summary>
        Student student;
        #endregion

        #region--Properties--
        public int TotalDuration { get => totalDuration; set => totalDuration = value; }
        public int TotalDurationUnjustified { get => totalDurationUnjustified; set => totalDurationUnjustified = value; }
        public string StudentLastName { get => this.student.LastName; set => this.student.LastName = value; }
        #endregion

        #region--Constructor--
        public StatsAbsences(Student student, int Duration = 0, int totalUnjustified = 0)
        {
            this.student = student;
            totalDuration = Duration;
            totalDurationUnjustified = totalUnjustified;
        }
        #endregion
    }
}

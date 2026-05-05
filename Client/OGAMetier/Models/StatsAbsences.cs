using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGAMetier.Models
{
    /// <summary>
    /// Statistiques des absences d'un étudiant
    /// </summary>
    public class StatsAbsences
    {
        #region--Attributs--
        /// <summary>
        /// Durée totale des absences en minutes
        /// </summary>
        int totalDuration;

        /// <summary>
        /// Durée totale des absences non justifiées en minutes
        /// </summary>
        int totalDurationUnjustified;

        /// <summary>
        /// L'étudiant concerné
        /// </summary>
        Student student;
        #endregion

        #region--Propriétés--
        public int TotalDuration { get => totalDuration; set => totalDuration = value; }
        public int TotalDurationUnjustified { get => totalDurationUnjustified; set => totalDurationUnjustified = value; }
        public string StudentLastName { get => this.student.LastName; set => this.student.LastName = value; }
        #endregion

        #region--Constructeur--
        public StatsAbsences(Student student, int Duration = 0, int totalUnjustified = 0)
        {
            this.student = student;
            totalDuration = Duration;
            totalDurationUnjustified = totalUnjustified;
        }
        #endregion
    }
}

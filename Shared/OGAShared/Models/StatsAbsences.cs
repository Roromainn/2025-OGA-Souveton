namespace OGAShared.Models
{
    /// <summary>
    /// Synthèse des absences d'un étudiant (durées totale et injustifiée)
    /// </summary>
    public class StatsAbsences
    {
        #region--Attributs--
        int totalDuration;
        int totalDurationUnjustified;
        Student student;
        #endregion


        #region--Propriétées--
        /// <summary>
        /// Durée totale d'absence en minutes
        /// </summary>
        public int TotalDuration { get => totalDuration; set => totalDuration = value; }
        /// <summary>
        /// Durée totale d'absence injustifiée en minutes
        /// </summary>
        public int TotalDurationUnjustified { get => totalDurationUnjustified; set => totalDurationUnjustified = value; }
        /// <summary>
        /// Nom de l'étudiant
        /// </summary>
        public string StudentLastName { get => this.student.LastName; set => this.student.LastName = value; }
        #endregion

        #region--Constructeurs--
        /// <summary>
        /// Initialise une synthèse d'absences pour un étudiant
        /// </summary>
        /// <param name="student">Étudiant concerné</param>
        /// <param name="Duration">Durée totale d'absence en minutes</param>
        /// <param name="totalUnjustified">Durée totale d'absence injustifiée en minutes</param>
        public StatsAbsences(Student student, int Duration = 0, int totalUnjustified = 0)
        {
            this.student = student;
            totalDuration = Duration;
            totalDurationUnjustified = totalUnjustified;
        }
        #endregion
    }
}

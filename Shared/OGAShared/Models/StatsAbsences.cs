namespace OGAShared.Models
{
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
        public StatsAbsences(Student student, int Duration = 0, int totalUnjustified = 0)
        {
            this.student = student;
            totalDuration = Duration;
            totalDurationUnjustified = totalUnjustified;
        }
        #endregion
    }
}

using OGAMetier.Models;

namespace OGAVM.ViewModel
{
    /// <summary>
    /// ViewModel pour le résumé des absences par étudiant
    /// </summary>
    public class ResumeAbsVM
    {
        #region--Attributs--
        /// <summary>
        /// Statistiques des absences par étudiant
        /// </summary>
        private List<StatsAbsences> stats;
        #endregion

        #region--Propriétés--
        /// <summary>
        /// Liste des statistiques d'absences
        /// </summary>
        public List<StatsAbsences> Stats { get => stats; }
        #endregion

        #region--Constructeur--
        /// <summary>
        /// Initialise le ViewModel avec étudiants et cours
        /// </summary>
        public ResumeAbsVM(IEnumerable<Student> students, IEnumerable<Course> courses)
        {
            stats = students
                .Select(s => new StatsAbsences(
                    s,
                    courses.Where(c => c.AbsentStudentsCodes.Contains(s.Code)).Sum(c => c.Duration)
                ))
                .ToList();
        }
        #endregion
    }
}

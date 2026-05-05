using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGAVM.ViewModel
{
    /// <summary>
    /// Détails d'une absence d'étudiant
    /// </summary>
    public class StudentAbsenceDetail
    {
        #region--Attributes--
        /// <summary>
        /// Date et heure du cours
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Nom du cours
        /// </summary>
        public string CourseName { get; set; } = string.Empty;

        /// <summary>
        /// Nom de l'enseignant
        /// </summary>
        public string TeacherName { get; set; } = string.Empty;

        /// <summary>
        /// Durée du cours en minutes
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Indique si l'absence est justifiée
        /// </summary>
        public bool Justified { get; set; }

        /// <summary>
        /// Justification de l'absence
        /// </summary>
        public string Justification { get; set; } = string.Empty;
        #endregion

        #region--Properties--
        /// <summary>
        /// Date formatée jj/mm/aaaa
        /// </summary>
        public string FormattedDate => Date.ToString("dd/MM/yyyy");

        /// <summary>
        /// Heure formatée hh:mm
        /// </summary>
        public string FormattedTime => Date.ToString("H:mm");

        /// <summary>
        /// Statut justification (Oui/Non)
        /// </summary>
        public string JustifiedStatus => Justified ? "Oui" : "Non";
        #endregion
    }
}

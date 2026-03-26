using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMetier
{
    public class Absence : CourseDetails
    {
        #region--Attributes--
        /// <summary>
        /// Justification of the absence
        /// </summary>
        string justification;
        /// <summary>
        /// Whether or not the absence was justified
        /// </summary>
        bool justified;
        #endregion

        #region--Properties--
        public string Justification { get => justification; set => justification = value; }
        public bool Justified { get => justified; set => justified = value; }
        #endregion
    }
}

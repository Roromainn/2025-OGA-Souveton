using OGAMetier.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OGAVM.ViewModel
{
    public class StudentPresenceVM : INotifyPropertyChanged
    {
        #region--Événements--
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region--Attributs--
        /// <summary>
        /// Si l'étudiant est absent
        /// </summary>
        private bool isAbsent;

        /// <summary>
        /// L'étudiant concerné
        /// </summary>
        private readonly Student student;
        #endregion

        #region--Propriétés--
        /// <summary>
        /// Nom complet formaté de l'étudiant
        /// </summary>
        public string StudentFullName => $"{student.LastName} {student.FirstName}";

        /// <summary>
        /// L'étudiant concerné
        /// </summary>
        public Student Student => student;

        /// <summary>
        /// Statut d'absence de l'étudiant
        /// </summary>
        public bool IsAbsent
        {
            get => isAbsent;
            set
            {
                isAbsent = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region--Constructeur--
        public StudentPresenceVM(Student student)
        {
            this.student = student;
        }
        #endregion

        #region--Méthodes--
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

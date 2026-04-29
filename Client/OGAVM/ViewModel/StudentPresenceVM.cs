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
        #region--Attributs--
        /// <summary>
        /// Flag pour le MVVM
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Si l'étudiant est absent
        /// </summary>
        private bool isAbsent;

        /// <summary>
        /// L'étudiant concerné
        /// </summary>
        private readonly Student student;
        #endregion

        #region--Properties--
        public string StudentFullName => $"{student.LastName} {student.FirstName}";
        public Student Student => student;

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

        #region--Methods--
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

using OGAMetier.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OGAVM.ViewModel
{
    public class StudentVM : INotifyPropertyChanged
    {
        #region--Events--
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region--Attributes--
        /// <summary>
        /// L'étudiant concerné
        /// </summary>
        private Student student;
        #endregion

        #region--Properties--
        /// <summary>
        /// Prénom de l'étudiant
        /// </summary>
        public string? FirstName
        {
            get => student.FirstName;
            set
            {
                student.FirstName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Nom de famille de l'étudiant
        /// </summary>
        public string LastName
        {
            get => student.LastName;
            set
            {
                student.LastName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// L'étudiant concerné
        /// </summary>
        public Student Student { get => student; set => student = value; }
        #endregion

        #region--Constructor--
        /// <summary>
        /// Initialise la VM avec un étudiant
        /// </summary>
        public StudentVM(Student student)
        {
            this.student = student;
        }
        #endregion

        #region--Methods--
        /// <summary>
        /// Flag MVVM
        /// </summary>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

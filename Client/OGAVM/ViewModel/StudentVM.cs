using OGAShared.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OGAVM.ViewModel
{
    public class StudentVM : INotifyPropertyChanged
    {
        #region--Événements--
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region--Attributs--
        /// <summary>
        /// L'étudiant concerné
        /// </summary>
        private Student student;

        /// <summary>
        /// Message d'erreur de validation
        /// </summary>
        private string? errorMessage;
        #endregion

        #region--Propriétés--
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

        /// <summary>
        /// Message d'erreur de validation
        /// </summary>
        public string? ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region--Constructeur--
        /// <summary>
        /// Initialise la VM avec un étudiant
        /// </summary>
        public StudentVM(Student student)
        {
            this.student = student;
        }
        #endregion

        #region--Méthodes--
        /// <summary>
        /// Flag MVVM
        /// </summary>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Valide l'étudiant et retourne true si valide
        /// </summary>
        public bool TryValidate()
        {
            bool res= true;
            if (string.IsNullOrWhiteSpace(student.Code))
            {
                ErrorMessage = "Code étudiant obligatoire";
                res = false;
            }
            if (student.Code.Length > 32)
            {
                ErrorMessage = "Code ne doit pas dépasser 32 caractères";
                res = false;
            }
            if (string.IsNullOrWhiteSpace(student.LastName))
            {
                ErrorMessage = "Nom de famille obligatoire";
                res = false;
            }
            if (student.LastName.Length > 100)
            {
                ErrorMessage = "Nom de famille ne doit pas dépasser 100 caractères";
                res = false;
            }
            if (!string.IsNullOrWhiteSpace(student.FirstName) && student.FirstName.Length > 100)
            {
                ErrorMessage = "Prénom ne doit pas dépasser 100 caractères";
                res = false;
            }

            ErrorMessage = null;
            return res;
        }
        #endregion
    }
}

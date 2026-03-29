using ProjetMetier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutilGestionAbsences.ViewModel
{
    public class StudentVM : INotifyPropertyChanged
    {
        #region--Events--
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region--Attributes--
        /// <summary>
        /// First name of the student
        /// </summary>
        private string firstName;
        /// <summary>
        /// Last name of the student
        /// </summary>
        private string lastName;
        #endregion

        #region--Properties--
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                NotifyPropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region--Constructor--
        public StudentVM()
        {
        }
        #endregion

        #region--Methods--
        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Creates a new student 
        /// </summary>
        /// <param name="codeEt">Sudent's code</param>
        /// <param name="first">Student first name</param>
        /// <param name="last">Student's last name</param>
        public void AddStudent(string codeEt, string first, string  last)
        {
            Student student = new Student(codeEt, last, first);
        }
        #endregion
    }
}

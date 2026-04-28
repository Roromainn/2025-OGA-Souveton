using OGAMetier.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGAVM.ViewModel
{
    public class StudentVM : INotifyPropertyChanged
    {
        #region--Events--
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region--Attributes--
        /// <summary>
        /// The student itself
        /// </summary>
        /// 
        private Student student;

        private ObservableCollection<Student> students;
        #endregion

        #region--Properties--
        public string FirstName
        {
            get => Student.FirstName;
            set
            {
                Student.FirstName = value;
                NotifyPropertyChanged();
            }
        }
        public string LastName
        {
            get => Student.LastName;
            set
            {
                Student.LastName = value;
                NotifyPropertyChanged();
            }
        }

        public Student Student { get => student; set => student = value; }
        #endregion

        #region--Constructor--
        public StudentVM(Student student)
        {
            this.student = student;
            students = new ObservableCollection<Student>();
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
        public void AddStudent(string codeEt, string first, string last)
        {
            Student student = new Student(codeEt, last, first);
            students.Add(student);
        }

        public void ValideStudent(Student student)
        {
            students.Add(student);
        }
        #endregion
    }
}

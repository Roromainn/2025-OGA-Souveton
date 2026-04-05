using ProjetMetier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        /// <summary>
        /// The student's code
        /// </summary>
        private string code;


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
            get => this.Student.FirstName;
            set
            {
                this.Student.FirstName = value;
                NotifyPropertyChanged();
            }
        }
        public string LastName
        {
            get => this.Student.LastName;
            set
            {
                this.Student.LastName = value;
                NotifyPropertyChanged();
            }
        }

        public Student Student { get => student; set => student = value; }
        #endregion

        #region--Constructor--
        public StudentVM(Student student)
        {
            this.student = student;
            this.students = new ObservableCollection<Student>();
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

        public void ListStudent()
        {
            for (int i = 0; i < students.Count ; i++)
            {
                Student student = students[i];
            }           
        }

        public void ValideStudent(Student student)
        {
            students.Add(student);
        }
        #endregion
    }
}

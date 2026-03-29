using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OutilGestionAbsences.View;
using ProjetMetier;

namespace OutilGestionAbsences.ViewModel
{
    /// <summary>
    /// Deals with the gestion the the differents views and the students list
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {
        #region--Events--
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region--Attributes--
        /// <summary>
        /// List of students
        /// </summary>
        private ObservableCollection<Student> students;
        /// <summary>
        /// Selected student in the list
        /// </summary>
        private Student? selectedStudent;
        #endregion

        #region--Properties--
        public ObservableCollection<Student> Students
        {
            get => students;
            set
            {
                students = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Étudiant sélectionné dans la liste
        /// </summary>
        public Student? SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region--Constructor--
        public MainVM()
        {
            students = new ObservableCollection<Student>();
        }
        #endregion

        #region--Methods--
        /// <summary>
        /// Open the view for adding a new student and add it to the list if validated
        /// </summary>
        public void AddStudent()
        {
            StudentView studentView = new StudentView();
            bool? result = studentView.ShowDialog();

            // Si l'utilisateur a validé 
            if (result == true && studentView.NewStudent != null)
            {
                Students.Add(studentView.NewStudent);
            }
        }

        /// <summary>
        /// Open the view for adding an absence for the selected student
        /// </summary>
        public void AddAbsence()
        {
            StudentAbsView studentAbsView = new StudentAbsView();
            studentAbsView.ShowDialog();
        }

        /// <summary>
        /// Open the view for student's absences summary
        /// </summary>
        public void ResumeAbsences()
        {
            ResumeAbsView studentAbsView = new ResumeAbsView();
            studentAbsView.ShowDialog();
        }

        /// <summary>
        /// Import students data
        /// </summary>
        public void ImportData()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Flag update for mvvm
        /// </summary>
        /// <param name="propertyName">Name of the property changed</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

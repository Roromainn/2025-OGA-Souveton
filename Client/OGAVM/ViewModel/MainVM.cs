using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json;
using OGAMetier.Models;
using OGAMetier.Interfaces;

namespace OGAVM.ViewModel
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

        private StudentVM studentVM ;

        private readonly IStudentRepository repository;  
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
                UpdateStudentVM();
            }
        }

        /// <summary>
        /// ViewModel for the currently selected student
        /// </summary>
        public StudentVM? StudentVM
        {
            get => studentVM;
            set
            {
                studentVM = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region--Constructor--
        public MainVM(IStudentRepository repository)
        {
            this.repository = repository;
            students = new ObservableCollection<Student>();
            selectedStudent = null;
            studentVM = null;
            ListStudent();
        }
        #endregion

        #region--Methods--
        /// <summary>
        /// Open the view for adding a new student and add it to the list if validated
        /// </summary>
        public void AddStudent(Student student)
        {
            if (student != null)
            {
                Students.Add(student);
                repository.SaveStudents(students.ToList());
            }
        }

        public void ListStudent()
        {
            var result = this.repository.ListStudent();
            foreach (var student in result)
                Students.Add(student);
        }

        /// <summary>
        /// Updates StudentVM when selected student changes
        /// </summary>
        private void UpdateStudentVM()
        {
            if (selectedStudent != null)
            {
                StudentVM = new StudentVM(selectedStudent);
            }
            else
            {
                StudentVM = null;
            }
        }

        /// <summary>
        /// Open the view for adding an absence for the selected student
        /// </summary>
        public void AddAbsence()
        {
            //StudentAbsView studentAbsView = new StudentAbsView();
            //studentAbsView.ShowDialog();
        }

        /// <summary>
        /// Open the view for student's absences summary
        /// </summary>
        public void ResumeAbsences()
        {
            //ResumeAbsView studentAbsView = new ResumeAbsView();
            //studentAbsView.ShowDialog();
        }

        /// <summary>
        /// Import students data
        /// </summary>
        public void ImportData(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] values = line.Split(';');  

                    if (values.Length >= 3) 
                    {
                        Student student = new Student(values[0], values[1], values[2]);
                        this.AddStudent(student);
                        repository.SaveStudents(students.ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'importation : {ex.Message}");
            }
        }
        /// <summary>
        /// Flag update for mvvm
        /// </summary>
        /// <param name="propertyName">Name of the property changed</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

using OGAMetier.Interfaces;
using OGAMetier.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OGAVM.ViewModel
{
    /// <summary>
    /// Gère la liste des étudiants et la navigation entre les vues
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {
        #region--Events--
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region--Attributes--
        /// <summary>
        /// Liste des étudiants
        /// </summary>
        private ObservableCollection<Student> students;

        /// <summary>
        /// Étudiant sélectionné dans la liste
        /// </summary>
        private Student? selectedStudent;

        private StudentVM? studentVM;

        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;
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
        /// ViewModel de l'étudiant sélectionné
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
        public MainVM(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
            students = new ObservableCollection<Student>();
            selectedStudent = null;
            studentVM = null;
            ListStudent();
        }
        #endregion

        #region--Methods--
        /// <summary>
        /// Ajoute un étudiant à la liste et sauvegarde
        /// </summary>
        public void AddStudent(Student student)
        {
            if (student != null)
            {
                Students.Add(student);
                studentRepository.SaveStudents(Students.ToList());
            }
        }

        /// <summary>
        /// Charge la liste des étudiants depuis le dépôt
        /// </summary>
        public void ListStudent()
        {
            foreach (var student in studentRepository.ListStudent())
                Students.Add(student);
        }

        /// <summary>
        /// Met à jour le StudentVM quand la sélection change
        /// </summary>
        private void UpdateStudentVM()
        {
            StudentVM = selectedStudent != null ? new StudentVM(selectedStudent) : null;
        }

        /// <summary>
        /// Ajoute un cours avec ses absences et sauvegarde
        /// </summary>
        public List<Course> ListCourses()
        {
            return courseRepository.ListCourse();
        }

        public void AddAbsence(Course course)
        {
            List<Course> courses = courseRepository.ListCourse();
            courses.Add(course);
            courseRepository.SaveCourse(courses);
        }

        public void ImportData(string path)
        {
            studentRepository.ImportFromCsv(path);
            Students.Clear();
            ListStudent();
        }

        /// <summary>
        /// Notifie le binding MVVM qu'une propriété a changé
        /// </summary>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

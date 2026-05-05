using OGAMetier.Interfaces;
using OGAMetier.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OGAVM.ViewModel
{
    public class CourseVM : INotifyPropertyChanged
    {
        #region--Événements--
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region--Attributs--

        /// <summary>
        /// Date du cours
        /// </summary>
        private DateTime courseDate = DateTime.Today;

        /// <summary>
        /// Heure de début du cours, par défaut 8
        /// </summary>
        private int selectedHour = 8;

        /// <summary>
        /// Minutes du début du cours, par défaut 0
        /// </summary>
        private int selectedMinute = 0;

        /// <summary>
        /// Nom du professeur
        /// </summary>
        private string teacherName = String.Empty;

        /// <summary>
        /// Nom du cours
        /// </summary>
        private string courseName = String.Empty;

        /// <summary>
        /// Durée du cours en minutes, par défaut 120
        /// </summary>
        private int duration = 120;

        /// <summary>
        /// Dépôt pour la persistance des cours
        /// </summary>
        private readonly ICourseRepository repository;

        /// <summary>
        /// Liste des étudiants avec statut de présence
        /// </summary>
        private ObservableCollection<StudentPresenceVM> studentsPresence;
        #endregion

        #region--Propriétés--
        public List<int> Hours { get; } = Enumerable.Range(0, 24).ToList();
        public List<int> Minutes { get; } = new List<int> { 0, 15, 30, 45 };

        public DateTime CourseDate
        {
            get => courseDate;
            set { courseDate = value; NotifyPropertyChanged(); }
        }

        public int SelectedHour
        {
            get => selectedHour;
            set { selectedHour = value; NotifyPropertyChanged(); }
        }

        public int SelectedMinute
        {
            get => selectedMinute;
            set { selectedMinute = value; NotifyPropertyChanged(); }
        }

        public string TeacherName
        {
            get => teacherName;
            set { teacherName = value; NotifyPropertyChanged(); }
        }

        public string CourseName
        {
            get => courseName;
            set { courseName = value; NotifyPropertyChanged(); }
        }

        public int Duration
        {
            get => duration;
            set { duration = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<StudentPresenceVM> StudentsPresence
        {
            get => studentsPresence;
            set { studentsPresence = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region--Constructeur--
        /// <summary>
        /// Initialise la VM avec une liste d'étudiants et le dépôt
        /// </summary>
        public CourseVM(IEnumerable<Student> students, ICourseRepository repo)
        {
            this.repository = repo;
            studentsPresence = new ObservableCollection<StudentPresenceVM>(
                students.Select(s => new StudentPresenceVM(s))
            );
        }
        #endregion

        #region--Méthodes--
        /// <summary>
        /// Construit un cours avec les infos actuelles
        /// </summary>
        public Course BuildCourse()
        {
            string[] absentCodes = StudentsPresence.Where(sp => sp.IsAbsent).Select(sp => sp.Student.Code).ToArray();

            DateTime fullDate = courseDate.Date.AddHours(selectedHour).AddMinutes(selectedMinute);

            return new Course
            {
                DateDetail = fullDate,
                TeacherName = teacherName,
                CourseName = courseName,
                Duration = duration,
                AbsentStudentsCodes = absentCodes
            };
        }

        /// <summary>
        /// Sauvegarde les cours
        /// </summary>
        public void SaveAbs(List<Course> course)
        {
            this.repository.SaveCourse(course);
        }

        /// <summary>
        /// Retourne les étudiants absents pour un cours donné
        /// </summary>
        public IEnumerable<Student> ListAbsences(Course course)
        {
            return repository.ListAbsences(course, studentsPresence.Select(sp => sp.Student));
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

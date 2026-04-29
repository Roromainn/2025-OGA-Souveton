using OGAMetier.Interfaces;
using OGAMetier.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OGAVM.ViewModel
{
    public class CourseVM : INotifyPropertyChanged
    {
        #region--Attributes--
        /// <summary>
        /// Flag pour le MVVM
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Date du cours
        /// </summary>
        private DateTime courseDate = DateTime.Today;

        /// <summary>
        /// Heure de d�but du cours, par d�faut 8
        /// </summary>
        private int selectedHour = 8;

        /// <summary>
        /// minutes du d�but du cours, par d�faut 0
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
        /// dur�e du cours en minutes, par d�faut 120
        /// </summary>
        private int duration = 120;

        private readonly ICourseRepository repository;


        /// <summary>
        /// Liste �tudiants pr�sents
        /// </summary>
        private ObservableCollection<StudentPresenceVM> studentsPresence;
        #endregion

        #region--Properties--
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

        #region--Constructor--
        public CourseVM(IEnumerable<Student> students, ICourseRepository repo)
        {
            this.repository = repo;
            studentsPresence = new ObservableCollection<StudentPresenceVM>(
                students.Select(s => new StudentPresenceVM(s))
            );
        }
        #endregion

        #region--Methods--
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

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

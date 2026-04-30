using Microsoft.Win32;
using OGAData;
using OGAVM.ViewModel;
using OutilGestionAbsences.View;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OutilGestionAbsences
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM(new StudentData(), new CourseData());

        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            MainVM vm = (MainVM)DataContext;
            StudentView stdView = new StudentView();
            bool? result = stdView.ShowDialog();
            if (result == true && stdView.StudentVM?.Student != null)
            {
                vm.AddStudent(stdView.StudentVM.Student);
            }
        }

        private void ImportData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "Fichiers CSV (*.csv)|*.csv";
            openFileDialog.DefaultExt = ".csv";
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = openFileDialog.FileName;

                MainVM vm = (MainVM)DataContext;
                vm.ImportData(filePath);
            }
        }

        private void AddAbsence_Click(object sender, RoutedEventArgs e)
        {
            MainVM vm = (MainVM)DataContext;
            CourseVM courseVM = new CourseVM(vm.Students, new CourseData());
            AbsenceInputView absenceView = new AbsenceInputView(courseVM);
            bool? result = absenceView.ShowDialog();
            if (result == true)
            {
                vm.AddAbsence(courseVM.BuildCourse());
            }
        }

        private void StudentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainVM vm = (MainVM)DataContext;
            if (vm.SelectedStudent != null)
            {
                StudentAbsView absView = new StudentAbsView(new StudentAbsVM(vm.SelectedStudent, vm.ListCourses()));
                absView.ShowDialog();
            }
        }

        private void ResumeAbsences_Click(object sender, RoutedEventArgs e)
        {
            MainVM vm = (MainVM)DataContext;
            ResumeAbsView resumeView = new ResumeAbsView(new ResumeAbsVM(vm.Students, vm.ListCourses()));
            resumeView.ShowDialog();
        }
    }
}

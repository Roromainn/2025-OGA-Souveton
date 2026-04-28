using Microsoft.Win32;
using OGAData;
using OGAVM.ViewModel;
using OutilGestionAbsences.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
            DataContext = new MainVM(new StudentData());

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
            vm.AddAbsence();
        }

        private void ResumeAbsences_Click(object sender, RoutedEventArgs e)
        {
            MainVM vm = (MainVM)DataContext;
            vm.ResumeAbsences();
        }
    }
}

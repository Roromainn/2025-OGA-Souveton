using OGAVM.ViewModel;
using System.Windows;

namespace OutilGestionAbsences.View
{
    public partial class AbsenceInputView : Window
    {
        public AbsenceInputView(CourseVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is CourseVM courseVM)
            {
                if (courseVM.TryValidate())
                {
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show(courseVM.ErrorMessage, "Erreur de validation", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

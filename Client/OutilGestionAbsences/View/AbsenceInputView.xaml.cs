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
            DialogResult = true;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

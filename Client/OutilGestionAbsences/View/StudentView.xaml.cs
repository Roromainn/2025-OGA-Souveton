using OGAShared.Models;
using OGAVM.ViewModel;
using System.Windows;

namespace OutilGestionAbsences.View
{
    /// <summary>
    /// Logique d'interaction pour StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        #region--Propriétés--
        public StudentVM? StudentVM { get; private set; }
        #endregion

        #region--Constructeur--
        public StudentView()
        {
            InitializeComponent();
            StudentVM = new StudentVM(new Student("", "", ""));
            DataContext = StudentVM;
        }
        #endregion

        #region--Méthodes--
        /// <summary>
        /// Valide la saisie et ferme la fenêtre
        /// </summary>
        private void ValideStudent(object sender, RoutedEventArgs e)
        {
            if (StudentVM!.TryValidate())
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show(StudentVM.ErrorMessage, "Erreur de validation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Annule la saisie et ferme la fenêtre
        /// </summary>
        private void CancelStudent(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        #endregion
    }
}

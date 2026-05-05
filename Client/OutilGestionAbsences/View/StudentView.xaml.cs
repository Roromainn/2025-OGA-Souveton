using OGAMetier.Models;
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
            DialogResult = true;
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

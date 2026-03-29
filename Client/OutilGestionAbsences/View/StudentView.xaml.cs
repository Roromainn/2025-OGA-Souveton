using OutilGestionAbsences.ViewModel;
using ProjetMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OutilGestionAbsences.View
{
    /// <summary>
    /// Logique d'interaction pour StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        #region--Attributes--
        /// <summary>
        /// New student created
        /// </summary>
        private Student? newStudent;
        #endregion

        #region--Properties--
        /// <summary>
        /// New student created
        /// </summary>
        public Student? NewStudent
        {
            get => newStudent;
        }
        #endregion

        #region--Constructor--
        public StudentView()
        {
            InitializeComponent();
        }
        #endregion

        #region--Methods--
        /// <summary>
        /// Creates the students when clicking on the button "OK"
        /// </summary>
        private void ValideStudent(object sender, RoutedEventArgs e)
        {
            newStudent = new Student(code.Text, last.Text, first.Text);
            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Cancels the creation of the student when clicking on the button "Cancel"
        /// </summary>
        private void CancelStudent(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        #endregion
    }
}

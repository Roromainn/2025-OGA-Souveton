using OutilGestionAbsences.ViewModel;
using ProjetMetier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private StudentVM studentVM;

        private string _code;

        private string _lastName;

        private string _firstName;
        #endregion

        #region--Properties--
        public StudentVM StudentVM
        {  get { return studentVM; } }

        public string Code
        { get { return _code; } }

        public string LastName
        { get { return _lastName; } }

        public string FirstName
        { get { return _firstName; } }
        #endregion


        #region--Constructor--
        public StudentView()
        {
            InitializeComponent();
            this.studentVM = new StudentVM(this._code, this._lastName, this._firstName);
        }
        #endregion

        #region--Methods--
        /// <summary>
        /// Creates the students when clicking on the button "OK"
        /// </summary>
        private void ValideStudent(object sender, RoutedEventArgs e)
        {
            Student newStudent = studentVM.Student;
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

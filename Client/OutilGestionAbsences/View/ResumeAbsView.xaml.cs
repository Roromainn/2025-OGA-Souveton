using OGAVM.ViewModel;
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
    public partial class ResumeAbsView : Window
    {
        public ResumeAbsView(ResumeAbsVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}

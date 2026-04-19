using OGAMetier.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGAMetier.Interfaces
{
    public interface IStudentRepository
    {
        public ObservableCollection<Student> ListStudent();

    }
}

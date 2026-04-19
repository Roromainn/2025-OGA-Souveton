using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGAMetier.Models
{
    /// <summary>
    /// Class representing a student
    /// </summary>
    public class Student
    {
        #region--Attributes--
        /// <summary>
        /// Code representing the student
        /// </summary>
        string code;

        /// <summary>
        /// Last name of the student
        /// </summary>
        string lastName;

        /// <summary>
        /// First name of the student
        /// </summary>
        string? firstName;
        #endregion

        #region--Properties--
        public string Code { get => code; set => code = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string? FirstName { get => firstName; set => firstName = value; }
        #endregion

        #region--Constructor--
        public Student() { }

        public Student(string code, string lastName, string firstName=null)
        {
            this.code = code;
            this.lastName = lastName;
            this.firstName = firstName;
        }
        #endregion
    }
}

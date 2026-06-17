using OGAShared.Models;
using System.Collections.Generic;

namespace OGAMetier.Interfaces
{
    /// <summary>
    /// Interface pour la persistance des cours
    /// </summary>
    public interface ICourseRepository
    {
        /// <summary>
        /// Récupère la liste des cours
        /// </summary>
        List<Course> ListCourse();

        /// <summary>
        /// Récupère les étudiants absents pour un cours donné
        /// </summary>
        IEnumerable<Student> ListAbsences(Course course, IEnumerable<Student> students);

        /// <summary>
        /// Sauvegarde la liste des cours
        /// </summary>
        void SaveCourse(List<Course> courses);
    }
}

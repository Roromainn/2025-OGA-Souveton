using OGAMetier.Models;
using System.Collections.ObjectModel;

namespace OGAMetier.Interfaces
{
    /// <summary>
    /// Interface pour la persistance des étudiants
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Récupère la liste des étudiants
        /// </summary>
        ObservableCollection<Student> ListStudent();

        /// <summary>
        /// Sauvegarde la liste des étudiants
        /// </summary>
        void SaveStudents(List<Student> students);

        /// <summary>
        /// Importe les étudiants depuis un fichier CSV
        /// </summary>
        void ImportFromCsv(string path);
    }
}

using OGAShared.Models;

namespace OutilGestionAbsencesServeur.Data
{
    /// <summary>
    /// Contrat pour l'accès aux données des étudiants
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Ajoute un nouvel étudiant à la base de données
        /// </summary>
        /// <param name="student">L'étudiant à ajouter</param>
        /// <returns>true si succès, false sinon</returns>
        /// <exception cref="InvalidOperationException">Si l'étudiant existe déjà</exception>
        bool AddStudent(Student student);

        /// <summary>
        /// Récupère tous les étudiants de la base de données
        /// </summary>
        /// <returns>Liste de tous les étudiants</returns>
        List<Student> GetAllStudents();
    }
}

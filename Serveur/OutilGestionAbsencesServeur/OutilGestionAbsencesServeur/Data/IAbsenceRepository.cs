using OGAShared.Models;

namespace OutilGestionAbsencesServeur.Data
{
    /// <summary>
    /// Contrat pour l'accès aux données des absences
    /// </summary>
    public interface IAbsenceRepository
    {
        /// <summary>
        /// Récupère toutes les absences d'un étudiant
        /// </summary>
        /// <param name="studentCode">Code de l'étudiant</param>
        /// <returns>Liste des absences de l'étudiant</returns>
        List<Absence> ListForStudent(string studentCode);

        /// <summary>
        /// Saisit les absences à un cours 
        /// </summary>
        /// <param name="course">Cours concerné, avec la liste des codes des étudiants absents</param>
        /// <exception cref="KeyNotFoundException">Si le cours n'existe pas en base de données</exception>
        void Insert(Course course);

        /// <summary>
        /// Calcule les statistiques d'absence par étudiant
        /// </summary>
        /// <returns>Liste des statistiques d'absence</returns>
        List<StatsAbsences> GetStats();
    }
}

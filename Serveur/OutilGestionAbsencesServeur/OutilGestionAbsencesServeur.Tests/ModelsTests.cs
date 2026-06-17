using System.ComponentModel.DataAnnotations;
using OGAShared.Models;

namespace OutilGestionAbsencesServeur.Tests
{
    /// <summary>
    /// Tests unitaires de la logique de validation des modèles partagés
    /// </summary>
    public class ModelsTests
    {

        [Fact]
        public void Student_Valide_ExposeLesValeurs()
        {
            Student student = new Student("S1", "Dupont", "Jean");

            Assert.Equal("S1", student.Code);
            Assert.Equal("Dupont", student.LastName);
            Assert.Equal("Jean", student.FirstName);
        }

        [Fact]
        public void Student_CodeVide_LeveValidationException()
        {
            Student student = new Student("", "Dupont", "Jean");

            Assert.Throws<ValidationException>(() =>
            {
                string valeur = student.Code;
            });
        }

        [Fact]
        public void Student_CodeTropLong_LeveValidationException()
        {
            string codeTropLong = new string('x', 33);
            Student student = new Student(codeTropLong, "Dupont", "Jean");

            Assert.Throws<ValidationException>(() =>
            {
                string valeur = student.Code;
            });
        }

        [Fact]
        public void Student_NomVide_LeveValidationException()
        {
            Student student = new Student("S1", "", "Jean");

            Assert.Throws<ValidationException>(() =>
            {
                string valeur = student.LastName;
            });
        }


        [Fact]
        public void CourseDetails_DateNonDefinie_LeveInvalidOperationException()
        {
            CourseDetails course = new CourseDetails();

            Assert.Throws<InvalidOperationException>(() =>
            {
                DateTime valeur = course.DateDetail;
            });
        }

        [Fact]
        public void CourseDetails_NomCoursVide_LeveInvalidOperationException()
        {
            CourseDetails course = new CourseDetails();

            Assert.Throws<InvalidOperationException>(() =>
            {
                string valeur = course.CourseName;
            });
        }

        [Fact]
        public void CourseDetails_DureeNulle_LeveInvalidOperationException()
        {
            CourseDetails course = new CourseDetails();
            course.Duration = 0;

            Assert.Throws<InvalidOperationException>(() =>
            {
                int valeur = course.Duration;
            });
        }

        [Fact]
        public void CourseDetails_Valide_ExposeLesValeurs()
        {
            CourseDetails course = new CourseDetails();
            course.CourseName = "Maths";
            course.TeacherName = "Martin";
            course.DateDetail = new DateTime(2026, 1, 1);
            course.Duration = 60;

            Assert.Equal("Maths", course.CourseName);
            Assert.Equal("Martin", course.TeacherName);
            Assert.Equal(60, course.Duration);
        }


        [Fact]
        public void StatsAbsences_ExposeDureesEtNomEtudiant()
        {
            Student student = new Student("S1", "Dupont");
            StatsAbsences stats = new StatsAbsences(student, 120, 60);

            Assert.Equal(120, stats.TotalDuration);
            Assert.Equal(60, stats.TotalDurationUnjustified);
            Assert.Equal("Dupont", stats.StudentLastName);
        }
    }
}

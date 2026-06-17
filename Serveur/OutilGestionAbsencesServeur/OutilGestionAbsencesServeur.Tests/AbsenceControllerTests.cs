    using Microsoft.AspNetCore.Mvc;
using Moq;
using OGAShared.Models;
using OutilGestionAbsencesServeur.Controllers;
using OutilGestionAbsencesServeur.Data;

namespace OutilGestionAbsencesServeur.Tests
{
    /// <summary>
    /// Tests unitaires du contrôleur des absences (repository mocké, pas d'accès base)
    /// </summary>
    public class AbsenceControllerTests
    {
        private readonly Mock<IAbsenceRepository> _repository;
        private readonly AbsenceController _controller;

        public AbsenceControllerTests()
        {
            _repository = new Mock<IAbsenceRepository>();
            _controller = new AbsenceController(_repository.Object);
        }

        private static Course CoursAvecEtudiants(string[] codes)
        {
            Course course = new Course();
            course.CourseName = "Maths";
            course.TeacherName = "Martin";
            course.DateDetail = new DateTime(2026, 1, 1);
            course.Duration = 60;
            course.AbsentStudentsCodes = codes;
            return course;
        }


        [Fact]
        public void ListForStudent_Valide_Retourne200AvecListe()
        {
            List<Absence> absences = new List<Absence>();
            _repository.Setup(r => r.ListForStudent("S1")).Returns(absences);

            IActionResult result = _controller.ListForStudent("S1");

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(absences, okResult.Value);
        }

        [Fact]
        public void ListForStudent_CodeChaineVide_Retourne400()
        {
            IActionResult result = _controller.ListForStudent("");

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void ListForStudent_CodeEspaces_Retourne400()
        {
            IActionResult result = _controller.ListForStudent("   ");

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void ListForStudent_ErreurServeur_Retourne500()
        {
            Exception erreur = new Exception("erreur SQL");
            _repository.Setup(r => r.ListForStudent("S1")).Throws(erreur);

            IActionResult result = _controller.ListForStudent("S1");

            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }


        [Fact]
        public void AddAbsenceCourse_Valide_Retourne200()
        {
            string[] codes = new string[] { "S1", "S2" };
            Course course = CoursAvecEtudiants(codes);

            IActionResult result = _controller.AddAbsenceCourse(course);

            Assert.IsType<OkResult>(result);
            _repository.Verify(r => r.Insert(course), Times.Once);
        }

        [Fact]
        public void AddAbsenceCourse_CoursNull_Retourne400()
        {
            IActionResult result = _controller.AddAbsenceCourse(null!);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void AddAbsenceCourse_AucunEtudiant_Retourne400()
        {
            string[] codes = new string[] { };
            Course course = CoursAvecEtudiants(codes);

            IActionResult result = _controller.AddAbsenceCourse(course);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void AddAbsenceCourse_CoursIntrouvable_Retourne404()
        {
            string[] codes = new string[] { "S1" };
            Course course = CoursAvecEtudiants(codes);
            KeyNotFoundException erreur = new KeyNotFoundException("Cours introuvable");
            _repository.Setup(r => r.Insert(course)).Throws(erreur);

            IActionResult result = _controller.AddAbsenceCourse(course);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void AddAbsenceCourse_ErreurServeur_Retourne500()
        {
            string[] codes = new string[] { "S1" };
            Course course = CoursAvecEtudiants(codes);
            Exception erreur = new Exception("erreur SQL");
            _repository.Setup(r => r.Insert(course)).Throws(erreur);

            IActionResult result = _controller.AddAbsenceCourse(course);

            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }


        [Fact]
        public void Stats_Retourne200AvecListe()
        {
            List<StatsAbsences> stats = new List<StatsAbsences>();
            stats.Add(new StatsAbsences(new Student("S1", "Dupont"), 120, 60));
            _repository.Setup(r => r.GetStats()).Returns(stats);

            IActionResult result = _controller.Stats();

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(stats, okResult.Value);
        }

        [Fact]
        public void Stats_ErreurServeur_Retourne500()
        {
            Exception erreur = new Exception("erreur SQL");
            _repository.Setup(r => r.GetStats()).Throws(erreur);

            IActionResult result = _controller.Stats();

            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Moq;
using OGAShared.Models;
using OutilGestionAbsencesServeur.Controllers;
using OutilGestionAbsencesServeur.Data;

namespace OutilGestionAbsencesServeur.Tests
{
    /// <summary>
    /// Tests unitaires du contrôleur des étudiants (repository mocké, pas d'accès base)
    /// </summary>
    public class StudentControllerTests
    {
        private readonly Mock<IStudentRepository> _repository;
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            _repository = new Mock<IStudentRepository>();
            _controller = new StudentController(_repository.Object);
        }

        [Fact]
        public void AddStudent_Valide_Retourne200()
        {
            Student student = new Student("S1", "Dupont", "Jean");
            _repository.Setup(r => r.AddStudent(student)).Returns(true);

            IActionResult result = _controller.AddStudent(student);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddStudent_ModelStateInvalide_Retourne400()
        {
            Student student = new Student("S1", "Dupont");
            _controller.ModelState.AddModelError("Code", "obligatoire");

            IActionResult result = _controller.AddStudent(student);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void AddStudent_Doublon_Retourne400()
        {
            Student student = new Student("S1", "Dupont");
            InvalidOperationException erreur = new InvalidOperationException("existe déjà");
            _repository.Setup(r => r.AddStudent(student)).Throws(erreur);

            IActionResult result = _controller.AddStudent(student);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void AddStudent_EchecInsertion_Retourne500()
        {
            Student student = new Student("S1", "Dupont");
            _repository.Setup(r => r.AddStudent(student)).Returns(false);

            IActionResult result = _controller.AddStudent(student);

            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        [Fact]
        public void AddStudent_ErreurServeur_Retourne500()
        {
            Student student = new Student("S1", "Dupont");
            Exception erreur = new Exception("erreur SQL");
            _repository.Setup(r => r.AddStudent(student)).Throws(erreur);

            IActionResult result = _controller.AddStudent(student);

            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

        [Fact]
        public void GetAllStudents_Retourne200AvecListe()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("S1", "Dupont"));
            _repository.Setup(r => r.GetAllStudents()).Returns(students);

            IActionResult result = _controller.GetAllStudents();

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(students, okResult.Value);
        }

        [Fact]
        public void GetAllStudents_ErreurServeur_Retourne500()
        {
            Exception erreur = new Exception("erreur SQL");
            _repository.Setup(r => r.GetAllStudents()).Throws(erreur);

            IActionResult result = _controller.GetAllStudents();

            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }
    }
}

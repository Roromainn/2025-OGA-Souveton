using OGAShared.Models;
using OGAData;
using Xunit;
using System.IO;

namespace OGATests
{
    public class CourseDataTests
    {
        private string GetTempPath() => Path.Combine(Path.GetTempPath(), $"course_test_{Guid.NewGuid()}.json");

        [Fact]
        public void ListCourse_FichierVide_RetourneListeVide()
        {
            CourseData? repo = new CourseData();
            List<Course> courses = repo.ListCourse();

            Assert.NotNull(courses);
            Assert.IsType<List<Course>>(courses);
        }

        [Fact]
        public void SaveCourse_PuisListCourse_RetourneCours()
        {
            string? tempPath = GetTempPath();
            try
            {
                CourseData? repo = new CourseData();
                Course course = new Course { CourseName = "Maths", Duration = 120, AbsentStudentsCodes = new[] { "001" } };

                repo.SaveCourse(new List<Course> { course });
                List<Course> loaded = repo.ListCourse();

                Assert.Single(loaded);
                Assert.Equal("Maths", loaded[0].CourseName);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }

        [Fact]
        public void ListAbsences_RetourneEtudiantsAbsents()
        {
            CourseData? repo = new CourseData();
            Student[] students = new[] { new Student("001", "Potter", "Harry"), new Student("002", "Granger", "Hermione") };
            Course course = new Course { CourseName = "Maths", AbsentStudentsCodes = new[] { "001" } };

            List<Student> absences = repo.ListAbsences(course, students).ToList();
            Assert.Single(absences);
            Assert.Equal("001", absences.First().Code);
        }

        [Fact]
        public void ListAbsences_PasAbsent_RetourneVide()
        {
            CourseData? repo = new CourseData();
            Student[] students = new[] { new Student("001", "Potter", "Harry"), new Student("002", "Granger", "Hermione") };
            Course course = new Course { CourseName = "Maths", AbsentStudentsCodes = new string[] { } };

            List<Student> absences = repo.ListAbsences(course, students).ToList();
            Assert.Empty(absences);
        }

        [Fact]
        public void SaveCourse_MultiplesCours()
        {
            CourseData repo = new CourseData();
            List<Course> courses = new List<Course>
            {
                new Course { CourseName = "Maths", Duration = 120 },
                new Course { CourseName = "Français", Duration = 90 }
            };

            repo.SaveCourse(courses);
            List<Course> loaded = repo.ListCourse();

            Assert.Equal(2, loaded.Count);
        }
    }
}

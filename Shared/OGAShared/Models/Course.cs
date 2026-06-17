namespace OGAShared.Models
{
    public class Course : CourseDetails
    {
        string[] absentStudentsCodes = Array.Empty<string>();

        public string[] AbsentStudentsCodes { get => absentStudentsCodes; set => absentStudentsCodes = value; }
    }
}

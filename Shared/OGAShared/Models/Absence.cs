namespace OGAShared.Models
{
    public class Absence : CourseDetails
    {
        string justification = string.Empty;
        bool justified;

        public string Justification { get => justification; set => justification = value; }
        public bool Justified { get => justified; set => justified = value; }
    }
}

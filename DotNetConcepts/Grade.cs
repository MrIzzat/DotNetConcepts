namespace DotNetConcepts
{
    public class Grade : IGrade
    {
        public double Mark { get; set; }
        public string Subject { get; set; }

        public Grade(double mark, string subject)
        {
            Mark = mark;
            Subject = subject;
        }
    }
}
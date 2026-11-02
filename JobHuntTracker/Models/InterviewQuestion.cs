namespace JobHuntTracker.Models
{
    public class InterviewQuestion
    {
        public Guid Id { get; set; }
        public string Section { get; set; }
        public int Position { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}

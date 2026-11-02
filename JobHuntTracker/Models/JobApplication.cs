using System;
using System.ComponentModel.DataAnnotations;

namespace JobHuntTracker.Models
{
    public class JobApplication
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Job title is required.")]
        public string Title { get; set; }
        public string Company { get; set; }
        public string Salary { get; set; }
        [Required(ErrorMessage = "Job description is required.")]
        public string JobDescription { get; set; }
        public string Recruiter { get; set; }
        public string RecruiterAgency { get; set; }
        [Required(ErrorMessage = "Site applied is required.")]
        public string SiteApplied { get; set; }
        public string Location { get; set; }
        public bool IsRemote { get; set; }
        public DateTimeOffset AppliedDate { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public bool IsActive { get; set; }

        public List<InterviewQuestion> InterviewQuestions { get; set; } = new();

    }
}

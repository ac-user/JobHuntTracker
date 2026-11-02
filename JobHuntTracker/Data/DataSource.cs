using JobHuntTracker.Models;
using Newtonsoft.Json;

namespace JobHuntTracker.Data
{
    public static class DataSource
    {
        private static readonly string _defaultQuestionFileName = "Default_Questions";
        private static readonly string _folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Data");

        /// <summary>
        /// Save the new job application
        /// </summary>
        /// <param name="jobApplication">application details to save</param>
        /// <returns>boolean success indicator</returns>
        public static bool Create(JobApplication jobApplication)
        {
            string json = JsonConvert.SerializeObject(jobApplication);
            string filePath = Path.Combine(_folder, jobApplication.Id.ToString());

            if (File.Exists(filePath) || String.IsNullOrWhiteSpace(json))
                return false;
            
            File.WriteAllText(filePath, json);            
            return File.Exists(filePath);
        }

        /// <summary>
        /// Get all the job applications
        /// </summary>
        /// <returns>Job applications list</returns>
        public static List<JobApplication> Get()
        {
            List<JobApplication> list = new List<JobApplication>();
            foreach (string file in Directory.GetFiles(_folder))
            {
                if (!file.Contains(_defaultQuestionFileName))
                {
                    string content = File.ReadAllText(file);
                    list.Add(JsonConvert.DeserializeObject<JobApplication>(content));
                }
            }
         
            return list;
        }

        /// <summary>
        /// Get job applications
        /// </summary>
        /// <returns>Job applications</returns>
        public static JobApplication Get(Guid id)
        {
            string file = Path.Combine(_folder, id.ToString());            
            if (File.Exists(file))
            {
                string content = File.ReadAllText(file);
                return JsonConvert.DeserializeObject<JobApplication>(content);
            }
            
            return null;
        }

        /// <summary>
        /// Get default questions
        /// </summary>
        /// <returns>Default question list</returns>
        public static List<InterviewQuestion> GetDefaultQuestions()
        {
            List<InterviewQuestion> list = new List<InterviewQuestion>();
            string file = Path.Combine(_folder, _defaultQuestionFileName);
            if (File.Exists(file))
            {
                string content = File.ReadAllText(file);
                list = JsonConvert.DeserializeObject<List<InterviewQuestion>>(content);
            }
         
            return list;
        }


        /// <summary>
        /// Save the default interview questions
        /// </summary>
        /// <param name="interviewQuestions">questions to save</param>
        /// <returns>boolean success indicator</returns>
        public static bool Upsert(List<InterviewQuestion> interviewQuestions)
        {
            string json = JsonConvert.SerializeObject(interviewQuestions);
            if (String.IsNullOrWhiteSpace(json))
                return false;
            
            string filePath = Path.Combine(_folder, _defaultQuestionFileName);
            File.WriteAllText(filePath, json);            
            return File.Exists(filePath);
        }

        /// <summary>
        /// Update the application info
        /// </summary>
        /// <param name="jobApplication">application to update</param>
        /// <returns>boolean success indicator</returns>
        public static bool Upsert(JobApplication jobApplication)
        {
            string json = JsonConvert.SerializeObject(jobApplication);
            if (String.IsNullOrWhiteSpace(json))
                return false;
            
            string filePath = Path.Combine(_folder, jobApplication.Id.ToString());
            File.WriteAllText(filePath, json);            
            return File.Exists(filePath);
        }


    }
}

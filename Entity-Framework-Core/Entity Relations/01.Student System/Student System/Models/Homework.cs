using System;
using System.Collections.Generic;
using System.Text;

namespace Student_System.Models
{
    internal class Homework
    {
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public enum ContentType
        {
            Application,
            Pdf,
            Zip
        }
        public DateTime SubmissionTime { get; set; }
        public int StudentId{ get; set; }
        public int CourseId { get; set; }

        //TODO StudentCourse class implementation
    }
}

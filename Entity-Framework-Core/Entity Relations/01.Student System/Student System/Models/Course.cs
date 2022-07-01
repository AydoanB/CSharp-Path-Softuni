using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student_System.Models
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        ICollection<Student> StudentsEnrolled { get; set; }
        ICollection<Resource> Resources { get; set; }
        ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}

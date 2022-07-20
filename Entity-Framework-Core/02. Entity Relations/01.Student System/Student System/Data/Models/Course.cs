using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Student_System.Models
{
    public class Course
    {
        public Course()
        {
            StudentsEnrolled = new HashSet<Student>();
            Resources = new HashSet<Resource>();
            HomeworkSubmissions = new HashSet<Homework>();
        }
        [Key]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(100)]
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

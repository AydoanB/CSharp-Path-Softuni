using Student_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    internal class Student
    {
        [Key]
        [Required]
        public int StudentId { get; set; }
        
        [MaxLength(50)]
        [Required]

        public string Name { get; set; }

        [StringLength(10)]
        public string PhoneNumber{ get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime Birthday{ get; set; }

        ICollection<Course> CourseEnrollments { get; set; }
        ICollection<Homework> HomeworkSubmissions { get; set; }


    }
}

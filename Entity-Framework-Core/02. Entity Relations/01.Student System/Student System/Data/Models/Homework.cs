using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Student_System.Models.Enumerators;

namespace Student_System.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        
        public DateTime SubmissionTime { get; set; }
        public int StudentId{ get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }


    }
}

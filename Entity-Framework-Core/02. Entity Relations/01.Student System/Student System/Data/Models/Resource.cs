using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using P01_StudentSystem.Data.Models;
using Student_System.Models.Enumerators;

namespace Student_System.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Name { get; set; }
        
        public string Url { get; set; }
        
        public ResourceType ResourceType { get; set; }
       
        public int StudentId { get; set; }
        public Student Student { get; set; }
       
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

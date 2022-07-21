using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeesTasks = new HashSet<EmployeeTask>();
        }

        [Key] public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required] public string Phone { get; set; }

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }

    }
}
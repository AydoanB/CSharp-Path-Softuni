using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Excercises.App.Data.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Git.Services;

namespace Git.Data
{
    public class User
    {
        public User()
        {
            this.Repositories = new HashSet<Repository>();
            this.Commits = new HashSet<Commit>();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Repository> Repositories { get; set; }
        public virtual ICollection<Commit> Commits { get; set; }
    }
}
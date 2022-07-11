using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealProductShop.Data.Models;

public class User
{
    public User()
    {
        productsSold = new List<Product>();
        productsBought= new List<Product>();
    }
    [Key]
    [Required]
    public int Id { get; set; }

    
    public string FirstName { get; set; }
    
    [Required]
    [MinLength(3)]
    public string LastName { get; set; }
    public int Age { get; set; }

   public virtual ICollection<Product> productsSold { get; set; }
   public virtual ICollection<Product> productsBought { get; set; }
}
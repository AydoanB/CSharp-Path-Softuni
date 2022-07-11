using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealProductShop.Data.Models;

public class Category
{
    public Category()
    {
        categoryProducts = new List<CategoryProduct>();
    }

    [Key]
    [Required]
    public int Id{ get; set; }

    [StringLength(15),MinLength(3)]
    public string Name{ get; set; }

    public virtual ICollection<CategoryProduct> categoryProducts { get; set; }
}
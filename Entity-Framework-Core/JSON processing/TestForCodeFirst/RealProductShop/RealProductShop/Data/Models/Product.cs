using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealProductShop.Data.Models;

public class Product
{
    public Product()
    {
        categoryProducts = new List<CategoryProduct>();
    }

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public decimal Price { get; set; }

    [Required]
    public int SellerId { get; set; }
    public User Seller { get; set; }

    public int BuyerId { get; set; }
    public User Buyer { get; set; }

    public virtual ICollection<CategoryProduct> categoryProducts { get; set; }

}
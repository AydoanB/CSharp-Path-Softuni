using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RealProductShop.Data.Models;

public class CategoryProduct
{
    [Key]
    [Column(Order = 1)]
    [Required] 
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    [Key]
    [Column(Order = 2)]
    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }

}

using System.ComponentModel.DataAnnotations.Schema;

namespace Rij62.Models;

public class ProductStepOption
{
    public int ProductStepId { get; set; }
    public int ProductId { get; set; }

    [ForeignKey("ProductStepId")]
    public ProductStep? ProductStep { get; set; }

    [ForeignKey("ProductId")]
    public Product? Product {get; set;}
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Rij62.Models;

public class ProductStep
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int? DefaultOptionId { get; set; }
    public bool MultipleChoice { get; set; }
    public required string TitleKey { get; set; }

    [ForeignKey("ProductId")]
    public Product? Product { get; set; }

    public ICollection<ProductStepOption> Options { get; set; }
}

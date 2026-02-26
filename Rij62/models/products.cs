using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rij62.Models;

[Table("products")]
public class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    // The TitleKey and DescriptionKey are keys to look up the localized strings in the resource files.
    [Column("title_key")]
    public string TitleKey { get; set; } = string.Empty;

    // The DescriptionKey is a key to look up the localized description in the resource files.
    [Column("description_key")]
    public string DescriptionKey { get; set; } = string.Empty;

    [Column("price_cent")]
    public int PriceCent { get; set; }

    [Column("stock")]
    public int Stock { get; set; }

    [Column("is_available")]
    public bool IsAvailable { get; set; }

    [Column("img_url")]
    public string? ImgUrl { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }
}
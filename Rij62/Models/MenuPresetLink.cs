
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rij62.Models;

[Keyless]
public class MenuPresetLink
{
    public required int ProductId { get; set; }
    public required int MenuPresetId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product;
    [ForeignKey("MenuPresetId")]
    public MenuPreset MenuPreset;
}

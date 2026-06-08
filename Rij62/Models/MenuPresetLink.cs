
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rij62.Models;

public class MenuPresetLink
{
    public int Id { get; set; }
    public required int ProductId { get; set; }
    public required int MenuPresetId { get; set; }

    [ForeignKey("MenuPresetId")]
    public MenuPreset MenuPreset { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}

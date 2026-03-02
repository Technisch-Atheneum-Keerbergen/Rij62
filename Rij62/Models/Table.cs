using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rij62.Models;

public class Table
{
    [Key]
    public int Id { get; set; }

    public int TableNumber {get; set;}
}
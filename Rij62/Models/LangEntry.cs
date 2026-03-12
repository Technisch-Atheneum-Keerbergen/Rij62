using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rij62.Models;

/// <summary>
/// Entry in the language table of the db
/// </summary>
[PrimaryKey(nameof(Key), nameof(Language))]
public class LangEntry
{
    public required string Key {get; set;}
    public Language Language {get; set;}
    public required string Value {get; set;}
    
}
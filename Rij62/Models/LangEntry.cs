using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Rij62.Models;

/// <summary>
/// Entry in the language table of the db
/// </summary>
[PrimaryKey(nameof(Key), nameof(Language))]
public class LangEntry
{
    public string Key {get; set;}
    public Language Language {get; set;}
    public string Value {get; set;}
    
}
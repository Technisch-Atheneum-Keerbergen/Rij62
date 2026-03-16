// **********************************
//     *** ProductCategory Model  ***
// Author: Xavier Demaerel
// Date: 02/03/2026
// File: Models/ProductCategory.cs
// **********************************
namespace Rij62.Models
{
    public class ProductCategory
    { 
        public int Id { get; set; }
        public int? ScreenId { get; set; }
        public required string NameKey { get; set; }

    }
}
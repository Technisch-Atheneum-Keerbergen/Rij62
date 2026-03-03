// **********************************
//   *** ProductHistory Model  ***
// Author: Xavier Demaerel
// Date: 03/03/2026
// File: Models/ProductHistory.cs
// **********************************

namespace Rij62.Models
{
    public class ProductHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal LastPrice { get; set; }
    }

}
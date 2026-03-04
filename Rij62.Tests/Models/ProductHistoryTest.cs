// **********************************************
//       *** ProductHistory Model Test  ***
// Author: Xavier Demaerel
// Date: 04/03/2026
// File: Rij62.Tests\Models\ProductHistoryTest.cs
// **********************************************

using Xunit;
using Rij62.Models;

namespace Rij62.Tests.Models
{
    public class ProductHistoryTests
    {
        [Fact]
        public void ProductHistory_Creation_Works()
        {
            // Arrange
            var timestamp = new DateTime(2026, 3, 4, 12, 0, 0);
            var dateStart = timestamp.AddDays(-1);

            // Act
            var productHistory = new ProductHistory
            {
                Id = 1,
                ProductId = 5,
                DateStart = dateStart,
                DateEnd = timestamp,
                LastPrice = 1900
            };

            // Assert
            Assert.Equal(1, productHistory.Id);
            Assert.Equal(5, productHistory.ProductId);
            Assert.Equal(dateStart, productHistory.DateStart);
            Assert.Equal(timestamp, productHistory.DateEnd);
            Assert.Equal(1900, productHistory.LastPrice);

            // Optional domain rule check
            Assert.True(productHistory.DateStart < productHistory.DateEnd);
        }
    }
}
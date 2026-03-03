// **********************************
//     *** Product Model Test  ***
// Author: Xavier Demaerel
// Date: 03/03/2026
// File: Rij26.Tests/models/ProductTest.cs
// **********************************

using Xunit;
using Rij62.Models;

namespace Rij62.Tests.Models
{
    public class ProductTest
    {
        [Fact]
        public void Product_Creation_Works()
        {
            // Arrange
            var id = 1;
            var TitleKey = "Test Product";
            var DescriptionKey = "This is a test product.";
            var priceCent = 1099; // Price in cents (10.99 euros)
            var stock = 50;
            var isAvailable = true;
            var imgUrl = "https://example.com/product-image.jpg";
            var categoryId = 1;

            // Act
            var product = new Product
            {
                Id = id,
                TitleKey = TitleKey,
                DescriptionKey = DescriptionKey,
                PriceCent = priceCent,
                Stock = stock,
                IsAvailable = isAvailable,
                ImgUrl = imgUrl,
                CategoryId = categoryId
            };

            // Assert
            Assert.Equal(id, product.Id);
            Assert.Equal(TitleKey, product.TitleKey);
            Assert.Equal(DescriptionKey, product.DescriptionKey);
            Assert.Equal(priceCent, product.PriceCent);
            Assert.Equal(stock, product.Stock);
            Assert.Equal(isAvailable, product.IsAvailable);
            Assert.Equal(imgUrl, product.ImgUrl);
            Assert.Equal(categoryId, product.CategoryId);
        }
    }
}


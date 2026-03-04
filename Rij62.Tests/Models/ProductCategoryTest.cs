// **********************************
//     *** ProductCategory Model Test  ***
// Author: Xavier Demaerel
// Date: 03/03/2026
// File: Rij62.Tests\Models\ProductCategoryTest.cs
// **********************************


using Rij62.Models;
using Xunit;

namespace Rij62.Tests.Models
{
    public class ProductCategoryTest
    {
        [Fact]
        public void CanCreateProductCategory()
        {
            // Arrange
            var productCategory = new ProductCategory
            {
                Id = 1,
                ScreenId = 2,
                Name = "Test Category"
            };

            // Act & Assert
            Assert.NotNull(productCategory);
            Assert.Equal(1, productCategory.Id);
            Assert.Equal(2, productCategory.ScreenId);
            Assert.Equal("Test Category", productCategory.Name);
        }
    }
}
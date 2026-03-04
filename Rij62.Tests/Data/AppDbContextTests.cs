// **********************************
//     *** AppDbContext Test  ***
// Author: Xavier Demaerel
// Date: 03/03/2026
// File: /Rij62.Test/models/AppDbContextTest.cs
// **********************************

using Xunit;
using Rij62.Data;
using Microsoft.EntityFrameworkCore;

namespace Rij62.Tests.Data
{
    public class AppDbContextTests
    {
        [Fact]
        public void AppDbContext_Creation_Works()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Act
            using var context = new AppDbContext(options);

            // Assert
            Assert.NotNull(context);
            Assert.IsType<AppDbContext>(context);
        }
    }
}
// **********************************
//     *** Screen Model Test  ***
// Author: Xavier Demaerel
// Date: 03/03/2026
// File: Rij62.Test/models/ScreenTest.cs
// **********************************

using Xunit;
using Rij62.Models;

namespace Rij62.Tests.Models
{
    public class ScreenTest
    {
        [Fact]
        public void Screen_Creation_Works()
        {
            // Arrange
            var id = 1;
            var name = "Main Screen";
            var description = "The main screen in the restaurant.";

            // Act
            var screen = new Screen
            {
                Id = id,
                Name = name,
                Description = description
            };

            // Assert
            Assert.Equal(id, screen.Id);
            Assert.Equal(name, screen.Name);
            Assert.Equal(description, screen.Description);
        }
    }
}
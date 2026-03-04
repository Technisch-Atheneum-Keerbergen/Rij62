// **********************************
//     *** Tabel Model Test  ***
// Author: Xavier Demaerel
// Date: 04/03/2026
// File: Rij62.Tests\Models\TableTest.cs
// **********************************

using Xunit;
using Rij62.Models;

namespace Rij62.Tests.Models
{
    public class TableTest
    {
        [Fact]
        public void TestTableProperties()
        {
            // Arrange
            var table = new Table();

            // Act
            table.Id = 1;
            table.TableNumber = 5;

            // Assert
            Assert.Equal(1, table.Id);
            Assert.Equal(5, table.TableNumber);
        }
    }
}
// **********************************
//     *** Table Controller Test  ***
// Author: Xavier Demaerel
// Date: 09/03/2026
// File: Rij62.Tests\Controllers\TableControllerTest.cs
// **********************************

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Controllers;
using Rij62.Data;
using Rij62.Models;
using Xunit;

namespace Rij62.Tests.Controllers
{
    public class TableControllerTest
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task CanCreateTable()
        {
            // Arrange
            var context = GetDbContext();
            var controller = new TableController(context);

            var table = new Table
            {
                TableNumber = 10
            };

            // Act
            var result = await controller.CreateTable(table);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Table>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);

            var createdTable = Assert.IsType<Table>(createdResult.Value);

            Assert.Equal(10, createdTable.TableNumber);
        }

        [Fact]
        public async Task GetTablesReturnsTables()
        {
            // Arrange
            var context = GetDbContext();
            context.Tables.Add(new Table { TableNumber = 1 });
            context.Tables.Add(new Table { TableNumber = 2 });
            context.SaveChanges();

            var controller = new TableController(context);

            // Act
            var result = await controller.GetTables();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var tables = Assert.IsAssignableFrom<IEnumerable<Table>>(okResult.Value);

            Assert.Equal(2, tables.Count());
        }

        [Fact]
        public async Task GetTableReturnsSingleTable()
        {
            // Arrange
            var context = GetDbContext();
            context.Tables.Add(new Table { Id = 1, TableNumber = 5 });
            context.SaveChanges();

            var controller = new TableController(context);

            // Act
            var result = await controller.GetTable(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var table = Assert.IsType<Table>(okResult.Value);

            Assert.Equal(5, table.TableNumber);
        }

        [Fact]
        public async Task DeleteTableRemovesTable()
        {
            // Arrange
            var context = GetDbContext();
            context.Tables.Add(new Table { Id = 1, TableNumber = 3 });
            context.SaveChanges();

            var controller = new TableController(context);

            // Act
            var result = await controller.DeleteTable(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
            Assert.Empty(context.Tables);
        }
    }
}
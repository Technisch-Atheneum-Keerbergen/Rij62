// **********************************
//     *** Order Model Test  ***
// Author: Xavier Demaerel
// Date: 03/03/2026
// File: Rij26.Tests/models/OrderTest.cs
// **********************************

using Xunit;
using Rij62.Models;

namespace Rij62.Tests.Models
{
    public class OrderTests
    {
        [Fact]
        public void Order_Creation_Works()
        {
            // Arrange
            var pickupTime = DateTime.Now;

            // Act
            var order = new Order
            {
                Id = 1,
                TableId = 3,
                PickupTime = pickupTime,
                Status = "Open"
            };

            // Assert
            Assert.Equal(1, order.Id);
            Assert.Equal(3, order.TableId);
            Assert.Equal(pickupTime, order.PickupTime);
            Assert.Equal("Open", order.Status);
        }
    }
}


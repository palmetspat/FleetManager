namespace FleetManager.UnitTest
{
    using FleetManager.Logic;

    /// <summary>
    /// Contains unit tests for the <see cref="CargoVehicle"/> class.
    /// </summary>
    /// <remarks>
    /// This class is responsible for testing various functionalities of the <see cref="CargoVehicle"/> class,
    /// including revenue calculation, cargo weight capping, and total weight calculation.
    /// </remarks>
    [TestClass]
    public class CargoVehicleTests
    {
        /// <summary>
        /// Tests the <see cref="CargoVehicle.GetRevenue"/> method to ensure it calculates the revenue correctly.
        /// </summary>
        /// <remarks>
        /// This test verifies that given a valid cargo weight and rate, the revenue is calculated as expected.
        /// Specifically, it checks that for a cargo weight of 3000 and a rate of 50.0, the calculated revenue is 500.0.
        /// </remarks>
        /// <example>
        /// <code>
        /// var vehicle = new CargoVehicle("123456789X", 3000, 10, 50.0);
        /// var revenue = vehicle.GetRevenue();
        /// Assert.AreEqual(500.0, revenue);
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldCalculateRevenue_GivenValidCargoWeightAndRate()
        {
            // Arrange
            var vehicle = new CargoVehicle("123456789X", 3000, 10, 50.0);

            // Act
            var revenue = vehicle.GetRevenue();

            // Assert
            Assert.AreEqual(500.0, revenue);
        }

        /// <summary>
        /// Tests the behavior of the <see cref="CargoVehicle"/> class when the cargo weight exceeds the maximum limit.
        /// </summary>
        /// <remarks>
        /// This test verifies that the cargo weight is capped correctly when the excess cargo weight is provided.
        /// </remarks>
        /// <example>
        /// <code>
        /// var vehicle = new CargoVehicle("123456789X", 3000, 30, 50.0);
        /// var cargoWeight = vehicle.CargoWeight; // Expected to be capped at 20.0
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldCapCargoWeight_GivenExcessCargoWeight()
        {
            // Arrange
            var vehicle = new CargoVehicle("123456789X", 3000, 30, 50.0);

            // Act
            var cargoWeight = vehicle.CargoWeight;

            // Assert
            Assert.AreEqual(20.0, cargoWeight);
        }

        /// <summary>
        /// Tests the <see cref="CargoVehicle.GetTotalWeight"/> method to ensure it calculates the total weight
        /// correctly when given a cargo weight.
        /// </summary>
        /// <remarks>
        /// This test initializes a <see cref="CargoVehicle"/> with a specific cargo weight,
        /// then calls the <see cref="GetTotalWeight"/> method and asserts that the total weight
        /// is equal to the sum of the cargo weight and the weight of the cargo items.
        /// </remarks>
        /// <example>
        /// <code>
        /// var vehicle = new CargoVehicle("123456789X", 3000, 15, 50.0);
        /// var totalWeight = vehicle.GetTotalWeight();
        /// Assert.AreEqual(3000 +
        [TestMethod]
        public void ItShouldCalculateTotalWeight_GivenCargoWeight()
        {
            // Arrange
            var vehicle = new CargoVehicle("123456789X", 3000, 15, 50.0);

            // Act
            var totalWeight = vehicle.GetTotalWeight();

            // Assert
            Assert.AreEqual(3000 + 15 * 1_000, totalWeight);
        }

        // Add a useful test to the test
    }
}

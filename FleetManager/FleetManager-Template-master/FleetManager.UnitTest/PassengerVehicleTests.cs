namespace FleetManager.UnitTest
{
    using FleetManager.Logic;

    /// <summary>
    /// Contains unit tests for the <see cref="PassengerVehicle"/> class.
    /// </summary>
    /// <remarks>
    /// This class tests various functionalities of the <see cref="PassengerVehicle"/> class,
    /// including revenue calculation, passenger count capping, default passenger count assignment,
    /// and total weight calculation.
    /// </remarks>
    [TestClass]
    public class PassengerVehicleTests
    {
        /// <summary>
        /// Tests the <see cref="PassengerVehicle.GetRevenue"/> method to ensure it calculates the revenue correctly.
        /// </summary>
        /// <remarks>
        /// This test verifies that when a valid passenger count and ticket price are provided,
        /// the revenue is calculated as expected. The test uses a <see cref="PassengerVehicle"/>
        /// instance with a specific vehicle ID, passenger capacity, and ticket price.
        /// </remarks>
        /// <example>
        /// <code>
        /// var vehicle = new PassengerVehicle("123456789X", 2000, 30, 10.0);
        /// var revenue = vehicle.GetRevenue();
        /// Assert.AreEqual(300.0, revenue);
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldCalculateRevenue_GivenValidPassengerCountAndTicketPrice()
        {
            // Arrange
            var vehicle = new PassengerVehicle("123456789X", 2000, 30, 10.0);

            // Act
            var revenue = vehicle.GetRevenue();

            // Assert
            Assert.AreEqual(300.0, revenue);
        }

        /// <summary>
        /// Tests that the passenger count is capped when the number of passengers exceeds the maximum limit.
        /// </summary>
        /// <remarks>
        /// This test method arranges a PassengerVehicle instance with a specified maximum capacity,
        /// then asserts that the actual passenger count does not exceed the maximum allowed value.
        /// </remarks>
        /// <example>
        /// <code>
        /// var vehicle = new PassengerVehicle("123456789X", 2000, 60, 10.0);
        /// Assert.AreEqual(50, vehicle.PassengerCount);
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldCapPassengerCount_GivenExcessPassengerCount()
        {
            // Arrange
            var vehicle = new PassengerVehicle("123456789X", 2000, 60, 10.0);

            // Act
            var passengerCount = vehicle.PassengerCount;

            // Assert
            Assert.AreEqual(50, passengerCount);
        }

        /// <summary>
        /// Tests that the default passenger count is assigned correctly when no passenger count is specified.
        /// </summary>
        /// <remarks>
        /// This test initializes a <see cref="PassengerVehicle"/> with a specified VIN, weight, and ticket price,
        /// and then verifies that the default passenger count is set to 20.
        /// </remarks>
        /// <example>
        /// <code>
        /// var vehicle = new PassengerVehicle("123456789X", 2000, ticketPrice: 10.0);
        /// var passengerCount = vehicle.PassengerCount;
        /// Assert.AreEqual(20, passengerCount);
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldAssignDefaultPassengerCount_GivenNoPassengerCount()
        {
            // Arrange
            var vehicle = new PassengerVehicle("123456789X", 2000, ticketPrice: 10.0);

            // Act
            var passengerCount = vehicle.PassengerCount;

            // Assert
            Assert.AreEqual(20, passengerCount);
        }

        /// <summary>
        /// Tests the calculation of the total weight of a passenger vehicle based on its base weight and passenger count.
        /// </summary>
        /// <remarks>
        /// This test verifies that the total weight is correctly calculated by adding the base weight of the vehicle
        /// to the weight contributed by each passenger. The total weight is expected to be the sum of the base weight
        /// and the product of the number of passengers and the average weight per passenger (70 kg).
        /// </remarks>
        /// <exception cref="AssertFailedException">
        /// Thrown when the calculated total weight does not match the expected value.
        /// </exception>
        [TestMethod]
        public void ItShouldCalculateTotalWeight_GivenPassengerCount()
        {
            // Arrange
            var vehicle = new PassengerVehicle("123456789X", 2000, 30, 10.0);

            // Act
            var totalWeight = vehicle.GetTotalWeight();

            // Assert
            Assert.AreEqual(2000 + 30 * 70, totalWeight);
        }

        // Add a useful test to the test

    }
}

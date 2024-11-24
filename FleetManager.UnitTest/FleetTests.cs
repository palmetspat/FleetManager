namespace FleetManager.UnitTest
{
    using FleetManager.Logic;
    /// <summary>
    /// Contains unit tests for the <see cref="Fleet"/> class.
    /// </summary>
    /// <remarks>
    /// This class tests various functionalities of the <see cref="Fleet"/> class, including adding vehicles,
    /// calculating total fleet weight, retrieving the most profitable vehicle, and managing passenger counts
    /// in vehicles. Each test ensures that the fleet operates within its defined weight limits and behaves
    /// correctly when interacting with different vehicle types.
    /// </remarks>
    [TestClass]
    public class FleetTests
    {
        /// <summary>
        /// Tests the <see cref="Fleet.AddVehicle(PassengerVehicle)"/> method to ensure that it correctly adds a vehicle
        /// to the fleet when the total weight does not exceed the fleet's weight limit.
        /// </summary>
        /// <remarks>
        /// This test creates a fleet with a weight limit of 5000 and attempts to add a passenger vehicle
        /// with a weight of 2000. It asserts that the vehicle is successfully added and verifies that the
        /// fleet's vehicle count is updated accordingly.
        /// </remarks>
        /// <exception cref="System.Exception">Thrown if the vehicle cannot be added due to exceeding the weight limit.</exception>
        [TestMethod]
        public void ItShouldAddVehicle_GivenValidFleetWeightLimit()
        {
            // Arrange
            var fleet = new Fleet(5000);
            var vehicle = new PassengerVehicle("123456789X", 2000, 30, 10.0);

            // Act
            var result = fleet.AddVehicle(vehicle);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, fleet.Vehicles.Count);
        }

        /// <summary>
        /// Tests that a vehicle cannot be added to the fleet when the total weight
        /// exceeds the fleet's weight capacity.
        /// </summary>
        /// <remarks>
        /// This test verifies that when a <see cref="CargoVehicle"/> with a weight
        /// of 3000 is attempted to be added to a <see cref="Fleet"/> with a weight
        /// capacity of 4000, the addition fails, and the fleet remains empty.
        /// </remarks>
        /// <example>
        /// <code>
        /// var fleet = new Fleet(4000);
        /// var vehicle = new CargoVehicle("123456789X", 3000, 15, 50.0);
        /// var result = fleet.AddVehicle(vehicle);
        /// Assert.IsFalse(result);
        [TestMethod]
        public void ItShouldNotAddVehicle_GivenExcessFleetWeight()
        {
            // Arrange
            var fleet = new Fleet(4000);
            var vehicle = new CargoVehicle("123456789X", 3000, 15, 50.0);

            // Act
            var result = fleet.AddVehicle(vehicle);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, fleet.Vehicles.Count);
        }

        /// <summary>
        /// Tests the calculation of the total weight of a fleet containing multiple vehicles.
        /// </summary>
        /// <remarks>
        /// This test initializes a fleet with a specific total weight based on the sum of the weights of
        /// its vehicles. It adds a passenger vehicle and a cargo vehicle to the fleet, then calculates
        /// the total weight of the fleet and asserts that it matches the expected value.
        /// </remarks>
        /// <example>
        /// <code>
        /// Fleet fleet = new Fleet(2000 + 30 * 70 + 3000 + 10 * 1_000);
        /// fleet.AddVehicle(new PassengerVehicle("123456789X", 2000, 30, 10.0));
        /// fleet.AddVehicle(new CargoVehicle
        [TestMethod]
        public void ItShouldCalculateTotalFleetWeight_GivenMultipleVehicles()
        {
            // Arrange
            var fleet = new Fleet(2000 + 30 * 70 + 3000 + 10 * 1_000);
            fleet.AddVehicle(new PassengerVehicle("123456789X", 2000, 30, 10.0));
            fleet.AddVehicle(new CargoVehicle("987654321X", 3000, 10, 50.0));

            // Act
            var totalWeight = fleet.GetFleetWeight();

            // Assert
            Assert.AreEqual(2000 + 30 * 70 + 3000 + 10 * 1_000, totalWeight);
        }

        /// <summary>
        /// Tests the <see cref="Fleet.GetMostProfitableVehicle"/> method to ensure it returns the most profitable vehicle
        /// when multiple vehicles are present in the fleet.
        /// </summary>
        /// <remarks>
        /// This test initializes a <see cref="Fleet"/> with two vehicles: a <see cref="PassengerVehicle"/> and a
        /// <see cref="CargoVehicle"/>. It verifies that the <see cref="GetMostProfitableVehicle"/> method correctly
        /// identifies the <see cref="CargoVehicle"/> as the most profitable based on their revenue calculations.
        /// </remarks>
        /// <exception cref="AssertFailedException">Thrown when the expected vehicle does not match the actual result.</exception>
        [TestMethod]
        public void ItShouldReturnMostProfitableVehicle_GivenMultipleVehicles()
        {
            // Arrange
            var fleet = new Fleet(2000 + 30 * 70 + 3000 + 10 * 1000);
            var vehicle1 = new PassengerVehicle("123456789X", 2000, 30, 10.0); // Revenue = 300
            var vehicle2 = new CargoVehicle("987654321X", 3000, 10, 50.0);    // Revenue = 500

            fleet.AddVehicle(vehicle1);
            fleet.AddVehicle(vehicle2);

            // Act
            var mostProfitable = fleet.GetMostProfitableVehicle();

            // Assert
            Assert.AreEqual(vehicle2, mostProfitable);
        }

        /// <summary>
        /// Tests the <see cref="Fleet.AddPassengersToVehicle(string, int)"/> method to ensure it correctly adds passengers
        /// to a vehicle when provided with a valid vehicle ID.
        /// </summary>
        /// <remarks>
        /// This test method sets up a <see cref="Fleet"/> with a specified capacity, adds a <see cref="PassengerVehicle"/>
        /// to the fleet, and then attempts to add a specified number of passengers to that vehicle. It asserts that the
        /// operation is successful and verifies that the passenger count is updated correctly.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the vehicle ID is null or empty.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the vehicle is
        [TestMethod]
        public void ItShouldAddPassengersToVehicle_GivenValidVehicleID()
        {
            // Arrange
            var fleet = new Fleet(10_000);
            var vehicle = new PassengerVehicle("123456789X", 2000, 30, 10.0);
            fleet.AddVehicle(vehicle);

            // Act
            var result = fleet.AddPassengersToVehicle("123456789X", 10);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(40, vehicle.PassengerCount);
        }

        /// <summary>
        /// Tests that the method <see cref="Fleet.AddPassengersToVehicle"/> does not add passengers
        /// when provided with an invalid vehicle ID.
        /// </summary>
        /// <remarks>
        /// This test method initializes a fleet with a single passenger vehicle. It then attempts to
        /// add passengers to a vehicle using an invalid vehicle ID. The expected outcome is that
        /// the operation should fail, returning <c>false</c>.
        /// </remarks>
        /// <example>
        /// <code>
        /// var fleet = new Fleet(10_000);
        /// fleet.AddVehicle(new PassengerVehicle("123456789X", 2000, 30, 10.0));
        /// var result = fleet.AddPassengersToVehicle("INVALID_ID", 10);
        [TestMethod]
        public void ItShouldNotAddPassengers_GivenInvalidVehicleID()
        {
            // Arrange
            var fleet = new Fleet(10_000);
            fleet.AddVehicle(new PassengerVehicle("123456789X", 2000, 30, 10.0));

            // Act
            var result = fleet.AddPassengersToVehicle("INVALID_ID", 10);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

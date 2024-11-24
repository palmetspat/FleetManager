namespace FleetManager.UnitTest
{
    using FleetManager.Logic;

    /// <summary>
    /// Contains unit tests for validating vehicle identification numbers (VINs).
    /// This class tests various scenarios to ensure that the <see cref="Vehicle.CheckId(string)"/> method
    /// correctly identifies valid and invalid vehicle IDs based on specified criteria.
    /// </summary>
    /// <remarks>
    /// The tests cover cases including valid IDs with different check digits, invalid IDs with incorrect check digits,
    /// IDs with invalid lengths, non-alphanumeric characters, and edge cases such as empty or null IDs.
    /// </remarks>
    [TestClass]
    public class VehicleIdValidationTests
    {
        /// <summary>
        /// Tests the <see cref="Vehicle.CheckId(string)"/> method to verify that it returns true
        /// when a valid ID with a numeric check digit of 8 is provided.
        /// </summary>
        /// <remarks>
        /// This test case uses the ID "3446193138", which has a check digit of 8.
        /// The test ensures that the method correctly identifies this ID as valid.
        /// </remarks>
        /// <example>
        /// <code>
        /// var id = "3446193138"; // Prüfziffer: 8
        /// var isValid = Vehicle.CheckId(id);
        /// Assert.IsTrue(isValid);
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldReturnTrue_GivenValidIdWithNumericCheckDigit8()
        {
            // Arrange
            var id = "3446193138"; // Prüfziffer: 8

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// Tests the <see cref="Vehicle.CheckId(string)"/> method to verify that it returns true
        /// when a valid ID with a numeric check digit of 6 is provided.
        /// </summary>
        /// <remarks>
        /// This test case uses the ID "0747551006", which has a check digit of 6.
        /// The test is designed to confirm that the method correctly identifies
        /// this ID as valid.
        /// </remarks>
        /// <example>
        /// <code>
        /// var id = "0747551006"; // Prüfziffer: 6
        /// var isValid = Vehicle.CheckId(id);
        /// Assert.IsTrue(isValid);
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldReturnTrue_GivenValidIdWithNumericCheckDigit6()
        {
            // Arrange
            var id = "0747551006"; // Prüfziffer: 6

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// Tests the <see cref="Vehicle.CheckId(string)"/> method to verify that it returns true
        /// when provided with a valid ID that has a numeric check digit of 2.
        /// </summary>
        /// <remarks>
        /// This test case uses the ID "1572314222", where the check digit is expected to be valid.
        /// </remarks>
        /// <example>
        /// <code>
        /// var id = "1572314222"; // Prüfziffer: 2
        /// var isValid = Vehicle.CheckId(id);
        /// Assert.IsTrue(isValid);
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldReturnTrue_GivenValidIdWithNumericCheckDigit2()
        {
            // Arrange
            var id = "1572314222"; // Prüfziffer: 2

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// Tests the <see cref="Vehicle.CheckId(string)"/> method to verify that it returns true
        /// when provided with a valid vehicle ID that has a check digit of 'X'.
        /// </summary>
        /// <remarks>
        /// The test uses the vehicle ID "349913599X", which is expected to be valid according to the
        /// specified check digit validation rules.
        /// </remarks>
        /// <example>
        /// <code>
        /// ItShouldReturnTrue_GivenValidIdWithCheckDigitX();
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldReturnTrue_GivenValidIdWithCheckDigitX()
        {
            // Arrange
            var id = "349913599X"; // Prüfziffer: X

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// Tests the <see cref="Vehicle.CheckId(string)"/> method to ensure it returns false
        /// when the provided ID has an incorrect check digit.
        /// </summary>
        /// <remarks>
        /// This test method uses a sample ID "3499135995", which is known to have an incorrect
        /// check digit. The expected outcome is that the method should return false.
        /// </remarks>
        /// <example>
        /// <code>
        /// var id = "3499135995"; // Prüfziffer ist falsch
        /// var isValid = Vehicle.CheckId(id);
        /// Assert.IsFalse(isValid);
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldReturnFalse_GivenIdWithIncorrectCheckDigit()
        {
            // Arrange
            var id = "3499135995"; // Prüfziffer ist falsch

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests the <see cref="Vehicle.CheckId(string)"/> method to ensure it returns false
        /// when the provided ID has an invalid length (less than 10 characters).
        /// </summary>
        /// <remarks>
        /// This test method sets up an ID with a length of 5 characters, which is
        /// considered invalid according to the business rules. The method then checks
        /// if <see cref="Vehicle.CheckId(string)"/> correctly identifies the ID as invalid.
        /// </remarks>
        /// <example>
        /// <code>
        /// var id = "12345"; // Less than 10 characters
        /// var isValid = Vehicle.CheckId(id); // Expected: false
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldReturnFalse_GivenIdWithInvalidLength()
        {
            // Arrange
            var id = "12345"; // Weniger als 10 Zeichen

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests the <see cref="Vehicle.CheckId(string)"/> method to ensure it returns false
        /// when the provided ID contains non-alphanumeric characters.
        /// </summary>
        /// <remarks>
        /// This test case uses an ID that includes invalid characters ('!', '@') to verify that
        /// the method correctly identifies it as invalid.
        /// </remarks>
        /// <param name="id">The ID string to be validated, which in this case contains non-alphanumeric characters.</param>
        /// <returns>Returns false, indicating that the ID is not valid.</returns>
        [TestMethod]
        public void ItShouldReturnFalse_GivenIdWithNonAlphanumericCharacters()
        {
            // Arrange
            var id = "34991!@599"; // Enthält ungültige Zeichen

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests the <see cref="Vehicle.CheckId(string)"/> method to ensure it returns false
        /// when the provided ID contains no digits.
        /// </summary>
        /// <remarks>
        /// This test case verifies that the method correctly identifies an invalid ID format
        /// when the ID consists entirely of alphabetic characters.
        /// </remarks>
        /// <param name="id">The ID to be checked, which in this case is "ABCDEFGHIJ".</param>
        /// <returns>Returns false if the ID does not contain any digits.</returns>
        [TestMethod]
        public void ItShouldReturnFalse_GivenIdWithNoDigits()
        {
            // Arrange
            var id = "ABCDEFGHIJ"; // Keine Ziffern enthalten

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests that the <see cref="Vehicle.CheckId(string)"/> method returns false when the provided ID contains no letters.
        /// </summary>
        /// <remarks>
        /// This test verifies that an ID consisting solely of numeric characters is considered invalid.
        /// </remarks>
        /// <param name="id">A string representing the ID to be checked, which in this case contains only digits.</param>
        /// <returns>Returns false if the ID does not contain any letters.</returns>
        [TestMethod]
        public void ItShouldReturnFalse_GivenIdWithNoLetters()
        {
            // Arrange
            var id = "1234567890"; // Keine Buchstaben enthalten

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests the <see cref="Vehicle.CheckId(string)"/> method to ensure it returns false
        /// when an empty string is provided as the ID.
        /// </summary>
        /// <remarks>
        /// This test case verifies that the method correctly identifies an empty ID as invalid.
        /// </remarks>
        /// <example>
        /// <code>
        /// var id = ""; // Empty string
        /// var isValid = Vehicle.CheckId(id); // Expected result: false
        /// </code>
        /// </example>
        [TestMethod]
        public void ItShouldReturnFalse_GivenEmptyId()
        {
            // Arrange
            var id = ""; // Leerer String

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// Tests the <see cref="Vehicle.CheckId(string)"/> method to ensure it returns false when the provided ID is null.
        /// </summary>
        /// <remarks>
        /// This test method sets up a null value for the ID and verifies that the method correctly identifies it as invalid.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if the method does not handle null IDs correctly.</exception>
        [TestMethod]
        public void ItShouldReturnFalse_GivenNullId()
        {
            // Arrange
            string id = null; // Null-Wert

            // Act
            var isValid = Vehicle.CheckId(id);

            // Assert
            Assert.IsFalse(isValid);
        }

        // Add a useful test to the test

    }
}

namespace WarehouseApp.Tests
{
    public class BoxTests
    {
        [Fact]
        public void Box_ProductionDate_CalculatesExpirationDateCorrectly()
        {
            // Arrange
            DateTime productionDate = new DateTime(2025, 1, 1);
            DateTime expectedExpirationDate = productionDate.AddDays(100);

            // Act
            Box box = new Box(10, 10, 10, 1, productionDate: productionDate);

            // Assert
            Assert.Equal(expectedExpirationDate, box.ExpirationDate);
        }

        [Fact]
        public void Box_ExpirationDate_SetsExpirationDateCorrectly()
        {
            // Arrange
            DateTime expirationDate = new DateTime(2025, 12, 31);

            // Act
            Box box = new Box(10, 10, 10, 1, expirationDate: expirationDate);

            // Assert
            Assert.Equal(expirationDate, box.ExpirationDate);
        }

        [Fact]
        public void Box_NoDates_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Box(10, 10, 10, 1));
        }

        [Fact]
        public void Box_Volume_CalculatesCorrectly()
        {
            // Arrange
            Box box = new Box(2, 3, 4, 1, expirationDate: DateTime.Now);

            // Act
            double volume = box.Volume;

            // Assert
            Assert.Equal(2 * 3 * 4, volume);
        }
    }
}
namespace WarehouseApp.Tests
{
    public class PalletTests
    {
        [Fact]
        public void Pallet_InitialWeight_Is30Kg()
        {
            // Arrange & Act
            Pallet pallet = new Pallet(100, 100, 100);

            // Assert
            Assert.Equal(30, pallet.Weight);
        }

        [Fact]
        public void Pallet_AddBox_IncreasesWeightAndVolume()
        {
            // Arrange
            Pallet pallet = new Pallet(100, 100, 100);
            Box box1 = new Box(10, 10, 10, 5, expirationDate: DateTime.Now);
            Box box2 = new Box(20, 20, 20, 10, expirationDate: DateTime.Now);

            // Act
            pallet.AddBox(box1);
            pallet.AddBox(box2);

            // Assert
            Assert.Equal(30 + 5 + 10, pallet.Weight);
            Assert.Equal(100 * 100 * 100 + (10 * 10 * 10) + (20 * 20 * 20), pallet.Volume);
        }

        [Fact]
        public void Pallet_AddBox_ThrowsExceptionIfBoxTooLarge()
        {
            // Arrange
            Pallet pallet = new Pallet(50, 50, 50);
            Box largeBox = new Box(60, 10, 10, 1, expirationDate: DateTime.Now);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => pallet.AddBox(largeBox));
        }

        [Fact]
        public void Pallet_ExpirationDate_IsMinOfBoxes()
        {
            // Arrange
            Pallet pallet = new Pallet(100, 100, 100);
            Box box1 = new Box(10, 10, 10, 1, expirationDate: new DateTime(2025, 1, 1));
            Box box2 = new Box(10, 10, 10, 1, expirationDate: new DateTime(2024, 1, 1));

            // Act
            pallet.AddBox(box1);
            pallet.AddBox(box2);

            // Assert
            Assert.Equal(new DateTime(2024, 1, 1), pallet.ExpirationDate);
        }

        [Fact]
        public void Pallet_ExpirationDate_NoBoxes_IsMaxValue()
        {
            // Arrange & Act
            Pallet pallet = new Pallet(100, 100, 100);

            // Assert
            Assert.Equal(DateTime.MaxValue, pallet.ExpirationDate);
        }
    }
}
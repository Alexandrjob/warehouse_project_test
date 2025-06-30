using System;

namespace WarehouseApp
{
    public class Box : StorageItem
    {
        public DateTime ExpirationDate { get; private set; }

        public Box(double width, double height, double depth, double weight, DateTime? productionDate = null, DateTime? expirationDate = null)
            : base(width, height, depth, weight)
        {
            if (productionDate.HasValue)
            {
                ExpirationDate = productionDate.Value.AddDays(100);
            }
            else if (expirationDate.HasValue)
            {
                ExpirationDate = expirationDate.Value;
            }
            else
            {
                throw new ArgumentException("Either productionDate or expirationDate must be provided for a Box.");
            }
        }
    }
}
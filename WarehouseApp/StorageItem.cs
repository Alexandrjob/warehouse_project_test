namespace WarehouseApp
{
    public abstract class StorageItem
    {
        public Guid Id { get; }
        public double Width { get; protected set; }
        public double Height { get; protected set; }
        public double Depth { get; protected set; }
        public virtual double Weight { get; protected set; }

        public virtual double Volume => Width * Height * Depth;

        protected StorageItem(double width, double height, double depth, double weight)
        {
            Id = Guid.NewGuid();
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
        }
    }
}
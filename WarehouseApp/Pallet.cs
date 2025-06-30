namespace WarehouseApp
{
    public class Pallet : StorageItem
    {
        private readonly List<Box> _boxes;

        public IReadOnlyCollection<Box> Boxes => _boxes.AsReadOnly();

        public DateTime ExpirationDate => _boxes.Any() ? _boxes.Min(b => b.ExpirationDate) : DateTime.MaxValue;

        public override double Weight => base.Weight + _boxes.Sum(b => b.Weight);

        public override double Volume => base.Volume + _boxes.Sum(b => b.Volume);

        public Pallet(double width, double height, double depth)
            : base(width, height, depth, 30)
        {
            _boxes = new List<Box>();
        }

        public void AddBox(Box box)
        {
            if (box.Width > Width || box.Depth > Depth)
            {
                throw new ArgumentException("Box dimensions exceed pallet dimensions (width or depth).");
            }
            _boxes.Add(box);
        }
    }
}
namespace OnlineStrore.Logic.Queries.Product.GetProduct
{
    public class ProductVm
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public uint CountOfProduct {  get; set; }
        public string Characteristics { get; set; }

        public string ProductTypeName { get; set; }
    }
}

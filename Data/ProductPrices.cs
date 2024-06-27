public static class ProductPrices {
    public static readonly Dictionary<ProductType, double> Prices = new Dictionary<ProductType, double>
        {
            { ProductType.Tomato, 0.75 },
            { ProductType.Aubergine, 0.90 },
            { ProductType.Carrot, 1.00 }
        };
}
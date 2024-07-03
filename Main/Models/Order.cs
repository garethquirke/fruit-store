public class Order {
    public int Quantity { get; set; }
    public virtual double Subtotal { get; set; }
}

public class VegetableOrder : Order {
    public VegetableType VegetableType { get; set; }
    private readonly PriceList _priceList;

    public VegetableOrder(VegetableType vegetableType, int quantity, PriceList priceList)
    {
        VegetableType = vegetableType;
        Quantity = quantity;
        _priceList = priceList;
    }

    public override double Subtotal => Quantity * GetVegetablePrice(VegetableType);

    private double GetVegetablePrice(VegetableType vegetableType)
    {
        var vegetablePrice = _priceList.Vegetables.FirstOrDefault(v => v.Type == vegetableType);
        if (vegetablePrice == null)
        {
            throw new ArgumentException("Unknown vegetable type");
        }
        return vegetablePrice.Price;
    }

}
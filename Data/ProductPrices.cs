public class Product
{
    public double Price { get; set; }
}

public class Vegetable : Product
{
    public VegetableType Type { get; set; }
}

public class PriceList
{
    public List<Vegetable> Vegetables { get; set; } = new List<Vegetable>();

    public void SetVegetablePricesFromCsv(string csvFilePath)
    {
        Vegetables = File.ReadAllLines(csvFilePath)
                           .Skip(1)
                           .Select(x => x.Split(','))
                           .Select(x => new Vegetable
                           {
                               Type = (VegetableType)Enum.Parse(typeof(VegetableType), x[0], true),
                               Price = double.Parse(x[1])
                           }).ToList();
    }
}
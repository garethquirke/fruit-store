public interface IVegetableStore {
    Invoice HandleOrder(string csvFilePath);
    List<VegetableOrder> LoadOrderFromFile(string csvFilePath);
}

public class VegetableStore : IVegetableStore {
    public PriceList _priceList { get; set; }

    public VegetableStore(PriceList priceList)
    {
        _priceList = priceList;
    }
    public Invoice HandleOrder(string csvFilePath)
    {
        var vegetableOrder = LoadOrderFromFile(csvFilePath);
        return new Invoice(_priceList, vegetableOrder);
    }
    public List<VegetableOrder> LoadOrderFromFile(string csvFilePath)
    {
        try
        {
            string orderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", csvFilePath);
            return File.ReadAllLines(orderPath)
                           .Skip(1)
                           .Select(ParseOrder)
                           .ToList();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<VegetableOrder>();
    }


    private VegetableOrder ParseOrder(string line)
    {
        var parts = line.Split(',');
        var vegetableType = (VegetableType)Enum.Parse(typeof(VegetableType), parts[0], true);
        var quantity = int.Parse(parts[1]);

        return new VegetableOrder(vegetableType, quantity, _priceList);
    }

}
// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var priceList = new PriceList("PRODUCT_PRICES.csv");
            var VegetableStore = new VegetableStore(priceList);

            var invoice = VegetableStore.HandleOrder("ORDER_1.csv");
            invoice.Print();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
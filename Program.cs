// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        // Move this to VegetableStore class
        // Set PriceList
        // Set Order
        try
        {

            var priceList = new PriceList("PRODUCT_PRICES.csv");
            var VegetableStore = new VegetableStore() { PriceList = priceList, PriceDocument = "PRODUCT_PRICES.csv" };

            foreach (var item in priceList.Vegetables)
            {
                Console.WriteLine(item.Price + " " + item.Type);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }







    }
}
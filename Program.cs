// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string pricePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "PRODUCT_PRICES.csv");
            var priceList = new PriceList();
            priceList.SetVegetablePricesFromCsv(pricePath);

            foreach (var item in priceList.Vegetables)
            {
                Console.WriteLine(item.Price + " " + item.Type);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }






    }
}
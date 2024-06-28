public sealed class VegetableStore
{
    public required string PriceDocument { get; set; } = "";
    public required PriceList PriceList { get; set; }
    public List<VegetableOrder> OrderList { get; set; } = new List<VegetableOrder>();

    public void SetVegetableOrderFromCsv(string csvFilePath)
    {
        try
        {
            string orderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", csvFilePath);
            OrderList = File.ReadAllLines(orderPath)
                           .Skip(1)
                           .Select(x => x.Split(','))
                           .Select(x => new VegetableOrder
                           {
                               VegetableType = (VegetableType)Enum.Parse(typeof(VegetableType), x[0], true),
                               Quantity = int.Parse(x[1])
                           }).ToList();

            foreach (var item in OrderList)
            {
                Console.WriteLine(item.VegetableType + " " + item.Quantity);
            }
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


        public void PrintInvoice() {
            
        }
}
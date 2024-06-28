public class Invoice {
    public List<Order> Orders{ get; set; } = new List<Order>();

    public List<Offer> Offers{ get; set; } = new List<Offer>();

    // public double Subtotal => Orders.Sum(order => order.Subtotal);

    public double TotalDiscount => Offers.Sum(offer => offer.Discount);

    // public void AddOrder(VegetableType productType, int quantity) {
    //     double price = ProductPrices.Prices.ContainsKey(productType) ? quantity * ProductPrices.Prices[productType] : 0.0;
    //     double subtotal = price * quantity;

    //     Orders.Add(new Order {
    //         ProductType = productType,
    //         Quantity = quantity,
    //         ItemPrice = price,
    //         Subtotal = subtotal // ApplyOffers(productType, quantity, price, subtotal)
    //     });
    // }

    public void PrintInvoice() {
        // string builder
        // based on the orders
        // create invoice
        // total discount 
        // add the free tomatoes for the aubergines purchased
    }

    // Buy 3 Aubergines and pay 2.
    // Get a free Aubergine for every 2 Tomatoes you buy.
    // For every 4€ spent on Tomatoes, we will deduct one euro from your final invoice.

    // private double ApplyOffers(VegetableType productType, int quantity, double itemPrice, double subtotal) {
    //     double discount = 0.0;
    //     double total = subtotal;

    //     switch (productType) {
    //         case ProductType.Tomato:
    //             discount = (int)(subtotal / 4);
    //             break;
    //         case ProductType.Aubergine:
    //         case ProductType.Carrot:
    //         default:
    //         return 1;
    //     }

    //     return total - discount;
    // }

}
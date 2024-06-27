public class Invoice {
    public List<Order> Orders{ get; set; } = new List<Order>();

    public double Total => Orders.Sum(order => order.Total);

    public void AddOrder(ProductType productType, int quantity) {
        double price = ProductPrices.Prices.ContainsKey(productType) ? quantity * ProductPrices.Prices[productType] : 0.0;
        double subtotal = price * quantity;

        Orders.Add(new Order {
            ProductType = productType,
            Quantity = quantity,
            ItemPrice = price,
            Total = ApplyOffers(productType, quantity, price, subtotal)
        });
    }

    // Buy 3 Aubergines and pay 2.
    // Get a free Aubergine for every 2 Tomatoes you buy.
    // For every 4€ spent on Tomatoes, we will deduct one euro from your final invoice.

    private double ApplyOffers(ProductType productType, int quantity, double itemPrice, double subtotal) {
        double discount = 0.0;
        double total = subtotal;

        switch (productType) {
            case ProductType.Tomato:
                discount = (int)(subtotal / 4);
                break;
            case ProductType.Aubergine:
            case ProductType.Carrot:
            default:
            return 1;
        }

        return total - discount;
    }

}
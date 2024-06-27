public class Order {
    public ProductType ProductType { get; set; }
    public double ItemPrice { get; set; }
    public int Quantity { get; set; }
    public double Total { get; set; }
}

// Product
// Name - enum
// Price - double

// Order
// Name
// Quantity
// Total

// Invoice
// List<Order>

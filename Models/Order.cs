public class Order {
    public VegetableType VegetableType { get; set; }
    public double ItemPrice { get; set; }
    public int Quantity { get; set; }
    public double Subtotal { get; set; }
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

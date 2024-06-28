public class Order {
    public int Quantity { get; set; }
}

public class VegetableOrder : Order {
    public VegetableType VegetableType { get; set; }
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

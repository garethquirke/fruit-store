using System.Text;

public class Invoice {
    public PriceList PriceList { get; set; }
    public List<VegetableOrder> CurrentOrder { get; set; }
    public double Subtotal { get { return CurrentOrder.Sum(o => o.Subtotal); } }
    public double TotalDiscount { get { return VegetableOffers.Sum(x => x.Discount); } }
    public double FinalAmount { get { return Subtotal - TotalDiscount; } }
    public List<VegetableOffer> VegetableOffers { get; set; }

    public Invoice(PriceList priceList, List<VegetableOrder> order) {
        PriceList = priceList;
        CurrentOrder = order;
        VegetableOffers = GetVegetableOffers();
     }

    public List<VegetableOffer> GetVegetableOffers()
    {
        var offers = new List<VegetableOffer>();

        foreach (var order in CurrentOrder)
        {
            var offer = ApplyOffer(order);
            if (offer != null)
            {
                offers.Add(offer);
            }
        }

        var freeItem = ApplyFreeItemOffer();

        if (freeItem != null)
        {
            offers.Add(freeItem);
        }

        return offers;
    }

    public VegetableOffer? ApplyOffer(VegetableOrder vegetableOrder)
    {
        double discount;
        string? discountMessage;

        switch (vegetableOrder.VegetableType)
        {
            case VegetableType.Tomato:
                var tomatoDiscountUnits = (int)(vegetableOrder.Subtotal / 4);
                if (tomatoDiscountUnits > 0)
                {
                    discount = tomatoDiscountUnits * 1;
                    discountMessage = $"For every 4€ spent on Tomatoes, save 1€ from your final invoice. Discount: {discount}€.";
                    return new VegetableOffer(vegetableOrder.VegetableType, discount, discountMessage);
                }
                break;
            case VegetableType.Aubergine:
                if (vegetableOrder.Quantity >= 3)
                {
                    var freeQuantity = vegetableOrder.Quantity / 3;
                    var auberginePrice = vegetableOrder.Subtotal / vegetableOrder.Quantity;
                    discount = freeQuantity * auberginePrice;
                    discountMessage = $"Buy 3 Aubergines and pay for 2. You have earned {freeQuantity} Aubergines for free. Saving €{discount}";
                    return new VegetableOffer(vegetableOrder.VegetableType, discount, discountMessage);
                }
                break;
            default:
                return null;
        }
        return null;
    }

    private VegetableOffer? ApplyFreeItemOffer()
    {
        var tomatoesOrdered = CurrentOrder.FirstOrDefault(x => x.VegetableType == VegetableType.Tomato);
        if (tomatoesOrdered != null && tomatoesOrdered.Quantity >= 2)
        {
            var auberginesOrdered = CurrentOrder.FirstOrDefault(x => x.VegetableType == VegetableType.Aubergine);
            var freeAubergines = (int)Math.Floor(tomatoesOrdered.Quantity / 3.0);
            var discount = PriceList.Vegetables.First(x => x.Type == VegetableType.Aubergine).Price * freeAubergines;

            if (auberginesOrdered != null)
            {
                auberginesOrdered.Quantity = auberginesOrdered.Quantity + freeAubergines;
            }
            else
            {
                CurrentOrder.Add(new VegetableOrder(VegetableType.Aubergine, freeAubergines, PriceList));
            }

            return new VegetableOffer(VegetableType.Aubergine, discount, "Get a free Aubergine for every 2 Tomatoes you buy. You have earned " + freeAubergines);
        }

        return null;
    }

    public void Print()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Vegetable Store Invoice:");
        sb.AppendLine(new string('*', 30));
        sb.AppendLine("Items:");
        sb.AppendLine(string.Format("{0, -15} {1, 10} {2, 10}", "Vegetable", "Quantity", "Subtotal"));

        foreach (var order in CurrentOrder)
        {
            sb.AppendLine(string.Format("{0, -15} {1, 10} {2, 10:C2}", order.VegetableType, order.Quantity, order.Subtotal));
        }

        sb.AppendLine("\nDiscount and Offers:");

        foreach (var offer in VegetableOffers)
        {
            sb.AppendLine(offer.PromotionName);
        }

        sb.AppendLine("\nSummary:");
        sb.AppendLine(new string('-', 30));
        sb.AppendLine(string.Format("{0, -20} {1, 10:C2}", "Subtotal:", Subtotal));
        sb.AppendLine(string.Format("{0, -20} {1, 10:C2}", "Total Discounts:", TotalDiscount));
        sb.AppendLine(string.Format("{0, -20} {1, 10:C2}", "Final Amount:", FinalAmount));

        Console.WriteLine(sb.ToString());
    }
}
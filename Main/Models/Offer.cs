public class Offer {
    public double Discount { get; set; }
    public string PromotionName { get; set; } = "";
}

public sealed class VegetableOffer : Offer {
    public VegetableType VegetableType { get; set; }

    public VegetableOffer(VegetableType vegetableType, double discount, string promotionName) {
        VegetableType = vegetableType;
        Discount = discount;
        PromotionName = promotionName;
    }
}

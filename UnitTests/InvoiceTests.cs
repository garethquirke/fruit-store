using System.Collections.Generic;
using Moq;
using Xunit;

public class InvoiceTests
{
    private PriceList _priceList;

    public InvoiceTests()
    {
        _priceList = new PriceList("");
        _priceList.Vegetables = new List<Vegetable> {
                    new Vegetable { Type = VegetableType.Tomato, Price = 0.75 },
                    new Vegetable { Type = VegetableType.Aubergine, Price = 0.9 },
                    new Vegetable { Type = VegetableType.Carrot, Price = 1.0 }
        };
    }

    [Fact]
    public void TestTotalDiscount()
    {
        var offers = new List<VegetableOffer>
            {
                new VegetableOffer(VegetableType.Tomato, 0.5, "Tomato Discount"),
                new VegetableOffer(VegetableType.Carrot, 1.0, "Carrot Discount")
            };
        var order = new List<VegetableOrder>
            {
                new VegetableOrder(VegetableType.Tomato, 3, _priceList),
                new VegetableOrder(VegetableType.Carrot, 4, _priceList)
            };

        var invoice = new Invoice(_priceList, order)
        {
            VegetableOffers = offers
        };

        Assert.Equal(0.5 + 1.0, invoice.TotalDiscount);
    }

    [Fact]
    public void TestFinalAmount()
    {
        var order = new List<VegetableOrder>
            {
                new VegetableOrder(VegetableType.Tomato, 3, _priceList),
                new VegetableOrder(VegetableType.Carrot, 4, _priceList)
            };

        var offers = new List<VegetableOffer>
            {
                new VegetableOffer(VegetableType.Tomato, 0.5, "Tomato Discount"),
                new VegetableOffer(VegetableType.Carrot, 1.0, "Carrot Discount")
            };

        var invoice = new Invoice(_priceList, order);

        Assert.Equal(6.25, invoice.FinalAmount);
    }
}

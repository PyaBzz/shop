namespace Unit;

public class OrderItem_
{
    private Mock<ProductConcept> productMocker = new Mock<ProductConcept>();

    private ProductConcept productMock => productMocker.Object;

    //[Fact]
    //public void Price_MultipliesUnitPriceByQuantity()
    //{
    //    var price = Randomiser.APrice;
    //    var quantity = Randomiser.AQuantity;
    //    productMocker.SetupGet(x => x.Price).Returns(price);
    //    var sut = new OrderItem(productMock, quantity, null);

    //    Assert.Equal(quantity * price, sut.Price, 8);
    //}
}

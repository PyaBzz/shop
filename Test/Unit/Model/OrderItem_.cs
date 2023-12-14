namespace Unit;

public class OrderItem_
{
    private Mock<ProductConcept> productMocker = new Mock<ProductConcept>();
    private ProductConcept product => productMocker.Object;
    private Mock<ProductRepoConcept> productRepoMocker = new();
    private ProductRepoConcept productRepo => productRepoMocker.Object;

    public OrderItem_()
    {
        productRepoMocker
            .Setup(x => x.Get(It.IsAny<int>()))
            .ReturnsAsync(product);
    }

    [Fact]
    public async Task Price_MultipliesUnitPriceByQuantityAsync()
    {
        var price = Randomiser.APrice;
        var quantity = Randomiser.AQuantity;
        productMocker
            .SetupGet(x => x.Price)
            .Returns(price);
        var sut = new OrderItem(It.IsAny<int>(), It.IsAny<int>(), quantity);
        var expected = quantity * price;
        Assert.Equal(expected, await sut.GetPrice(productRepo));
    }
}

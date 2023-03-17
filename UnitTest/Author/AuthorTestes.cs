// ReSharper disable HeapView.BoxingAllocation
namespace UnitTest.Author;

public class AuthorTestes
{
    [SetUp]
    public void SetUp() { }
    // MethodName_Scenario_ExpectedBehavior
    [Test]
    public void AveragePricePerBook_ShouldReturnZero_WhenBooksListIsEmpty()
    {
        // Arrange
        var author = new Domain.Entities.Author();

        // Act
        var result = author.AveragePricePerBook();

        // Assert
        Assert.That(result, Is.EqualTo(0.0));
    }

    [Test]
    [TestCase(10,20,30, 20)]
    [TestCase(20,10,30, 20)]
    [TestCase(10,10,10, 10)]
    [TestCase(30.4d, 20.8d, 25.6d, 25.6d)]
    public void AveragePricePerBook_ShouldReturnCorrectAveragePrice_WhenBooksListIsNotEmpty(double v1, double v2, double v3, double media)
    {
        // Arrange
        var author = new Domain.Entities.Author
        {
            Books = new List<Domain.Entities.Book>()
            {
                new() {Price = v1},
                new() {Price = v2},
                new() {Price = v3}
            }
        };

        // Act
        var result = author.AveragePricePerBook();

        // Assert
        Assert.That(result, Is.EqualTo(media).Within(0.001));
    }
}
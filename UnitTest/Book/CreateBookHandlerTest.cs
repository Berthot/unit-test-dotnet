using Application.UseCase.Book.Command.Create;
using Domain.Interfaces;
using Moq;
using UnitTestCommon.Extensions;

namespace UnitTest.Book;

public class CreateBookHandlerTest
{
    private CreateBookHandler _handler = null!;
    private readonly Mock<IBookRepository> _repository = new();

    [SetUp]
    public void ClassSetUp()
    {
        _handler = new CreateBookHandler(_repository.Object);
    }

    [Test]
    public async Task Create_ExecuteAsync_ReturnVoid()
    {
        // Arrange
        var command = new CreateBookCommand
        {
            Title = "Clean Code",
            Url = "www.amazon.com.br/clean-code",
            Price = 35.90,
            AuthorId = 1.ToGuid().ToString(),
            CategoryId = 1.ToGuid().ToString(),
        };
        _repository.Setup(x => x.CreateAsync(It.IsAny<Domain.Entities.Book>()));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
        });
    }
}
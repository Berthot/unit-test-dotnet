using Application.UseCase.Book.Command.Create;
using Infrastructure.Repositories;
using UnitTestCommon.Base;
using UnitTestCommon.Extensions;

namespace IntegrationTest.Book;

public class CreateBookHandlerTest : UnitTestBase
{
    private CreateBookHandler _handler = null!;
    private BookRepository _repository = null!;

    [SetUp]
    public void ClassSetUp()
    {
        _repository = new BookRepository(Context);
        _handler = new CreateBookHandler(_repository);
    }

    [Test]
    public async Task Create_Handle_CreatedSuccess()
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

        // Act
        var before = await _repository.GetAllAsync();
        var result = await _handler.Handle(command, CancellationToken.None);
        var after = await _repository.GetAllAsync();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(after, Has.Count.GreaterThan(before.Count));
        });
    }
}
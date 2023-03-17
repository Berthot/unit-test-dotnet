using Application.UseCase.Book.Command.Create;
using FluentValidation.TestHelper;

namespace UnitTest.Book;

public class CreateBookValidationTest
{
    private CreateBookCommandValidator _validator = null!;


    [SetUp]
    public void SetUp()
    {
        _validator = new CreateBookCommandValidator();
    }


    [Test]
    public void Validate_TitleLessThanFiveCharacters_ValidationError()
    {
        var command = new CreateBookCommand
        {
            Title = "1234",
            Url = "http://test.com",
            Price = 10.0,
            AuthorId = Guid.NewGuid().ToString(),
            CategoryId = Guid.NewGuid().ToString()
        };
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Test]
    public void Validate_UrlLessThanFiveCharacters_ValidationError()
    {
        var command = new CreateBookCommand
        {
            Title = "Test Book",
            Url = "1234",
            Price = 10.0,
            AuthorId = Guid.NewGuid().ToString(),
            CategoryId = Guid.NewGuid().ToString()
        };
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Url);
    }

    [Test]
    public void Validate_PriceEqualToZero_ValidationError()
    {
        var command = new CreateBookCommand
        {
            Title = "Test Book",
            Url = "http://test.com",
            Price = 0.0,
            AuthorId = Guid.NewGuid().ToString(),
            CategoryId = Guid.NewGuid().ToString()
        };
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Price);
    }
}
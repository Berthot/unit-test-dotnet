using MediatR;

namespace Application.UseCase.Book.Query.GetBookById;

public class GetBookByIdQuery : IRequest<GetBookResponse>
{
    public string Id { get; set; } = null!;
}
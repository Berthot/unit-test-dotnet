using MediatR;

namespace Application.UseCase.Book.Query.GetBookByName;

public class GetBookByNameQuery : IRequest<GetBookByNameResponse>
{
    public string Title { get; set; }
}
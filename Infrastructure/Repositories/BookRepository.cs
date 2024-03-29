using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(Context context) : base(context)
    {
    }
}
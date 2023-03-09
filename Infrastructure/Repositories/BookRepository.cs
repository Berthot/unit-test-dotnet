using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(DbContext context) : base(context)
    {
    }
}
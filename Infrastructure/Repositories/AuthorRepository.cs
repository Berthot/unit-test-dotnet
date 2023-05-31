using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    private readonly Context _context;

    public AuthorRepository(Context context) : base(context)
    {
        _context = context;
    }
    
    public async Task<Author> GetAuthorWithBooks(Guid id)
    {
        return (await _context.Authors
            .Include(x => x.Books)
            .FirstOrDefaultAsync(x => x.Id == id))!;
    }
}
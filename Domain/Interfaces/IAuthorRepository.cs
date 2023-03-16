using Domain.Entities;
using Domain.Interfaces.Base;

namespace Domain.Interfaces;

public interface IAuthorRepository : IRepository<Author>
{
    Task<Author> GetAuthorWithBooks(Guid id);
}
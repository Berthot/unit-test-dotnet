using Domain.Entities;
using Domain.Models;

namespace Domain.Mapping;

public static class MapCategory
{
    public static CategoryDto CategoryMap(this Category category)
    {
        return new CategoryDto
        {
            Name = category.Name
        };
    }

    public static Category CategoryMap(this CategoryDto category)
    {
        return new Category
        {
            Name = category.Name,
        };
    }
}
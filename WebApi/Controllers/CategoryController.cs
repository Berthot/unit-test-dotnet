using Application.UseCase.Category.Command.Create;
using Microsoft.AspNetCore.Mvc;
using WebApi.Base;

namespace WebApi.Controllers;

public class CategoryController : ApiControllerBase
{
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryCreated))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<CategoryCreated> Create([FromBody] CreateCategoryCommand command, CancellationToken cToken)
    {
        return await Mediator.Send(command, cToken);
    }
}
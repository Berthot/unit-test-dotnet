using Application.UseCase.Category.Command.Create;
using Application.UseCase.Category.Command.Delete;
using Application.UseCase.Category.Query.GetCategories;
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
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDeleted))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<CategoryDeleted> Delete([FromRoute] string id, CancellationToken cToken)
    {
        var command = new DeleteCategoryCommand() {Id = id};
        return await Mediator.Send(command, cToken);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoriesResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<GetCategoriesResponse> GetAll(CancellationToken cToken)
    {
        var command = new GetCategoriesQuery();
        return await Mediator.Send(command, cToken);
    }
}
using FIAP.Application.InputModels;
using FIAP.Application.Interfaces;
using FIAP.Domain.Entities.Enums;
using FIAP.Domain.Entities.Store;
using FIAP.Infrastructure.CrossCutting.Extensions;
using FIAP.Presentation.API.Base;

using Microsoft.AspNetCore.Mvc;

namespace FIAP.Presentation.API.Controllers;

[Route("[controller]")]
public class ProductsController : DbControllerBase
{
    private readonly IProductUseCases _useCases;
    public ProductsController(IProductUseCases useCases)
    {
        _useCases = useCases;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductModel model)
    {
        if (model == default)
            return BadRequest("Invalid parameters");

        var category = (Category)EnumExtensions.GetFromAlternateValue(model.Category, typeof(Category));
        if (category == default)
            return BadRequest("Invalid category product");

        await _useCases.CreateProductAsync(new Products(
            id: null,
            name: model.Name,
            description: model.Description,
            price: model.Price,
            quantity: model.Quantity,
            category: category,
            timeToPrepareMinutes: model.TimeToPrepareMinutes
        ));

        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(
        [FromRoute] long id,
        [FromBody] UpdateProductModel model
    )
    {
        if (model == default || model.Id != id)
            return BadRequest("Invalid parameters");

        var category = (Category)EnumExtensions.GetFromAlternateValue(model.Category, typeof(Category));
        if (category == default)
            return BadRequest("Invalid category product");

        return Ok(
            await _useCases.UpdateProductAsync(new Products(
                id: model.Id,
                name: model.Name,
                description: model.Description,
                price: model.Price,
                quantity: model.Quantity,
                category: category,
                timeToPrepareMinutes: model.TimeToPrepareMinutes
            ))
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] long id)
    {
        await _useCases.DeleteProductAsync(id);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetProduct([FromQuery] string category)
    {
        if (category.IsEmpty())
            return Ok(await _useCases.FindProductsAsync());

        var findCategory = (Category)EnumExtensions.GetFromAlternateValue(category, typeof(Category));
        if (findCategory == default)
            return BadRequest("Invalid order status");

        return Ok(await _useCases.FindProductsByCategoryAsync(findCategory));
    }
}
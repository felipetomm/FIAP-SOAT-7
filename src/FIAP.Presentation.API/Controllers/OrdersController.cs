using AutoMapper;

using FIAP.Application.InputModels;
using FIAP.Application.Interfaces;
using FIAP.Domain.Entities.Enums;
using FIAP.Presentation.API.Base;
using FIAP.Infrastructure.CrossCutting.Extensions;

using Microsoft.AspNetCore.Mvc;

namespace FIAP.Presentation.API.Controllers;

[Route("[controller]")]
public class OrdersController : DbControllerBase
{
    private readonly IOrderUseCases _useCases;
    private readonly IMapper _mapper;

    public OrdersController(
        IOrderUseCases useCases,
        IMapper mapper
    )
    {
        _useCases = useCases;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderModel model)
    {
        if (model == default)
            return BadRequest("Invalid params sent to controller");

        var createDto = _mapper.Map<CreateOrderDto>(model);

        await _useCases.CreateAsync(createDto);
        return Created();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder([FromRoute] long id)
    {
        return Ok(await _useCases.FindOrderAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(
        [FromRoute] long id,
        [FromBody] UpdateOrderModel model
    )
    {
        if (model == default || model.Id != id)
            return BadRequest("Invalid params sent to controller");

        var status = (OrderStatus)EnumExtensions.GetFromAlternateValue(model.Status, typeof(OrderStatus));
        if (status == default)
            return BadRequest("Invalid order status");

        return Ok(await _useCases.UpdateOrderAsync(new UpdateOrderDto
        {
            Id = id,
            Status = status
        }));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders([FromQuery] string status)
    {
        if (status.IsEmpty())
            return Ok(await _useCases.FindAllOrdersAsync());

        var findStatus = (OrderStatus)EnumExtensions.GetFromAlternateValue(status, typeof(OrderStatus));
        if (findStatus == default)
            return BadRequest("Invalid order status");

        return Ok(await _useCases.FindOrderByStatusAsync(findStatus));
    }
}
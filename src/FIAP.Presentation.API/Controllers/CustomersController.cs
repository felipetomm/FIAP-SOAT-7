using FIAP.Application.InputModels;
using FIAP.Application.Interfaces;
using FIAP.Domain.Entities.Store;
using FIAP.Presentation.API.Base;

using Microsoft.AspNetCore.Mvc;

namespace FIAP.Presentation.API.Controllers;

[Route("[controller]")]
public class CustomersController : DbControllerBase
{
    private readonly ICustomerUseCases _useCases;
    public CustomersController(ICustomerUseCases useCases)
    {
        _useCases = useCases;
    }

    /// <summary>
    /// Create a new customer
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerModel model)
    {
        await _useCases.CreateCustomerAsync(
            new Customers(
                id: null,
                name: model.Name,
                cpf: model.Cpf,
                email: model.Email,
                phone: model.Phone
            )
        );

        return Created();
    }

    /// <summary>
    /// Return customer by brazilian CPF
    /// </summary>
    /// <param name="cpf"></param>
    /// <returns></returns>
    [HttpGet("GetCustomerByCpf")]
    public async Task<IActionResult> GetCustomerByCpf([FromQuery] string cpf)
    {
        return Ok(await _useCases.FindByCpfAsync(cpf));
    }
}
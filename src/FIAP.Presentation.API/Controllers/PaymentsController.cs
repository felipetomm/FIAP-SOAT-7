using FIAP.Application.InputModels;
using FIAP.Application.Interfaces;
using FIAP.Presentation.API.Base;

using Microsoft.AspNetCore.Mvc;

namespace FIAP.Presentation.API.Controllers;

[Route("[controller]")]
public class PaymentsController : DbControllerBase
{
    private readonly IPaymentUseCases _useCases;
    public PaymentsController(IPaymentUseCases useCases)
    {
        _useCases = useCases;
    }

    [HttpGet("CheckPayment/{id}")]
    public async Task<IActionResult> CheckPayment([FromRoute] long id)
    {
        return Ok(await _useCases.CheckPaymentAsync(id));
    }

    [HttpPost("SyncPayment")]
    public async Task<IActionResult> SyncPayment([FromBody] SyncPaymentByGatewayModel model)
    {
        if (model == default)
            return BadRequest("Invalid data sent to controller");

        return Ok(await _useCases.SyncPaymentByGatewayAsync(model));
    }

}
using FIAP.Presentation.API.Base;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FIAP.Presentation.API.Controllers;

[Route("/")]
public class HelloController : BaseController
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Burguer Store - FIAP/SOAT7 - Felipe Tomm");
    }
}
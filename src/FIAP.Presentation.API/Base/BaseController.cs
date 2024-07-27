using Microsoft.AspNetCore.Mvc;

namespace FIAP.Presentation.API.Base;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected BaseController() { }
}
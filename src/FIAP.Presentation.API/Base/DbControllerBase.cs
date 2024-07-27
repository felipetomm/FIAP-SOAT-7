using FIAP.Presentation.API.Filters;

namespace FIAP.Presentation.API.Base;

[TransactionDb]
public abstract class DbControllerBase : BaseController
{
    protected DbControllerBase() { }
}
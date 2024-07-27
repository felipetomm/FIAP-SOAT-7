using FIAP.Infrastructure.CrossCutting.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FIAP.Presentation.API.Filters;

public class TransactionDbAttribute : TypeFilterAttribute
{
    public TransactionDbAttribute() : base(typeof(TransactionDbFilter)) { }

    public class TransactionDbFilter : IActionFilter
    {
        private readonly IUnitOfWork _uow;

        public TransactionDbFilter(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _uow.BeginTransaction();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
                Task.Run(async () => await _uow.CommitTransactionAsync()).Wait();
            else
                Task.Run(async () => await _uow.RollBackTransactionAsync()).Wait();
        }
    }
}
using GoodHealth.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHealth.CroosCuttimg.Ioc
{
    public interface IValidationResultBuilder
    {
        ValidationResultModel<TResult> Build<TResult>(TResult result);
        ValidationResultModel<Exception> Build(Exception ex);
        Task<ValidationResultModel<Exception>> BuildAsync(Exception ex);
        Task<ValidationResultModel<TResult>> BuildAsync<TResult>(TResult result);
    }
}

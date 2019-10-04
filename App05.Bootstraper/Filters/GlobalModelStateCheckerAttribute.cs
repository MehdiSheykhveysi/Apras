using System.Collections.Generic;
using System.Linq;
using App03.AppService.Communication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App05.Bootstraper.Filtes
{
    public class GlobalMvcValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is BadRequestResult badRequestResult)
            {
                ApiResponse ApiBadRequestRsponse = new ApiResponse(null, EStatusCode.BadRequest);

                context.Result = new JsonResult(ApiBadRequestRsponse) { StatusCode = badRequestResult.StatusCode };
            }
            else if (context.Result is BadRequestObjectResult badRequestObjectResult)
            {
                string RequestErrorMessage = null;

                if (badRequestObjectResult.Value is ValidationProblemDetails validationProblem)
                {
                    RequestErrorMessage = string.Join('|', validationProblem.Errors.SelectMany(c => (string[])c.Value).Distinct());
                }
                else if (badRequestObjectResult.Value is string)
                {
                    RequestErrorMessage = badRequestObjectResult.Value.ToString();
                }
                ApiResponse ApiBadRequestRsponse = new ApiResponse(RequestErrorMessage, EStatusCode.BadRequest);

                context.Result = new JsonResult(ApiBadRequestRsponse) { StatusCode = badRequestObjectResult.StatusCode };
            }
            base.OnResultExecuting(context);
        }
    }
}

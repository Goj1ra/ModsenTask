using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ModsenTask.Business.Models;
using System.Text.Json;

namespace ModsenTask.API.Attributes
{
    public class ValidateViewModelStareAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Any())
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToArray();

                var response = ApiResult<string>.Failure(errors);

                context.Result = new JsonResult(JsonSerializer.Serialize(response))
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}

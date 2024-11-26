using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;
using System.Net;

namespace E_Commerce.API.Factories
{
    public class ApiResponseFactory
    {
        public static IActionResult CustomeValidationErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.Where(error => error.Value.Errors.Any())
                .Select(error => new ValidationErrore
                {
                    Field = error.Key,
                    Errors = error.Value.Errors.Select(e=>e.ErrorMessage)
                });
            var response = new ValidationErrorResponse
            {
                StatusCod = (int)HttpStatusCode.BadRequest,
                ErrorMessage = "Validation Faild",
                Errors = errors
            };
            return new BadRequestObjectResult(response);
        }
    }
}

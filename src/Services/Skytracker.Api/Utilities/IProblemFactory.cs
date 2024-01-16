using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Skytracker.Api.Utilities;

public interface IProblemFactory
{
    IActionResult CreateProblemResult(IEnumerable<Error> errors);
}

public class ProblemFactory : IProblemFactory
{
    private readonly ProblemDetailsFactory _problemDetailsFactory;
    private readonly IHttpContextAccessor _httpContext;

    public ProblemFactory(ProblemDetailsFactory problemDetailsFactory, IHttpContextAccessor httpContext)
    {
        _problemDetailsFactory = problemDetailsFactory;
        _httpContext = httpContext;
    }

    public IActionResult CreateProblemResult(IEnumerable<Error> errors)
    {
        var modelState = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelState.AddModelError(error.Code, error.Description);
        }

        var detail = _problemDetailsFactory.CreateValidationProblemDetails(
            _httpContext.HttpContext!, modelState, StatusCodes.Status400BadRequest);

        return new BadRequestObjectResult(detail);
    }
}
using Melad.CleanArchitecture.Application;

namespace Melad.CleanArchitecture.WebApi.Controllers.v1;
/// <summary>
/// </summary>
[ApiVersion("1")]
public class HomeController:BaseController
{
    private readonly IMediator _mediator;

    /// <summary>
    /// </summary>
    /// <param name="mediator"></param>
    public HomeController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
       await _mediator.Send(new UpdateTodoItemCommand
        {
            Title = "Melad"
        });
       return "";
    }
}

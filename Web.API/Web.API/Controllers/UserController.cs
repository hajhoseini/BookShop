using Core.Commands.UserCommands;
using Core.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly IMediator mediator;

	public UserController(IMediator mediator)
	{
		this.mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetListUsers([FromBody] GetListUsersQuery query)
	{
		var result = await mediator.Send(query);
		return Ok(new { Data = result });
	}

	[HttpGet]
	public async Task<IActionResult> GetUserById([FromBody] GetUserQuery query)
	{
		var result = await mediator.Send(query);
		return Ok(new { Data = result });
	}

	[HttpPost]
	public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
	{
		var result = await mediator.Send(command);
		return Ok(new { Data = result });
	}

	[HttpPut]
	public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
	{
		var result = await mediator.Send(command);
		return Ok(new { Data = result });
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand command)
	{
		var result = await mediator.Send(command);
		return Ok(new { Data = result });
	}
}

﻿using MediatR;

namespace Core.Commands.UserCommands;

public class UpdateUserCommand : IRequest<bool>
{
	public Guid Guid { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }
	public string NationalCode { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string Password { get; set; }
}

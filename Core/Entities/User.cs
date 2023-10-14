using Core.Common;

namespace Core.Entities;

public class User : BaseEntity
{
	public string Name { get; set; }
	public string LastName { get; set; }
	public string NationalCode { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string Password { get; set; }	
}

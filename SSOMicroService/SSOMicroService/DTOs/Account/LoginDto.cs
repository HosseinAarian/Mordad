using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SSOMicroService.DTOs.Account;

public class LoginDto
{
	[Display(Name = "Email")]
	[Required(ErrorMessage = "Enter Email")]
	public string Email { get; set; }

	[Display(Name = "Password")]
	[Required(ErrorMessage = "Enter Password")]
	public string Password { get; set; }
}

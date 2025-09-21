using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SSOMicroService.DTOs.Account;

namespace SSOMicroService.Pages.Account;

public class LoginModel : PageModel
{
	[BindProperty]
	public LoginDto InputModel { get; set; }
	public void OnGet()
	{
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (!ModelState.IsValid)
			return Page();

		return Page();
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class RegisterModel : PageModel
{
    public class RegisterInput
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Compare("pass")]
        public string ConfirmPassword { get; set; }

        [Range(18, 100)]
        public int? Age { get; set; }
    }

    [BindProperty]
    public RegisterInput Input { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        TempData["SuccessMsg"] = $"Користувач {Input.Name} зареєстрований";
        return RedirectToPage("Success");
    }
}



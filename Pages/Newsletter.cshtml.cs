using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class NewsletterModel : PageModel
{
    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        TempData["SuccessMsg"] = $"Підписка оформлена: {Email}";
        return RedirectToPage("Success");
    }
}



using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class ContactModel : PageModel
{
    public class ContactInput
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Message { get; set; }
    }

    private static readonly List<ContactInput> Saved = new List<ContactInput>();

    [BindProperty]
    public ContactInput Input { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        Saved.Add(Input);
        return RedirectToPage("ThankYou");
    }
}



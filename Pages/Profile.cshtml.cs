using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class ProfileModel : PageModel
{
    public class ProfileInput
    {
        [Required(ErrorMessage = "Ім'я обов'язкове")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ім'я має бути від 2 до 50 символів")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email обов'язковий")]
        [EmailAddress(ErrorMessage = "Неправильний формат email")]
        public string Email { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Опис не може перевищувати 200 символів")]
        public string Description { get; set; } = string.Empty;
    }

    [BindProperty]
    public ProfileInput Input { get; set; } = new();

    public void OnGet()
    {
        Input = new ProfileInput
        {
            Name = "Олександр Шалаєв",
            Email = "ivan@example.com",
            Description = "студент"
        };
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        TempData["SuccessMessage"] = "Профіль успішно збережено!";
        return RedirectToPage("/Profile");
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chef_Helper_Web.Pages
{
    public class addrecptModel : PageModel
    {
        private readonly ILogger<addrecptModel> _logger;

        public addrecptModel(ILogger<addrecptModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
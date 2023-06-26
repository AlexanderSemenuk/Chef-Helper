using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chef_Helper_Web.Pages
{
    public class Warehouse : PageModel
    {
        private readonly ILogger<Warehouse> _logger;

        public Warehouse(ILogger<Warehouse> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
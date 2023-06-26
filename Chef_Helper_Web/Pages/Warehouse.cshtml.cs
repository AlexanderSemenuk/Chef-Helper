using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chef_Helper_Web.Pages
{
    public class WarehouseModel : PageModel
    {
        private readonly ILogger<WarehouseModel> _logger;

        public WarehouseModel(ILogger<WarehouseModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
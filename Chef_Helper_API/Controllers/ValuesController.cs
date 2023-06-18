using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Chef_Helper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ChefdbContext _dbContext;

        public ValuesController(ChefdbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

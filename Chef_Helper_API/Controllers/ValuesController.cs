using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Chef_Helper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController<T> : ControllerBase where T : class
    {
        public readonly ChefdbContext _dbContext;

        public ValuesController(ChefdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _dbContext.Set<T>().ToList();
            return Ok(entities);
        }

        // GET: api/Generic/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST: api/Generic
        [HttpPost]
        public IActionResult Post(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Generic/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, T entity)
        {
            var existingEntity = _dbContext.Set<T>().Find(id);
            if (existingEntity == null)
            {
                return NotFound();
            }
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/Generic/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

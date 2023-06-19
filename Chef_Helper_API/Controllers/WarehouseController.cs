using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Chef_Helper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        public readonly ChefdbContext _dbContext;

        public WarehouseController(ChefdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/Warehouse
        [HttpGet("/Warehouse")]
        public IActionResult Get()
        {
            var warehouses = _dbContext.Warehouse.ToList();
            return Ok(warehouses);
        }

        // GET: api/Warehouse/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var warehouse = _dbContext.Warehouse.Find(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }

        // POST: api/Warehouse
        [HttpPost]
        public IActionResult Post(Warehouse warehouse)
        {
            _dbContext.Warehouse.Add(warehouse);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Warehouse/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Warehouse updatedWarehouse)
        {
            var warehouseToUpdate = _dbContext.Warehouse.Find(id);
            if (warehouseToUpdate == null)
            {
                return NotFound();
            }

            warehouseToUpdate.BoxNumber = updatedWarehouse.BoxNumber;
            warehouseToUpdate.IngredientName = updatedWarehouse.IngredientName;
            warehouseToUpdate.WarehouseQuantity = updatedWarehouse.WarehouseQuantity;

            _dbContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/Warehouse/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var warehouseToDelete = _dbContext.Warehouse.Find(id);
            if (warehouseToDelete == null)
            {
                return NotFound();
            }

            _dbContext.Warehouse.Remove(warehouseToDelete);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}

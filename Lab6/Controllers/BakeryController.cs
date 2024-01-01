using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab6.Models;

namespace Lab6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BakeryController : ControllerBase
    {
        private readonly UsersContext _context;

        public BakeryController(UsersContext context)
        {
            _context = context;
        }

        // GET: api/Bakery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BakeryProduct>>> GetBakeryProducts()
        {
            return await _context.BakeryProducts.ToListAsync();
        }

        // GET: api/Bakery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BakeryProduct>> GetBakeryProduct(int id)
        {
            var bakeryProduct = await _context.BakeryProducts.FindAsync(id);

            if (bakeryProduct == null)
            {
                return NotFound();
            }

            return bakeryProduct;
        }

        // POST: api/Bakery
        [HttpPost]
        public async Task<ActionResult<BakeryProduct>> PostBakeryProduct(BakeryProduct bakeryProduct)
        {
            _context.BakeryProducts.Add(bakeryProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBakeryProduct", new { id = bakeryProduct.BakeryProductId }, bakeryProduct);
        }


        // PUT: api/Bakery/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBakeryProduct(int id, BakeryProduct bakeryProduct)
        {
            if (id != bakeryProduct.BakeryProductId)
            {
                return BadRequest();
            }

            _context.Entry(bakeryProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BakeryProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Bakery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBakeryProduct(int id)
        {
            var bakeryProduct = await _context.BakeryProducts.FindAsync(id);
            if (bakeryProduct == null)
            {
                return NotFound();
            }

            _context.BakeryProducts.Remove(bakeryProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BakeryProductExists(int id)
        {
            return _context.BakeryProducts.Any(e => e.BakeryProductId == id);
        }

    }
}

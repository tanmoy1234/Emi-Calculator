using EmiAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class PolicyController : ControllerBase
    {
        private readonly PolicyContext _dbContext;
        public PolicyController(PolicyContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicy()
        {
            if (_dbContext.DbSet == null)
            {
                return NotFound();
            }
            return await _dbContext.DbSet.ToListAsync();   
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            if(_dbContext.DbSet == null)
            {
                return NotFound();
            }
            var policy = await _dbContext.DbSet.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }
            return policy;
        }

        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(Policy policies)
        {
            _dbContext.DbSet.Add(policies);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPolicy),new {id = policies.Id}, policies);
        }

    }
}

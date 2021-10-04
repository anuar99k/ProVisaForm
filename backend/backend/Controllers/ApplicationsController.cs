using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.DB;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationsContext _dbContext;
        public ApplicationsController(ApplicationsContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        //{
        //    return await _dbContext.Applications.ToListAsync();
        //}

        //// GET: api/Applications/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Application>> GetApplication(int id)
        //{
        //    var application = await _dbContext.Applications.FindAsync(id);

        //    if (application == null)
        //        return NotFound();

        //    return application;
        //}

        // PUT: api/Applications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutApplication(int id, Application application)
        //{
        //    if (id != application.Id)
        //        return BadRequest();

        //    _dbContext.Entry(application).State = EntityState.Modified;

        //    try
        //    {
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ApplicationExists(id))
        //            return NotFound();
        //        else
        //            throw;
        //    }

        //    return NoContent();
        //}

        // POST: api/Applications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
            _dbContext.Applications.Add(application);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetApplication", new { id = application.Id }, application);
        }

        // DELETE: api/Applications/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteApplication(int id)
        //{
        //    var application = await _dbContext.Applications.FindAsync(id);

        //    if (application == null)
        //        return NotFound();

        //    _dbContext.Applications.Remove(application);
        //    await _dbContext.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ApplicationExists(int id)
        {
            return _dbContext.Applications.Any(e => e.Id == id);
        }
    }
}

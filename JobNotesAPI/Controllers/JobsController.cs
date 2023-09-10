using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobNotesAPI.Data;
using JobNotesAPI.Models;

namespace JobNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobsDbContext _db;

        public JobsController(JobsDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _db.Jobs
                .Where( x => x.IsRemoved == false)
                .ToListAsync();
            return Ok(jobs);
        }
        [HttpGet]
        [Route("get-removed-jobs")]
        public async Task<IActionResult> GetAllRemovedJobs()
        {
            var jobs = await _db.Jobs
                .Where(x => x.IsRemoved == true)
                .OrderByDescending(x => x.RemovedDate)
                .ToListAsync();
            return Ok(jobs);
        }
        [HttpPost]
        public async Task<IActionResult> AddJobs(JobInfo jobs)
        {
            jobs.Id = Guid.NewGuid();
            _db.Jobs.Add(jobs);
            await _db.SaveChangesAsync();
            return Ok(jobs);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateJobs([FromRoute] Guid id, JobInfo JobsUpdate)
        {
            var jobs = await _db.Jobs.FindAsync(id);
            if (jobs == null)
            {
                return NotFound();
            }

            jobs.Searched = JobsUpdate.Searched;
            jobs.SearchedDate = DateTime.Now; 
            await _db.SaveChangesAsync();
            return Ok(jobs);
        }
        [HttpPut]
        [Route("restore-removed-job/{id:Guid}")]
        public async Task<IActionResult> RestoreRemovedJobs([FromRoute] Guid id, JobInfo restoreRemovedJobs)
        {
            var jobs = await _db.Jobs.FindAsync(id);

            if (jobs == null)
            {
                return NotFound();
            }

            jobs.IsRemoved = false;
            jobs.RemovedDate = null;
            await _db.SaveChangesAsync();
            return Ok(jobs);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteJobs([FromRoute] Guid id)
        {
            var jobs = await _db.Jobs.FindAsync(id);
            if (jobs == null)
            {
                return NotFound();
            }
            jobs.IsRemoved = true;
            jobs.RemovedDate = DateTime.Now;
            await _db.SaveChangesAsync();
            return Ok(jobs);
        }
        [HttpDelete]
        [Route("perm-delete/{id:Guid}")]
        public async Task<IActionResult> PermDeleteJobs([FromRoute] Guid id)
        {
            var jobs = await _db.Jobs.FindAsync(id);
            if (jobs == null)
            {
                return NotFound();
            }
            _db.Jobs.Remove(jobs);
            await _db.SaveChangesAsync();
            return Ok(jobs);
        }
        [HttpGet]
        [Route("get-searched-jobs")]
        public async Task<IActionResult> GetAllSearchedJobs()
        {
            var jobs = await _db.Jobs
                .Where(x => x.Searched == true)
                .OrderByDescending(x => x.Searched)
                .ToListAsync();
            return Ok(jobs);
        }
    }
}

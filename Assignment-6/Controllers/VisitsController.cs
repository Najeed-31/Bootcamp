using System;

/// <summary>
/// Summary description for Class1
/// </summary>
using Microsoft.AspNetCore.Mvc;
using Assignment_6.DTO;
using Assignment_6.Services;
using Assignment_6.Repositories;
using Microsoft.AspNetCore.Authorization;
namespace Assignment_6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitRepository _repo;
        public VisitsController(IVisitRepository repo) { _repo = repo; }

        [HttpPost("add")]
        [Authorize(Policy = "RequireReceptionistOrAdmin")]
        public async Task<IActionResult> Add([FromBody] AddVisitRequest req)
        {
            try
            {
                await _repo.AddVisitAsync(req);
                return Created("", new { message = "Visit added." });
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpPut("update")]
        [Authorize(Policy = "RequireDoctorOrAdmin")]
        public async Task<IActionResult> Update([FromBody] UpdateVisitRequest req)
        {
            try
            {
                await _repo.UpdateVisitAsync(req);
                return Ok(new { message = "Visit updated." });
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpDelete("delete")]
        [Authorize(Policy = "RequireReceptionistOrAdmin")]
        public async Task<IActionResult> Delete([FromBody] DeleteVisitRequest req)
        {
            try
            {
                await _repo.DeleteVisitAsync(req);
                return Ok(new { message = "Visit deleted." });
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpGet("by-patient")]
        [Authorize(Policy = "RequireAny")]
        public async Task<IActionResult> ByPatient([FromQuery] string name)
        {
            try
            {
                var list = await _repo.SearchByPatientAsync(name);
                return Ok(list);
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpGet("by-doctor")]
        [Authorize(Policy = "RequireAny")]
        public async Task<IActionResult> ByDoctor([FromQuery] string name)
        {
            try
            {
                var list = await _repo.SearchByDoctorAsync(name);
                return Ok(list);
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpGet("by-type")]
        [Authorize(Policy = "RequireAny")]
        public async Task<IActionResult> ByType([FromQuery] string type)
        {
            try
            {
                var list = await _repo.SearchByVisitTypeAsync(type);
                return Ok(list);
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }
    }
}
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
using Microsoft.AspNetCore.Mvc;
using Assignment_6.DTO;
using Assignment_6.Services;

namespace Assignment_6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth) { _auth = auth; }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            try
            {
                // Force all new users to be Guests regardless of passed RoleID
                var id = await _auth.RegisterAsync(req.Username, req.Password, 4);

                // After successful registration, authenticate and issue token
                var token = await _auth.AuthenticateAsync(req.Username, req.Password);

                return Ok(new { UserID = id, token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var token = await _auth.AuthenticateAsync(req.Username, req.Password);
            if (token == null) return Unauthorized(new { message = "Invalid credentials" });
            return Ok(new { token });
        }
    }
}
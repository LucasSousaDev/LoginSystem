using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LoginSystem.Models;
using LoginSystem.Services;
using LoginSystem.DTO;

namespace LoginSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IUserService userService,
            IJwtService jwtService,
            ILogger<AuthController> logger)
        {
            _userService = userService;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var existingUser = await _userService.GetUserByUsername(request.Username);
                if (existingUser != null)
                {
                    return BadRequest(new { message = "Ops! Parece que esse nome de usuário já está sendo usado 😅" });
                }

                var user = new User
                {
                    Username = request.Username,
                    Email = request.Email
                };

                await _userService.CreateUser(user, request.Password);
                var token = _jwtService.GenerateToken(user);

                return Ok(new { 
                    message = "Parabéns! Você foi registrado com sucesso! 🎉",
                    token,
                    user = new { 
                        username = user.Username,
                        email = user.Email
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Deu ruim no registro 😢");
                return StatusCode(500, new { message = "Ops! Algo deu errado. Tente novamente mais tarde!" });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _userService.GetUserByEmail(request.Email);
                if (user == null)
                {
                    return BadRequest(new { message = "Eita! Não encontrei esse usuário 🤔" });
                }

                var authenticatedUser = await _userService.AuthenticateUser(user.Username, request.Password);
                if (authenticatedUser == null)
                {
                    return BadRequest(new { message = "Ops! Senha incorreta 😅" });
                }

                var token = _jwtService.GenerateToken(authenticatedUser);
                return Ok(new { 
                    message = "Bem-vindo de volta! 👋",
                    token,
                    user = new { 
                        username = authenticatedUser.Username,
                        email = authenticatedUser.Email
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Deu ruim no login 😢");
                return StatusCode(500, new { message = "Ops! Algo deu errado. Tente novamente mais tarde!" });
            }
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            // Como estamos usando JWT, não precisamos fazer nada no servidor
            // O cliente só precisa remover o token do localStorage
            return Ok(new { message = "Até logo! 👋" });
        }
    }
} 
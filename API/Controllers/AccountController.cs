using System.Security.Claims;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly TokenService _tokenService;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
		{
			_tokenService = tokenService;
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
		{
			var user = await _userManager.Users
				.Include(p => p.Photo)
				.FirstOrDefaultAsync(x => x.Email == loginDTO.Email);
			if (user == null) return Unauthorized();

			var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

			if (result.Succeeded)
			{
				return CreateUserObject(user);
			}
			return Unauthorized();
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
		{
			if (await _userManager.Users.AnyAsync(x => x.Email == registerDTO.Email))
			{
				ModelState.AddModelError("email", "Email taken");
				return ValidationProblem(ModelState);
			}

			if (await _userManager.Users.AnyAsync(x => x.UserName == registerDTO.Username))
			{
				ModelState.AddModelError("username", "Username taken");
				return ValidationProblem(ModelState);
			}

			var user = new AppUser
			{
				FullName = registerDTO.FullName,
				Email = registerDTO.Email,
				UserName = registerDTO.Username,
				Photo = default
			};

			var result = await _userManager.CreateAsync(user, registerDTO.Password);

			if (result.Succeeded)
			{
				return CreateUserObject(user);
			}

			return BadRequest("Problem registering user");
		}

		[Authorize]
		[HttpGet]
		public async Task<ActionResult<UserDTO>> GetCurrentUser()
		{
			var user = await _userManager.Users.Include(p => p.Photo)
				.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));
			return CreateUserObject(user!);
		}

		[Authorize("isGlobalAdmin")]
		[HttpGet("isGlobalAdmin")]
		public ActionResult<bool> UserIsGlobalAdmin()
		{
			return Ok(true);
		}

		[Authorize("isLocalAdmin")]
		[HttpGet("isLocalAdmin/{higherEducationFacilityId}")]
		public ActionResult<bool> UserIsLocalAdmin()
		{
			return Ok(true);
		}

		private UserDTO CreateUserObject(AppUser user)
		{
			if (user == null) return null;
			return new UserDTO
			{
				FullName = user.FullName,
				Image = user.Photo != null ? user.Photo.Url : "",
				Token = _tokenService.CreateToken(user),
				Username = user.UserName
			};
		}
	}
}
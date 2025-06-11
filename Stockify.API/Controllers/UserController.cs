using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stockify.API.Dto;
using Stockify.API.Helpers;
using Stockify.Objects;

namespace Stockify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtHelper _jwtHelper;
        //TODO:: Ability to register a user 
        //TODO:: ability to sign in a user (obtain a token)

        public UserController(UserManager<ApplicationUser> userManager, JwtHelper jwtHelper)
        {
            _userManager = userManager;
            _jwtHelper = jwtHelper;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(UserDto userDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _userManager.CreateAsync(new IdentityUser()
        //    {
        //        UserName = userDto.UserName,
        //        Email = userDto.Email,

        //    }, userDto.Password);

        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }

        //    userDto.Password = "";

        //    return Ok("User created");
        //    //return CreatedAtAction("GetUser", new {username = userDto.UserName},userDto);
        //}
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthDto authDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(authDto.UserName);

            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, authDto.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Invalid credentials");
            }

            var token = _jwtHelper.CreateToken(user);

            //generate JWT TOKEN
            return Ok(token);

        }

    }

}


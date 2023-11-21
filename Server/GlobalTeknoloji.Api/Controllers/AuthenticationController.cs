using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using GlobalTeknoloji.Domain.Models.user;
using GlobalTeknoloji.Application.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using GlobalTeknoloji.Application.Contracts.IServices;

namespace GlobalTeknoloji.Api.Controllers;

[Route("authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    IConfiguration _configuration;
    IUserService _userService;

    public AuthenticationController(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [Route("authenticate")]
    public ActionResult<string> Authenticate(AuthenticationRequestBody authenticattionRequestBody)
    {
        var user = _userService.ValidateUserCredentials(authenticattionRequestBody.UserName, authenticattionRequestBody.Password);
        if (user == null) return Unauthorized();

        if (user == null)
        {
            return Unauthorized();
        }

        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:secretForKey"]));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>();
      
        var jwtSecurityToke = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claimsForToken,
            DateTime.Now,
            DateTime.Now.AddHours(1),
            signingCredentials
            );

        var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToke);
        return Ok(tokenToReturn);

    }





}

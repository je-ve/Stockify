﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Stockify.API.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Stockify.API.Helpers;

public class JwtHelper
{
    private const int EXPIRATION_MINUTES = 5;

    private readonly IConfiguration _configuration;
    public JwtHelper(IConfiguration configuration)
    {

        _configuration = configuration;
    }

    public AuthResDto CreateToken(IdentityUser user)
    {
        var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);

        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            expiration
        );


        var tokenHandler = new JwtSecurityTokenHandler();


        return new AuthResDto
        {
            Token = tokenHandler.WriteToken(token),
            Expiration = expiration
        };
    }
    private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) => new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: expiration,
            signingCredentials: credentials
        );

    private Claim[] CreateClaims(IdentityUser user)
    {
        var nowUtc = DateTime.UtcNow;
        var unixTimeSeconds = new DateTimeOffset(nowUtc).ToUnixTimeSeconds();
        return new[]
        {
           new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
           new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
           new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString()),
           new Claim(ClaimTypes.NameIdentifier, user.Id),
           new Claim(ClaimTypes.Name, user.UserName),
           new Claim(ClaimTypes.Email, user.Email),
        };
    }
    private SigningCredentials CreateSigningCredentials() => new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256);

}

﻿using CSProject.Auth.Interfaces;
using CSProject.Auth.Models;
using CSProject.Auth.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CSProject.Auth.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        private AuthenticationSettings _auth;
        public TokenGenerator(IOptions<AuthenticationSettings> authSettings)
        {
            _auth = authSettings.Value;
        }
        public string GenerateToken(UserInfo userInfo)
        {
            string secret = _auth.Secret;

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, $"{userInfo.Username}{userInfo.JobTitle}"),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToUniversalTime().ToString(),
                    ClaimValueTypes.Integer64),
                new Claim("Username", userInfo.Username),
                new Claim("JobTitle", userInfo.JobTitle)
            };

            var jwt = new JwtSecurityToken(
                issuer: _auth.Issuer,
                audience: _auth.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(600),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}

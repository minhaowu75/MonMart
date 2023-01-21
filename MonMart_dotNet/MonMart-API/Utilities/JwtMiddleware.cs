﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MonMart.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MonMart.Utilities
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate requestDelegate, IOptions<AppSettings> appSettings)
        {
            _requestDelegate = requestDelegate;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                AttachUserToContext(context, userService, token);
            }

            await _requestDelegate(context);
        }

        private void AttachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                context.Items["UserModel"] = userService.GetByUserId(userId);
            }

            catch
            {

            }
        }
    }
}

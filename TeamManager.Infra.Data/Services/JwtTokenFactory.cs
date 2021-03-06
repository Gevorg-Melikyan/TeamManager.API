using TeamManager.Domain.Identity;
using TeamManager.Domain.Interfaces;
using TeamManager.Infra.Data.Identity.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TeamManager.Infra.Data.Services
{
    public class JwtTokenFactory : IJwtService
    {
        private readonly JwtIssuerOptions _jwtOptions;
        public JwtTokenFactory(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);
        }

        public async Task<string> GenerateEncodedToken(string id, string userName, IEnumerable<string> roles, IEnumerable<string> roleClaims = null)
        {
            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Sub, id),
                 new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            if (roleClaims != null)
            {
                foreach (var rolecClaime in roleClaims)
                {
                    claims.Add(new Claim(CustomClaimTypes.Permission, rolecClaime));
                }
            }

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                  issuer: _jwtOptions.Issuer,
                  audience: _jwtOptions.Audience,
                  claims: claims,
                  notBefore: _jwtOptions.NotBefore,
                  expires: _jwtOptions.Expiration,
                  signingCredentials: _jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() -
                               new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                              .TotalSeconds);

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
    }
}

using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductApi.Base;
using ProductApi.Data.Model;
using ProductApi.Data.Repository.Abstract;
using ProductApi.Data.Uow;
using ProductApi.Dto;
using ProductApi.Service.Abstract;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductApi.Service.Concrete
{
    public class TokenManagementService : ITokenManagementService
    {
        private readonly IGenericRepository<User> genericRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtConfig _jwtConfig;
        private readonly byte[] _secret;

        public TokenManagementService(IGenericRepository<User> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jwtConfig = jwtConfig.CurrentValue;
            _secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        }


        public async Task<BaseResponse<TokenResponse>> GenerateTokensAsync(TokenRequest tokenRequest, DateTime now, string userAgent)
        {
            try
            {
                var user = genericRepository.Where(x => x.Username == tokenRequest.UserName).FirstOrDefault();
                if (user is null)
                {
                    Log.Error("InvalidUserInformation");
                    return new BaseResponse<TokenResponse>("InvalidUserInformation");
                }

                if (user.Password != tokenRequest.Password)
                {
                    Log.Error("InvalidUserInformation");
                    return new BaseResponse<TokenResponse>("InvalidUserInformation");
                }

                var token = GenerateAccessToken(user, now);

                user.LastActivity = DateTime.Now;
                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.CompleteAsync();

                TokenResponse response = new TokenResponse
                {
                    AccessToken = token,
                    ExpireTime = now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                    Role = user.Role,
                    UserName = user.Username
                };

                return new BaseResponse<TokenResponse>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Token_Error");
                return new BaseResponse<TokenResponse>("Token_Error");
            }
        }

        private string GenerateAccessToken(User user, DateTime now)
        {
            // Get claim value
            Claim[] claims = GetClaim(user);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                _jwtConfig.Issuer,
                shouldAddAudienceClaim ? _jwtConfig.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private static Claim[] GetClaim(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("AccountId", user.Id.ToString()),
                new Claim("LastActivity", user.LastActivity.ToLongTimeString())
            };

            return claims;
        }

    }
}
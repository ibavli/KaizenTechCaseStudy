using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KaizenTechCaseStudy.Api.UIModels;
using KaizenTechCaseStudy.Api.UIModels.LoginModels;
using KaizenTechCaseStudy.Dal.Abstract.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KaizenTechCaseStudy.Api.Controllers.Login
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        //TODO Resource'dan çekilecek
        private readonly string _invalidMessage = "Lütfen girdiğiniz bilgileri kontrol edin";

        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public LoginController(IUserService userService,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginUIModel model)
        {
            #region Check if the model is valid.

            if (!ModelState.IsValid)
                return BadRequest(new { message = _invalidMessage });

            #endregion

            bool result = _userService.CheckUserByPassword(username: model.Username, password: model.Password);

            if (result)
            {
                var appSettingValue = _appSettings.Secret;
                var token = GenerateToken(username: model.Username, appSettings: appSettingValue);
                return Ok(new { token });
            }
            else
            {
                return NotFound();
            }
        }

        #region Utilities

        private string GenerateToken(string username, string appSettings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username.Trim())
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
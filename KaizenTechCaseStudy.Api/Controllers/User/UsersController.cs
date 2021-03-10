using KaizenTechCaseStudy.Api.UIModels.UserModels;
using KaizenTechCaseStudy.Dal.Abstract.UserService;
using KaizenTechCaseStudy.Entities.UserEntities;
using Microsoft.AspNetCore.Mvc;

namespace KaizenTechCaseStudy.Api.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        //TODO Resource'dan çekilecek
        private readonly string _invalidMessage = "Lütfen girdiğiniz bilgileri kontrol edin";

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpPost("addnewuser")]
        public IActionResult AddNewUser([FromBody]AddNewUserUIModel model)
        {
            #region Check if the model is valid.

            if (!ModelState.IsValid)
                return BadRequest(new { message = _invalidMessage });

            #endregion

            //TODO girilen mail veya username ile kullanıcı var mı yok mu kontrol et

            //TODO nugetten AutoMapper indirip, mapper işlemi yap
            Users user = new Users()
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Username = model.Username
            };

            //TODO nugetten AutoMapper indirip, mapper işlemi yap
            UserPassword userPassword = new UserPassword()
            {
                Password = model.Password
            };

            bool result = _userService.AddNewUser(user: user, userPassword: userPassword);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("deleteuser")]
        public IActionResult DeleteUser([FromBody]DeleteUserUIModel model)
        {
            #region Check if the model is valid.

            if (!ModelState.IsValid)
                return BadRequest(new { message = _invalidMessage });

            #endregion

            bool result = _userService.DeleteUser(userId: model.UserId);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("getuserbyid")]
        public IActionResult GetUserById([FromBody]GetUserByIdUIModel model)
        {
            #region Check if the model is valid.

            if (!ModelState.IsValid)
                return BadRequest(new { message = _invalidMessage });

            #endregion

            var user = _userService.GetUserById(userId: model.UserId);

            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpGet("getuserlist")]
        public IActionResult GetUserList()
        {
            var userList = _userService.GetUserList();

            if (userList != null)
                return Ok(userList);
            else
                return NotFound();
        }

        [HttpPost("updateuser")]
        public IActionResult UpdateUser([FromBody]UpdateUserUIModel model)
        {
            #region Check if the model is valid.

            if (!ModelState.IsValid)
                return BadRequest(new { message = _invalidMessage });

            #endregion

            //TODO girilen mail veya username ile kullanıcı var mı yok mu kontrol et

            //TODO nugetten AutoMapper indirip, mapper işlemi yap
            Users user = new Users()
            {
                Id = model.Id,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Username = model.Username
            };

            //TODO nugetten AutoMapper indirip, mapper işlemi yap
            UserPassword userPassword = new UserPassword()
            {
                Password = model.Password
            };

            bool result = _userService.UpdateUser(user: user, userPassword: userPassword);

            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}
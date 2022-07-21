//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using WebAPI.Helpers;
//using WebAPI.IServices;
//using WebAPI.Models;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthenticationController : ControllerBase
//    {
//        private IUserService _userService;
//        private IMapper _mapper;
//        private readonly AppSettings _appSettings;

//        public AuthenticationController(
//            IUserService userService,
//            IMapper mapper,
//            IOptions<AppSettings> appSettings)
//        {
//            _userService = userService;
//            _mapper = mapper;
//            _appSettings = appSettings.Value;
//        }

//        [AllowAnonymous]
//        [HttpPost("authenticate")]
//        public IActionResult Authenticate(AuthenticateRequest model)
//        {
//            var response = _userService.Authenticate(model);

//            if (response == null)
//                return BadRequest(new { message = "Username or password is incorrect" });

//            return Ok(response);
//        }
//    }
//}

using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundooNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL; 
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost("Register")]
        public IActionResult Register(UserRegistrationModel userRegistration)
        {
            var result = userBL.Register(userRegistration);
            if(result != null)
            {
                return Ok(new { success = true, message = "Ragistrtion successfull", data = result });
            }
            else
            {
                return null;
            }
        }
        
    }
}

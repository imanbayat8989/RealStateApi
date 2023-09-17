using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealStateApi.DTO;
using RealStateApi.Services;

namespace RealStateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatServices _chatService;
        public ChatController(ChatServices chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("register-user")]
        public IActionResult RegisterUser(UserDTO model)
        {
            if (_chatService.AddUserToList(model.Name))
            {
                return NoContent();
            }

            return BadRequest("This name is taken please choose another name");
        }
    }
}

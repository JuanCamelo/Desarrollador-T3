using ApplicationT3.Service.Contract;
using ApplicationT3.Service.DTOs.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationT3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAsync()
        {
            try
            {
                var result = await _userApplicationService.GetUserAll();

                return new ObjectResult(result)
                {
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {

                return new ConflictObjectResult(ex) { StatusCode = 409};
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync([FromBody] UserModel model)
        {
            try
            {
                var result = await _userApplicationService.PostUserAsync(model);

                return new ObjectResult(result)
                {
                    StatusCode = 201
                };
            }
            catch (Exception ex)
            {

                return new ConflictObjectResult(ex) { StatusCode = 409 };
            }
        }

        [HttpPut("/api/User/{id}")]
        public async Task<IActionResult> PutUserAsync([FromBody] UserModel model, string id)
        {
            try
            {
                var result = await _userApplicationService.PutUserAsync(model, id);

                return new ObjectResult(result)
                {
                    StatusCode = 201
                };
            }
            catch (Exception ex)
            {

                return new ConflictObjectResult(ex) { StatusCode = 409 };
            }
        }

        [HttpDelete("/api/User/{id}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            try
            {
                var result = await _userApplicationService.DeleteUserAsync(id);

                return new ObjectResult(result)
                {
                    StatusCode = 201
                };
            }
            catch (Exception ex)
            {

                return new ConflictObjectResult(ex) { StatusCode = 409 };
            }
        }
    }
}

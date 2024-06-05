using FlowerShop.Models;
using FlowerShop.Service;
using Microsoft.AspNetCore.Mvc;



namespace FlowerShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private string connectionString = WebApplication.Create().Configuration.GetConnectionString("DefaultConnection");
        private UserService userService;

        public UserController()
        {
            this.userService = new UserService(connectionString);
        }


        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            List<String> users = new List<String>();
            try
            {
                users = await userService.GetUsers();


                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost(Name = "PostUser")]
        public async Task<IActionResult> PostUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            try
            {

                await userService.PostUser(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateUserByRole")]
        public async Task<IActionResult>  UpdateUserByRole(string oldRole, string newRole, User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            try
            {

                await userService.UpdateUserByRole(oldRole, newRole, user);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }
        [HttpDelete(Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {

                await userService.DeleteUser(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

       
    }






}















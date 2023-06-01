using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserWebAPI.Repository;
using UserWebAPI.ViewModels;

namespace UserWebAPI.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    public class UserController : Controller
    {
        private IUserRepositorry userRepositorry;
        public UserController(IUserRepositorry _userRepositorry)
        {
            userRepositorry = _userRepositorry;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="User"></param>
        /// <returns>added user id</returns>
        [HttpPost]
        [Route("/api/users")]
        public async Task<IActionResult> Users(tbUserViewModels User)
        {
            try
            {
                if (User != null)
                {

                    // validate the email is alrady in use.
                    if (User.StrEmail != null)
                    {
                        if (await userRepositorry.CheckUserExistByEmail(User.StrEmail))
                        {
                            ModelState.AddModelError("Email", "User email already in use");
                            return BadRequest(ModelState);
                        }
                    }
                    // validate the age of the user
                    if (User.DtDateOfBirth != null)
                    {
                        if ((DateTime.Now.Year - User.DtDateOfBirth.Year) < 18)
                        {
                            ModelState.AddModelError("Date of birth", "User is uder 18 years");
                            return BadRequest(ModelState);
                        }
                    }

                    var createdUser = await userRepositorry.AddUsers(User);

                    return Ok(createdUser);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all the users 
        /// </summary>
        /// <returns>User list</returns>
        [HttpGet]
        [Route ("/api/users")]

        public async Task<IActionResult> Users()
        {
            try
            {
                var _users = await userRepositorry.GetUsers();
                if (_users == null)
                {
                    ModelState.AddModelError("User", "Users not found");
                    return NotFound(ModelState);
                }
                else
                {
                    return Ok(_users);
                }
            }
            catch (Exception ex)
            { 
            return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get user by Use ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        [HttpGet]
        [Route("/api/users/{id}")]
        public async Task<IActionResult> Users(int id)
        {
            try
            {
                if (id != 0)
                {
                    var _users = await userRepositorry.GetUsers(id);
                    if (_users == null)
                    {
                        ModelState.AddModelError("User", $"User with Id = {id} not found");
                        return NotFound(ModelState);
                    }
                    else
                    {
                        
                        return Ok(_users);
                    }
                }
                else
                {
                    ModelState.AddModelError("User", $"User ID {id} is Invalid");
                    return NotFound (ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// delete user by Use ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns>delete user id</returns>
        [HttpDelete]
        [Route("/api/users/{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            try
            {
                if (id != 0)
                {
                    var _users = await userRepositorry.DeleteUsers(id);
                    if (_users == null)
                    {
                        ModelState.AddModelError("User", $"User with Id = {id} not found");
                        return NotFound(ModelState);
                    }
                    else
                    {
                                     
                  
                        return NoContent();
                    }
                }
                else
                {
                    ModelState.AddModelError("User", $"User ID {id} is Invalid");
                    return NotFound(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/api/users/{id}")]
        public async Task<IActionResult> UpdateUsers(int id, tbUserViewModels User)
        {
            try
            {

                if (id != User.IUserId)
                {
                    return BadRequest("User ID mismatch");
                }

                var userToUpdate = await userRepositorry.GetUsers(id);

                if (userToUpdate == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }


                 await userRepositorry.UpdateUsers(id, User);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

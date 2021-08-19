using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UsersController :  ControllerBase
	{
		private readonly IUserService _userService;
		public UsersController(IUserService userService) => _userService = userService; 

		[HttpGet]
		public IActionResult GetAll()
		{
			var result = _userService.GetAll();
			return result.Success ? (IActionResult) Ok(result.Data) : BadRequest(result.Message);
		}
		[HttpGet]
		public IActionResult GetById(int id)
		{
			var result = _userService.GetById(id);
			return result.Success ? (IActionResult) Ok(result.Data) : BadRequest(result.Message);
		}
		[HttpPost]
		public IActionResult Insert(User user)
		{
			var result = _userService.Add(user);
			return result.Success ? (IActionResult) Ok(result.Data) : BadRequest(result.Message);
		}
		[HttpPut]
		public IActionResult Update(User user)
		{
			var result = _userService.Update(user);
			return result.Success ? (IActionResult) Ok(result.Data) : BadRequest(result.Message);
		}
		[HttpDelete]
		public IActionResult Delete(User user)
		{
			var result = _userService.Delete(user);
			 return result.Success ? (IActionResult) Ok(result.Message) : BadRequest(result.Message);
		}
	}
}


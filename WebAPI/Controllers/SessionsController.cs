using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class SessionsController :  ControllerBase
	{
		private readonly ISessionService _sessionService;
		public SessionsController(ISessionService sessionService) => _sessionService = sessionService; 

		[HttpGet]
		public IActionResult GetAll()
		{
			var result = _sessionService.GetAll();
			return result.Success ? (IActionResult) Ok(result.Data) : BadRequest(result.Message);
		}
		[HttpGet]
		public IActionResult GetByToken(string id)
		{
			var result = _sessionService.GetByToken(id);
			return result.Success ? (IActionResult) Ok(result.Data) : BadRequest(result.Message);
		}
		[HttpPost]
		public IActionResult Insert(Session session)
		{
			var result = _sessionService.Add(session);
			return result.Success ? (IActionResult) Ok(result.Data) : BadRequest(result.Message);
		}
		[HttpPut]
		public IActionResult Update(Session session)
		{
			var result = _sessionService.Update(session);
			return result.Success ? (IActionResult) Ok(result.Data) : BadRequest(result.Message);
		}
		[HttpDelete]
		public IActionResult Delete(Session session)
		{
			var result = _sessionService.Delete(session);
			 return result.Success ? (IActionResult) Ok(result.Message) : BadRequest(result.Message);
		}
	}
}


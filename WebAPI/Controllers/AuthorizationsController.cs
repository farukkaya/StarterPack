using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationsController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ISessionService _sessionService;

        public AuthorizationsController(IAuthorizationService authorizationService,ISessionService sessionService)
        {
            _authorizationService = authorizationService;
            _sessionService = sessionService;
        }

        [HttpPost]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authorizationService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authorizationService.CreateAccessToken(userToLogin.Data);
            if (!result.Success) return BadRequest(result.Message);
            var endDate = (userForLoginDto.KeepSession) ? DateTime.Now.AddDays(7) : DateTime.Now.AddHours(12);
            var session = new Session { AccessToken = Guid.NewGuid().ToString(), RefreshToken = Guid.NewGuid().ToString(), CreatedDate = DateTime.Now, IsActive = true, UserId = userToLogin.Data.Id, SessionExpireDate = endDate };
            session.FillClientDetails(Request);
            var activeSessions = _sessionService.GetActiveSessions(userToLogin.Data.Id);
            if (activeSessions.Count() >= userForLoginDto.MaxSessionLimit)
            {
                return Ok(new Result(ResultType.USER_MAX_SESSION_LIMIT));
            }
            else
            {
                if (_sessionService.Add(session).Success)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(new Result(ResultType.BAD_REQUEST));
                }
            }
        }

        [HttpPost]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authorizationService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authorizationService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authorizationService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
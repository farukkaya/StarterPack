using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguagesController(ILanguageService languageService) => _languageService = languageService;

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _languageService.GetAll();
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _languageService.GetById(id);
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpPost]
        public IActionResult Insert(Language language)
        {
            var result = _languageService.Add(language);
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpPut]
        public IActionResult Update(Language language)
        {
            var result = _languageService.Update(language);
            return result.Success ? (IActionResult)Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpDelete]
        public IActionResult Delete(Language language)
        {
            var result = _languageService.Delete(language);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Test(Language language)
        {
            var result = _languageService.TransactionOperation(language);
            return result.Success ? (IActionResult)Ok(result.Message) : BadRequest(result.Message);
        }

    }
}
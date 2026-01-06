using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private readonly IAutorInterface _autorInterface;
        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("listarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> GetAllAutors()
        {
            var response = await _autorInterface.GetAllAutors();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

using Librerias_AMGD.Data.Services;
using Librerias_AMGD.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Librerias_AMGD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorService;

        public AuthorsController(AuthorService authorsServices) 
        {
            _authorService = authorsServices;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }
    }
}

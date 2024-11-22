using Librerias_AMGD.Data.Services;
using Librerias_AMGD.Data.ViewModels;
using Librerias_AMGD.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Librerias_AMGD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublisherService _publishersService;

        public PublishersController(PublisherService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameExceptions ex)
            {
                return BadRequest($"{ex.Message}, Nombre de la editorial: {ex.PublisherName}");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id) 
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherByID(int id)
        {
            var _response = _publishersService.GetPublisherByID(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else 
            {
                return NotFound();
            }
        }

        [HttpDelete("delete-publisher-by-id")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

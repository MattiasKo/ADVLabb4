using ADVLabb4.Models;
using IntresseKlubbenAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntresseKlubbenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonerController : ControllerBase
    {
        private IIntresseKlubben<Personer> _intresseKlubben;
        public PersonerController(IIntresseKlubben<Personer> intresseklubben)
        {
            _intresseKlubben = intresseklubben;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                return Ok(await _intresseKlubben.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to recive data from database.");
            }
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Personer>> GetPerson(int id)
        {
            try
            {
                var result = await _intresseKlubben.GetSingel(id);
                if (result == null)
                {
                    return NotFound(); 
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to recive single data from database.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Personer>> CreateNewPerson(Personer newPer)
        {
            try
            {
                if (newPer == null)
                {
                    return BadRequest();
                }
                var createdProduct = await _intresseKlubben.Add(newPer);
                return CreatedAtAction(nameof(GetPerson), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Personer>> Delete(int id)
        {
            try
            {
                var DeletePerson = await _intresseKlubben.GetSingel(id);
                if(DeletePerson == null)
                {
                    return NotFound($"Person with id {id} not found.");
                }
                return await _intresseKlubben.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to delete from database.");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Personer>> Update(int id, Personer Pers)
        {
            try
            {
                if(id != Pers.Id)
                {
                    return BadRequest($"Person id {id} doesnt exist");
                }
                var PersonToUpdate = await _intresseKlubben.GetSingel(id);
                if(PersonToUpdate == null)
                {
                    return NotFound($"Person with id {id} not found.");
                }
                return await _intresseKlubben.Update(Pers);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Error to update to database.");
            }
        }

    }
}

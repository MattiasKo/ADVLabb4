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
    public class IntresseController : ControllerBase
    {
        private IIntresseKlubben<Interest> _intresseKlubben;
        public IntresseController(IIntresseKlubben<Interest> intresseklubben)
        {
            _intresseKlubben = intresseklubben;
        }
  
        [HttpGet]
        public async Task<IActionResult> GetAllIntresse()
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Interest>> GetPerson(int id)
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
        public async Task<ActionResult<Interest>> CreateNewPerson(Interest newPer)
        {
            try
            {
                if (newPer == null)
                {
                    return BadRequest();
                }
                var createdProduct = await _intresseKlubben.Add(newPer);
                return CreatedAtAction(nameof(GetPerson), new { id = createdProduct.ID }, createdProduct);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interest>> Delete(int id)
        {
            try
            {
                var DeletePerson = await _intresseKlubben.GetSingel(id);
                if(DeletePerson == null)
                {
                    return NotFound($"Interest with id {id} not found.");
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
        public async Task<ActionResult<Interest>> Update(int id, Interest Pers)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest($"Interest id {id} doesnt exist");
                }
                var PersonToUpdate = await _intresseKlubben.GetSingel(id);
                if(PersonToUpdate == null)
                {
                    return NotFound($"Interest with id {id} not found.");
                }
                return await _intresseKlubben.Update(Pers);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Error to update to database.");
            }
        }
        [HttpGet("Person{id}")]
          public async Task<ActionResult> AllPInterests(int id)
        {
            try
            {
                var result2 = await _intresseKlubben.GetAllMisc(id);
                //var result = await _intresseKlubben.GetSingel(id);
                if (result2 == null)
                {
                    return NotFound();
                }
                
                return Ok(result2);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to recive single data from database.");
            }
        }



    }
}

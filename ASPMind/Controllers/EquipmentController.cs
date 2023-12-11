using ASPMind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPMind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public EquipmentController(ApplicationDBContext context) 
        {
            _context = context;
        }
        // GET: api/<EquipmentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEquipments = await _context.Equipments.ToListAsync();
                return Ok(listEquipments);
            }
            catch(Exception e) { 
                return BadRequest(e.Message);
            }
        }

        // GET api/<EquipmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EquipmentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Equipment equipment)
        {
            try
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return Ok(equipment);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);  
            }
        }

        // PUT api/<EquipmentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Equipment equipment)
        {
            try
            {
                if(id != equipment.Id)
                {
                    return NotFound();
                }

                _context.Update(equipment);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The equipment was updated successfully"});
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<EquipmentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var equipment = await _context.Equipments.FindAsync(id);

                if(equipment == null)
                {
                    return NotFound();
                }

                _context.Equipments.Remove(equipment);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Equipment deleted"});


            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

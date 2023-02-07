using FBTarjetas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBTarjetas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public TarjetaController(AplicationDbContext context) 
        {
         _context= context;
        }
        // GET: api/<TarjetaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try 
            {
                var listTarjetas = await _context.TarjetaCredito.ToListAsync();
                return Ok(listTarjetas);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // POST api/<TarjetaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                if(id != tarjeta.Id)
                {
                    return NotFound();
                }

                _context.Update(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "La tarjeta se actualizo con exito"});
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjeta = await _context.TarjetaCredito.FindAsync(id);

                if(tarjeta == null){
                    return NotFound();
                }

                _context.TarjetaCredito.Remove(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "La tarjeta ha sido eliminado con exito"});
            }
            catch(Exception e) 
            { 
            return BadRequest(e.Message);
            }
        }
    }
}

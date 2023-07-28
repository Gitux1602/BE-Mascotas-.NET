using BE_CRUD_Mascotas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
//using System;

namespace BE_CRUD_Mascotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public MascotaController(AplicationDbContext context) { 
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {   //Clase IActionResult nos permite trabajar con los status, ex: 200, etc.
            try 
            {
                var listMascotas = await _context.Mascotas.ToListAsync();
                return Ok(listMascotas);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); 
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {  
            try
            {
                
                var mascota = await _context.Mascotas.FindAsync(id);
                return Ok(mascota);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
           // Console.WriteLine(id);
            try
            {

                var mascota = await _context.Mascotas.FindAsync(id);
                
                if (mascota == null)
                {
                    return NotFound();
                }
                _context.Mascotas.Remove(mascota);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Mascota mascota)
        {
             Console.WriteLine(mascota);
            try
            {
                
                mascota.FechaCreacion = DateTime.Now;
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

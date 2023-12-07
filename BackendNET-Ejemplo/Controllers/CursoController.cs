using BackendNET_Ejemplo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendNET_Ejemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CursoController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CursoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCursos = await _context.Curso.ToListAsync();
                return Ok(listCursos);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var curso = await _context.Curso.FindAsync(id);
                if (curso == null)
                {
                    return NotFound();
                }
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CursoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Curso curso)
        {
            try
            {
                _context.Curso.Add(curso);
                await _context.SaveChangesAsync();
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CursoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Curso curso)
        {
            try
            {
                if(id != curso.Id)
                {
                    return BadRequest();
                }
                _context.Curso.Update(curso);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Curso actualizado con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var curso = await _context.Curso.FindAsync(id);
                if(curso == null)
                {
                    return BadRequest();
                }
                _context.Curso.Remove(curso);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Curso eliminado con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

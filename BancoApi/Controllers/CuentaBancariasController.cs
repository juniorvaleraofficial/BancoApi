using BancoApi.Data;
using BancoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly BancoContext _context;

        public CuentasController(BancoContext context)
        {
            _context = context;
        }

        // GET: api/cuentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuentaBancaria>>> Get()
        {
            return await _context.Cuentas.ToListAsync();
        }

        // GET: api/cuentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaBancaria>> Get(int id)
        {
            var cuenta = await _context.Cuentas.FindAsync(id);

            if (cuenta == null)
                return NotFound();

            return cuenta;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<CuentaBancaria>> Post(CuentaBancaria cuenta)
        {
            cuenta.FechaCreacion = DateTime.Now;

            _context.Cuentas.Add(cuenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = cuenta.Id }, cuenta);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CuentaBancaria cuenta)
        {
            if (id != cuenta.Id)
                return BadRequest();

            _context.Entry(cuenta).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financePlay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public UsuariosController(IUnitOfWork uow) => _uow = uow;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _uow.Usuarios.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _uow.Usuarios.GetByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario model)
        {
            await _uow.Usuarios.AddAsync(model);
            await _uow.CommitAsync();
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario model)
        {
            var exists = await _uow.Usuarios.GetByIdAsync(id);
            if (exists is null) return NotFound();
            model.Id = id;
            _uow.Usuarios.Update(model);
            await _uow.CommitAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _uow.Usuarios.GetByIdAsync(id);
            if (exists is null) return NotFound();
            _uow.Usuarios.Remove(exists);
            await _uow.CommitAsync();
            return NoContent();
        }
    }
}

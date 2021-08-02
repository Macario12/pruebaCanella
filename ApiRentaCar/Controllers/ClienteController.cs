using System.Collections.Generic;
using System.Linq;
using ApiRentaCar.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRentaCar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ClienteController : ControllerBase
    {
        private readonly RentaCarDbContext _context;

        public ClienteController(RentaCarDbContext context){
            _context  = context;
        }
    
        [HttpGet]
        public List<Cliente> GetAllClientes(){
            
            return _context.Clientes.ToList();
        }

        [HttpPost]
        public IActionResult AddCliente([FromBody] Cliente cliente){
            if(!this.ModelState.IsValid){
                return BadRequest();
            }else{
                this._context.Clientes.Add(cliente);
                this._context.SaveChanges();
                return Created($"clientes/{cliente.codigo}",cliente);
            }
        }

        [HttpPut]
        public IActionResult PutCliente([FromBody] Cliente cliente){
            var _cliente = _context.Clientes.FirstOrDefault(data => data.codigo == cliente.codigo);

            if(_cliente == null){
                return NotFound();
            }else{
                _cliente.codigo = cliente.codigo;
                _cliente.nombres = cliente.nombres;
                _cliente.apellidos = cliente.apellidos;

                _context.Clientes.Update(_cliente);

                _context.SaveChanges();
                return new NoContentResult();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteCliente(int id){
            var _cliente = _context.Clientes.FirstOrDefault(data => data.codigo == id);

            if(!this.ModelState.IsValid){
                return BadRequest();
            }else{
                _context.Clientes.Remove(_cliente);
                _context.SaveChanges();
                return Ok();
            }
        }

    }

    
}
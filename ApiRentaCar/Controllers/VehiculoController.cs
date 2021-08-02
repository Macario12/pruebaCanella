using System.Collections.Generic;
using System.Linq;
using ApiRentaCar.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRentaCar.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly RentaCarDbContext _context;

        public VehiculoController(RentaCarDbContext context){
            _context  = context;
        }

        [HttpGet]
        public List<Vehiculo> GetAllVehiculos(){
            
            return _context.Vehiculos.ToList();
        }

        [HttpPost]
        public IActionResult AddVehiculo([FromBody] Vehiculo vehiculo){
            if(!this.ModelState.IsValid){
                return BadRequest();
            }else{
                this._context.Vehiculos.Add(vehiculo);
                this._context.SaveChanges();
                return Created($"clientes/{vehiculo.matricula}",vehiculo);
            }
        }

        [HttpPut]
        public IActionResult PutVehiculo([FromBody] Vehiculo vehiculo){
            var _vehiculo = _context.Vehiculos.FirstOrDefault(data => data.matricula == vehiculo.matricula);

            if(_vehiculo == null){
                return NotFound();
            }else{
                _vehiculo.matricula = vehiculo.matricula;
                _vehiculo.marca = vehiculo.marca;
                _vehiculo.color = vehiculo.color;
                _vehiculo.precioAlquiler = vehiculo.precioAlquiler;
                _vehiculo.dias_reserva = vehiculo.dias_reserva;
                _vehiculo.precioFinal = vehiculo.precioFinal;
                _vehiculo.id_persona = vehiculo.id_persona;
                
                _context.Vehiculos.Update(_vehiculo);

                _context.SaveChanges();
                return new NoContentResult();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteVehiculo(string id){
            var _vehiculo = _context.Vehiculos.FirstOrDefault(data => data.matricula == id);

            if(!this.ModelState.IsValid){
                return BadRequest();
            }else{
                _context.Vehiculos.Remove(_vehiculo);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
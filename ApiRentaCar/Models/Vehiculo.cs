
using System.ComponentModel.DataAnnotations;
namespace ApiRentaCar.Models
{
    public class Vehiculo
    {
        [Key]
        public string matricula {get; set;}
        public string marca {get; set;}
        public string color {get; set;}
        public int precioAlquiler {get; set;}
        public int id_garaje {get; set;}
        public int dias_reserva {get; set;}
        public int precioFinal {get; set;}
        public int id_persona {get; set;}
    }
}
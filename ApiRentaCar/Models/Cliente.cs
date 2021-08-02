using System.ComponentModel.DataAnnotations;
namespace ApiRentaCar.Models
{
    public class Cliente
    {
        [Key]
        public int codigo {get; set;}
        public string nombres {get; set;}
        public string apellidos {get; set;}
    }
}
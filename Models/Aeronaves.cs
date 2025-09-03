using System.ComponentModel.DataAnnotations;
namespace RegistroAeronaves.Models
{
    public class Aeronaves
    {
        [Key]
        public int AeronavesId { get; set; }

        [Required(ErrorMessage = "Favor introduzca un tipo de aeronave")]
        public string TipoAeronave { get; set; }

        [Required(ErrorMessage = "Favor ingrese una aerolinea")]

        public string categoria { get; set; }

        [Required(ErrorMessage = "Favor ingrese un identificador valido")]
        public string Identificador { get; set; }

        [Required(ErrorMessage = "Favor ingrese una fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Favor ingrese una aerolinea")]

        public string Aerolinea { get; set; }

        [Required(ErrorMessage = "Favor ingrese una matricula")]

        public string Matricula { get; set; }

        [Required(ErrorMessage = "Favor ingrese una ruta")]

        public string ruta { get; set; }

        [Required(ErrorMessage = "Favor ingrese una imagen")]

        public byte[]? Imagen { get; set; }



    }
}

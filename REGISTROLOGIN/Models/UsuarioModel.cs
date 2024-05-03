using System.ComponentModel.DataAnnotations;

namespace REGISTROLOGIN.Models
{
    public class UsuarioModel{

        [Key]
        public int id { get; set; }
        [Required (ErrorMessage = "Campo requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Usuario { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Clave { get; set; }

        // id int identity(1,1) PRIMARY KEY,
        // Nombre VARCHAR(50),
        // Correo VARCHAR(100),
        // Edad int,
        // Usuario VARCHAR(50),
        // Clave VARCHAR(50)
    }
}

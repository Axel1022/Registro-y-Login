using System.ComponentModel.DataAnnotations;

namespace REGISTROLOGIN.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo requerido")]
        public string? Usuario { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Clave { get; set; }
    }
}

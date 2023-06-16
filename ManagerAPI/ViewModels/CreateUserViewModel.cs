using Manager.Services.DTO;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vazio")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "O nome pode ter no máximo 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email não pode ser vazio")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O email informado não é válido.")]
        [MaxLength(50, ErrorMessage = "O email pode ter no máximo 180 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazio")]
        [MinLength(3, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        [MaxLength(50, ErrorMessage = "A senha pode ter no máximo 30 caracteres")]
        public string Password { get; set; }
    }
}

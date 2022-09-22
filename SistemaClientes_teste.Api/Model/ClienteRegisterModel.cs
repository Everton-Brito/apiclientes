using System.ComponentModel.DataAnnotations;

namespace SistemaClientes_teste.Api.Model
{
    public class ClienteRegisterModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {6} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no maximo {150} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cpf do cliente.")]
        [MinLength(11, ErrorMessage = "Por favor, informe no mínimo {11} caracteres.")]
        [MaxLength(11, ErrorMessage = "Por favor, informe no maximo {11} caracteres.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do cliente.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]      
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone do cliente.")]
        [MinLength(11, ErrorMessage = "Por favor, informe no mínimo {11} caracteres.")]
        [MaxLength(11, ErrorMessage = "Por favor, informe no mínimo {11} caracteres.")]
        public string Telefone { get; set; }
    }
}

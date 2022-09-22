using System.ComponentModel.DataAnnotations;

namespace SistemaClientes_teste.Api.Model
{
    public class EnderecoPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do cliente.")]
        public Guid IdEndereco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a rua do endereço.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Por favor, informe o numero do endereço.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Por favor, informe o complemento do endereço.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o bairro.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Por favor, informe a cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o estado.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Por favor, informe o numero do Cep.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {8} caracteres.")]
        [MaxLength(8, ErrorMessage = "Por favor, informe no mínimo {8} caracteres.")]
        public String Cep { get; set; }
    }
}

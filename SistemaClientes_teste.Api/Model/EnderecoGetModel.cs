namespace SistemaClientes_teste.Api.Model
{
    public class EnderecoGetModel
    {
        public Guid IdEndereco { get; set; }
        public Guid IdCliente { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}

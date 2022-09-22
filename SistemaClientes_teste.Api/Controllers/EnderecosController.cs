using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaClientes_teste.Api.Model;
using SistemaClientes_teste.Data.Entities;
using SistemaClientes_teste.Data.Repositories;

namespace SistemaClientes_teste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(EnderecoRegisterModel model)
        {
            try
            {
                var endereco = new Endereco();                  
                

                endereco.IdEndereco = Guid.NewGuid();
                endereco.IdCliente = model.IdCliente;
                endereco.Rua = model.Rua;
                endereco.Numero = model.Numero;
                endereco.Complemento = model.Complemento;
                endereco.Bairro = model.Bairro;
                endereco.Cidade = model.Cidade;
                endereco.Estado = model.Estado;
                endereco.Cep = model.Cep;

                var enderecoRepository = new EnderecoRepository();
                enderecoRepository.Create(endereco);

                return StatusCode(201, new { mensagem = "Endereço cadastrado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }

        }

        [HttpPut]
        public IActionResult Put(EnderecoPutModel model)
        {
            try
            {
                var enderecoRepository = new EnderecoRepository();
                var endereco = enderecoRepository.GetByEndereco(model.IdEndereco);

                if (endereco != null)
                {
                    endereco.IdEndereco = model.IdEndereco;
                    endereco.Rua = model.Rua;
                    endereco.Numero = model.Numero;
                    endereco.Complemento = model.Complemento;
                    endereco.Bairro = model.Bairro;
                    endereco.Cidade = model.Cidade;
                    endereco.Estado = model.Estado;
                    endereco.Cep = model.Cep;

                    enderecoRepository.Update(endereco);

                    return StatusCode(200, new {mensagem = "Endereço atualizado com sucesso."});
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Endereço nao encontrado." });
                }

            }
            catch(Exception e)
            {
                return StatusCode(500, new {mensagem = $"Falha: {e.Message}"});
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnderecoGetModel))]
        public IActionResult GetByEndereco(Guid idEndereco)
        {
            try
            {
                var enderecoRepository = new EnderecoRepository();
                var endereco = enderecoRepository.GetByEndereco(idEndereco);
                if(endereco != null)
                {
                    var model = new EnderecoGetModel();

                    model.IdCliente = endereco.IdCliente;
                    model.IdEndereco = endereco.IdEndereco;
                    model.Rua = endereco.Rua;
                    model.Numero = endereco.Numero;
                    model.Complemento = endereco.Complemento;
                    model.Bairro = endereco.Bairro;
                    model.Cidade = endereco.Cidade;
                    model.Estado = endereco.Estado;
                    model.Cep = endereco.Cep;

                    return StatusCode(200, model);

                }
                else
                {
                    return StatusCode(204);
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        [HttpGet("{idCliente}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnderecoGetModel))]
        public IActionResult GetById(Guid idCliente)
        {
            try
            {
                var lista = new List<EnderecoGetModel>();

                var enderecoRepository = new EnderecoRepository();

                foreach (var item in enderecoRepository.GetByCliente(idCliente))
                {
                    var model = new EnderecoGetModel();
                    model.IdEndereco = item.IdEndereco;
                    model.Rua = item.Rua;
                    model.Numero = item.Numero;
                    model.Complemento = item.Complemento;
                    model.Bairro = item.Bairro;
                    model.Cidade = item.Cidade;
                    model.Estado = item.Estado;
                    model.Cep = item.Cep;

                    lista.Add(model);
                }
                return StatusCode(200, lista);              
                

                
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }
       

    }
}

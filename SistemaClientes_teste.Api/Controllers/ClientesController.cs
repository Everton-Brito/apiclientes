using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaClientes_teste.Api.Model;
using SistemaClientes_teste.Data.Entities;
using SistemaClientes_teste.Data.Repositories;

namespace SistemaClientes_teste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClienteRegisterModel model)
        {
            try
            {
                var cliente = new Cliente();

                cliente.IdCliente = Guid.NewGuid();
                cliente.Nome = model.Nome;
                cliente.Cpf = model.Cpf;
                cliente.Email = model.Email;
                cliente.Telefone = model.Telefone;
                cliente.DataNascimento = model.DataNascimento;

                var clienteRepository = new ClienteRepository();
                clienteRepository.Create(cliente);

                return StatusCode(201, new { mensagem = $"Cliente {model.Nome} cadastrado com sucesso. " });     
                
            }
            catch(Exception e)
            {
                return StatusCode(500, new {mensagem = e.Message}); 
            }
        }

        [HttpPut]
        public IActionResult Put(ClientePutModel model)
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.GetById(model.IdCliente);
                if (cliente != null)
                {
                    cliente.Nome = model.Nome;
                    cliente.Cpf = model.Cpf;
                    cliente.Email = model.Email;
                    cliente.Telefone = model.Telefone;
                    cliente.DataNascimento = model.DataNascimento;

                    clienteRepository.Update(cliente);

                    return StatusCode(200, new { mensagem = $"Cliente {cliente.Nome} atualizado com sucesso." });
                }
                return StatusCode(400, new { mensagem = "Cliente nao encontrado." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }



        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClienteGetModel>))]
        public IActionResult GetAll()
        {
            try
            {
                var lista = new List<ClienteGetModel>();

                var clienteRepository = new ClienteRepository();
                foreach (var item in clienteRepository.GetAll())
                {
                    var model = new ClienteGetModel();

                    model.IdCliente = item.IdCliente;
                    model.Nome = item.Nome;
                    model.Cpf = item.Cpf;
                    model.Email = item.Email;
                    model.Telefone = item.Telefone;
                    model.DataNascimento = item.DataNascimento;
                    model.Idade = ObterIdade(model.DataNascimento);

                    lista.Add(model);
                }

                return StatusCode(200, lista);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        [HttpGet("{idCliente}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteGetModel))]
        public IActionResult ObterPorId(Guid idCliente)
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.GetById(idCliente);
                if (cliente != null)
                {
                    var model = new ClienteGetModel();

                    model.IdCliente = cliente.IdCliente;
                    model.Nome = cliente.Nome;
                    model.Cpf = cliente.Cpf;
                    model.Email = cliente.Email;
                    model.Telefone = cliente.Telefone;
                    model.DataNascimento = cliente.DataNascimento;
                    model.Idade = ObterIdade(model.DataNascimento);


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


        public static int ObterIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade--;

            }
            return idade;
        }


    }
}

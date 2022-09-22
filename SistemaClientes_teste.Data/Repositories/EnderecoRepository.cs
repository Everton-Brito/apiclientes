using Microsoft.EntityFrameworkCore;
using SistemaClientes_teste.Data.Contexts;
using SistemaClientes_teste.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes_teste.Data.Repositories
{
    public class EnderecoRepository
    {
        public void Create(Endereco endereco)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Add(endereco);
                sqlServerContext.SaveChanges();
            }
        }

        public void Delete(Endereco endereco)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Remove(endereco);
                sqlServerContext.SaveChanges();
            }
        }

        public void Update(Endereco endereco)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(endereco).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }     

        public Endereco GetByEndereco(Guid idEndereco)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Endereco.FirstOrDefault(e => e.IdEndereco == idEndereco);
            }
        }

        public List<Endereco> GetByCliente(Guid idCliente)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Endereco.Where(e => e.IdCliente == idCliente).ToList();
            }
        }
        
    }
}

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
    public class ClienteRepository
    {
        public void Create(Cliente cliente)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Cliente.Add(cliente);
                sqlServerContext.SaveChanges();
            }
        }

        public void Update(Cliente cliente)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(cliente).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }

        public void Delete(Cliente cliente)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Remove(cliente);
                sqlServerContext.SaveChanges();
            }
        }

        public List<Cliente> GetAll()
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Cliente.OrderByDescending(c => c.Nome).ToList();
            }
        }

        public Cliente? GetById(Guid idCliente)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Cliente.FirstOrDefault(c => c.IdCliente.Equals(idCliente));
            }
        }
    }
}

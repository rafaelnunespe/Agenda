using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTesteFactory.Data;
using AgendaTesteFactory.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaTesteFactory.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel BuscarPorId(int id)
        {
            return _bancoContext.Clientes.Include(x => x.Endereco).FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;
        }

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel clienteDB = BuscarPorId(cliente.Id);

            if (clienteDB == null) throw new Exception("Erro na atualização do cliente");

            clienteDB.Nome = cliente.Nome;
            clienteDB.Email = cliente.Email;
            clienteDB.Celular = cliente.Celular;

            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();

            return clienteDB;
        }

        public bool Apagar(int id)
        {
            ClienteModel clienteDB = BuscarPorId(id);

            if (clienteDB == null) throw new Exception("Erro na atualização do cliente");

            _bancoContext.Clientes.Remove(clienteDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}

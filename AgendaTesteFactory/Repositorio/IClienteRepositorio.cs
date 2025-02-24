using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTesteFactory.Models;

namespace AgendaTesteFactory.Repositorio
{
    public interface IClienteRepositorio
    {
        ClienteModel BuscarPorId(int id);
        List<ClienteModel> BuscarTodos();
        ClienteModel Adicionar(ClienteModel cliente);
        ClienteModel Atualizar(ClienteModel cliente);
        bool Apagar(int id);
    }
}

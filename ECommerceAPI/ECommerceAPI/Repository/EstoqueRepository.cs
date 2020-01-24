using ECommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository
{
    interface EstoqueRepository
    {
        bool Cadastrar(Estoque estoque);
        bool Atualizar(Estoque estoque);
        bool Remover(int id);
        Estoque SelecionarPorId(int id);
        List<Estoque> ListarTodos();
    }
}

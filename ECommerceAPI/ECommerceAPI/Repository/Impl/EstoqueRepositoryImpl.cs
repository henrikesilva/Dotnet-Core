using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository
{
    public class EstoqueRepositoryImpl : EstoqueRepository
    {
        private readonly ECommerceDbContext _context;

        public EstoqueRepositoryImpl(ECommerceDbContext context)
        {
            _context = context;
        }
        public void Atualizar(Estoque estoque)
        {
            if (!Exists(estoque))
            {
                _context.Update(estoque);
                _context.SaveChanges();
            }
        }

        public void Cadastrar(Estoque estoque)
        {
            if (!Exists(estoque))
            {
                _context.Add(estoque);
                _context.SaveChanges();
            }
        }

        public List<Estoque> ListarTodos()
        {
            return _context.Estoques.Include(e => e.Produto).ToList();
        }

        public void Remover(int id)
        {
            var estoque = SelecionarPorId(id);
            _context.Estoques.Remove(estoque);
            _context.SaveChanges();
        }

        public Estoque SelecionarPorId(int id)
        {
            return _context.Estoques.Find(id);
        }

        private bool Exists(Estoque estoque)
        {
            return _context.Estoques.Any(e => (e.Id == estoque.Id));
        }
    }
}

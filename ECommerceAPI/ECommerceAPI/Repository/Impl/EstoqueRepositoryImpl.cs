using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public bool Atualizar(Estoque estoque)
        {
            if (Exists(estoque))
            {
                _context.Entry(estoque).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Cadastrar(Estoque estoque)
        {
            if (!Exists(estoque))
            {
                _context.Add(estoque);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Estoque> ListarTodos()
        {
            return _context.Estoques.Include(e => e.Produto).ToList();
        }

        public bool Remover(int id)
        {
            var estoque = SelecionarPorId(id);

            if (estoque == null)
            {
                return false;
            }

            _context.Estoques.Remove(estoque);
            _context.SaveChanges();
            return true;
        }

        public Estoque SelecionarPorId(int id)
        {
            return _context.Estoques.Find(id);
        }

        private bool Exists(Estoque estoque)
        {
            return _context.Estoques.Any(e => (e.Id == estoque.Id || e.IdProduto == estoque.IdProduto));
        }
    }
}

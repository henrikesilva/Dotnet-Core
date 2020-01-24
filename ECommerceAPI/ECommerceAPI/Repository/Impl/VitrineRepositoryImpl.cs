using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository
{
    public class VitrineRepositoryImpl : VitrineRepository
    {
        private readonly ECommerceDbContext _context;

        public VitrineRepositoryImpl(ECommerceDbContext context)
        {
            _context = context;
        }

        public List<Vitrine> ListarVitrineAtivas()
        {
            return _context.Produtos.Where(p => p.Ativo == true).Select(p => new Vitrine()
            {
                IdProduto = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = (decimal)p.Preco,
                IdEstoque = p.estoque.Id,
                QuantidadeEstoque = p.estoque.Quantidade
            }).ToList();
        }

        public bool ValidaQuantidadeProduto(int idProduto)
        {
            return _context.Estoques.Any(e => e.IdProduto == idProduto && e.Quantidade == 0);
        }
    }
}

using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository
{
    public class UsuarioRepositoryImpl : UsuarioRepository
    {
        private readonly ECommerceDbContext _context;
        public UsuarioRepositoryImpl(ECommerceDbContext context)
        {
            _context = context;
        }
        public void Gravar(Usuario usuario)
        {
            if (!Exists(usuario))
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
        }

        public List<Usuario> ListarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario SelecionarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        private bool Exists(Usuario usuario)
        {
            return _context.Perfis.Any(e => e.Nome == usuario.Nome);
        }
    }
}

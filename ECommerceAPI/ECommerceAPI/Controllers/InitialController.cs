using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Models;
using ECommerceAPI.Repository;


namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;
        private readonly PerfilRepository _perfilRepository;
        private readonly UsuarioRepository _usuarioRepository;
        public InitialController(ECommerceDbContext context)
        {
            _produtoRepository = new ProdutoRepositoryImpl(context);
            _perfilRepository = new PerfilRepositoryImpl(context);
            _usuarioRepository = new UsuarioRepositoryImpl(context);
        }

        [HttpGet]
        public ActionResult Initiate()
        {
            var perfilAdmin = new Perfil() { Nome = "ADMIN" };
            var perfilUser = new Perfil() { Nome = "USUARIO" };

            _perfilRepository.Gravar(perfilAdmin);
            _perfilRepository.Gravar(perfilUser);

            var userAdmin = new Usuario() { Perfil = perfilAdmin, DataModificacao = DateTime.Now, Ativo = true, Nome = "Henrique Lima", Email = "henrique.lima@gmail.com", Login = "Henrique", Senha = "1234" };
            _usuarioRepository.Gravar(userAdmin);
            var userAdmin2 = new Usuario() { Perfil = perfilAdmin, DataModificacao = DateTime.Now, Ativo = true, Nome = "Admin", Email = "admin@gmail.com", Login = "admin", Senha = "1234" };
            _usuarioRepository.Gravar(userAdmin2);
            var userAdmin3 = new Usuario() { Perfil = perfilAdmin, DataModificacao = DateTime.Now, Ativo = false, Nome = "Inativo", Email = "inativo@gmail.com", Login = "admin2", Senha = "1234" };
            _usuarioRepository.Gravar(userAdmin3);

            var userFinal = new Usuario() { Perfil = perfilUser, DataModificacao = DateTime.Now, Ativo = true, Nome = "User 1", Email = "user1@gmail.com", Login = "user1", Senha = "1234" };
            _usuarioRepository.Gravar(userFinal);
            var userFinal2 = new Usuario() { Perfil = perfilUser, DataModificacao = DateTime.Now, Ativo = true, Nome = "User 2", Email = "user2@gmail.com", Login = "user2", Senha = "3456" };
            _usuarioRepository.Gravar(userFinal2);
            var userFinal3 = new Usuario() { Perfil = perfilUser, DataModificacao = DateTime.Now, Ativo = false, Nome = "User 3", Email = "user3@gmail.com", Login = "user2", Senha = "3456" };
            _usuarioRepository.Gravar(userFinal3);

            _produtoRepository.Cadastrar(new Produto() { Nome = "TV Smart 32 4k", Preco = 1000.90m, Ativo = true, Descricao = "TV Smart 4k, 3 USBs, 3HDMI", DataModificacao = DateTime.Now, UsuarioCriador = userAdmin});
            _produtoRepository.Cadastrar(new Produto() { Nome = "Microondas LG", Preco = 399.78m, Ativo = true, Descricao = "Microondas LG", DataModificacao = DateTime.Now, UsuarioCriador = userAdmin2 });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Fogão Brastemp", Preco = 899.99m, Ativo = true, Descricao = "Fogão Brastemp", DataModificacao = DateTime.Now, UsuarioCriador = userAdmin3 });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Notebook Gamer Acer", Preco = 3800.00m, Ativo = true, Descricao = "Notebook Gamer Acer", DataModificacao = DateTime.Now, UsuarioCriador = userFinal });            
            _produtoRepository.Cadastrar(new Produto() { Nome = "Geladeira Samsung", Preco = 2858.25m, Ativo = false, Descricao = "Geladeira Samsung", DataModificacao = DateTime.Now, UsuarioCriador = userFinal2 });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Liquidificador Philco", Preco = 1000.90m, Ativo = false, Descricao = "Liquidificador Philco", DataModificacao = DateTime.Now, UsuarioCriador = userFinal3 });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Cama Box Baú King", Preco = 1500.00m, Ativo = true, Descricao = "Cama Box Baú King", DataModificacao = DateTime.Now, UsuarioCriador = userAdmin3 });
            _produtoRepository.Cadastrar(new Produto() { Nome = "Colchão King", Preco = 2200.89m, Ativo = true, Descricao = "Colchão King", DataModificacao = DateTime.Now, UsuarioCriador = userFinal2 });

            return Ok(new
            {
                Produtos = _produtoRepository.ListarTodos(),
                Perfis = _perfilRepository.ListarTodos(),
                Usuario = _usuarioRepository.ListarTodos()
            });
        }

    }
}

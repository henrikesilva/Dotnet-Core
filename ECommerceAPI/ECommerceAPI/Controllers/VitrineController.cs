using ECommerceAPI.Models;
using ECommerceAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VitrineController : ControllerBase
    {
        private readonly VitrineRepository _vitrineRepository;
        private readonly ProdutoRepository _produtoRepository;

        public VitrineController(VitrineRepository vitrineRepository,
            ProdutoRepository produtoRepository)
        {
            _vitrineRepository = vitrineRepository;
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vitrine>> ExibirVitrineAtivas()
        {
            return _vitrineRepository.ListarVitrineAtivas();
        }

        [HttpPost("aviseme")]
        [Authorize(Roles = "USER")]
        public ActionResult AviseMe(AviseMe aviseMe)
        {
            var produto = _produtoRepository.SelecionarPorId(aviseMe.IdProduto);

            if (produto == null)
            {
                return BadRequest("Produto não encontrado");
            }

            if (_vitrineRepository.ValidaQuantidadeProduto(aviseMe.IdProduto))
            {
                return Ok($"Avisaremos no {aviseMe.Email} quando tivermos novo estoque do seguinte produto: {produto.Nome} - {produto.Descricao}");
            }
            else
            {
                return BadRequest("Produto tem estoque, não está indisponível");
            }
        }
    }
}

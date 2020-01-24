using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Vitrine
    {
        public int IdProduto { get; set; }
        public int IdEstoque { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal Preco { get; set; }   
        public string Nome { get; set; }   
        public string Descricao { get; set; }          
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        [MinLength(1)]
        public int Quantidade { get; set; }
        public DateTime DataModificacao { get; set; }
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }
        
    }
}

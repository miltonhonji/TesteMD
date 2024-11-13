using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.DTO
{
    public class Produto : Base
    {
        public string Descricao { get; set; }
        public Decimal Preco { get; set; }
        public int Estoque { get ; set; }
        public int IdItemVenda { get; set; }
    }
}

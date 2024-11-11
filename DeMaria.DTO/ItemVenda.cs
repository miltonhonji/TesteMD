using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.DTO
{
    public class ItemVenda
    {
        public int IdItemVenda { get; set; }
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}

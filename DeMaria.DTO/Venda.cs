using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.DTO
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public Decimal ValorTotal { get; set; }
    }
}

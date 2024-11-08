using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.DTO
{
    public class Cliente : Base
    {
        //os itens Id e Nome, irão vir da classe base
        public string Telefone { get; set; }
        public string Email { get; set; }     

        //a classe Endereço será agregada
        public Endereco Endereco { get; set; }

        public string Rua => Endereco.Rua;
        public int Numero => Endereco.Numero;
        public string Complemento => Endereco.Complemento;
        public string Bairro => Endereco.Bairro;
        public string Cep => Endereco.Cep;
    }
}

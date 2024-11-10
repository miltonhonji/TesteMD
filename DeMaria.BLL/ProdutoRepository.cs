using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeMaria.BLL.Contracts;
using DeMaria.DTO;
using DeMaria.DAL;
using Npgsql;
using System.Data;

namespace DeMaria.BLL
{
    class ProdutoRepository : IBaseRepository<Produto>, IDisposable
    {
        public int Deletar(Produto TEntity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Inserir(Produto TEntity)
        {
            throw new NotImplementedException();
        }

        public List<Produto> Listar()
        {
            throw new NotImplementedException();
        }

        public Produto Obter(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Produto TEntity)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeMaria.BLL.Contracts
{
    interface IBaseRepository<T>
    {
        int Deletar(T TEntity);
        T Obter(int id);
        int Inserir(T TEntity);
        int Update(T TEntity);
        List<T> Listar();
    }
}

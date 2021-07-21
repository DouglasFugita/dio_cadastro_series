using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Lista();
        T RetornaPorId(Guid id);
        void Insere(T entidade);
        void Exclui(Guid id);
        void Atualiza(Guid id, T entidade);
        Guid ProximoId();
    }
}

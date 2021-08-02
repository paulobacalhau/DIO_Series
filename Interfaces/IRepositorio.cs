using System.Collections.Generic;

namespace series.interfaces
{
    public interface IRepositorio<T>
    {
         void Atualiza(T entidade, int id);
         void Exclui(int id);
         void Insere(T entidade);
         List<T> Lista();
         T RetornaPorID(int id);
         
         int ProximoId();
    }
}
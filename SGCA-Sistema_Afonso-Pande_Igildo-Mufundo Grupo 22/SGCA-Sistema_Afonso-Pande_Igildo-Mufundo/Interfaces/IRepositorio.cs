using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        void Inserir(T entidade);
        T? ObterPorId(int id);
        IEnumerable<T> ObterTodos();
        void Actualizar(T entidade);
        void Eliminar(int id);
    }
}

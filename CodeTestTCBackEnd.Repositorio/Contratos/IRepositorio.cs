using CodeTestTCBackEnd.BL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.Repositorio.Contratos
{
    public interface IRepositorio<T>
    {
        void Agregar(T nuevo);
        T Buscar(int codigo);
        void Eliminar(int codigo);
        void Modificar(int codigoActual, T PedidoModificado);
        List<T> ObtenerLista();
    }
}

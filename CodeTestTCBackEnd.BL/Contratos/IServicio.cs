using CodeTestTCBackEnd.BL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.Contratos
{
    public interface IServicio<T>
    {
        void Agregar(T nuevoPedido);
        T Buscar(int codigo);
        void Eliminar(int codigo);
        void Modificar(int codigoActual, T PedidoModificado);
        List<T> ObtenerLista();
    }
}

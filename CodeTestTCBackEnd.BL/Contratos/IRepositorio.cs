using CodeTestTCBackEnd.BL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.Contratos
{
    public interface IRepositorio
    {
        void AgregarPedido(Pedido nuevoPedido);
        Pedido BuscarPedido(int codigo);
        void EliminarProducto(int codigo);
        void ModificarPedido(int codigoActual, Pedido PedidoModificado);
        List<Pedido> ObtenerLista();
    }
}

using CodeTestTCBackEnd.BL.Contratos;
using CodeTestTCBackEnd.BL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.Servicios
{
    public class PedidoServicio : IPedidoServicio
    {
        private readonly IRepositorio _pedidosRepositorio;
        public PedidoServicio(IRepositorio pedidosRepositorio)
        {
            _pedidosRepositorio = pedidosRepositorio;
        }
        public void AgregarPedido(Pedido nuevoPedido)
        {
            _pedidosRepositorio.AgregarPedido(nuevoPedido);
        }

        public Pedido BuscarPedido(int codigo)
        {
            return _pedidosRepositorio.BuscarPedido(codigo);
        }

        public void EliminarProducto(int codigo)
        {
            _pedidosRepositorio.EliminarProducto(codigo);
        }

        public void ModificarPedido(int codigoActual, Pedido PedidoModificado)
        {
            _pedidosRepositorio.ModificarPedido(codigoActual, PedidoModificado);
        }

        public List<Pedido> ObtenerLista()
        {
            return _pedidosRepositorio.ObtenerLista();
        }

        public int GetNuevoCodigo()
        {
            return _pedidosRepositorio.ObtenerLista().Max(p => p.Codigo) + 1;
        }
    }
}

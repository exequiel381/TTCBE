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
        private readonly IRepositorio<Pedido> _pedidosRepositorio;
        public PedidoServicio(IRepositorio<Pedido> pedidosRepositorio)
        {
            _pedidosRepositorio = pedidosRepositorio;
        }
        public void Agregar(Pedido nuevoPedido)
        {
            _pedidosRepositorio.Agregar(nuevoPedido);
        }

        public Pedido Buscar(int codigo)
        {
            return _pedidosRepositorio.Buscar(codigo);
        }

        public void Eliminar(int codigo)
        {
            _pedidosRepositorio.Eliminar(codigo);
        }

        public void Modificar(int codigoActual, Pedido PedidoModificado)
        {
            _pedidosRepositorio.Modificar(codigoActual, PedidoModificado);
        }

        public List<Pedido> ObtenerLista()
        {
            return _pedidosRepositorio.ObtenerLista();
        }

        public int GetNuevoCodigo()
        {
            return _pedidosRepositorio.ObtenerLista().Max(p => p.Codigo) + 1;
        }

        public List<Pedido> ObtenerListaOrdenadaPorFechaAscendente()
        {
            return _pedidosRepositorio.ObtenerLista().OrderBy(pedido => pedido.FechaCreacion).ToList();
        }
    }
}

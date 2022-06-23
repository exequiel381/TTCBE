using CodeTestTCBackEnd.BL.Contratos;
using CodeTestTCBackEnd.BL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.Repositorios.Memoria
{
    public class PedidoRepositorio : IRepositorio
    {
        private List<Pedido> _pedidos = new List<Pedido>();

        public PedidoRepositorio()
        {
            _pedidos.Add(new Pedido()
            {
                Codigo = 1,
                Direccion = "Junin 2421",
                Estado = Enumeraciones.EstadoPedido.PENDIENTE,
                Mascota = new Perro(10,5,true) 
            });
        }
        
        public void AgregarPedido(Pedido nuevoPedido)
        {
            if (YaExiste(nuevoPedido.Codigo)) throw new Exception("Ya existe un producto con este codigo.");
            _pedidos.Add(nuevoPedido);
        }

        public Pedido BuscarPedido(int codigo)
        {
            return _pedidos.Find(x => x.Codigo == codigo);
        }

        public void EliminarProducto(int codigo)
        {
            if (YaExiste(codigo))
            {
                int indiceEliminar = _pedidos.FindIndex(x => x.Codigo == codigo);
                _pedidos.RemoveAt(indiceEliminar);
            }
        }

        public void ModificarPedido(int codigoActual, Pedido PedidoModificado)
        {
            if (codigoActual != PedidoModificado.Codigo && YaExiste(PedidoModificado.Codigo)) throw new Exception("Ya existe un producto con este codigo.");
            int indiceModificar = _pedidos.FindIndex(x => x.Codigo == codigoActual);
            _pedidos[indiceModificar] = PedidoModificado;
        }

        public int GetNuevoCodigo()
        {
            return _pedidos.Max(p => p.Codigo)+1;
        }

        public List<Pedido> ObtenerLista()
        {
            return _pedidos;
        }

        private bool YaExiste(int codigoConsulta)
        {
            return _pedidos.Exists(x => x.Codigo == codigoConsulta);
        }
    }
}

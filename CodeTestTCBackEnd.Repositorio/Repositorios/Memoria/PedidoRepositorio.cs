using CodeTestTCBackEnd.BL.Modelos;
using CodeTestTCBackEnd.Repositorio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.Repositorio.Repositorios.Memoria
{
    public class PedidoRepositorio : IRepositorio<Pedido>
    {
        private List<Pedido> _pedidos = new List<Pedido>();

        public PedidoRepositorio()
        {
            _pedidos.Add(new Pedido(1, "Junin 2421", "42716480", BL.Enumeraciones.EstadoPedido.PENDIENTE, new Perro(10, 5, true), new DateTime(2022, 6, 22, 12, 32, 30)));
            
        }
        
        public void Agregar(Pedido nuevoPedido)
        {
            if (YaExiste(nuevoPedido.Codigo)) throw new Exception("Ya existe un producto con este codigo.");
            _pedidos.Add(nuevoPedido);
        }

        public Pedido Buscar(int codigo)
        {
            return _pedidos.Find(x => x.Codigo == codigo);
        }

        public void Eliminar(int codigo)
        {
            if (YaExiste(codigo))
            {
                int indiceEliminar = _pedidos.FindIndex(x => x.Codigo == codigo);
                _pedidos.RemoveAt(indiceEliminar);
            }
        }

        public void Modificar(int codigoActual, Pedido PedidoModificado)
        {
            if (codigoActual != PedidoModificado.Codigo && YaExiste(PedidoModificado.Codigo)) throw new Exception("Ya existe un producto con este codigo.");
            int indiceModificar = _pedidos.FindIndex(x => x.Codigo == codigoActual);
            _pedidos[indiceModificar] = PedidoModificado;
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

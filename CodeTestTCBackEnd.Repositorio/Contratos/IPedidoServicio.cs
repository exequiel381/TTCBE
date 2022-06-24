using CodeTestTCBackEnd.BL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.Repositorio.Contratos
{
    public interface IPedidoServicio : IServicio<Pedido>
    {
        int GetNuevoCodigo();
        List<Pedido> ObtenerListaOrdenadaPorFechaAscendente();
    }
}

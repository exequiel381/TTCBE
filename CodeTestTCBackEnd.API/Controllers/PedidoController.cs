using AutoMapper;
using CodeTestTCBackEnd.BL.DTOs;
using CodeTestTCBackEnd.BL.Enumeraciones;
using CodeTestTCBackEnd.BL.Modelos;
using CodeTestTCBackEnd.Repositorio.Contratos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace CodeTestTCBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class PedidoController : Controller
    {
        //Una mejor manera de instanciar los animales segun el tipo en el POST
        private readonly IPedidoServicio _pedidosServicio;
        private readonly IMapper _mapper;
        //@DOC : Inyectamos el servicio y Mapper como un singleton. El servicio para no instanciar nuevamente los datos de memoria, y para usar una sola instancia de ambos
        public PedidoController(IMapper mapper, IPedidoServicio pedidosServicio)
        {
            _mapper = mapper;
            _pedidosServicio = pedidosServicio;
        }

        [HttpGet]
        //@DOC : Brindamos la lista de pedidos ordenadas por tiempo ascendente, para conllevar un estilo de FIFO. 
        public IActionResult GetPedidos()
        {
            var pedidos = _pedidosServicio.ObtenerListaOrdenadaPorFechaAscendente();
            List<GetPedidoDTO> pedidosDTO = new List<GetPedidoDTO>();
            foreach (var pedido in pedidos)
            {
                //@DOC : Utilizamos un AutoMapper , para no devolver datos innecesarios en la consulta, solo los del DTO correspondiente
                var pedidoDTO = _mapper.Map<GetPedidoDTO>(pedido);
                pedidosDTO.Add(pedidoDTO);
            }
            return Ok(pedidosDTO);
        }

        [HttpPost]
        public IActionResult PostPedido(PostPedidoDTO pedidoDTO)
        {
            if (ModelState.IsValid)
            {
                int codigoPedido = _pedidosServicio.GetNuevoCodigo();
                Mascota mascota;
                if (pedidoDTO._tipoMascota == TipoMascota.PERRO)
                {
                    mascota = new Perro(pedidoDTO._mascota._peso, pedidoDTO._mascota._edad, pedidoDTO._mascota._esCastrado);
                }
                else
                {
                    mascota = new Gato(pedidoDTO._mascota._peso, pedidoDTO._mascota._edad, pedidoDTO._mascota._esCastrado);
                }

                Pedido pedido = new Pedido(codigoPedido, pedidoDTO._direccion, pedidoDTO._telefono, EstadoPedido.PENDIENTE, mascota); 
                _pedidosServicio.Agregar(pedido);
                return Ok();
            }
            return BadRequest();
        }

        //@DOC : Una ruta que calcule la cantidad de alimento y le muestre al usuario como quedaria el pedido y decida si aceptarlo o no.
        [HttpPost("confirmationPost")]
        public IActionResult PostPedidoPrev(PostPedidoDTO pedidoDTO)
        {
            if (ModelState.IsValid)
            {
                int codigoPedido = _pedidosServicio.GetNuevoCodigo();
                Mascota mascota;
                if (pedidoDTO._tipoMascota == TipoMascota.PERRO)
                {
                    mascota = new Perro(pedidoDTO._mascota._peso, pedidoDTO._mascota._edad, pedidoDTO._mascota._esCastrado);
                }
                else
                {
                    mascota = new Gato(pedidoDTO._mascota._peso, pedidoDTO._mascota._edad, pedidoDTO._mascota._esCastrado);
                }

                var mascotaDTO = _mapper.Map<GetMascotaDTO>(mascota);
                return Ok(mascotaDTO);
            }
            return BadRequest();
        }

        //@DOC : Podriamos validar , por ejemplo , no permitir pasar de un estado COMPLETADO a CANCELADO, pero no como no es especificado en el dominio , dejo sin validacion.
        [HttpPut("{codigo}")]
        public IActionResult putPedido(int codigo,PutPedidoDTO putPedidoDTO)
        {
            if (ModelState.IsValid)
            {
                Pedido p = _pedidosServicio.Buscar(codigo);
                p.Estado = putPedidoDTO._estado;
                _pedidosServicio.Modificar(codigo, p);
                return Ok();
            }

            return BadRequest();
        }
    }
}

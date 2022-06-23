using AutoMapper;
using CodeTestTCBackEnd.BL.Contratos;
using CodeTestTCBackEnd.BL.DTOs;
using CodeTestTCBackEnd.BL.Enumeraciones;
using CodeTestTCBackEnd.BL.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace CodeTestTCBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class VeterinariaController : Controller
    {
        //Una mejor manera de instanciar los animales segun el tipo en el POST
        private readonly IPedidoServicio _pedidosServicio;
        private readonly IMapper _mapper;

        public VeterinariaController(IMapper mapper, IPedidoServicio pedidosServicio)
        {
            _mapper = mapper;
            _pedidosServicio = pedidosServicio;
        }

        [HttpGet]
        public  List<GetPedidoDTO> GetPedidos()
        {
            var pedidos = _pedidosServicio.ObtenerListaOrdenadaPorFechaAscendente();
            List<GetPedidoDTO> pedidosDTO = new List<GetPedidoDTO>();
            foreach (var pedido in pedidos)
            {
                var pedidoDTO = _mapper.Map<GetPedidoDTO>(pedido);
                pedidosDTO.Add(pedidoDTO);
            }
            return pedidosDTO;
        }

        [HttpPost]
        public ActionResult PostPedido(PostPedidoDTO pedidoDTO)
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


        [HttpPost("confirmationPost")]
        public ActionResult PostPedidoPrev(PostPedidoDTO pedidoDTO)
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

                var mascotaDTO= _mapper.Map<GetMascotaDTO>(mascota);
                return Ok(mascotaDTO);
            }
            return BadRequest();
        }

        [HttpPut("{codigo}")]
        public ActionResult putPedido(int codigo,PutPedidoDTO putPedidoDTO)
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

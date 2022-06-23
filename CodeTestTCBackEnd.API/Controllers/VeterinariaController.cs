using AutoMapper;
using CodeTestTCBackEnd.BL.DTOs;
using CodeTestTCBackEnd.BL.Enumeraciones;
using CodeTestTCBackEnd.BL.Modelos;
using CodeTestTCBackEnd.BL.Repositorios.Memoria;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.API.Controllers
{
    [Route("apiveteriania")]
    [ApiController]
    public class VeterinariaController : Controller
    {
        //Una mejor manera de instanciar los animales segun el tipo en el POST
        //Y otra manera de crear el repo , no se si hara falta hacerlo mas generico

        private readonly PedidoRepositorio _pedidosRepositorio = new PedidoRepositorio();
        private readonly IMapper _mapper;

        public VeterinariaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public  List<GetPedidoDTO> GetPedidos()
        {
            var pedidos = _pedidosRepositorio.ObtenerLista();
            List<GetPedidoDTO> pedidosDTO = new List<GetPedidoDTO>();
            foreach (var pedido in pedidos)
            {
                pedidosDTO.Add(_mapper.Map<GetPedidoDTO>(pedido));
            }
            return pedidosDTO;
        }

        [HttpPost]
        public ActionResult PostPedido(PostPedidoDTO pedidoDTO, TipoMascota tipoMascota)
        {
            if (ModelState.IsValid)
            {
                int codigoPedido = _pedidosRepositorio.GetNuevoCodigo();
                Mascota mascota;
                if (tipoMascota == TipoMascota.PERRO)
                {
                    mascota = new Perro(pedidoDTO._mascota._peso, pedidoDTO._mascota._edad, pedidoDTO._mascota._esCastrado);
                }
                else
                {
                    mascota = new Gato(pedidoDTO._mascota._peso, pedidoDTO._mascota._edad, pedidoDTO._mascota._esCastrado);
                }
                
                Pedido pedido = new Pedido() { Codigo= codigoPedido,Direccion = pedidoDTO._direccion,Estado= EstadoPedido.PENDIENTE,Telefono=pedidoDTO._telefono, Mascota = mascota };
                _pedidosRepositorio.AgregarPedido(pedido);
                return Ok();
            }
            return BadRequest();
        }
    }
}

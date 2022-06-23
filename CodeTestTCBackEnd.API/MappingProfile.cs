using AutoMapper;
using CodeTestTCBackEnd.BL.DTOs;
using CodeTestTCBackEnd.BL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pedido, GetPedidoDTO>();
            CreateMap<Mascota, GetMascotaDTO>();
        }
    }
}

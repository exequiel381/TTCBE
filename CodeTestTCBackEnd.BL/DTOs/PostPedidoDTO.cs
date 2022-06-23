using CodeTestTCBackEnd.BL.Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.DTOs
{
    public class PostPedidoDTO
    {
        [Required]
        public string _direccion { get; set; }
        [Required]
        public string _telefono { get; set; }
        [Required]
        public PostMascotaDTO _mascota { get; set; }
    }
}

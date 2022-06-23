using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.DTOs
{
    public class GetMascotaDTO
    {
        public string _tipoDeMascota { get; set; }
        public int _CantidadComplementosDietarios { get; set; }
        public double _cantidadAlimento { get; set; }

    }
}

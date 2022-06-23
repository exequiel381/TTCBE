using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.DTOs
{
    public class PostMascotaDTO
    {
        [Required]
        public double _peso { get; set; }
        [Required]
        public int _edad { get; set; }
        [Required]
        public bool _esCastrado { get; set; }
       
    }
}

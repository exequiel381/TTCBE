﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.Contratos
{
    public interface IPedidoServicio : IServicio
    {
        int GetNuevoCodigo();
    }
}
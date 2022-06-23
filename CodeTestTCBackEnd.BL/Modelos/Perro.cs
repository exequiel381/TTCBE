using CodeTestTCBackEnd.BL.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.Modelos
{
    public class Perro : Mascota
    {
        public Perro(double peso, int edad, bool esCastrado)
        {
            Peso = peso;
            Edad = edad;
            EsCastrado = esCastrado;
            TipoDeMascota = TipoMascota.PERRO.ToString();
            CalculoDeAlimento();

        }
        public new void CalculoDeAlimento()
        {
            CantidadAlimento = 0.8 * Peso;
            CantidadComplementosDietarios = Edad/3 ;
            
            if (EsCastrado && Edad > 5)
            {
                CantidadComplementosDietarios += 1;
            }
        }
    }
}

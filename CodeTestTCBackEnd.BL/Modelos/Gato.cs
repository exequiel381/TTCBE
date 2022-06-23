using CodeTestTCBackEnd.BL.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.Modelos
{
    public class Gato : Mascota 
    {
        public Gato(double peso, int edad, bool esCastrado)
        {
            Peso = peso;
            Edad = edad;
            EsCastrado = esCastrado;
            TipoDeMascota = TipoMascota.GATO.ToString();
            CalculoDeAlimento();

        }

        //La palabra override se usa generalmente para implementar interfaces (implementar métodos virtuales de clases bases), mientras que new te permite "pisar" o reescribir un método de una clase base, sea virtual o no.
        public new void CalculoDeAlimento()
        {
            CantidadAlimento = 0.5*Peso;
            if(Edad > 5)
            {
                CantidadComplementosDietarios += 1;
            }

            if (EsCastrado)
            {
                CantidadComplementosDietarios += 1;
            }
        }
    }
}

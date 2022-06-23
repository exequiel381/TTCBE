using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestTCBackEnd.BL.Modelos
{
    public class Mascota
    {
        #region Constructores
        public Mascota()
        {

        }

       
        #endregion

        #region Atributos
        private double _peso;
        private int _edad;
        private double _cantidadAlimento;
        private int _CantidadComplementosDietarios = 0;
        private bool _esCastrado = false;
        private string _tipoDeMascota = "Mascota";
        
        #endregion

        #region Propiedades
        public double Peso
        {
            get { return _peso; }
            set { 
                _peso = value;
                CalculoDeAlimento();
            }
        }
        public int Edad
        {
            get { return _edad; }
            set { _edad = value;
                CalculoDeAlimento();
            }
        }
        public double CantidadAlimento
        {
            get { return _cantidadAlimento; }
            set { _cantidadAlimento = value; }
        }

        public int CantidadComplementosDietarios
        {
            get { return _CantidadComplementosDietarios; }
            set { _CantidadComplementosDietarios = value; }
           
        }

        public bool EsCastrado
        {
            get { return _esCastrado; }
            set { _esCastrado = value; }

        }

        public string TipoDeMascota
        {
            get { return _tipoDeMascota; }
            set { _tipoDeMascota = value; }

        }

        #endregion

        #region Metodos
        public void CalculoDeAlimento()
        {
            
        }
        #endregion
    }
}

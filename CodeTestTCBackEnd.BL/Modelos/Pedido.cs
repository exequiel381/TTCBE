using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTestTCBackEnd.BL.Enumeraciones;

namespace CodeTestTCBackEnd.BL.Modelos
{
    public class Pedido
    {
        #region Constructores
        public Pedido()
        {

        }

        public Pedido(string direccion, string telefono, EstadoPedido estado, Mascota mascota)
        {
            _direccion = direccion;
            _telefono = telefono;
            _estado = estado;
            _mascota = mascota;
        }


        #endregion
        #region Atributos
        private int _codigo;
        private string _direccion;
        private string _telefono;
        private EstadoPedido _estado;
        private Mascota _mascota;

        #endregion
        #region Propiedades
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public EstadoPedido Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public Mascota Mascota
        {
            get { return _mascota; }
            set { _mascota = value; }
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        #endregion
        #region Metodos
        #endregion
    }
}

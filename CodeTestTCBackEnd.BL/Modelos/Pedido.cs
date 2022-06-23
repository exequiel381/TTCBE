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

        public Pedido(int codigo,string direccion, string telefono, EstadoPedido estado, Mascota mascota)
        {
            _codigo = codigo;
            _direccion = direccion;
            _telefono = telefono;
            _estado = estado;
            _mascota = mascota;
            _fechaCreacion = DateTime.Now;
        }

        public Pedido(int codigo, string direccion, string telefono, EstadoPedido estado, Mascota mascota,DateTime fechaCreacion)
        {
            _codigo = codigo;
            _direccion = direccion;
            _telefono = telefono;
            _estado = estado;
            _mascota = mascota;
            _fechaCreacion = fechaCreacion;
        }


        #endregion
        #region Atributos
        private int _codigo;
        private string _direccion;
        private string _telefono;
        private EstadoPedido _estado;
        private Mascota _mascota;
        private DateTime _fechaCreacion;

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

        public string FechaCreacion
        {
            get { return _fechaCreacion.ToString("dd/MM/yyyy HH:mm"); }
            
        }
        #endregion

    }
}

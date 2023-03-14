using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalASP.Modelos
{
    public class Chat
    {
        int idMensaje;
        int fkIDEvento;
        int fkIDUsuario;
        string mensaje;

        public Chat()
        {

        }
        public Chat(int idMensaje, int fkIDEvento, int fkIDUsuario, string mensaje)
        {
            this.idMensaje = idMensaje;
            this.fkIDEvento = fkIDEvento;
            this.fkIDUsuario = fkIDUsuario;
            this.mensaje = mensaje;
        }

        public int IdMensaje { get => idMensaje; set => idMensaje = value; }
        public int FkIDEvento { get => fkIDEvento; set => fkIDEvento = value; }
        public int FkIDUsuario { get => fkIDUsuario; set => fkIDUsuario = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
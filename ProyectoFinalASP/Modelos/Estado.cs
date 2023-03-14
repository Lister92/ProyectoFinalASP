using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalASP.Modelos
{
    public class Estado
    {
        int idEstado;
        string estadoDescripcion;

        public Estado()
        {

        }
        public Estado(int idEstado, string estadoDescripcion)
        {
            this.idEstado = idEstado;
            this.estadoDescripcion = estadoDescripcion;
        }

        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string EstadoDescripcion { get => estadoDescripcion; set => estadoDescripcion = value; }
    }
}
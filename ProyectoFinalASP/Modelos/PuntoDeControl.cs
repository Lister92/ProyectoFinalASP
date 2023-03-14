using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace ProyectoFinalASP.Modelos
{
    public class PuntoDeControl
    {
        int idPuntoDeControl;
        int fkIDRuta;
        decimal point;
        string descripcion;

        public PuntoDeControl()
        {

        }
        public PuntoDeControl(int idPuntoDeControl, int fkIDRuta, decimal point, string descripcion)
        {
            this.idPuntoDeControl = idPuntoDeControl;
            this.fkIDRuta = fkIDRuta;
            this.point = point;
            this.descripcion = descripcion;
        }

        public int IdPuntoDeControl { get => idPuntoDeControl; set => idPuntoDeControl = value; }
        public int FkIDRuta { get => fkIDRuta; set => fkIDRuta = value; }
        public decimal Point { get => point; set => point = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
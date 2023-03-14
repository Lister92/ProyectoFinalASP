using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalASP.Modelos
{
    public class Evento
    {
        int idEvento;
        int fkIDRuta;
        bool esPublico;
        DateTime? fechaDeRealizacion;
        int? voluntariosNecesarios;
        int fkIDEstado;

        public Evento()
        {

        }
        public Evento(int fkIDRuta, bool esPublico, DateTime? fechaDeRealizacion, int? voluntariosNecesarios, int fkIDEstado)
        {
            this.fkIDRuta = fkIDRuta;
            this.esPublico = esPublico;
            this.fechaDeRealizacion = fechaDeRealizacion;
            this.voluntariosNecesarios = voluntariosNecesarios;
            this.fkIDEstado = fkIDEstado;
        }
        public Evento(int idEvento, int fkIDRuta, bool esPublico, DateTime? fechaDeRealizacion, int? voluntariosNecesarios, int fkIDEstado)
        {
            this.idEvento = idEvento;
            this.fkIDRuta = fkIDRuta;
            this.esPublico = esPublico;
            this.fechaDeRealizacion = fechaDeRealizacion;
            this.voluntariosNecesarios = voluntariosNecesarios;
            this.fkIDEstado = fkIDEstado;
        }

        public int IdEvento { get => idEvento; set => idEvento = value; }
        public int FkIDRuta { get => fkIDRuta; set => fkIDRuta = value; }
        public bool EsPublico { get => esPublico; set => esPublico = value; }
        public DateTime? FechaDeRealizacion { get => fechaDeRealizacion; set => fechaDeRealizacion = value; }
        public int? VoluntariosNecesarios { get => voluntariosNecesarios; set => voluntariosNecesarios = value; }
        public int FkIDEstado { get => fkIDEstado; set => fkIDEstado = value; }
    }
}
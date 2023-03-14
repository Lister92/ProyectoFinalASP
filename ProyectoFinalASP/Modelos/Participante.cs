using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalASP.Modelos
{
    public class Participante
    {
        int fkIDEvento;
        int fkIDUsuario;
        int? valoracionRuta;
        string comentarioRuta;

        public Participante()
        {

        }
        public Participante(int fkIDEvento, int fkIDUsuario)
        {
            this.fkIDEvento = fkIDEvento;
            this.fkIDUsuario = fkIDUsuario;
        }
        public Participante(int fkIDEvento, int fkIDUsuario, int? valoracionRuta, string comentarioRuta)
        {
            this.fkIDEvento = fkIDEvento;
            this.fkIDUsuario = fkIDUsuario;
            this.valoracionRuta = valoracionRuta;
            this.comentarioRuta = comentarioRuta;
        }

        public int FkIDEvento { get => fkIDEvento; set => fkIDEvento = value; }
        public int FkIDUsuario { get => fkIDUsuario; set => fkIDUsuario = value; }
        public int? ValoracionRuta { get => valoracionRuta; set => valoracionRuta = value; }
        public string ComentarioRuta { get => comentarioRuta; set => comentarioRuta = value; }
    }
}
using ProyectoFinalASP.DAL;
using ProyectoFinalASP.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalASP
{
    public partial class EventosDisponibles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            DALEvento eventoDal = new DALEvento();
            DALRuta rutaDal = new DALRuta();
            DALUsuario usuarioDal = new DALUsuario();
            DALParticipante participanteDal = new DALParticipante();
            List<Evento> eventos = new List<Evento>();
            Ruta ruta = new Ruta();
            Usuario user = new Usuario();
            int countElement = 0;

            eventos = eventoDal.SelectEventosOrderByFecha();
            foreach (var evento in eventos)
            {
                ruta = rutaDal.SelectRutaByIdRuta(evento.FkIDRuta);
                user = usuarioDal.SelectUsuarioByIDUsuario(ruta.FkIDUsuario);
                sb.Append(" <div class='border border-3 rounded m-2 p-4'>");
                sb.Append("     <div id='base1' class='row'>");
                sb.Append("         <div class='col-10'>");
                sb.Append("             <label class='h3' id='lblRuta'>"+ ruta.Nombre +"</label>");
                sb.Append("             <label class='form-label' id='lblCreador'> por "+ user.ToString() + "</label>");
                sb.Append("         </div>");
                sb.Append("         <div class='col-1'>");
                sb.Append("             <img src='Media/iconusers.png' alt='Participantes del evento' width='20px' />");
                sb.Append("             <label class='form-label' id='numUsuarios'>"+ participanteDal.SelectCountParticipantesByIdEvento(evento.IdEvento).ToString() +"</label>");
                sb.Append("         </div>");
                sb.Append("         <div class='col-1'>");
                sb.Append("             <img src='Media/iconhandshake.png' alt='Voluntarios apuntados' width='20px' />");
                sb.Append("             <label class='form-label' id='numVoluntarios'>" + participanteDal.SelectCountParticipantesVoluntariosByIdEvento(evento.IdEvento).ToString() + "</label>");
                sb.Append("         </div>");
                sb.Append("     </div>");
                sb.Append("     <div id='base2' class='row'>");
                sb.Append("         <div class='col-10'>");
                sb.Append("             <label class='h5' id='lblFecha'>" + evento.FechaDeRealizacion.Value.ToString("dd/MM/yyyy") + "</label>");
                sb.Append("             <label class='h5' id='lblHora'>" + evento.FechaDeRealizacion.Value.ToString("HH:mm") + "</label>");
                sb.Append("         </div>");
                sb.Append("         <div class='col-2'>");
                sb.Append("             <button type='button' class='btn btn-outline-dark' onClick='irEvento(" + evento.IdEvento + ")' id='btnVerEvento'>Ver Evento</button>");
                sb.Append("         </div>");
                sb.Append("     </div>");
                sb.Append(" </div>");

                countElement++;
                ltEventosDisponibles.Text = sb.ToString();
            }
            
        }
    }
}


//sb.Append("         <div class='col-2'>");
//sb.Append("             <label class='form-label' id='lblKm'>Km: " + ((int)ruta.LongitudKm) + "</label><br />");
//sb.Append("             <label class='form-label' id='lblAccesibilidad'>Accesibilidad: " + ruta.NivelAccesibilidad + "</label><br />");
//sb.Append("         </div>");
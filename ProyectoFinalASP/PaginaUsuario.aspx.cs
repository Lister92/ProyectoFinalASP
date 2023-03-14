using ProyectoFinalASP.DAL;
using ProyectoFinalASP.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalASP
{
    public partial class PaginaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = -1;
            
            try
            {
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                id = int.Parse(reqCookies["id"]);
            }
            catch (NullReferenceException ex)
            {
                Response.Redirect("PaginaPrincipal");
            }
            
            StringBuilder sb = new StringBuilder();
            StringBuilder sbEv = new StringBuilder();
            DALEvento eventoDal = new DALEvento();
            DALRuta rutaDal = new DALRuta();
            DALParticipante participanteDal = new DALParticipante();
            DALUsuario usuarioDal = new DALUsuario();
            DALEstado estadoDal = new DALEstado();
            List<Evento> eventos = new List<Evento>();
            Usuario user = new Usuario();
            Ruta ruta = new Ruta();
            Estado estado = new Estado();

            //Se le pasa un valor al evento hasta que se lo enviemos desde otro lado
            user = usuarioDal.SelectUsuarioByIDUsuario(id);
            Debug.WriteLine(id);

            sb.Append(" <div id ='base1' class='row border border-3 rounded mt-2 p-2'>");
            sb.Append("     <div class='col-2'>");
            sb.Append("         <img src='Media/iconpfp.png' alt='Participantes del evento' class='w-100 rounded' />");
            sb.Append("         <label class='h4 w-100 text-center' id='lblNombre'>" + user.ToString() + "</label><br/>");
            //sb.Append("         <label class='form-label' id='lblTipo'>" + user.Tipo() + "</label><br/>");
            sb.Append("     </div>");
            sb.Append("     <div class='col-6 pt-4'>");
            sb.Append("         <img src='Media/iconlocation.png' alt='Localidad del usuario' width='20px' />");
            sb.Append("         <label class='h5 mb-3' id='lblLocalidad'>" + user.Localidad + "</label><br/>");
            sb.Append("         <img src='Media/iconmail.png' alt='Correo electronico del usuario' width='20px' />");
            sb.Append("         <label class='h5 mb-3' id='lblEmail'>" + user.Email + "</label><br/>");
            sb.Append("         <img src='Media/icontelef.png' alt='Numero de telefono del usuario' width='20px' />");
            sb.Append("         <label class='h5 mb-3' id='lblTelefono'>" + user.Telefono + "</label>");
            sb.Append("     </div>");
            if (user.EsMinusvalido)
            {
                sb.Append("     <div class='col-3  pt-4'>");
                sb.Append("         <label class='form-label' id='lblTipoMinusvalia'>Minusvalia: " + user.TipoMinusvalia + "</label><br/>");
                sb.Append("         <label class='form-label' id='lblPorcentajeMinusvalia'>Porcentaje: " + user.PorcentajeMinusvalia + "%</label><br/>");
                sb.Append("         <label class='form-label' id='lblDependencia'>Dependencia: " + user.Dependencias + "</label>");
                sb.Append("     </div>");
            }
            sb.Append(" </div>");

            ltPaginaUsuario.Text = sb.ToString();

            // Eventos del Usuario
            eventos = eventoDal.SelectEventosByIdUsuarioOrderEstado(user.IdUsuario);
            if (eventos.Count > 0)
            {
                foreach (var evento in eventos)
                {
                    ruta = rutaDal.SelectRutaByIdRuta(evento.FkIDRuta);
                    user = usuarioDal.SelectUsuarioByIDUsuario(ruta.FkIDUsuario);
                    estado = estadoDal.SelectEstadoByIdEstado(evento.FkIDEstado);
                    switch (estado.IdEstado)
                    {
                        case 1:
                            sbEv.Append("         <div class='row border border-primary border-3 rounded-pill p-4 my-3'>");
                            break;
                        case 2:
                            sbEv.Append("         <div class='row border border-success border-3 rounded-pill p-4'>");
                            break;
                        case 3:
                            sbEv.Append("         <div class='row border border-danger border-3 rounded-pill p-4'>");
                            break;
                        case 4:
                            sbEv.Append("         <div class='row border border-dark border-3 rounded-pill p-4'>");
                            break;
                        default:
                            sbEv.Append("         <div class='row border bg-info border-3 rounded-pill p-4'>");
                            break;
                    }

                    sbEv.Append("         <label class='form-label' id='lblEstado'>Evento " + estado.EstadoDescripcion + "</label>");
                    sbEv.Append("     <div id='base1' class='row'>");
                    sbEv.Append("         <div class='col-10'>");
                    sbEv.Append("             <label class='h3' id='lblRuta'>" + ruta.Nombre + "</label>");
                    sbEv.Append("             <label class='form-label' id='lblCreador'> por " + user.ToString() + "</label>");
                    sbEv.Append("         </div>");
                    sbEv.Append("         <div class='col-1'>");
                    sbEv.Append("             <img src='Media/iconusers.png' alt='Participantes del evento' width='20px' />");
                    sbEv.Append("             <label class='form-label' id='numUsuarios'>" + participanteDal.SelectCountParticipantesByIdEvento(evento.IdEvento).ToString() + "</label>");
                    sbEv.Append("         </div>");
                    sbEv.Append("         <div class='col-1'>");
                    sbEv.Append("             <img src='Media/iconhandshake.png' alt='Voluntarios apuntados' width='20px' />");
                    sbEv.Append("             <label class='form-label' id='numVoluntarios'>" + participanteDal.SelectCountParticipantesVoluntariosByIdEvento(evento.IdEvento).ToString() + "</label>");
                    sbEv.Append("         </div>");
                    sbEv.Append("     </div>");
                    sbEv.Append("     <div id='base2' class='row'>");
                    sbEv.Append("         <div class='col-10'>");
                    sbEv.Append("             <label class='h5' id='lblFecha'>" + evento.FechaDeRealizacion.Value.ToString("dd/MM/yyyy") + "</label>");
                    sbEv.Append("             <label class='h5' id='lblHora'>" + evento.FechaDeRealizacion.Value.ToString("HH:mm") + "</label>");
                    sbEv.Append("         </div>");
                    sbEv.Append("         <div class='col-2'>");
                    sbEv.Append("             <button type='button' class='btn btn-outline-dark' onClick='irEvento(" + evento.IdEvento + ")' id='btnVerEvento'>Ver Evento</button>");
                    sbEv.Append("         </div>");
                    sbEv.Append("     </div>");
                    sbEv.Append(" </div>");

                    ltPaginaUsuarioEventos.Text = sbEv.ToString();
                }
            }
            else
            {
                Label1.Text = "Aún no te has apuntado a ningún evento... :(<br>¡Apúntate para disfrutar de la experiencia completa de MoviRutas!";
                Button1.Visible = true;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventosDisponibles");
        }
    }
}
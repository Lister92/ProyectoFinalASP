using Microsoft.Ajax.Utilities;
using ProyectoFinalASP.DAL;
using ProyectoFinalASP.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ProyectoFinalASP
{
    public partial class RutasDisponibles : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            DALRuta rutaDal = new DALRuta();
            List<Ruta> rutas = new List<Ruta>();
            int countElement = 0;

            rutas = rutaDal.SelectRutasOrderByLocalizacion();
            foreach (var ruta in rutas)
            {
                sb.Append("<div class='border border-4 rounded m-2 p-4'>");
                sb.Append(" <div id='base' class='row'>");
                sb.Append("     <div class='col-6'>");
                sb.Append("         <label class='h3' id='lblRuta'>" + ruta.Nombre + ", " + ruta.Localizacion + "</label>");
                sb.Append("     </div>");
                sb.Append("     <div class='col-2'>");
                sb.Append("         <img src='Media/iconroad.png' alt='Kilometros de distancia' width='20px' />");
                sb.Append("         <label class='form-label' id='lblLongitud'> " + ((int)ruta.LongitudKm) + " km </label>");
                sb.Append("     </div>");
                sb.Append("     <div class='col-2'>");
                sb.Append("         <img src='Media/iconwheelchair.png' alt='Adaptabilidad de la ruta' width='20px' />");
                sb.Append("         <label class='form-label' id='lblLocalizacion'>" + ruta.NivelAccesibilidad + "/5</label>");
                sb.Append("     </div>");
                sb.Append("     <div class='col-2'>");
                sb.Append("         <img src='Media/iconstar.png' alt='Valoracion de la ruta' width='20px' />");
                sb.Append("         <label class='form-label' id='lblValoracion'> " + ruta.ValoracionMedia + " </label><br />");
                sb.Append("     </div>");
                sb.Append(" </div>");
                sb.Append(" <div id='base2' class='row'>");
                sb.Append("     <div class='col-4'>");
                sb.Append("         <img src='/Media/" + ruta.ImageMap + "' class='img-thumbnail' alt='" + ruta.Descripcion + "'>");
                sb.Append("     </div>");
                sb.Append("     <div class='col-4'>");
                sb.Append("         <img src='/Media/" + ruta.ImageZone + "' class='img-thumbnail' alt='" + ruta.Descripcion + "'>");
                sb.Append("     </div>");
                sb.Append("     <div class='col-4'>");
                sb.Append("         <label class='form-label' id='lblDescripcion'>" + ruta.Descripcion + "</label>");
                sb.Append("     </div>");
                sb.Append(" </div>");
                sb.Append(" <div>");
                sb.Append("     <button type='button' class='btn btn-outline-dark my-4 w-25' onClick='irRuta(" + ruta.IdRuta + ")' id='btnVerRuta'>Ver Detalles</button><br />");
                sb.Append(" </div>");
                sb.Append("</div>");
                countElement++;
                ltRutasDisponibles.Text = sb.ToString();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalASP.DAL;
using ProyectoFinalASP.Modelos;

namespace ProyectoFinalASP
{
    public partial class Register : System.Web.UI.Page
    {
        DALUsuario dalUsuario = new DALUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinuarRegistro_Click(object sender, EventArgs e)
        {

            string email = emailBox.Text;

            errorEmail.InnerText = " ";
            errorEmailV2.InnerText = " ";
            errorPassword.InnerText = " ";
            errorPasswordV2.InnerText = " ";

            if (Regex.IsMatch(email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                if (emailBox.Text != rEmailBox.Text || passwordBox.Text != rPasswordBox.Text)
                {
                    if (emailBox.Text != rEmailBox.Text)
                    {
                        errorEmailV2.InnerText = "El correo no coincide";
                    }
                    if (passwordBox.Text != rPasswordBox.Text)
                    {
                        errorPasswordV2.InnerText = "La contraseña no coincide";
                    }
                }
                else
                {
                    bool emailCheck = dalUsuario.SelectUsuarioByEmail(email);
                    if (!emailCheck)
                    {
                        Session["email"] = emailBox.Text;
                        Session["password"] = passwordBox.Text;
                        Response.Redirect("RegisterManual");
                    }
                    else
                    {
                        errorEmail.InnerText = "El usuario ya existe";
                    }
                }
            }
            else
            {
                errorEmail.InnerText = "El correo electrónico no es válido";
            }
        }
    }
}
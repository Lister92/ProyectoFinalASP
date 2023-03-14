using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalASP.DAL;
using ProyectoFinalASP.Modelos;

namespace ProyectoFinalASP
{
    public partial class Login : System.Web.UI.Page
    {
        DALUsuario dalUsuario = new DALUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string loginEmail = emailBox.Text;
            string loginPassword = passwordBox.Text;

            string hash = dalUsuario.SelectUserHashByEmail(loginEmail);

            if (hash != null)
            {
                // Verify
                bool result = Hash.SecurePasswordHasher.Verify(loginPassword, hash); // Comprueba si la contraseña es válida para el hash específico.

                Usuario usuario = new Usuario();
                if (result == true)
                {
                    usuario = dalUsuario.SelectUsuarioByEmailPassword(loginEmail, hash); // Si es true seleccionamos el usuario por el email + password (hash en BDD)

                    if (usuario != null)
                    {
                        labelEmailPassword.Text = "Credenciales correctas";

                        HttpCookie userInfo = new HttpCookie("userInfo");

                        userInfo["id"] = usuario.IdUsuario.ToString();
                        userInfo["username"] = usuario.Nombre;
                        userInfo["surname"] = usuario.Apellidos;

                        userInfo.Secure = true;

                        Response.Cookies.Add(userInfo);

                        Response.Redirect("PaginaPrincipal");
                    }

                }
                else
                    labelEmailPassword.Text = "La contraseña es incorrecta.";
            }
            else
                labelEmailPassword.Text = "El email introducido no existe.";

        }
    }
}
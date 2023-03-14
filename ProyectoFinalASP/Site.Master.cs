using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalASP
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                string username = reqCookies["username"];
                string surname = reqCookies["surname"];
                textoUserLogin.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bienvenid@, " + username + " " + surname;

                Register.Visible = false;
                Login.Visible = false;
            }
            else
            {
                textoUserLogin.Visible = false;
                Logout.Visible = false;
                PagUser.Visible = false;
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("PaginaPrincipal");
        }
    }
}
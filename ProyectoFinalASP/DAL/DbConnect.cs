using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProyectoFinalASP.DAL
{
    public class DbConnect
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        SqlConnection cnx;
        // SqlConnection cnx = new SqlConnection("Data Source=46.183.116.173,54321;Initial Catalog=GrupoRutas;User ID=GrupoRutas;Password=4e5r448r5g585op265;");

        public DbConnect()
        {
            builder.DataSource = "46.183.116.173, 54321";
            builder.InitialCatalog = "GrupoRutas";
            builder.PersistSecurityInfo = true;
            builder.UserID = "GrupoRutas";
            builder.Password = "4e5r448r5g585op265";

            cnx = new SqlConnection(builder.ConnectionString);
        }

        public SqlConnection MiCnx { get => cnx; set => cnx = value; }
    }
}
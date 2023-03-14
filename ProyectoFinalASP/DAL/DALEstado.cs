using ProyectoFinalASP.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinalASP.DAL
{
    public class DALEstado
    {
        DbConnect cnx;
        public DALEstado()
        {
            cnx = new DbConnect();
        }
        public Estado SelectEstadoByIdEstado(int idEstado)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            Estado estado = null;

            try
            {
                string sql = "SELECT * FROM Estado WHERE IDEstado=@pIdEstado";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pIdEstado = new SqlParameter("@pIdEstado", idEstado);
                cmd.Parameters.Add(pIdEstado);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estado = new Estado();
                    estado.IdEstado = (int)dr["IDEstado"];
                    estado.EstadoDescripcion = (string)(dr["EstadoDescripcion"]);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en Insert: " + ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cnx.MiCnx.Close();
            }

            return estado;
        }
    }
}
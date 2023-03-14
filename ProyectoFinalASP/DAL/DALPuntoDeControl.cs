using ProyectoFinalASP.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinalASP.DAL
{
    public class DALPuntoDeControl
    {
        DbConnect cnx;
        public DALPuntoDeControl()
        {
            cnx = new DbConnect();
        }
        public void InsertPuntoDeControl(PuntoDeControl puntoDeControl)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            try
            {
                string sql = @"INSERT INTO PuntoDeControl 
                    (FKRutaID, Coordenada, Descripcion)
                    VALUES (@pFKRutaID,
                        @pCoordenada,
                        @pDescripcion)";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pFKRutaID = new SqlParameter("@pFKRutaID", System.Data.SqlDbType.Int);
                pFKRutaID.Value = puntoDeControl.FkIDRuta;
                //SqlParameter pCoordenada = new SqlParameter("@pCoordenada", System.Data.SqlDbType.Udt);
                //pCoordenada.Value = puntoDeControl.Point;
                SqlParameter pDescripcion = new SqlParameter("@pDescripcion", System.Data.SqlDbType.NVarChar, 200);
                pDescripcion.Value = puntoDeControl.Descripcion;

                cmd.Parameters.Add(pFKRutaID);
                //cmd.Parameters.Add(pCoordenada);
                cmd.Parameters.Add(pDescripcion);

                cmd.ExecuteNonQuery();
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
        }
        
        public List<PuntoDeControl> SelectPuntosDeControlByIdRuta(int idRuta)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            List<PuntoDeControl> puntosDeControl = new List<PuntoDeControl>();
            PuntoDeControl puntoDeControl = null;

            try
            {
                string sql = "SELECT * FROM PuntoDeControl WHERE FKRutaID=@pfkIDRuta ORDER BY IDPuntoDeControl";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pfkIDRuta = new SqlParameter("@pfkIDRuta", idRuta);
                cmd.Parameters.Add(pfkIDRuta);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    puntoDeControl = new PuntoDeControl();
                    puntoDeControl.IdPuntoDeControl = (int)dr["IDPuntoDeControl"];
                    puntoDeControl.FkIDRuta = (int)(dr["FKRutaID"]);
                    puntoDeControl.Point = (decimal)(dr["Punto"]);
                    puntoDeControl.Descripcion = (string)GestionarNulos(dr["Descripcion"]);

                    puntosDeControl.Add(puntoDeControl);
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

            return puntosDeControl;
        }
        public object GestionarNulos(object valOriginal)
        {
            if (valOriginal == System.DBNull.Value)
                return null;
            else
                return valOriginal;
        }
    }
}
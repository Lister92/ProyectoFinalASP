using ProyectoFinalASP.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinalASP.DAL
{
    public class DALRuta
    {
        DbConnect cnx;
        public DALRuta()
        {
            cnx = new DbConnect();
        }
        public void InsertRuta(Ruta ruta)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            try
            {
                string sql = @"INSERT INTO Ruta 
                    (Nombre, LongitudKm, NivelAccesibilidad, 
                    Localizacion, ValoracionMedia, FKIDUsuario, 
                    Descripcion, ImageZone, ImageMap)
                    VALUES (@pNombre,
                        @pLongitudKm,
                        @pNivelAccesibilidad,
                        @pLocalizacion,
                        @pValoracionMedia,
                        @pFKIDUsuario,
                        @pDescripcion,
                        @pImageZone,
                        @pImageMap)";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pNombre = new SqlParameter("@pNombre", System.Data.SqlDbType.NVarChar, 50);
                pNombre.Value = ruta.Nombre;
                SqlParameter pLongitudKm = new SqlParameter("@pLongitudKm", System.Data.SqlDbType.Decimal);
                pLongitudKm.Value = ruta.LongitudKm;
                SqlParameter pNivelAccesibilidad = new SqlParameter("@pNivelAccesibilidad", System.Data.SqlDbType.Int);
                pNivelAccesibilidad.Value = ruta.NivelAccesibilidad;
                SqlParameter pLocalizacion = new SqlParameter("@pLocalizacion", System.Data.SqlDbType.NVarChar, 200);
                pLocalizacion.Value = ruta.Localizacion;
                SqlParameter pValoracionMedia = new SqlParameter("@pValoracionMedia", System.Data.SqlDbType.Decimal);
                pValoracionMedia.Value = ruta.ValoracionMedia;
                SqlParameter pFKIDUsuario = new SqlParameter("@pFKIDUsuario", System.Data.SqlDbType.Int);
                pFKIDUsuario.Value = ruta.FkIDUsuario;
                SqlParameter pDescripcion = new SqlParameter("@pDescripcion", System.Data.SqlDbType.NVarChar, 400);
                pDescripcion.Value = ruta.Descripcion;
                SqlParameter pImageZone = new SqlParameter("@pImageZone", System.Data.SqlDbType.NVarChar, 50);
                pImageZone.Value = ruta.Descripcion;
                SqlParameter pImageMap = new SqlParameter("@pImageMap", System.Data.SqlDbType.NVarChar, 50);
                pImageMap.Value = ruta.Descripcion;

                cmd.Parameters.Add(pNombre);
                cmd.Parameters.Add(pLongitudKm);
                cmd.Parameters.Add(pNivelAccesibilidad);
                cmd.Parameters.Add(pLocalizacion);
                cmd.Parameters.Add(pValoracionMedia);
                cmd.Parameters.Add(pFKIDUsuario);
                cmd.Parameters.Add(pDescripcion);
                cmd.Parameters.Add(pImageZone);
                cmd.Parameters.Add(pImageMap);

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
        public List<Ruta> SelectRutasOrderByLocalizacion()
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            List<Ruta> rutas = new List<Ruta>();
            Ruta ruta;

            try
            {
                string sql = "SELECT * FROM Ruta ORDER BY Localizacion";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ruta = new Ruta();
                    ruta.IdRuta = (int)dr["RutaID"];
                    ruta.Nombre = (string)(dr["Nombre"]);
                    ruta.LongitudKm = (decimal)(dr["LongitudKm"]);
                    ruta.NivelAccesibilidad = (int)(dr["NivelAccesibilidad"]);
                    ruta.Localizacion = (string)(dr["Localizacion"]);
                    ruta.ValoracionMedia = (decimal?)GestionarNulos(dr["ValoracionMedia"]);
                    ruta.FkIDUsuario = (int)(dr["FKIDUsuario"]);
                    ruta.Descripcion = (string)(dr["Descripcion"]);
                    ruta.ImageZone = (string)(dr["ImageZone"]);
                    ruta.ImageMap = (string)(dr["ImageMap"]);

                    rutas.Add(ruta);
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

            return rutas;
        }
        public List<Ruta> SelectRutasByLocalizacion(string localizacion)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            List<Ruta> rutas = new List<Ruta>();
            Ruta ruta = null;

            try
            {
                string sql = "SELECT * FROM Ruta WHERE Localizacion=@pLocalizacion";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pLocalizacion = new SqlParameter("@pLocalizacion", localizacion);
                cmd.Parameters.Add(pLocalizacion);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ruta = new Ruta();
                    ruta.IdRuta = (int)dr["RutaID"];
                    ruta.Nombre = (string)(dr["Nombre"]);
                    ruta.LongitudKm = (decimal)(dr["LongitudKm"]);
                    ruta.NivelAccesibilidad = (int)(dr["NivelAccesibilidad"]);
                    ruta.Localizacion = (string)(dr["Localizacion"]);
                    ruta.ValoracionMedia = (decimal?)GestionarNulos(dr["ValoracionMedia"]);
                    ruta.FkIDUsuario = (int)(dr["FKIDUsuario"]);
                    ruta.Descripcion = (string)(dr["Descripcion"]);
                    ruta.ImageZone = (string)(dr["ImageZone"]);
                    ruta.ImageMap = (string)(dr["ImageMap"]);

                    rutas.Add(ruta);
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

            return rutas;
        }
        public Ruta SelectRutaByIdRuta(int idRuta)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            Ruta ruta = null;

            try
            {
                string sql = "SELECT * FROM Ruta WHERE RutaID=@pIdRuta";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pIdRuta = new SqlParameter("@pIdRuta", idRuta);
                cmd.Parameters.Add(pIdRuta);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ruta = new Ruta();
                    ruta.IdRuta = (int)dr["RutaID"];
                    ruta.Nombre = (string)(dr["Nombre"]);
                    ruta.LongitudKm = (decimal)(dr["LongitudKm"]);
                    ruta.NivelAccesibilidad = (int)(dr["NivelAccesibilidad"]);
                    ruta.Localizacion = (string)(dr["Localizacion"]);
                    ruta.ValoracionMedia = (decimal?)GestionarNulos(dr["ValoracionMedia"]);
                    ruta.FkIDUsuario = (int)(dr["FKIDUsuario"]);
                    ruta.Descripcion = (string)(dr["Descripcion"]);
                    ruta.ImageZone = (string)(dr["ImageZone"]);
                    ruta.ImageMap = (string)(dr["ImageMap"]);

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

            return ruta;
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
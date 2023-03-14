using ProyectoFinalASP.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProyectoFinalASP.DAL
{
    public class DALParticipante
    {
        DbConnect cnx;
        public DALParticipante()
        {
            cnx = new DbConnect();
        }
        public void InsertParticipante(Participante participante)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            try
            {
                string sql = @"INSERT INTO Participante 
                    (FKEventoID, FKUsuarioID)
                    VALUES (@pFKEventoID,
                        @pFKUsuarioID)";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pFKEventoID = new SqlParameter("@pFKEventoID", System.Data.SqlDbType.Int);
                pFKEventoID.Value = participante.FkIDEvento;
                SqlParameter pFKUsuarioID = new SqlParameter("@pFKUsuarioID", System.Data.SqlDbType.Int);
                pFKUsuarioID.Value = participante.FkIDUsuario;

                cmd.Parameters.Add(pFKEventoID);
                cmd.Parameters.Add(pFKUsuarioID);

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

        public void InsertParticipanteValoracion(Participante participante)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            try
            {
                string sql = @"INSERT INTO Participante 
                    (FKEventoID, FKUsuarioID, ValoracionRuta, ComentarioRuta)
                    VALUES (@pFKEventoID,
                        @pFKUsuarioID,
                        @pValoracionRuta,
                        @pComentarioRuta)";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pFKEventoID = new SqlParameter("@pFKEventoID", System.Data.SqlDbType.Int);
                pFKEventoID.Value = participante.FkIDEvento;
                SqlParameter pFKUsuarioID = new SqlParameter("@pFKUsuarioID", System.Data.SqlDbType.Int);
                pFKUsuarioID.Value = participante.FkIDUsuario;
                SqlParameter pValoracionRuta = new SqlParameter("@pValoracionRuta", System.Data.SqlDbType.Int);
                pValoracionRuta.Value = participante.ValoracionRuta;
                SqlParameter pComentarioRuta = new SqlParameter("@pComentarioRuta", System.Data.SqlDbType.NVarChar, 400);
                pComentarioRuta.Value = participante.ComentarioRuta;

                cmd.Parameters.Add(pFKEventoID);
                cmd.Parameters.Add(pFKUsuarioID);
                cmd.Parameters.Add(pValoracionRuta);
                cmd.Parameters.Add(pComentarioRuta);

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

        public Participante SelectParticipanteByIdEvento(int idUser, int idEvento)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            Participante participante = null;

            try
            {
                string sql = "SELECT * FROM Participante WHERE FKEventoID=@pfkIDEvento AND FKUsuarioID=@pfkIDUsuario";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pfkIDEvento = new SqlParameter("@pfkIDEvento", idEvento);
                cmd.Parameters.Add(pfkIDEvento);
                SqlParameter pfkIDUsuario = new SqlParameter("@pfkIDUsuario", idUser);
                cmd.Parameters.Add(pfkIDUsuario);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    participante = new Participante();
                    participante.FkIDEvento = (int)dr["FKEventoID"];
                    participante.FkIDUsuario = (int)(dr["FKUsuarioID"]);
                    participante.ValoracionRuta = (int?)GestionarNulos(dr["ValoracionRuta"]);
                    participante.ComentarioRuta = (string)GestionarNulos(dr["ComentarioRuta"]);
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

            return participante;
        }

        public void DeleteParticipanteByIdEvento(int idEvento, int idUser)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            try
            {
                string sql = "DELETE FROM Participante WHERE FKEventoID=@pfkIDEvento AND FKUsuarioID=@pfkIDUsuario";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pfkIDEvento = new SqlParameter("@pfkIDEvento", idEvento);
                cmd.Parameters.Add(pfkIDEvento);
                SqlParameter pfkIDUsuario = new SqlParameter("@pfkIDUsuario", idUser);
                cmd.Parameters.Add(pfkIDUsuario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en Insert: " + ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                cnx.MiCnx.Close();
            }
        }

        public List<Participante> SelectParticipantesByIdEvento(int idEvento)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            List<Participante> participantes = new List<Participante>();
            Participante participante = null;

            try
            {
                string sql = "SELECT * FROM Participante WHERE FKEventoID=@pfkIDEvento ORDER BY FKUsuarioID";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pfkIDEvento = new SqlParameter("@pfkIDEvento", idEvento);
                cmd.Parameters.Add(pfkIDEvento);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    participante = new Participante();
                    participante.FkIDEvento = (int)dr["FKEventoID"];
                    participante.FkIDUsuario = (int)(dr["FKUsuarioID"]);
                    participante.ValoracionRuta = (int?)GestionarNulos(dr["ValoracionRuta"]);
                    participante.ComentarioRuta = (string)GestionarNulos(dr["ComentarioRuta"]);

                    participantes.Add(participante);
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

            return participantes;
        }
        public int SelectCountParticipantesByIdEvento(int idEvento)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            int participantes = 0;

            try
            {
                string sql = "SELECT COUNT(*) FROM Participante WHERE FKEventoID=@pfkIDEvento";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pfkIDEvento = new SqlParameter("@pfkIDEvento", idEvento);
                cmd.Parameters.Add(pfkIDEvento);

                participantes = Convert.ToInt32(cmd.ExecuteScalar());
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

            return participantes;
        }
        public List<Participante> SelectParticipantesVoluntariosByIdEvento(int idEvento)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            List<Participante> participantes = new List<Participante>();
            Participante participante = null;

            try
            {
                string sql = "SELECT * FROM Participante INNER JOIN Usuario ON Participante.FKUsuarioID=Usuario.IDUsuario " +
                    "WHERE Participante.FKEventoID=@pfkIDEvento AND Usuario.EsVoluntario='True' ORDER BY FKUsuarioID";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pfkIDEvento = new SqlParameter("@pfkIDEvento", idEvento);
                cmd.Parameters.Add(pfkIDEvento);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    participante = new Participante();
                    participante.FkIDEvento = (int)dr["FKEventoID"];
                    participante.FkIDUsuario = (int)(dr["FKUsuarioID"]);
                    participante.ValoracionRuta = (int?)GestionarNulos(dr["ValoracionRuta"]);
                    participante.ComentarioRuta = (string)GestionarNulos(dr["ComentarioRuta"]);

                    participantes.Add(participante);
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

            return participantes;
        }
        public int SelectCountParticipantesVoluntariosByIdEvento(int idEvento)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            int participantes = 0;

            try
            {
                string sql = "SELECT COUNT(*) FROM Participante INNER JOIN Usuario ON Participante.FKUsuarioID=Usuario.IDUsuario " +
                    "WHERE Participante.FKEventoID=@pfkIDEvento AND Usuario.EsVoluntario='True'";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pfkIDEvento = new SqlParameter("@pfkIDEvento", idEvento);
                cmd.Parameters.Add(pfkIDEvento);

                participantes = Convert.ToInt32(cmd.ExecuteScalar());
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

            return participantes;
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
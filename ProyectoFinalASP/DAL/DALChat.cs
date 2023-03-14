using ProyectoFinalASP.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinalASP.DAL
{
    public class DALChat
    {
        DbConnect cnx;
        public DALChat()
        {
            cnx = new DbConnect();
        }
        public void InsertChat(Chat chat)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            try
            {
                string sql = @"INSERT INTO Chat 
                    (FKIDEvento, FKIDUsuario, Mensaje)
                    VALUES (@pFKIDEvento,
                        @pFKIDUsuario,
                        @pMensaje)";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pFKIDEvento = new SqlParameter("@pFKIDEvento", System.Data.SqlDbType.Int);
                pFKIDEvento.Value = chat.FkIDEvento;
                SqlParameter pFKIDUsuario = new SqlParameter("@pFKIDUsuario", System.Data.SqlDbType.Int);
                pFKIDUsuario.Value = chat.FkIDUsuario;
                SqlParameter pMensaje = new SqlParameter("@pMensaje", System.Data.SqlDbType.NVarChar, 400);
                pMensaje.Value = chat.Mensaje;

                cmd.Parameters.Add(pFKIDEvento);
                cmd.Parameters.Add(pFKIDUsuario);
                cmd.Parameters.Add(pMensaje);

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

        public List<Chat> SelectChatsByIdEvento(int idEvento)
        {
            if (cnx.MiCnx.State == System.Data.ConnectionState.Closed)
                cnx.MiCnx.Open();

            List<Chat> chats = new List<Chat>();
            Chat chat = null;

            try
            {
                string sql = "SELECT * FROM (SELECT TOP 20 * FROM Chat WHERE FKIDEvento=@pFkIDEvento ORDER BY IDMensaje DESC) SQ ORDER BY IDMensaje ASC";
                    //"SELECT BOT(10) * FROM Chat WHERE FKIDEvento=@pFkIDEvento ORDER BY IDMensaje";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pFkIDEvento = new SqlParameter("@pFkIDEvento", idEvento);
                cmd.Parameters.Add(pFkIDEvento);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    chat = new Chat();
                    chat.IdMensaje = (int)dr["IDMensaje"];
                    chat.FkIDEvento = (int)(dr["FKIDEvento"]);
                    chat.FkIDUsuario = (int)(dr["FKIDUsuario"]);
                    chat.Mensaje = (string)(dr["Mensaje"]);

                    chats.Add(chat);
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

            return chats;
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
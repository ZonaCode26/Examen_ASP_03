using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;
using System.Data;
using Dominio.Entidades;


namespace Infraestructura.Data.Sql
{
    public class herramientaDAO
    {

        conexionSQL conecta = new conexionSQL();

        public List<tb_Herramienta> listaHerramienta()
        {

            List<tb_Herramienta> lista = new List<tb_Herramienta>();

            SqlCommand cmd = new SqlCommand("USP_LISTAHERRAMIENTA", conecta.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            conecta.CN.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tb_Herramienta reg = new tb_Herramienta();
                reg.idHer = dr.GetString(0);
                reg.desHer = dr.GetString(1);
                reg.idprov = dr.GetInt32(2);
                reg.preUni = dr.GetDecimal(3);
                reg.stock = dr.GetInt32(4);
                

                lista.Add(reg);

            }
            conecta.CN.Close();
            dr.Close();



            return lista;
        }


        public string AgregarHerramienta(tb_Herramienta reg) {

            string msg = "";

            try
            {
                SqlCommand cmd = new SqlCommand("USP_AGREGARHERRAMIENTA", conecta.CN);
                cmd.CommandType = CommandType.StoredProcedure;
                conecta.CN.Open();

                cmd.Parameters.AddWithValue("@id",reg.idHer);
                cmd.Parameters.AddWithValue("@des", reg.desHer);
                cmd.Parameters.AddWithValue("@idp", reg.idprov);
                cmd.Parameters.AddWithValue("@pre", reg.preUni);
                cmd.Parameters.AddWithValue("@stock", reg.stock);

                cmd.ExecuteNonQuery();
                msg = "Herramienta agregada";

                
            }
            catch (Exception e)
            {

                msg = e.Message;
            }
            finally {

                conecta.CN.Close();
            }



            return msg;


        }

        public string EliminarHerramienta(string id) {
            string msg = "";

            try
            {
                SqlCommand cmd = new SqlCommand("USP_ELIMINARHERRAMIENTA", conecta.CN);
                cmd.CommandType = CommandType.StoredProcedure;
                conecta.CN.Open();

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                msg = "Herramienta Eliminada";


            }
            catch (Exception e)
            {

                msg = e.Message;
            }
            finally
            {

                conecta.CN.Close();
            }



            return msg;



        }



    }
}

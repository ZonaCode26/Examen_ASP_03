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
    public class proveedorDAO
    {
        conexionSQL conecta = new conexionSQL();

        public List<tb_Proveedor> listaProveedor() {

            List<tb_Proveedor> lista = new List<tb_Proveedor>();

            SqlCommand cmd = new SqlCommand("USP_LISTAPROVEEDOR", conecta.CN);
            cmd.CommandType = CommandType.StoredProcedure;
            conecta.CN.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) {
                tb_Proveedor reg = new tb_Proveedor();

                reg.idprov = dr.GetInt32(0);
                reg.nomprov = dr.GetString(1);

                lista.Add(reg);

            }
            conecta.CN.Close();
            dr.Close();



            return lista;
        }





    }
}

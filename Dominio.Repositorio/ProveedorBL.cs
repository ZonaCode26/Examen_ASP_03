using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using Infraestructura.Data.Sql;
using Dominio.Entidades;
namespace Dominio.Repositorio
{
    public class ProveedorBL
    {
        proveedorDAO proveedor = new proveedorDAO();

        public List<tb_Proveedor> listaProveedor()
        {
            return proveedor.listaProveedor();
        }
     }
}

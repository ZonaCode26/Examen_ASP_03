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
    public class HerramientaBL
    {
        herramientaDAO herramienta = new herramientaDAO();
        public List<tb_Herramienta> listaHerramienta() {
            return herramienta.listaHerramienta();
            
        }


        public string AgregarHerramienta(tb_Herramienta reg) {

            return herramienta.AgregarHerramienta(reg);

        }

        public string EliminarHerramienta(string id) {

            return herramienta.EliminarHerramienta(id);
        }
    }
}

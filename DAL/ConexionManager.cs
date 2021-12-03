using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConexionManager
    {
        public SqlConnection Conexion;

        public ConexionManager(string cadena)
        {
            Conexion = new SqlConnection(cadena);
        }

        public void Open()
        {
            Conexion.Open();
        }

        public void Close()
        {
            Conexion.Close();
        }
    }
}

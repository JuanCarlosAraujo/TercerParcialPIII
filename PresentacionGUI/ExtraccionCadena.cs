using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentacionGUI
{
    class ExtraccionCadena
    {
        public static string Conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}

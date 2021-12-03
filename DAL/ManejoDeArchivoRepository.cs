using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManejoDeArchivoRepository
    {

        public List<Factura> ConsultarTodos(string fileName)
        {
            List<Factura> estudiantesDelFile = new List<Factura>();

            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {
                estudiantesDelFile.Add(Map(linea));
            }

            reader.Close();
            file.Close();

            return estudiantesDelFile;
        }

        public Factura Map(string linea)
        {
            string[] matriz = linea.Split(';');
            Factura factura = new Factura();
            

            factura.NumeroFactura = matriz[0];
            factura.Identificacion = matriz[1];
            factura.CodigoServicio = matriz[2];
            factura.Valor = Convert.ToDouble(matriz[3]);
            factura.Estado = matriz[4];


            return factura;
        }

    }
}

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

        public List<Factura> ConsultarVentas(string fileName)
        {
            List<Factura> ventas = new List<Factura>();

            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {
                Factura venta = Map(linea);
                ventas.Add(venta);
            }

            reader.Close();
            file.Close();

            return ventas;
        }

        public Factura Map(string linea)
        {
            Factura factura = new Factura();
            string[] matriz = linea.Split(';');

            factura.NumeroFactura = matriz[0];
            factura.Identificacion = matriz[1];
            factura.CodigoServicio = matriz[2];
            factura.Valor = Convert.ToDouble(matriz[3]);
            factura.Estado = matriz[4];


            return factura;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Factura
    {
        public Factura()
        {
        }

        public string NumeroFactura { get; set; }
        public string Identificacion { get; set; }
        public string CodigoServicio { get; set; }
        public double Valor { get; set; }
        public string Estado { get; set; }

        public Factura(string numeroFactura, string identificacion, string codigoServicio, float valor, string estado)
        {
            NumeroFactura = numeroFactura;
            Identificacion = identificacion;
            CodigoServicio = codigoServicio;
            Valor = valor;
            Estado = estado;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Servicio
    {
        public Servicio()
        {
        }

        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }

        public Servicio(string codigo, string tipo, double valor)
        {
            Codigo = codigo;
            Tipo = tipo;
            Valor = valor;
        }
    }
}

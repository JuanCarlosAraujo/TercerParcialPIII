using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataBaseRepository
    {
        private ConexionManager conexionManager;
        SqlConnection sqlConnection;

        public DataBaseRepository(ConexionManager conexionManager)
        {
            sqlConnection = conexionManager.Conexion;
        }
        public List<Servicio> ConsultarProductos()
        {
            List<Servicio> productos = new List<Servicio>();
            using (var comando = sqlConnection.CreateCommand())
            {
                comando.CommandText = "SELECT codigo,tipo,valor FROM Servicio";
                var lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Servicio producto = new Servicio();
                        producto.Codigo = lector.GetString(0);
                        producto.Tipo = lector.GetString(1);
                        producto.Valor = lector.GetDouble(2);

                        productos.Add(producto);
                    }
                }
                lector.Close();
            }
            return productos;
        }
        public void GuardarVentas(Factura venta)
        {
            using (var comando = sqlConnection.CreateCommand())
            {
                comando.CommandText = "insert into Ventas(numero,identificacion,codigoServicio,valor,estado)" +
                    " values(@numero,@identificacion,@codigoServicio,@valor,@estado)";
                comando.Parameters.AddWithValue("@numero", venta.NumeroFactura);
                comando.Parameters.AddWithValue("@identificacion", venta.Identificacion);
                comando.Parameters.AddWithValue("@codigoServicio", venta.CodigoServicio);
                comando.Parameters.AddWithValue("@valor", venta.Valor);
                comando.Parameters.AddWithValue("@estado", venta.Estado);


                comando.ExecuteNonQuery();
            }
        }

        public List<Factura> ConsultarVentas()
        {
            List<Factura> ventas = new List<Factura>();
            using (var comando = sqlConnection.CreateCommand())
            {
                comando.CommandText = "SELECT numero, identificacion,codigoServicio,valor,estado FROM Factura";
                var lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        Factura venta = new Factura();
                        venta.NumeroFactura = lector.GetString(0);
                        venta.Identificacion = lector.GetString(1);
                        venta.CodigoServicio = lector.GetString(2);
                        venta.Valor = lector.GetDouble(3);
                        venta.Estado = lector.GetString(4);

                        ventas.Add(venta);
                    }
                }
                lector.Close();
            }
            return ventas;
        }

    }
}

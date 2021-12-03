using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ConexionBDService
    {

        private DataBaseRepository conexionBDRepository;
        private ConexionManager conexionManager;

        public ConexionBDService(string cadena)
        {
            conexionManager = new ConexionManager(cadena);
            conexionBDRepository = new DataBaseRepository(conexionManager);
        }
        public string GuardarVentas(Factura venta)
        {
            try
            {
                conexionManager.Open();
                conexionBDRepository.GuardarVentas(venta);
                return "se guardo correctamente";
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
            finally
            {
                conexionManager.Close();
            }
        }
        public List<Factura> ConsultarVentas()
        {
            try
            {
                conexionManager.Open();
                List<Factura> estudianteDelFile = conexionBDRepository.ConsultarVentas();
                return estudianteDelFile;
            }
            catch (Exception e)
            {
                return null;

            }
            finally
            {
                conexionManager.Close();
            }
        }

        public List<Servicio> ConsultarProductos()
        {
            try
            {
                conexionManager.Open();
                List<Servicio> estudianteDelFile = conexionBDRepository.ConsultarProductos();
                return estudianteDelFile;
            }
            catch (Exception e)
            {
                return null;

            }
            finally
            {
                conexionManager.Close();
            }
        }


        public class ServicioResponse
        {
            public List<Servicio> productos { get; set; }
            public string MensajeDeError { get; set; }

            public ServicioResponse(List<Servicio> productos)
            {
                this.productos = productos;
                this.MensajeDeError = null;
            }
            public ServicioResponse(string mensajeDeError)
            {
                this.productos = null;
                this.MensajeDeError = mensajeDeError;
            }
            public ServicioResponse()
            {

            }
        }

    }
}

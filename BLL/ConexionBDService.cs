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
        private ServicioResponse servicioResponse;

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

                return conexionBDRepository.ConsultarVentas();
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

        public ServicioResponse ConsultarProductos()
        {
            try
            {
                conexionManager.Open();
                servicioResponse = new ServicioResponse(conexionBDRepository.ConsultarProductos());
                return servicioResponse;
            }
            catch (Exception e)
            {
                servicioResponse = new ServicioResponse($"ERROR: {e}");
                return servicioResponse;
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

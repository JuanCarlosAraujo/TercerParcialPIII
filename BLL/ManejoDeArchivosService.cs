using DAL;
using Entity;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ManejoDeArchivosService
    {
        public ManejoDeArchivoRepository manejoArchivoRepository;
        public ArchivoVentaTryCatch archivoVentaTryCatch;



        public ManejoDeArchivosService()
        {
            manejoArchivoRepository = new ManejoDeArchivoRepository();
        }

        public ArchivoVentaTryCatch Consultar(string filename)
        {
            try
            {
                List<Factura> archivo = manejoArchivoRepository.ConsultarVentas(filename);
                archivoVentaTryCatch = new ArchivoVentaTryCatch(archivo);

                return archivoVentaTryCatch;
            }
            catch (Exception e)
            {
                archivoVentaTryCatch = new ArchivoVentaTryCatch("Se ha presentado la excepcion: " + e.Message);
                return archivoVentaTryCatch;
            }
        }

        public class ArchivoVentaTryCatch
        {
            public List<Factura> Ventas { get; set; }
            public string MensajeDeError { get; set; }

            public ArchivoVentaTryCatch(List<Factura> ventas)
            {
                this.Ventas = ventas;
                this.MensajeDeError = null;
            }
            public ArchivoVentaTryCatch(string mensajeDeError)
            {
                this.Ventas = null;
                this.MensajeDeError = mensajeDeError;
            }
            public ArchivoVentaTryCatch()
            {

            }
        }
    }
}

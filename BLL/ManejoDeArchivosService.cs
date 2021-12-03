using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ManejoDeArchivosService
    {       public ManejoDeArchivoRepository manejoArchivoRepository;


            
            public ManejoDeArchivosService()
            {
                manejoArchivoRepository = new ManejoDeArchivoRepository();
            }

        public EstudianteConsultarResponse ConsultarTodos(string fileName)
        {
            try
            {
                List<Factura> estudianteDelFile = manejoArchivoRepository.ConsultarTodos(fileName);
                return new EstudianteConsultarResponse(estudianteDelFile);
            }
            catch (Exception e)
            {
                return new EstudianteConsultarResponse("Se ha presentado la excepcion: " + e.Message);
            }
        }

        public class EstudianteConsultarResponse
        {
            public List<Factura> Estudiantes { get; set; }
            public bool Error { get; set; }
            public string MensajeDeError { get; set; }

            public EstudianteConsultarResponse(List<Factura> estudiantes)
            {
                Estudiantes = estudiantes;
                Error = false;
            }
            public EstudianteConsultarResponse(string mensajeDeError)
            {
                MensajeDeError = mensajeDeError;
                Error = true;
            }

        }
    }
}

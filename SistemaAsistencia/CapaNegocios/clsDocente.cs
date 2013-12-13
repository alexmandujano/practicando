using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
namespace CapaNegocios
{
    public class clsDocente
    {
        private Manejador manejador = new Manejador();
        private CapaEntidad.clsDocente docente = new CapaEntidad.clsDocente();

        public DataTable Listar(String dni) 
        {
            List<Parametros> lst = new List<Parametros>();
            String mensaje;
          

               lst.Add(new Parametros("@DNI", dni));
               return manejador.Listado("BUS_DOCENTE_DNI",lst);
          
        
        }

        public String InsertarDocente(CapaEntidad.clsDocente docente)
        {
            List<Parametros> lst = new List<Parametros>();
            String mensaje;
            try
            {

                lst.Add(new Parametros("@DNI", docente.DNI));
                lst.Add(new Parametros("@AP_PATERNO", docente.Ap_paterno));
                lst.Add(new Parametros("@AP_MATERNO", docente.Ap_materno));
                lst.Add(new Parametros("@NOMBRES", docente.Nombres));
                lst.Add(new Parametros("@SEXO", docente.Sexo));
                lst.Add(new Parametros("@CORREO", docente.Correo));
                lst.Add(new Parametros("@RUTA", docente.Ruta_foto));
                lst.Add(new Parametros("@ESTADO", docente.Estado));
                manejador.EjecutarSP("INSERTARDOCENTE", ref lst);
                mensaje = "Docente Guardado..";

            }
            catch (Exception ex)
            {

                mensaje = "Error al Registrar, intente de nuevo o pongase al contacto del administrador, " + ex.Message;
            }

            return mensaje;
        }

    }
}

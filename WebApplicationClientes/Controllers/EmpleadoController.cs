using EmpleadoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using WebApplicationClientes.Models;

namespace WebApplicationClientes.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("API/CertamenAPI/empleados")]
        public Alertas ListarAPI(string rut= "")
        {
            Alertas respuesta = new Alertas();
            try
                {
                List<empleado> listadoapi = new List<empleado>();
                EmpleadoEntity empleadodatos = new EmpleadoEntity();
                DataSet Datos = rut == "" ? empleadodatos.listadoEmpleado() : empleadodatos.listadoEmpleado(rut);

                for (int i = 0; i < Datos.Tables[0].Rows.Count; i++)
                {
                    empleado item = new empleado();
                    item.rut = Datos.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre = Datos.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.apellido = Datos.Tables[0].Rows[i].ItemArray[2].ToString();
                    item.mail = Datos.Tables[0].Rows[i].ItemArray[3].ToString();
                    item.telefono = Datos.Tables[0].Rows[i].ItemArray[4].ToString();
                    listadoapi.Add(item);
                }
                respuesta.error = false;
                respuesta.mensaje = "Aceptado";
                if (listadoapi.Count > 0)
                    respuesta.data = listadoapi;
                else
                    respuesta.data = "No se Encontro Cliente";
                return respuesta;
            }
            catch(Exception e)
            {
                respuesta.error = true;
                respuesta.mensaje = "Error:" + e.Message;
                respuesta.data = null;
                return respuesta;
            }
            

            
        }
        
        [HttpPost]
        [Route("API/CertamenAPI/empleados")]
        public Alertas guardar(empleado empleado)
        {
            Alertas respuesta = new Alertas();
            try
            {
                EmpleadoEntity Emple = new EmpleadoEntity(empleado.rut, empleado.nombre, empleado.apellido, empleado.telefono, empleado.telefono);
                int x = Emple.guardar();

                if (x == 1)
                {
                    respuesta.error = false;
                    respuesta.mensaje = "Cliente Ingresado Correctamente";
                }
                else
                {
                    respuesta.error = true;
                    respuesta.mensaje = "ERROR: Error en el Ingreso";
                    respuesta.data = null;
                }
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.error = true;
                respuesta.mensaje = "Error:" + e.Message;
                respuesta.data = null;
                return respuesta;
            }
        }
        [HttpDelete]
        [Route("API/CertamenAPI/empleados")]
        public Alertas eliminar(string rut)
        {
            Alertas respuesta = new Alertas();
            try
            {

                EmpleadoEntity emple = new EmpleadoEntity();
                emple.Rut = rut;
                int z = emple.eliminar();

                if (z == 1)
                {
                    respuesta.error = false;
                    respuesta.mensaje = "Cliente eliminado Correctamente";
                    respuesta.data = null;
                }
                else
                {
                    respuesta.error = true;
                    respuesta.mensaje = "Eliminacion Fallida";
                    respuesta.data = null;
                }
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.error = true;
                respuesta.mensaje = "Error:" + e.Message;
                respuesta.data = null;
                return respuesta;
            }
        }
            [HttpPut]
            [Route("API/CertamenAPI/empleados")]
            public Alertas update(EmpleadoEntity empleado)
            {
                Alertas respuesta = new Alertas();
                try
                {
                    EmpleadoEntity emple = new EmpleadoEntity(empleado.Rut, empleado.Nombre, empleado.Apellido, empleado.Mail, empleado.Telefono);
                    int x = emple.modificar(emple);

                    if (x == 1)
                    {
                    respuesta.error = false;
                    respuesta.mensaje = "Empleado modificado";
                    respuesta.data = empleado;
                    }
                    else
                    {
                    respuesta.error = true;
                    respuesta.mensaje = "No se realizó la modificiación";
                    respuesta.data = null;
                    }
                    return respuesta;
                }
                catch (Exception e)
                {
                respuesta.error = true;
                respuesta.mensaje = "Error:" + e.Message;
                respuesta.data = null;
                    return respuesta;
                }
            }
    }
}

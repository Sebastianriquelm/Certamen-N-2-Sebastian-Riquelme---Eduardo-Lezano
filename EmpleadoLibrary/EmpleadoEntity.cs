using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoLibrary
{
    public class EmpleadoEntity
    {
        private string rut;
        private string nombre;
        private string apellido;
        private string mail;
        private string telefono;

        Conectionbd datoconex = new Conectionbd();
       


        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Rut { get => rut; set => rut = value; }

        public EmpleadoEntity()
        {

        }

        public EmpleadoEntity(string rut, string nombre, string apellido, string mail, string telefono)
        {
            this.Rut = rut;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.telefono = telefono;

        }


        public DataSet listadoEmpleado()
        {
            return datoconex.listar("SELECT * FROM Empleado");
        }

        public DataSet listadoEmpleado(string rut)
        {
            return datoconex.listar("SELECT * FROM Empleado WHERE RUT = '"+ rut + "'");
        }

        public int guardardato(EmpleadoEntity empleado)
        {
            return datoconex.GuardarDatos("Insert into Empleado(rut, nombre, apellido, mail, telefono) values('" + empleado.Rut + "','" + empleado.Nombre + "','" + empleado.Apellido + "','" + empleado.Mail + "','" + empleado.Telefono + "')");
        }

        public int guardar(EmpleadoEntity empleado)
        {
            return datoconex.GuardarDatos("Insert into CLIENTES(rut, nombre, apellido, mail, telefono) values('" + empleado.Rut + "','" + empleado.Nombre + "','" + empleado.apellido + "','" + empleado.mail + "','" + empleado.Telefono + "')");
        }
        public int guardar()
        {
            return datoconex.GuardarDatos("Insert into CLIENTES(rut, nombre, apellido, mail, telefono) values('" + this.rut + "','" + this.nombre + "','" + this.apellido + "','" + this.mail + "','" + this.telefono + "')");
        }
        public int eliminar()
        {
            return datoconex.GuardarDatos("DELETE FROM CLIENTES WHERE RUT= '" + this.rut + "'");
        }
        public int modificar(EmpleadoEntity empleado)
        {
            return datoconex.GuardarDatos("UPDATE Empleado SET  nombre = '" + empleado.nombre + "', apellido='" + empleado.apellido + "', mail='" + empleado.mail + "', telefono ='" + empleado.telefono + "' WHERE rut ='" + empleado.rut + "'");
        }

    }
}


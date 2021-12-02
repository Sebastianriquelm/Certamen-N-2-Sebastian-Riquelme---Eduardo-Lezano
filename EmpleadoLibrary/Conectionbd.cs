using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoLibrary
{
    public class Conectionbd
    {
        public SqlConnection conexion = new SqlConnection("Data Source=200.36.208.13;Initial Catalog=pooipvg;User ID=ipvg;Password=ipvg"); //Se Genera un Constructor

        public void Conectarbd()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }
        public void Cerrarbd()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

        public DataSet listar(string query)
        {
            Conectarbd();

            DataSet data = new DataSet();                                             // clase encargada de recibir la informacion de la bd
            SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
            adapter.Fill(data);                                                        //ejecucion de sentancia en la conexion
            Cerrarbd();
            return data;
        }

        public int GuardarDatos(string query)
        {
            Conectarbd();
            SqlCommand ingr = new SqlCommand(query, conexion);
            int resul = ingr.ExecuteNonQuery();
            Cerrarbd();
            return resul;
        }
        
    }
}
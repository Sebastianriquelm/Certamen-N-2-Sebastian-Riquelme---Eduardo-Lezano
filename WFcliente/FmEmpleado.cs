using EmpleadoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFcliente
{
    public partial class FmEmpleado : Form
    {

        EmpleadoEntity empleado = new EmpleadoEntity();
        public FmEmpleado()
        {
            InitializeComponent();
        }

        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               
                empleado.Rut = txtRut.Text;
                empleado.Nombre = txtNombre.Text;
                empleado.Apellido = txtApellido.Text;
                empleado.Mail = txtMail.Text;
                empleado.Telefono = txtTelefono.Text;
                int x = empleado.guardardato(empleado);


                if (x == 1)
                {
                    MessageBox.Show("Empleado Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Empleado Ya ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRut.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtMail.Clear();
                txtTelefono.Clear();
            }
        }
    }
}

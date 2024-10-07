using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiAplicacion
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MiAplicacion;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre = @nombre AND Contrasena = @contrasena";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Login exitoso!");
                    Form2 clientesForm = new Form2();
                    clientesForm.Show(); 

                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }

        }
    }
}

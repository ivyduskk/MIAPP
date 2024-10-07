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
    public partial class Form2 : Form
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MiAplicacion;Trusted_Connection=True;";

        public Form2()
        {
            InitializeComponent();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Clientes (Nombre, Domicilio, Telefono, Correo) VALUES (@nombre, @domicilio, @telefono, @correo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@domicilio", txtDomicilio.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente agregado.");
            }

        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Clientes WHERE IdCliente = @idCliente";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idCliente", int.Parse(txtIdCliente.Text)); // Asegúrate de que txtIdCliente tenga el ID del cliente
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente eliminado.");
            }
        }

        private void btnShowClients_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Clientes", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewClientes.DataSource = dt;
            }
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Clientes SET Nombre = @nombre, Domicilio = @domicilio, Telefono = @telefono, Correo = @correo WHERE IdCliente = @idCliente";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idCliente", int.Parse(txtIdCliente.Text)); // Asegúrate de que txtIdCliente tenga el ID del cliente
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@domicilio", txtDomicilio.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente actualizado.");
            }

            }

        private void btnOpenProducts_Click(object sender, EventArgs e)
        {
            Form3 productosForm = new Form3();
            productosForm.Show();
            this.Hide(); 
        }
    }
}
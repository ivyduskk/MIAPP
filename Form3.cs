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
    public partial class Form3 : Form
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MiAplicacion;Trusted_Connection=True;";

        public Form3()
        {
            InitializeComponent();
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Productos (Producto, Descripcion, Cantidad, Precio) VALUES (@producto, @descripcion, @cantidad, @precio)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@producto", txtProducto.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@cantidad", int.Parse(txtCantidad.Text));
                cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecio.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto agregado.");
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Productos WHERE IdProducto = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(txtIdProducto.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto eliminado.");
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Productos SET Producto = @producto, Descripcion = @descripcion, Cantidad = @cantidad, Precio = @precio WHERE IdProducto = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@producto", txtProducto.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@cantidad", int.Parse(txtCantidad.Text));
                cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@id", int.Parse(txtIdProducto.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto actualizado.");
            }
        }

        private void btnShowProducts_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Productos", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewProductos.DataSource = dt;
            }
            
            
        }
    }
}
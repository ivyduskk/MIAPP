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
    public partial class Form4 : Form
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MiAplicacion;Trusted_Connection=True;";

        public Form4()
        {
            InitializeComponent();
        }
        private decimal CalculateTotal()
        {
            decimal total = 0;

           
            foreach (DataGridViewRow row in dataGridViewProductos.SelectedRows)
            {
                decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value); 
                int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value); 
                total += precio * cantidad; 
            }

            return total;
        }
        private void btnAddSale_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                decimal total = CalculateTotal(); 
                string query = "INSERT INTO Ventas (Total, Precio) VALUES (@total, @precio)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@precio", total); 
                cmd.ExecuteNonQuery();
                MessageBox.Show("Venta registrada.");
            }

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

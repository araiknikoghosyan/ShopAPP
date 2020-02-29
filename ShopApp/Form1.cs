using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp
{
    public partial class Form1 : Form
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Form1()
        {
            InitializeComponent();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private async void InsertProduct(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var comand = new SqlCommand("INSERT Into[Store](NameProducts,Quantity,Price)VALUES(@NameProducts,@Quantity,@price)", connection);
                comand.Parameters.AddWithValue("NameProducts", textBox1.Text);
                comand.Parameters.AddWithValue("Quantity", textBox3.Text);
                comand.Parameters.AddWithValue("Price", textBox2.Text);

                int number = comand.ExecuteNonQuery();
                MessageBox.Show($"Insert Element ");
            }
        }

        private async void DeleteProducts(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (MessageBox.Show("Sure?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    await connection.OpenAsync();
                    var comand = new SqlCommand("DELETE  STORE WHERE [ID]=@ID", connection);
                    comand.Parameters.AddWithValue("ID", textBox7.Text);
                    comand.ExecuteNonQuery();
                }
            }
        }
        private void SumInProducts(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT SUM(Price) * SUM(Quantity) FROM STORE  ", connection);
                var sum = command.ExecuteScalar();
                MessageBox.Show(Convert.ToString("SumInProducts=" + sum));
            }
        }
        private void ReadEmployes(object sender, EventArgs e)
        {

            var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("Select * From [Employes]", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }
        private async void InsertEmployes(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Connect Timeout=3;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var comand = new SqlCommand("INSERT Into[Employes](Name,Surename,Age)VALUES(@Name,@SureName,@Age)", connection);
                comand.Parameters.AddWithValue("Name", textBox8.Text);
                comand.Parameters.AddWithValue("SureName", textBox10.Text);
                comand.Parameters.AddWithValue("Age", textBox9.Text);

                int number = comand.ExecuteNonQuery();
                MessageBox.Show($"Insert Employes ");
            }
        }

        private async void DeleteEmployes(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var comand = new SqlCommand("DELETE  EMPLOYES WHERE [ID]=@ID", connection);
                comand.Parameters.AddWithValue("ID", textBox11.Text);
                comand.ExecuteNonQuery();
                MessageBox.Show($"Delete Emploes");
            }
        }
        private void SelectStor_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From [Store]", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }
    }
}



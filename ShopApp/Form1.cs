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

namespace ShopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connection = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand("Select * From [Store]", connection);
            try
            {
                reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(reader["ID"]) + " " + Convert.ToString(reader["NameProducts"]) + " " + Convert.ToString(reader["Quantity"]) + " " + Convert.ToString(reader["Price"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                await connection.OpenAsync();
                SqlCommand comand = new SqlCommand("INSERT Into[Store](NameProducts,Quantity,Price)VALUES(@NameProducts,@Quantity,@price)", connection);
                comand.Parameters.AddWithValue("NameProducts", textBox1.Text);
                comand.Parameters.AddWithValue("Quantity", textBox2.Text);
                comand.Parameters.AddWithValue("Price", textBox3.Text);

                int number = comand.ExecuteNonQuery();
                MessageBox.Show($"Insert Element ");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                await connection.OpenAsync();
                SqlCommand comand = new SqlCommand("DELETE  STORE WHERE [ID]=@ID", connection);
                comand.Parameters.AddWithValue("ID", textBox7.Text);


                comand.ExecuteNonQuery();
                MessageBox.Show($"Delete Element ");
            }
        }

        private async void Update_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                await connection.OpenAsync();
                SqlCommand comand = new SqlCommand("UPDATE  [STORE] SET [NameProducts]=@NameProducts, [Quantity]=@Quantity,[Price]=@Price WHERE [ID]=@ID", connection);
                comand.Parameters.AddWithValue("ID", textBox6.Text);
                comand.Parameters.AddWithValue("NameProducts", ProductNM.Text);
                comand.Parameters.AddWithValue("Quantity", textBox4.Text);
                comand.Parameters.AddWithValue("Price", textBox5.Text);


                comand.ExecuteNonQuery();
                MessageBox.Show($"UPDATE Element ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT SUM(Price*Quantity) FROM STORE  ", connection);
                var sum = command.ExecuteScalar();
                MessageBox.Show(Convert.ToString("SUM=" + sum));

            }
        }
    }

}

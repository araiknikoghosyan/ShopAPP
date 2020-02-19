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
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
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
                    listBox1.Items.Add(Convert.ToString(reader["ID"]) + "\t " + Convert.ToString(reader["NameProducts"]) + "\t" + Convert.ToString(reader["Quantity"]) + "\t" + Convert.ToString(reader["Price"]));
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
                var comand = new SqlCommand("INSERT Into[Store](NameProducts,Quantity,Price)VALUES(@NameProducts,@Quantity,@price)", connection);
                comand.Parameters.AddWithValue("NameProducts", textBox1.Text);
                comand.Parameters.AddWithValue("Quantity", textBox3.Text);
                comand.Parameters.AddWithValue("Price", textBox2.Text);

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
                var comand = new SqlCommand("DELETE  STORE WHERE [ID]=@ID", connection);
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
                var comand = new SqlCommand("UPDATE  [STORE] SET [NameProducts]=@NameProducts, [Quantity]=@Quantity,[Price]=@Price WHERE [ID]=@ID", connection);
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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=3;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT SUM(Price) * SUM(Quantity) FROM STORE  ", connection);
                var sum = command.ExecuteScalar();
                MessageBox.Show(Convert.ToString("SumInProducts=" + sum));
            }
        }

        private async void updateDBToolStripMenuItem_Click(object sender, EventArgs e)
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
                    listBox1.Items.Add(Convert.ToString(reader["ID"]) + "\t" + Convert.ToString(reader["NameProducts"]) + "\t" + Convert.ToString(reader["Quantity"]) + "\t" + Convert.ToString(reader["Price"]));
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

        private async void tabPage5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connection = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand("Select * From [Employes]", connection);
            try
            {
                reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    listBox2.Items.Add(Convert.ToString(reader["ID"]) + "\t" + Convert.ToString(reader["Name"]) + "\t" + Convert.ToString(reader["SureName"]) + "\t" + Convert.ToString(reader["Age"]));
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

        private async void button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=3;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connection = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand("Select * From [Employes]", connection);
            try
            {
                reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {

                    listBox2.Items.Add(Convert.ToString(reader["ID"]) + "\t" + Convert.ToString(reader["Name"]) + "\t" + Convert.ToString(reader["SureName"]) + "\t" + Convert.ToString(reader["Age"]));
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

        private async void button6_Click(object sender, EventArgs e)
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

        private async void button7_Click(object sender, EventArgs e)
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
        private static void UserAD()
        {
            string login = "ADMIN";
            string pasword = "123";
            if (login == "ADMIN" && pasword == "123")
            {
               
            }

        }
        private void button8_Click(object sender, EventArgs e)
        {
            UserAD();
            string login = "13";
            textBox1.Text=login;
        }
    }


}



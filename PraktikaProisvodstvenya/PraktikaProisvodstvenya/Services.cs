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

namespace Kursach
{
    public partial class Services : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=Потемкин_329196_16;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        public Services()
        {
            InitializeComponent();
            string query2 = "SELECT * FROM Услуги";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query2, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
        }
        private void Refreshing()
        {
            string query1 = "SELECT * FROM Услуги";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query1, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "INSERT INTO dbo.[Услуги] ([ID Услуги],[Наименование Услуги], [Стоимость Услуги]) VALUES" +
               "((\'" + textBox1.Text + "\'), (\'" + textBox2.Text + "\'), (\'" + textBox3.Text + "\'))";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refreshing();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var uslugi = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string delete = "DELETE  FROM dbo.[Услуги] WHERE [ID Услуги] = '" + uslugi + "'";
            SqlCommand com = new SqlCommand(delete, connection);

            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            Refreshing();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query1 = $"UPDATE  dbo.[Услуги] SET [ID Услуги] = '{textBox1.Text}',[Наименование Услуги] = '{textBox2.Text}', [Стоимость Услуги] = '{textBox3.Text}' WHERE [ID Услуги] = '{textBox1.Text}'";
            SqlCommand com = new SqlCommand(query1, connection);    
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refreshing();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Refreshing();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator administrator = new Administrator();
            administrator.ShowDialog();
        }
    }
}

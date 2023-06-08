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
    public partial class InfoAvto : Form
    {

        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=Потемкин_329196_16;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        public InfoAvto()
        {
            InitializeComponent();
            string query2 = "SELECT * FROM [Доп.Информация]";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query2, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
        }
        private void Refresh()
        {
            string query1 = "SELECT * FROM [Доп.Информация]";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query1, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var user = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string delete = "DELETE  FROM dbo.[Доп.Информация] WHERE [Номер Автомобиля] = '" + user + "'";
            SqlCommand com = new SqlCommand(delete, connection);

            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "INSERT INTO dbo.[Доп.Информация] ([Номер Автомобиля],[Сумма Штравфов], [ТехОсмотр], [Страховка], [Последнее обслуживание], [Машина Категории]) VALUES" +
                "((\'" + textBox1.Text + "\'), (\'" + textBox2.Text + "\'), (\'" + textBox3.Text + "\'), (\'" + textBox4.Text + "\'), (\'" + textBox5.Text + "\'), (\'" + textBox6.Text + "\'))";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sotr = textBox2.Text;
            string query1 = $"UPDATE dbo.[Доп.Информация] SET [Номер Автомобиля] = '{textBox1.Text}',[Сумма Штравфов] = '{sotr}',[ТехОсмотр] = '{textBox3.Text}', [Страховка] = '{textBox4.Text}', [Последнее обслуживание] = '{textBox5.Text}', [Машина Категории] = '{textBox6.Text}' WHERE [Номер Автомобиля] = '{textBox1.Text}'";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Director director = new Director();
            director.ShowDialog();
        }
    }
}

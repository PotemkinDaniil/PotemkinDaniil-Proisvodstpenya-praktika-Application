using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Auto : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=Потемкин_329196_16;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        
        public Auto()
        {
            InitializeComponent();
            string query2 = "SELECT * FROM Автомобили";
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
            string query1 = "SELECT * FROM Автомобили";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query1, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "INSERT INTO dbo.[Автомобили] ([Номер Автомобиля],[Модель Автомобиля], [Цвет Автомобиля], [Тип Автомобиля], [Тип Кузова], [Тип Трансмиссии], [Количество Дверей], [Количество Мест], [Положение Руля]) VALUES" +
                "((\'" + textBox2.Text + "\'), (\'" + textBox1.Text + "\'), (\'" + textBox3.Text + "\'), (\'" + textBox4.Text + "\'), (\'" + textBox5.Text + "\'), (\'" + textBox6.Text + "\'), (\'" + textBox7.Text + "\'), (\'" + textBox8.Text + "\'), (\'" + textBox9.Text + "\')) ";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            
            Refresh();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var carcode = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string delete = "DELETE  FROM dbo.[Автомобили] WHERE [Номер Автомобиля] = '" + carcode+"'";
            SqlCommand com = new SqlCommand(delete, connection);

            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            Refresh();
           
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query1 = $"UPDATE  dbo.[Автомобили] SET [Номер Автомобиля] = '{textBox2.Text}',[Модель Автомобиля] = '{textBox1.Text}', [Цвет Автомобиля] = '{textBox3.Text}', [Тип Автомобиля] = '{textBox4.Text}', [Тип Кузова] = '{textBox5.Text}', [Тип Трансмиссии] = '{textBox6.Text}', [Количество Дверей] = {textBox7.Text}, [Количество Мест] = '{textBox8.Text}', [Положение Руля] = '{textBox9.Text}' WHERE [Номер Автомобиля] = '{textBox2.Text}'";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refresh();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator administrator = new Administrator();
            administrator.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

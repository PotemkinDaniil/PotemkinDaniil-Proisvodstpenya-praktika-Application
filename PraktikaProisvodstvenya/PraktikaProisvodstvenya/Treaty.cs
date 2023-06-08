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
    public partial class Treaty : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=Потемкин_329196_16;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        public Treaty()
        {
            InitializeComponent();
            string query2 = "SELECT * FROM Договор";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query2, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
        }
        private void Fresh()
        {
            string query1 = "SELECT * FROM Договор";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query1, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            string query1 = "INSERT INTO dbo.[Договор] ([ID Сотрудника],[ID Арендатора], [ФИО Арендатора], [ФИО Сотрудники], [Номер договора], [Начало проката], [Конец Проката], [Номер Автомобиля], [Стоимость Проката]) VALUES" +
                "((\'" + textBox1.Text + "\'), (\'" + LoginBox.Text + "\'), (\'" + PasswordBox.Text + "\'), (\'" + textBox2.Text + "\'), (\'" + textBox3.Text + "\'), (\'" + textBox4.Text + "\'), (\'" + textBox5.Text + "\'), (\'" + textBox6.Text + "\'), (\'" + textBox7.Text + "\')) ";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Fresh();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var dogovor = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string delete = "DELETE  FROM dbo.[Договор] WHERE [Номер договора] = '" + dogovor + "'";
            SqlCommand com = new SqlCommand(delete, connection);

            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            Fresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = $"UPDATE  dbo.[Договор] SET [ID Сотрудника] = '{textBox1.Text}',[ID Арендатора] = '{LoginBox.Text}', [ФИО Арендатора] = '{PasswordBox.Text}', [ФИО Сотрудники] = '{textBox2.Text}', [Номер договора] = '{textBox3.Text}', [Начало проката] = '{textBox4.Text}', [Конец Проката] = '{textBox5.Text}', [Номер Автомобиля] = '{textBox6.Text}', [Стоимость Проката] = '{textBox7.Text}' WHERE [Номер договора] = '{textBox3.Text}'";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Fresh();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Fresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            LoginBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            PasswordBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

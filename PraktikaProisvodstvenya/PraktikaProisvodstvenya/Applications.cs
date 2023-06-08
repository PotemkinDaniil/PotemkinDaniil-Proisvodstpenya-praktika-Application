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
    public partial class Applications : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=Потемкин_329196_16;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        public Applications()
        {
            InitializeComponent();
            string query2 = "SELECT * FROM Заявки";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query2, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
        }
        public void NewSetings()
        {
            Settings settings = new Settings();
            settings.BackColor = this.BackColor;
            settings.ForeColor = this.ForeColor;
            settings.WindowState = this.WindowState;
            settings.Size = this.Size;

        }
        private void Refresh()
        {
            string query1 = "SELECT * FROM Заявки";
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
            var user = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string delete = "DELETE  FROM dbo.[Заявки] WHERE [ID Услуги] = '" + user + "'";
            SqlCommand com = new SqlCommand(delete, connection);

            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query1 = "INSERT INTO dbo.[Заявки] ([ID Услуги],[Номер Заявки], [ФИО Арендатора], [ФИО Сотрудника], [Наименование Услуги], [Дата начала оказание услуги], [Дата окончания оказание услуг], [Номер Автомобиля],[Тип Автомобиля]) VALUES" +
               "((\'" + textBox1.Text + "\'), (\'" + textBox2.Text + "\'), (\'" + textBox3.Text + "\'), (\'" + textBox4.Text + "\'), (\'" + textBox5.Text + "\'), (\'" + textBox6.Text + "\'), (\'" + textBox7.Text + "\'),(\'" + textBox8.Text + "\'),(\'" + textBox9.Text + "\'))";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sotr = textBox2.Text;
            string query1 = $"UPDATE dbo.[Заявки] SET [ID Услуги] = '{textBox1.Text}',[Номер Заявки] = '{sotr}',[ФИО Арендатора] = '{textBox3.Text}', [ФИО Сотрудника] = '{textBox4.Text}', [Наименование Услуги] = '{textBox5.Text}', [Дата начала оказание услуги] = '{textBox6.Text}', [Дата окончания оказание услуг] = '{textBox7.Text}', [Номер Автомобиля] = '{textBox8.Text}', [Тип Автомобиля] = '{textBox9.Text}' WHERE [ID Услуги] = '{textBox1.Text}'";
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
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void Applications_Load(object sender, EventArgs e)
        {
            NewSetings();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Assistent assistent = new Assistent();
            assistent.ShowDialog();

        }
    }
}

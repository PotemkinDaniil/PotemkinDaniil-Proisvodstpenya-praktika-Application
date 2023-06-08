using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace Kursach
{
    public partial class Login : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=Потемкин_329196_16;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        
        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var password = (PasswordBox.Text);
            string querystring = $"select Должность, Пароль from Сотрудники where Должность ='{textBox1.Text}' and Пароль = '{password}'";
            SqlCommand command = new SqlCommand(querystring, connection);
            if(command.ExecuteScalar() != null)
            {
                if (command.ExecuteScalar().ToString() == "Администратор")
                {
                    MessageBox.Show("Добро Пожаловать Администратор!");
                    Administrator administrator = new Administrator();
                    this.Hide();
                    administrator.ShowDialog();
                }
                else if (command.ExecuteScalar().ToString() == "Добро Пожаловать Директор")
                {
                    MessageBox.Show("Director");
                    Director director = new Director();
                    this.Hide();
                    director.ShowDialog();
                }
                else if (command.ExecuteScalar().ToString() == "Добро Пожаловать Консультант")
                {
                    MessageBox.Show("Assistent");
                    Assistent assistent = new Assistent();
                    this.Hide();
                    assistent.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connection.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 15;

            PasswordBox.MaxLength = 10;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

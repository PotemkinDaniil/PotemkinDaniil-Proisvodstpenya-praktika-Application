using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Director : Form
    {
        public Director()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Users Form = new Users();
            Form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InfoAvto Form = new InfoAvto();
            Form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Treaty treaty = new Treaty();
            this.Hide();
            treaty.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}

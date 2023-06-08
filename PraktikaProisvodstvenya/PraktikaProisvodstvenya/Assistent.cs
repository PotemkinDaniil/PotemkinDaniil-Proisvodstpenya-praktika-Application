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
    public partial class Assistent : Form
    {
        public Assistent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Treaty Form = new Treaty();
            Form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guests guests = new Guests();
            this.Hide();
            guests.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto();
            this.Hide();
            auto.button1.Hide();
            auto.button2.Hide();
            auto.button3.Hide();
            auto.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Applications applications = new Applications();
            this.Hide();
            applications.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
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

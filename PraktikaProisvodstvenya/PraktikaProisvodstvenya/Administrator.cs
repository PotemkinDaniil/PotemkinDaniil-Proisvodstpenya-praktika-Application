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
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Auto Form = new Auto();
            Form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Services Form = new Services();
            Form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settings Form = new Settings();
            Form.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Treaty Form = new Treaty();
            Form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

       
    }
}

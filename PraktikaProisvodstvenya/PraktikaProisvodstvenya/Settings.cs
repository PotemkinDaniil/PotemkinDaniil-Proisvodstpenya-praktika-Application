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
    public partial class Settings : Form
    {
        Administrator administrator = new Administrator();

        public Settings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.ForeColor = colorDialog1.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.BackColor = colorDialog1.Color;
            
           
        }
        public Size FormSize
        {
            get
            {
                if (Convert.ToInt32(textBox1.Text) < 700 && Convert.ToInt32(textBox2.Text) < 500)
                {
                   return new Size(700, 500);
                }
                else
                {
                   return new Size(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                }
            }
                

         }
       
        public  FormWindowState Maximizade
        {
            get
            {
                if (radioButton2.Checked == true)
                {
                    return FormWindowState.Normal;
                }
                else
                    return FormWindowState.Maximized;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Хотите сохранить все изменения?", "Вы точно хотите выйти?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

               
                administrator.BackColor = this.BackColor;
                administrator.ForeColor = this.ForeColor;
                administrator.WindowState = Maximizade;
                administrator.Size = FormSize;
                this.Hide();
                administrator.ShowDialog();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            administrator.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

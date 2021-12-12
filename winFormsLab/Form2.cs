using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winFormsLab
{
    public partial class Form2 : Form
    {
        public static Form2 Instance;
        public TextBox tb1;
        public Form2()
        {
            InitializeComponent();
            Instance = this;
            tb1 = textBox1;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Form1 form = new Form1();
            form.Show();
            Form1.Instance.tb2.Text = textBox1.Text;
            Instance.Hide();

        }
    }
}
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
    public partial class Form1 : Form
    {
        private int n;
        int[] arr;

        public static Form1 Instance;
        public TextBox tb2;
        public Form1()
        {
            InitializeComponent();
            Instance = this;
            tb2 = textBox2;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] strArr = textBox1.Text.Split(' ').ToArray();
            n = textBox1.Text.Split(' ').Count();

            arr = new int[n];
            bool[] b = new bool[n];

            for (int i = 0; i < n; i++)
                b[i] = int.TryParse(strArr[i], out arr[i]);

            for (int i = 0; i < n; i++)
                if (!b[i])
                    textBox1.Text = "Error";
                else
                    textBox1.Text = "Complete";
        }



        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "Complete" || textBox1.Text.First() == 'S')
                textBox1.Text = "Sum = " + arr.Sum();
            else
                textBox1.Text = "Error";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (arr == null || arr.Count() == 0)
                comboBox1.Text = "Error";
            else
            {
                comboBox1.Text = "Open me!";
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(arr.Select(x => x.ToString()).ToArray());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (arr == null || arr.Count() == 0)
                comboBox1.Text = "Error";
            else
            {
                int key = arr[comboBox1.SelectedIndex];
                int[] arrTemp = new int[n - 1];
                arrTemp = arr.Where(x => x != key).ToArray();
                arr = new int[n - 1];
                arr = arrTemp;
                comboBox1.Text = "Deleted!";
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(arrTemp.Select(x => x.ToString()).ToArray());
            }
        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            Form2.Instance.tb1.Text = textBox2.Text;
            Instance.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace exam_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            maskedTextBox1.Validating += maskedTextBox1_Validating;
            textBox1.Validating += textBox1_Validating;
            textBox2.Validating += textBox2_Validating;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n = "\n\n";
            if (this.ValidateChildren())
            {
                MessageBox.Show(textBox1.Text + n + textBox2.Text + n + maskedTextBox1.Text);
            }
            else
            {
      
            }

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Введите название города!");
                e.Cancel = true;
            }
            else if (textBox1.Text.Length < 2 )
            {
                errorProvider1.SetError(textBox1, "Слишком короткое название!");
                e.Cancel = true;
            }
            else if (textBox1.Text.Length > 25)
            {
                errorProvider1.SetError(textBox1, "Недопустимый объем строки!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox2, "Введите название улицы!");
                e.Cancel = true;
            }
            else if (textBox2.Text.Length < 10)
            {
                errorProvider1.SetError(textBox2, "Слишком короткое название!");
                e.Cancel = true;
            }
            else if (textBox2.Text.Length > 50)
            {
                errorProvider1.SetError(textBox2, "Недопустимый объем строки!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        { int count = Num(maskedTextBox1.Text); 
            if ( count< 6)
            {
                errorProvider1.SetError(maskedTextBox1, "Неправильно!");
                e.Cancel = true;
            }
           else if (count ==0)
            {
                errorProvider1.SetError(maskedTextBox1, "Введите индекс!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private int Num(string str)
        {
            char[] ch = str.ToCharArray();
            var count = ch.Where((n) => n >= '0' && n <= '9').Count();
            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        delegate void delegado(double valor);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread H1 = new Thread(new ThreadStart(Pro1));
            H1.Start();
            
        }
        public void Pro1()
        {
            double talla = Convert.ToDouble(textBox1.Text);
            double peso = Convert.ToDouble(textBox2.Text);                                  
            double m, m2;
            m = talla / 100;
            m2 = m * m;
            double IMC = peso / m2;
            delegado md = new delegado(rpta);
            this.Invoke(md, new object[] { IMC });
        }
        public void rpta(double valor)
        {
            int imc = Convert.ToInt32(valor);
            label4.Text = "Su indice de\nmasa corporal es : " + imc;
            if (imc < 18.5)
            {
                label5.Text="Peso Inferior al NORMAL";
                pictureBox1.Image = Image.FromFile(@"C:\Users\gonza\Desktop\imagenes\bajo.png");
            }
            else if (imc >= 18.5 && imc <= 24.9)
            {
                label5.Text = "Peso es NORMAL";
                pictureBox1.Image = Image.FromFile(@"C:\Users\gonza\Desktop\imagenes\normal.png");
            }
            else if (imc >= 25 && imc <= 29.9)
            {                
                label5.Text = "Peso Superior al NORMAL";
                pictureBox1.Image = Image.FromFile(@"C:\Users\gonza\Desktop\imagenes\alto.png");
            }
            else if (imc >= 30)
            {
                label5.Text = "Obesidad";
                pictureBox1.Image = Image.FromFile(@"C:\Users\gonza\Desktop\imagenes\obeso.png");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STP_task_1_interface
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
            
        }

		

        static double Sum(double x, int n) // посдчет через разложение в ряд
        {
            double sum = 0;
            if (x < 1)
            {
                for (int i = 1; i < n; i++)
                {
                    sum += -Math.Pow(x, i) / i;
                }
                return sum;
            }
            else
            {
                Console.WriteLine("Недопустимые вводные данные");
                Environment.Exit(0);
                return 0;
            }
        }

        static double FindSum(double x, double E)
        {
            double summary = 0;
            int i = 1;
            while (Math.Abs(-Math.Pow(x, i) / i) > E)
            {
                summary += Math.Abs(-Math.Pow(x, i) / i);
                i++;
            }

            return summary;
        }

        static int FindTerm(double x, double E)
        {
            int i = 1;
            while (Math.Abs(-Math.Pow(x, i) / i) > E)
            {
                i++;
            }

            return i--;
        }

		private void Form1_Enter(object sender, EventArgs e)
		{
            
        }

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
            double x = double.Parse(textBox1.Text.Replace('.', ','));
            int n = int.Parse(textBox2.Text.Replace('.', ','));

            double func = Math.Log(1 - x);
            label5.Text = "Value of Math function " + func;

            label6.Text = "Value of Taylor series " + Sum(x, n);

            double d = Math.Abs(func - Sum(x, n));
            label7.Text = "Value of difference " + d;

        }

		private void button2_Click(object sender, EventArgs e)
		{
            double x = double.Parse(textBox4.Text.Replace('.', ','));
            double E = double.Parse(textBox5.Text.Replace('.', ','));

            label8.Text = "Value of sum terms that are bigger than e " + FindSum(x, E);

            label9.Text = "Quantity of those terms " + FindTerm(x, E);

            label10.Text = "Value of sum terms that are bigger than e * 10 " + FindSum(x, E * 10);
            label11.Text = "Quantity of those terms with e * 10 " + FindTerm(x, E * 10);
        }
	}
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanNumeralConvertor
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private static readonly Dictionary<char, int> RomanNumberDict = new Dictionary<char, int>()
        {
            { 'I', 1},
            { 'V', 5},
            { 'X', 10},
            { 'L', 50},
            { 'C', 100},
            { 'D', 500},
            { 'M', 1000}
        };

        public static string RomanToInteger(string input)
        {
            int number = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 < input.Length && RomanNumberDict[input[i]] < RomanNumberDict[input[i + 1]])
                {
                    number -= RomanNumberDict[input[i]];
                }
                else
                {
                    number += RomanNumberDict[input[i]];
                }
            }
            return number.ToString();
        }

        private static string ConvertRomanInput(string input)
        {
            string result = "";
            result = RomanToInteger(input);
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var input = textBox1.Text;
                var returnResult = ConvertRomanInput(input);
                textBox2.Text = returnResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input was not Roman");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            foreach (Form frm in Application.OpenForms)
            {
                if (frm is Form1)
                {
                    frm.Show();
                    return;
                }
            }

            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}

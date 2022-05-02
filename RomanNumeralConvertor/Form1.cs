using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static readonly Dictionary<int, string> NumberRomanDict = new Dictionary<int, string>(){
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
        };

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private static string IntegerToRoman(int number)
        {
            var result = new StringBuilder();

            foreach (var item in NumberRomanDict)
            {
                while (number >= item.Key)
                {
                    result.Append(item.Value);
                    number -= item.Key;
                }
            }

            return result.ToString();
        }

        private static string ConvertNumberInput(int input)
        {
            string result = "";
            result = IntegerToRoman(input);
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var input = textBox1.Text;
                int.Parse(input);
                var returnResult = ConvertNumberInput(int.Parse(input));
                textBox2.Text = returnResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input not integer");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            foreach (Form frm in Application.OpenForms)
            {
                if (frm is Form2)
                {
                    frm.Show();
                    return;
                }
            }

            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}

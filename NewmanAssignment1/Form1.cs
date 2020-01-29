using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewmanAssignment1
{
    public partial class Form1 : Form
    {

        private OpenFileDialog openFileDialog1;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void SetText(string text)
        {
            textBox2.Text = text;
            questionBox.Text = text;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    SetText(sr.ReadToEnd());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

    }
}

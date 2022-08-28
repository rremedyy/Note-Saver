using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace copypasta
{
    public partial class Form1 : Form
    {
        public void refresh()
        {
            listBox1.Items.Clear();
            string[] getFiles = Directory.GetFiles(path + "//Files", "*.txt", SearchOption.AllDirectories);

            foreach (var file in getFiles)
            {
                FileInfo info = new FileInfo(file);
                listBox1.Items.Add(info.Name);
            }
        }

        string path = AppDomain.CurrentDomain.BaseDirectory;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // load
        {
            string item = "";
            foreach (int i in listBox1.SelectedIndices)
            {
                item += listBox1.Items[i];
            }
            string textPath = Path.Combine(path, "Files", item);
            string text = File.ReadAllText(textPath);
            richTextBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e) // save
        {
            if (textBox1.Text != "")
            {
                FileStream file = File.Create(path + "//Files//" + textBox1.Text + ".txt");
                byte[] bytes = Encoding.UTF8.GetBytes(richTextBox1.Text);
                file.Write(bytes, 0, bytes.Length);
                refresh();
                file.Close();
            }
            else
            {
                MessageBox.Show("Enter a file name");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // clear
        {
            richTextBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e) // refresh
        {
            refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) // delete
        {
            string item = "";
            foreach (int i in listBox1.SelectedIndices)
            {
                item += listBox1.Items[i] + Environment.NewLine;
            }
            if (File.Exists(path + "\\Files\\" + item))
            {
                File.Delete(path + "\\Files\\" + item);
                refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e) // copy
        {
            Clipboard.SetText(richTextBox1.Text);
        }
    }
}

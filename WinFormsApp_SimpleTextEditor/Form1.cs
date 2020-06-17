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

namespace WinFormsApp_SimpleTextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.FileName = ""; // Очищаем название файла.
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
        }

        private void buttonOpen_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                textBox1.Clear(); 
                openFileDialog1.Filter = "Text Files (*.txt)|*.txt";
                string fileName = openFileDialog1.FileName;
                textBox1.Text = File.ReadAllText(fileName, Encoding.GetEncoding(1251)); 
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";
            saveFileDialog1.DefaultExt = ".txt"; 
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                var name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox1.Text,Encoding.GetEncoding(1251));
            }
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        //Попытка реализовать просмотр фото)
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Файл не корректен. Выберите, пожалуйста, файл с расширением .png|.jpeg|.bmp|.gif", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

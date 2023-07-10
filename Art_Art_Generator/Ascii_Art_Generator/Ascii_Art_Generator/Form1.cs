using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Ascii_Art_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap pixelData;

        private void Button1_Click(object sender, EventArgs e)
        {
            //The file selection pop-up appears.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Attempt to load the image.
                try
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    pixelData = new Bitmap(openFileDialog1.FileName);
                }

                //Display an error if the file is not an image.
                catch (Exception error)
                {
                    MessageBox.Show("Error:Select an Image File!");
                }

                //Create an object instance and run a method.
                BitmapConverter process = new BitmapConverter();
                string asciiArt = process.Asciitize(pixelData);

                //Display the final result
                textBox1.Text = asciiArt;
            }
        }
    }
}
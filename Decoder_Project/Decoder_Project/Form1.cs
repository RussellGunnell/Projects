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

namespace Decoder_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string fileName;
        private Bitmap loadedImage;

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bool errorCaught = false;
                try
                {
                    fileName = openFileDialog1.FileName;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: Please select a PPM file!");
                    errorCaught = true;
                }
                if (!errorCaught)
                {
                    try
                    {
                        StreamReader fileSR = new StreamReader(openFileDialog1.FileName);
                        string ppmType = fileSR.ReadLine();
                        //P3 or P6?

                        fileSR.ReadLine();
                        //Skips the comment line.

                        string rawDeminsions = fileSR.ReadLine();
                        char[] dimensions = new char[rawDeminsions.Length];
                        rawDeminsions.CopyTo(0, dimensions, 0, rawDeminsions.Length);
                        //Fetches dimensions.

                        int i = 0;
                        string rawWidth = "";
                        bool spaceDetected = false;
                        string rawHeight = "";
                        while (i < dimensions.Length)
                        {
                            if (dimensions[i] == ' ')
                            {
                                spaceDetected = true;
                            }
                            else if (spaceDetected == false)
                            {
                                rawWidth += dimensions[i];
                            }
                            else
                            {
                                rawHeight += dimensions[i];
                            }
                            i++;
                        }
                        int width = Convert.ToInt32(rawWidth);
                        int height = Convert.ToInt32(rawHeight);
                        //Divide dimensions into individual width and height values.

                        fileSR.ReadLine();
                        //Skips the line that tells the maximum RGB value in the picture.

                        loadedImage = new Bitmap(width, height);
                        switch (ppmType)
                        {
                            case "P3":
                                string message = "";
                                for (int y = 0; y < loadedImage.Height; y++)
                                {
                                    for (int x = 0; x < loadedImage.Width; x++)
                                    {
                                        Color pixelColor = GetP3Color(fileSR);
                                        //
                                        int blueVal = pixelColor.B;
                                        if ((blueVal >= 48 && blueVal <= 90) || blueVal == 32)
                                        {
                                            char messageFragment = Convert.ToChar(blueVal);
                                            message += messageFragment;
                                        }
                                        //
                                        loadedImage.SetPixel(x, y, pixelColor);
                                    }
                                }
                                fileSR.Dispose();
                                textBox1.Text = message;
                                break;
                            case "P6":
                                fileSR.Dispose();
                                FileStream fileFS = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                                byte[] data = new byte[fileFS.Length];
                                fileFS.Read(data, 0, Convert.ToInt32(fileFS.Length));
                                fileFS.Dispose();
                                int lineIndex = 0;
                                int byteIndex = 0;
                                while (lineIndex < 4)
                                {
                                    if (data[byteIndex] == 10)
                                    {
                                        lineIndex++;
                                    }
                                    byteIndex++;
                                }
                                //Preps the byte array and adjusts the byte index to the proper starting point.

                                message = "";
                                for (int y = 0; y < loadedImage.Height; y++)
                                {
                                    for (int x = 0; x < loadedImage.Width; x++)
                                    {
                                        int redVal = GetP6Data(data, byteIndex);
                                        byteIndex++;
                                        int greenVal = GetP6Data(data, byteIndex);
                                        byteIndex++;
                                        int blueVal = GetP6Data(data, byteIndex);
                                        //
                                        if ((blueVal >= 48 && blueVal <= 90) || blueVal == 32)
                                        {
                                            char messageFragment = Convert.ToChar(blueVal);
                                            message += messageFragment;
                                        }
                                        //
                                        byteIndex++;
                                        Color pixelColor = Color.FromArgb(redVal, greenVal, blueVal);
                                        loadedImage.SetPixel(x, y, pixelColor);
                                    }
                                }
                                textBox1.Text = message;
                                break;
                        }
                        //Sets the pixels according to the RGB values collected.
                        //Formats and displays the image to the user.
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("The PPM file was formatted incorrectly, or it was not a P3/P6 type.");
                        errorCaught = true;
                    }
                    if (!errorCaught)
                    {
                        pictureBox1.Image = loadedImage;
                    }
                }
            }
        }

        static Color GetP3Color(StreamReader fileSR)
        {
            int redVal = Convert.ToInt32(fileSR.ReadLine());
            int greenVal = Convert.ToInt32(fileSR.ReadLine());
            int blueVal = Convert.ToInt32(fileSR.ReadLine());
            return Color.FromArgb(redVal, greenVal, blueVal);
            //Collects the RGB values of a single pixel.
        }

        static int GetP6Data(byte[] byteData, int byteIndex)
        {
            int newVal = Convert.ToInt32(byteData[byteIndex]);
            return newVal;
        }
    }
}

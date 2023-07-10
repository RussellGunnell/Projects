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
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Encoder_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string fileName;
        private Bitmap loadedImage;
        private Bitmap modifiedImage;
        private string ppmType;

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bool errorCaught = false;
                try
                {
                    fileName = Path.GetFileName(openFileDialog1.FileName);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: Please select a PPM file!");
                    errorCaught = true;
                }
                //The user selects a file to be read.

                if (!errorCaught)
                {
                    try
                    {
                        StreamReader fileSR = new StreamReader(openFileDialog1.FileName);
                        ppmType = fileSR.ReadLine();
                        //P3 or P6?

                        fileSR.ReadLine();
                        //Skips the comment line.

                        string rawDeminsions = fileSR.ReadLine();
                        char[] dimensions = new char[rawDeminsions.Length];
                        rawDeminsions.CopyTo(0, dimensions, 0, rawDeminsions.Length);
                        //Fetches dimensions.

                        string rawWidth = "";
                        bool spaceDetected = false;
                        string rawHeight = "";
                        for (int i = 0; i < dimensions.Length; i++)
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
                        }
                        //The width and height of the image is divided by a space,
                        //so this loop reads through the line one character at a time.

                        int width = Convert.ToInt32(rawWidth);
                        int height = Convert.ToInt32(rawHeight);
                        //integer variables formed from the dimensions line.

                        fileSR.ReadLine();
                        //Skips the line that tells the maximum RGB value in the picture.

                        loadedImage = new Bitmap(width, height);
                        switch (ppmType)
                        {
                            case "P3":
                                for (int y = 0; y < loadedImage.Height; y++)
                                {
                                    for (int x = 0; x < loadedImage.Width; x++)
                                    {
                                        Color pixelColor = GetP3Color(fileSR);
                                        loadedImage.SetPixel(x, y, pixelColor);
                                    }
                                }
                                fileSR.Dispose();
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
                                for (int y = 0; y < loadedImage.Height; y++)
                                {
                                    for (int x = 0; x < loadedImage.Width; x++)
                                    {
                                        int redVal = GetP6Data(data, byteIndex);
                                        byteIndex++;
                                        int greenVal = GetP6Data(data, byteIndex);
                                        byteIndex++;
                                        int blueVal = GetP6Data(data, byteIndex);
                                        byteIndex++;
                                        Color pixelColor = Color.FromArgb(redVal, greenVal, blueVal);
                                        loadedImage.SetPixel(x, y, pixelColor);
                                    }
                                }
                                break;
                            default:
                                MessageBox.Show("Error: Please select a PPM file!");
                                break;
                        }
                        //Sets the pixels according to the RGB values collected.
                        pictureBox1.Image = loadedImage;
                        //Formats and displays the image to the user.
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("The PPM file was formatted incorrectly, or it was not a P3/P6 type.");
                        errorCaught = true;
                    }
                    modifiedImage = loadedImage;
                    string rawClassified = textBox1.Text;
                    rawClassified = rawClassified.ToUpper();
                    char[] classified = new char[rawClassified.Length];
                    rawClassified.CopyTo(0, classified, 0, rawClassified.Length);
                    //Prepares the variables necessary for the user-inputted message to be encoded.
                    if (classified.Length > modifiedImage.Width * modifiedImage.Height)
                    {
                        MessageBox.Show("OH NO!\nThe image isn't big enough to contain the message.\nPlease pick a different file, or enter a shorter message.");
                        errorCaught = true;
                    }
                    else if (classified.Length > (modifiedImage.Width * modifiedImage.Height) / 100)
                    {
                        MessageBox.Show("WARNING! Your message takes up an alarming amount of space in this image!\nThis will likely make your message noticeable in the picture.\nYou can still proceed, but you may want to consider loading a different image instead.");
                    }
                    if (!errorCaught)
                    {
                        int z = 0;
                        //"z" is used as a substitute for "i",
                        //because apparently the program doesn't like when "i" coexists in a try/catch statement.
                        for (int y = 0; y < modifiedImage.Height; y++)
                        {
                            for (int x = 0; x < modifiedImage.Width; x++)
                            {
                                Color pixelColor = modifiedImage.GetPixel(x, y);
                                if (z < classified.Length && classified.Length >= (modifiedImage.Height * modifiedImage.Width) - (y * modifiedImage.Width) - x)
                                {
                                    pixelColor = Color.FromArgb(pixelColor.R, pixelColor.G, Convert.ToInt32(classified[z]));
                                    z++;
                                }
                                //condition is met where the message needs to be encoded.
                                else if (pixelColor.B == 32)
                                {
                                    pixelColor = Color.FromArgb(pixelColor.R, pixelColor.G, 33);
                                }
                                //A slight exception is made outside the range of numbers.
                                //This way, I can accomodate messages containing spaces.
                                else if (pixelColor.B >= 48 && pixelColor.B <= 90 && pixelColor.B <= 69)
                                {
                                    pixelColor = Color.FromArgb(pixelColor.R, pixelColor.G, 47);
                                }
                                //Runs if the message is not being encoded. (Rounds blue value downward.)
                                else if (pixelColor.B >= 48 && pixelColor.B <= 90 && pixelColor.B >= 70)
                                {
                                    pixelColor = Color.FromArgb(pixelColor.R, pixelColor.G, 91);
                                }
                                //Runs if the message is not being encoded. (Rounds blue value upward.)

                                if (pixelColor != modifiedImage.GetPixel(x, y))
                                {
                                    modifiedImage.SetPixel(x, y, pixelColor);
                                }
                                //If the retrieved pixel color has been modified, apply that modification to the image.
                            }
                        }
                        //Decimal range: 48-90 (include the beginning and ending numbers).
                        //An exception is made for spaces with a value of 32.
                        pictureBox2.Image = modifiedImage;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = saveFileDialog1.FileName;

                    using (StreamWriter dataSaver = new StreamWriter(path + ".ppm"))
                    {
                        dataSaver.WriteLine("P3");
                        dataSaver.WriteLine("# This is a modified copy of an existing ppm file named " + '"' + fileName + '"');
                        dataSaver.WriteLine(modifiedImage.Width + " " + modifiedImage.Height);
                        dataSaver.WriteLine("255");
                        //Set up header

                        for (int y = 0; y < modifiedImage.Height; y++)
                        {
                            for (int x = 0; x < modifiedImage.Width; x++)
                            {
                                Color pixelColor = modifiedImage.GetPixel(x, y);
                                dataSaver.WriteLine(pixelColor.R);
                                dataSaver.WriteLine(pixelColor.G);
                                dataSaver.WriteLine(pixelColor.B);
                            }
                        }
                        //Write each color value to a file.
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: Please make sure a .ppm file has been loaded.");
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

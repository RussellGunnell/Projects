using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Ascii_Art_Generator
{
    internal class BitmapConverter
    {
        public string Asciitize(Bitmap pixelData)//Bitmap
        {
            //kernel size
            int kernelWidth = 5;
            int kernelHeight = 10;

            //Define the current pixel to target inside the kernel.
            int targetX = 0;
            int targetY = 0;

            //Create a list to collect values from every pixel in the kernel.
            List<double> pixelList = new List<double>();

            string ascii = "";

            //Column
            for (int modY = 0; modY < pixelData.Height; modY += kernelHeight)
            {
                //Row
                for (int modX = 0; modX < pixelData.Width; modX += kernelWidth)
                {
                    //while loop runs until the last pixel of the kernel is added to the pixelList.
                    while (targetY != kernelHeight)
                    {
                        //The modX and modY indexes direct the target variable's aim.
                        Color pixelVal = pixelData.GetPixel(targetX + modX, targetY + modY);
                        double grayPixel = ConvertToGrayscale(pixelVal);
                        pixelList.Add(grayPixel);
                        targetX += 1;

                        //Target the next row of a kernel if the edge is detected.
                        if (targetX == kernelWidth)
                        {
                            targetX = 0;
                            targetY += 1;
                        }
                    }

                    //Calculate the average value of the pixels and return a a pair of ascii characters.
                    double grayKernel = AverageColor(pixelList);
                    ascii = GrayToString(grayKernel, ascii);

                    //Reset variables for the next iteration of the loop.
                    targetY = 0;
                    pixelList.Clear();

                    //Check to see if the remaining pixels in this row can fill up a full kernel.
                    int remX = pixelData.Width - modX - kernelWidth;
                    if (remX < kernelWidth)
                    {
                        modX = pixelData.Width;
                    }
                }
                //Check to see if the remaining pixels in this column can fill up a full kernel.
                int remY = pixelData.Height - modY - kernelHeight;
                if (remY < kernelHeight)
                {
                    modY = pixelData.Height;
                }

                //Adds a line break to the string output when the edge of a row of pixels is detected.
                ascii += Environment.NewLine;
            }
            return ascii;
        }

        double ConvertToGrayscale(Color pixelVal)
        {
            //Initialize RGB values as double variables.
            double R = pixelVal.R;
            double G = pixelVal.G;
            double B = pixelVal.B;

            //Make that thing gray!
            double grayPixel = ((R * 0.299) + (G * 0.587) + (B * 0.114)) / 255.0;
            return grayPixel;
        }

        double AverageColor(List<double> pixelList)
        {
            //Calculate the average of the grayscale values from a kernel. 
            double grayKernel = (pixelList.Sum() / pixelList.Count);
            return grayKernel;
        }

        string GrayToString(double grayKernel, string ascii)
        {
            //Determine the pair of ascii characters to be used, base of the average grayscale value of a pixel in the current kernel.
            if (grayKernel < 0.17)
            {
                ascii += "!!";
            }
            else if (grayKernel < 0.33)
            {
                ascii += ";!";
            }
            else if (grayKernel < 0.50)
            {
                ascii += ":;";
            }
            else if (grayKernel < 0.66)
            {
                ascii += ",:";
            }
            else if (grayKernel < 0.83)
            {
                ascii += ".,";
            }
            else
            {
                ascii += " .";
            }
            return ascii;
        }
    }
}

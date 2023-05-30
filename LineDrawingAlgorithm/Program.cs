using LineDrawingAlgorithm;
using System.Diagnostics;
using System.Transactions;

namespace DDA_Line_Drawing_Algorithm
{
    class Program
    {
        static void Main()
        {
            //STEP 1 - GET THE COORDINATES FROM THE USER
            Console.WriteLine("Welcome! To begin, please enter an X coordinate for your first dot.");
            int targetX = Convert.ToInt32(GetUserInput());
            Console.WriteLine("Next, enter another number for the Y coordinate.");
            int targetY = Convert.ToInt32(GetUserInput());
            Console.WriteLine("Great! Now for the second dot. Please enter a coordinate for X.");
            int endX = Convert.ToInt32(GetUserInput());
            Console.WriteLine("Almost done! Enter one more number for the Y coordinate!");
            int endY = Convert.ToInt32(GetUserInput());

            //These variables will be used as the starting point (targetX, targetY) and the ending point (endX, endY) of the line.
            //Both input retrieval and validation is included within the "GetUserInput" function.


            //STEP 2 - CALCULATE THE DIFFIRENCES BETWEEN COORDINATES
            int diffX = GetDifference(targetX, endX);
            int diffY = GetDifference(targetY, endY);
            
            //These "diff" variables will be used to calculate the numerator (diffY) and denominator (diffX) of the slope.


            //STEP 3 - IDENTIFY THE SMALLEST ABSOLUTE VALUE OF THE TWO DIFFERENCES
            int SmallAbsVal = GetSmallestAbsoluteValue(diffX, diffY);
            
            //Used to determine the stopping point of the "for" loop below.


            //STEP 4 - CALCULATE THE SLOPE BY SIMPLIFYING X AND Y
            for (int i = 2; i <= (SmallAbsVal / 2); i++)
            {
                while (diffX == (diffX / i) * i && diffY == (diffY / i) * i)
                {
                    diffX = diffX / i;
                    diffY = diffY / i;
                }//while ends
            }//for ends.
            
            //This "for" loop checks if the numerator (diffY) and the denominator (diffX) of the slope are both divisble by a number (i).
            //If so, the "while" loop will divide both values by that number repeatedly until it is no longer visible.
            //The "for" loop ends when "i" is more than half the smallest absolute value of the numerator/denomiator (SmallAbsVal)


            //STEP 5 - DRAW THE LINE ACCORDINGLY
            Console.Clear();
            Point newDot = new Point(targetX, targetY);
            newDot.Draw();
            while (targetX != endX)
            {
                targetX += diffX;
                targetY += diffY;
                newDot.Move(targetX, targetY);
            }//while ends

            //An instance of an object (newDot) is created to draw the line. It marks the starting point (targetX, targetY) directly after being created.
            //The "while" loop modifies the coordinates of the target variables using the values from the numerator and denominator of the slope (diffX/diffY)
            //After modifying the target variables, they will be used to move the dot across the line and to the next spot to be marked.
            //The "while" loop ends when the targeted "X" coordinate matches with the designated ending "X" coordinate (endX).


        }
        static string GetUserInput()
        {
            string input = Console.ReadLine();
            bool valid = false;
            while (valid == false)
            {
                char[] arr = new char[input.Length];
                input.CopyTo(0, arr, 0, input.Length);
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != '1' && arr[i] != '2' && arr[i] != '3' && arr[i] != '4' && arr[i] != '5' && arr[i] != '6' && arr[i] != '7' && arr[i] != '8' && arr[i] != '9' &&
                        arr[i] != '0')
                    {
                        i = arr.Length;
                        Console.WriteLine("Whoops, that won't do! Please try again entering numbers only. (No decimals either.)");
                        input = Console.ReadLine();
                    }//if ends
                    else if (i == arr.Length - 1)
                    {
                        valid = true;
                    }//else ends
                }//for ends
            }//while ends
            return input;
        }//function ends

        //Input validation ensures that the user enters an integer.


        static int GetDifference(int input0, int input1)
        {
            int inputD = input1 - input0;
            return inputD;
        }//function ends

        //This function exists to avoid redundant code when calculating the values for "diffX" and "diffY".


        static int GetSmallestAbsoluteValue(int diffX, int diffY)
        {
            int SmallAbsVal;
            diffX = checkForNegative(diffX);
            diffY = checkForNegative(diffY);
            if (diffX < diffY)
            {
                SmallAbsVal = diffX;
            }//if ends
            else
            {
                SmallAbsVal = diffY;
            }//else ends
            return SmallAbsVal;
        }//function ends
        
        //This function compares possibly altered versions of "diffX" and "diffY" that are always positive, to determine its return value (SmallAbsVal).
    
        
        static int checkForNegative(int diff)
        {
            if (diff < 0)
            {
                diff = diff * -1;
            }//if ends
            return diff;
        }//function ends

        //This function exists to avoid redundant code in the "GetSmallestAbsoluteValue" function.
        //It ensures that the "diffX" and "diffY" values are positive while being used to determine a variable that holds an absolute value (smallAbsVal).

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineDrawingAlgorithm
{
    class Point
    {
        //parameters
        int x = 0;
        int y = 0;

        //constructor method
        public Point(int targetX, int targetY)
        {
            x = targetX;
            y = targetY;
        }//method ends

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }//end method

        public void Move(int targetX, int targetY)//Draw is called here.
        {
            x = targetX;
            y = targetY;
            Draw();
        }//end method
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillaInfografía
{
    class Methods
    {
        public void createLinesGrid(int dimension, Graphics gr, int height, int width, string isVisible)
        {
            Pen myPen ;
            if (isVisible == "Visible Grid")
            {
                myPen = new Pen(Brushes.Black, 1);
            }
            else
            {
                myPen = new Pen(Brushes.Transparent, 1);
            }
            //Draw Horizontal lines
            for (int i = 1; i <= height; i += dimension)
            {
                gr.DrawLine(myPen, 0, i, width, i);
            }
            //Draw Vertical lines
            for (int i = 1; i <= width; i += dimension)
            {
                gr.DrawLine(myPen, i, 0, i, height);
            }
        }
        public void createLinesGridZoom(int xDimension, int yDimension, Graphics gr, int height, int width, string isVisible)
        {
            Pen myPen;
            if (isVisible == "Visible Grid")
            {
                myPen = new Pen(Brushes.Black, 1);
            }
            else
            {
                myPen = new Pen(Brushes.Transparent, 1);
            }
            //Draw Horizontal lines
            for (int i = 1; i <= height; i += yDimension)
            {
                gr.DrawLine(myPen, 0, i, width, i);
            }
            //Draw Vertical lines
            for (int i = 1; i <= width; i += xDimension)
            {
                gr.DrawLine(myPen, i, 0, i, height);
            }
        }
        public Color[,] createMatrix(int xScreenSize, int yScreenSize)
        {
            Color[,] matrixPixelData = new Color[xScreenSize, yScreenSize];
            for (int i = 0; i < matrixPixelData.GetLength(0); i++)
            {
                for (int j = 0; j < matrixPixelData.GetLength(1); j++)
                {
                    matrixPixelData[i, j] = Color.Transparent;
                }
            }
            return matrixPixelData;
        }
        public void printMatrix(Color[,] matrixPixelData)
        {
            for (int i = 0; i < matrixPixelData.GetLength(0); i++)
            {
                for (int j = 0; j < matrixPixelData.GetLength(1); j++)
                {
                    Console.Write(matrixPixelData[i,j] +" , ");
                }
                Console.WriteLine();
            }
        }
        public int GetDistance(int[] points)
        {
            return (int)Math.Sqrt(Math.Pow(points[2] - points[0], 2) + Math.Pow(points[3] - points[1], 2));
        }
        public bool iCanDraw(int x, int y, int xLimit, int yLimit)
        {
            return (x < xLimit && x >= 0) && (y < yLimit && y >= 0);
        }
        public int getMin(int a, int b)
        {
            return a < b ? a : b;
        }
        public int getMax(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}

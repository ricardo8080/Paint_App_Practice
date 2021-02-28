using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillaInfografía
{
    class Algorithms
    {
        Color[,] matrixPixelData;
        Methods processMethods = new Methods();
        public Color[,] createLineBres(Graphics gr, int xdimension, int ydimension, int []points, SolidBrush sb, Color[,] matrixPixelData)
        {
            int xa = points[0];
            int ya = points[1];
            int xb = points[2];
            int yb = points[3];
            int width = xb - xa;
            int height = yb - ya;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (width < 0) dx1 = -1; else if (width > 0) dx1 = 1;
            if (height < 0) dy1 = -1; else if (height > 0) dy1 = 1;
            if (width < 0) dx2 = -1; else if (width > 0) dx2 = 1;
            int longest = Math.Abs(width);
            int shortest = Math.Abs(height);
            if (!(longest > shortest))
            {
                longest = Math.Abs(height);
                shortest = Math.Abs(width);
                if (height < 0) dy2 = -1; else if (height > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                matrixPixelData[(int)xa / xdimension, (int)ya / ydimension] = paintFrame(gr, xdimension, ydimension, xa, ya, sb, matrixPixelData);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    xa += dx1;
                    ya += dy1;
                }
                else
                {
                    xa += dx2;
                    ya += dy2;
                }
            }
            return matrixPixelData;
        }
        public Color[,] createLineDDA(Graphics gr, int xdimension, int ydimension, int []points, SolidBrush sb, Color[,] matrixPixelData)
        {
            int dx = points[2] - points[0];
            int dy = points[3] - points[1];
            int steps, k;
            float xIncrement, yIncrement, x = points[0], y = points[1];
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                steps = Math.Abs(dx);
            }
            else
            {
                steps = Math.Abs(dy);
            }
            xIncrement = dx / (float)steps;
            yIncrement = dy / (float)steps;
            matrixPixelData[(int)x / xdimension, (int)y / ydimension] = paintFrame(gr, xdimension, ydimension, x, y, sb, matrixPixelData);
            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement; 
                paintFrame(gr, xdimension, ydimension, x, y, sb, matrixPixelData);
            }
            return matrixPixelData;
        }
        public Color[,] createCircleMidPoint(Graphics gr, SolidBrush sb,int xCenter, int yCenter, int r,int xdimension, int ydimension, Color[,] matrixPixelData)
        {
            int x = 0, y = r;
            int d = 3 - 2 * r;
            matrixPixelData = paintMidPointCircle(gr, xdimension, ydimension  , xCenter, yCenter, x, y,sb, matrixPixelData);
            while (y >= x)
            {
                x++;
                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                    d = d + 4 * x + 6;
                matrixPixelData = paintMidPointCircle(gr, xdimension, ydimension, xCenter, yCenter, x, y,sb, matrixPixelData);
            }
            return matrixPixelData;
        }
        public Color[,] createEllipseMidPoint(Graphics gr, SolidBrush sb, int xdimension, int ydimension, int xCenter, int yCenter, int rx,int ry, Color[,] matrixPixelData) {
            int rx2 = rx * rx;
            int ry2 = ry * ry;
            int twoRx2 = 2 * rx2;
            int twoRy2 = 2 * ry2;
            int p;
            int x = 0;
            int y = ry;
            int px = 0;
            int py = twoRx2 * y;
            //Paint first Set of Points
            matrixPixelData = paintMidPointEllipse(gr, sb, xdimension, ydimension, xCenter, yCenter, x, y,matrixPixelData);
            //region 1
            p = (int) (ry2-(rx2* ry) + (0.25 *rx2));
            while ( px < py) 
            {
                x++;
                px += twoRy2;
                if (p < 0)
                {
                    p += ry2 + px;
                }
                else 
                {
                    y--;
                    py -= twoRx2;
                    p += ry2 + px - py;
                }
                matrixPixelData = paintMidPointEllipse(gr, sb, xdimension, ydimension, xCenter, yCenter, x, y, matrixPixelData);
            }
            //region2
            p = (int) (ry2 * (x+0.5) * (x+0.5) + rx2 * (y-1) * (y-1) - rx2 * ry2);
            while ( y > 0 ) 
            {
                y--;
                py -= twoRx2;
                if (p > 0)
                {
                    p += rx2 - py;
                }
                else
                {
                    x++;
                    px += twoRy2;
                    p += rx2 - py + px;
                }
                matrixPixelData = paintMidPointEllipse(gr, sb, xdimension, ydimension, xCenter, yCenter, x, y, matrixPixelData);
            }
            return matrixPixelData;
        }
        public Color paintFrame(Graphics gr, int xDimension, int yDimension, float xPoint, float yPoint, SolidBrush sb, Color[,] matrixPixelData)
        {
            int x = ((int)xPoint) / xDimension;
            int y = ((int)yPoint) / yDimension;
            if (processMethods.iCanDraw(x, y, matrixPixelData.GetLength(0), matrixPixelData.GetLength(1)))
            {
                gr.FillRectangle(sb, x * xDimension, y * yDimension, xDimension, yDimension);
                matrixPixelData[x, y] = sb.Color;
            }
            return sb.Color;
        }
        public void paintFrameWithCoordinate(Graphics gr, int xDimension, int yDimension, int x, int y, SolidBrush sb)
        {
            gr.FillRectangle(sb, x * xDimension, y * yDimension, xDimension, yDimension);
        }
        public Color[,] paintMidPointEllipse(Graphics gr, SolidBrush sb, int xdimension, int ydimension, int xCenter, int yCenter, int x, int y, Color[,] matrixPixelData)
        {
            int xLimit = matrixPixelData.GetLength(0);
            int yLimit = matrixPixelData.GetLength(1);
            int xDown = (int)(xCenter + x) / xdimension;
            int xUp = (int)(xCenter - x) / xdimension;
            int yDown = (int)(yCenter + y) / ydimension;
            int yUp = (int)(yCenter - y) / ydimension;
            if (processMethods.iCanDraw(xDown, yDown, xLimit, yLimit)) { 
                matrixPixelData[xDown, yDown] = paintFrame(gr, xdimension, ydimension, xCenter + x, yCenter + y, sb, matrixPixelData);
            }
            if (processMethods.iCanDraw(xUp, yDown, xLimit, yLimit))
            {
                matrixPixelData[xUp, yDown] = paintFrame(gr, xdimension, ydimension, xCenter - x, yCenter + y, sb, matrixPixelData);
            }
            if (processMethods.iCanDraw(xUp, yUp, xLimit, yLimit))
            {
                matrixPixelData[xUp, yUp] = paintFrame(gr, xdimension, ydimension, xCenter - x, yCenter - y, sb, matrixPixelData);
            }
            if (processMethods.iCanDraw(xDown, yUp, xLimit, yLimit))
            {
                matrixPixelData[xDown, yUp] = paintFrame(gr, xdimension, ydimension, xCenter + x, yCenter - y, sb, matrixPixelData);
            }
            return matrixPixelData;
        }
        public Color[,] paintMidPointCircle(Graphics gr, int xdimension, int ydimension, int xc, int yc, int x, int y, SolidBrush sb, Color[,] matrixPixelData)
        {
            int xLimit = matrixPixelData.GetLength(0);
            int yLimit = matrixPixelData.GetLength(1);

            int xDown = (int)(xc + x) / xdimension;
            int xUp = (int)(xc - x) / xdimension;
            int yDown = (int)(yc + y) / ydimension;
            int yUp = (int)(yc - y) / ydimension;

            int xyDown = (int)(xc + y) / xdimension;
            int xyUp = (int)(xc - y) / xdimension;
            int yxDown = (int)(yc + x) / ydimension;
            int yxUp = (int)(yc - x) / ydimension;

            if (processMethods.iCanDraw(xDown, yDown, xLimit, yLimit))
            {
                matrixPixelData[xDown, yDown] = paintFrame(gr, xdimension , ydimension, xc + x, yc + y, sb, matrixPixelData);
            }
            if (processMethods.iCanDraw(xUp, yDown, xLimit, yLimit))
            {
                matrixPixelData[xUp, yDown] = paintFrame(gr, xdimension, ydimension, xc - x, yc + y, sb, matrixPixelData);
            }
            if (processMethods.iCanDraw(xDown, yUp, xLimit, yLimit))
            {
                matrixPixelData[xDown, yUp] = paintFrame(gr, xdimension, ydimension, xc + x, yc - y, sb, matrixPixelData);
            }
            if (processMethods.iCanDraw(xUp, yUp, xLimit, yLimit))
            {
                matrixPixelData[xUp, yUp] = paintFrame(gr, xdimension, ydimension, xc - x, yc - y, sb, matrixPixelData);
            }
            if (processMethods.iCanDraw(xyDown, yxDown, xLimit, yLimit))
            {
                matrixPixelData[xyDown, yxDown] = paintFrame(gr, xdimension, ydimension, xc + y, yc + x, sb, matrixPixelData);
            }
            if (processMethods.iCanDraw(xyUp, yxDown, xLimit, yLimit))
            {
                matrixPixelData[xyUp, yxDown] = paintFrame(gr, xdimension, ydimension, xc - y, yc + x, sb, matrixPixelData);
            }
            if (processMethods.iCanDraw(xyDown, yxUp, xLimit, yLimit))
            {
                matrixPixelData[xyDown, yxUp] = paintFrame(gr, xdimension, ydimension, xc + y, yc - x, sb, matrixPixelData);
            }
            if (processMethods.iCanDraw(xyUp, yxUp, xLimit, yLimit))
            {
                matrixPixelData[xyUp, yxUp] = paintFrame(gr, xdimension, ydimension, xc - y, yc - x, sb, matrixPixelData);
            }
            return matrixPixelData;
        }
        public Color[,] createFillColor(int xdimension, int ydimension, int xPoint, int yPoint, Color[,] matrixPixelData, Color fillColor)
        {
            int x = ((int)xPoint) / xdimension;
            int y = ((int)yPoint) / ydimension;
            this.matrixPixelData = matrixPixelData;
            Color oldColor = this.matrixPixelData[x, y];
            if (oldColor != fillColor) {
                floodFill(xdimension, ydimension, x, y, fillColor, oldColor);
            }

            return this.matrixPixelData;
        }
        private void floodFill(int xdimension, int ydimension, int x, int y, Color fillColor, Color oldColor) {
            if (processMethods.iCanDraw(x, y, this.matrixPixelData.GetLength(0), this.matrixPixelData.GetLength(1)) 
                && this.matrixPixelData[x, y] == oldColor)
            {
                this.matrixPixelData[x, y] = fillColor;
                floodFill(xdimension, ydimension, x + 1, y, fillColor, oldColor);
                floodFill(xdimension, ydimension, x - 1, y, fillColor, oldColor);
                floodFill(xdimension, ydimension, x, y + 1, fillColor, oldColor);
                floodFill(xdimension, ydimension, x, y - 1, fillColor, oldColor);
            }
        }
        internal Color[,] calcNewPointsOfMat(int grades, int[] center, Color[,] tempMatrix, int[] matrixBorder, Color[,] normalSizeMatrix)
        {
            this.matrixPixelData = normalSizeMatrix;
            double newX = 0;
            double newY = 0;
            cleanSectionOfMatrix(matrixBorder, tempMatrix);
            for (int i = matrixBorder[0]; i < matrixBorder[2]; i++)//i is X
            {
                for (int j = matrixBorder[1]; j < matrixBorder[3]; j++)//j is Y
                {   //center[0] is Xc and center[1] is Yc 
                    newX = center[0] + (i - center[0]) * Math.Cos(grades) - (j - center[1]) * Math.Sin(grades);
                    newY = center[1] + (i - center[0]) * Math.Sin(grades) + (j - center[1]) * Math.Cos(grades);
                    if (processMethods.iCanDraw((int)Math.Ceiling(newX), (int)Math.Ceiling(newY), this.matrixPixelData.GetLength(0), this.matrixPixelData.GetLength(1))
                        && tempMatrix[i - matrixBorder[0], j - matrixBorder[1]] != Color.Transparent)
                    {
                        //this.matrixPixelData[i, j] = Color.Transparent;
                        this.matrixPixelData[(int)Math.Ceiling(newX), (int)Math.Ceiling(newY)] = tempMatrix[i - matrixBorder[0], j - matrixBorder[1]];
                    }
                }
                Console.WriteLine();
            }
            return this.matrixPixelData;
        }
        internal Color[,] calcNewPointsOfMatv2(int grades, double[] center, Color[,] tempMatrix, double[] matrixBorder, Color[,] normalSizeMatrix, int xDim, int yDim)
        {
            this.matrixPixelData = normalSizeMatrix;
            double newX = 0;
            double newY = 0;
            int xs = (int)matrixBorder[0] / xDim;
            int ys = (int)matrixBorder[1] / yDim;
            int xe = (int)matrixBorder[2] / xDim;
            int ye = (int)matrixBorder[3] / yDim;
            int a = 0, b = 0;
            cleanSectionOfMatrixv2(matrixBorder, tempMatrix,xDim,yDim);
            for (int i = xs; i < xe; i++)//i is X
            {
                for (int j = ys; j < ye; j++)//j is Y
                {   //center[0] is Xc and center[1] is Yc 
                    newX = center[0] + ((matrixBorder[0] + a * xDim) - center[0]) * Math.Cos(grades) - ((matrixBorder[1] + b * yDim) - center[1]) * Math.Sin(grades);
                    newY = center[1] + ((matrixBorder[0] + a * xDim) - center[0]) * Math.Sin(grades) + ((matrixBorder[1] + b * yDim) - center[1]) * Math.Cos(grades);
                    a++;
                    Console.WriteLine((matrixBorder[0] + a * xDim) + " " + (matrixBorder[1] + b * yDim));
                    Console.WriteLine(newX + " " + newY);
                    if (processMethods.iCanDraw((int)Math.Ceiling(newX), (int)Math.Ceiling(newY), this.matrixPixelData.GetLength(0), this.matrixPixelData.GetLength(1))
                        && tempMatrix[i - xs, j - ys] != Color.Transparent)
                    {
                        this.matrixPixelData[(int)Math.Ceiling(newX)/xDim, (int)Math.Ceiling(newY)/yDim] = tempMatrix[i - xs, j - ys];
                    }
                }
                b++;
                Console.WriteLine();
            }
            return this.matrixPixelData;
        }

        private void cleanSectionOfMatrix(int[] matrixBorder, Color[,] tempMatrix) {
            for (int i = matrixBorder[0]; i < matrixBorder[2]; i++)//i is X
            {
                for (int j = matrixBorder[1]; j < matrixBorder[3]; j++)//j is Y
                {
                    this.matrixPixelData[i, j] = Color.Transparent;
                }
            }
        }
        private void cleanSectionOfMatrixv2(double[] matrixBorder, Color[,] tempMatrix, int xDim, int yDim)
        {
            int xs = (int)matrixBorder[0] / xDim;
            int ys = (int)matrixBorder[1] / yDim;
            int xe = (int)matrixBorder[2] / xDim;
            int ye = (int)matrixBorder[3] / yDim;

            for (int i = xs; i < xe; i++)
            {
                for (int j = ys; j < ye; j++)
                {
                    this.matrixPixelData[i, j] = Color.Transparent;
                }
            }
        }
    }
}

namespace enumLists
{
    public enum SelectedAlg
    {
        CLICK,          //0
        DDA,            //1
        BRESEN,         //2
        MIDDLECIRCLE,   //3
        MIDDLEELLIPSE,  //4
        ZOOM,           //5
        FILLCOLOR,      //6
        TRANSLATION,    //7
        ROTATION,       //8
        SCALING         //9
    }
    public enum CurrentStateOfClick
    {
        FIRSTCLICK,      //0
        SECONDCLICK,        //1
        THIRDCLICK     //2
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enumLists;
using System.Windows.Forms;

namespace GrillaInfografía
{
    public partial class MSPaint : Form
    {
        Algorithms algorithms = new Algorithms();
        Methods pm = new Methods();
        Graphics gr = null; //panel name
        ColorDialog varColorPicker = new ColorDialog(); //Color of Lines
        Color[,] normalSizeMatrix;
        Color[,] scaleSizeMatrix;
        int xDimMatrix = 0;
        int yDimMatrix = 0;
        int dimension = 10;                                    //Dimension of the grid boxes
        int chosenMove = (int)SelectedAlg.CLICK;               // Which function is selected
        int countClick = (int) CurrentStateOfClick.FIRSTCLICK; //When DDA alg. used, checks if you clicked one or two times
        int[] pointsToCreate = new int[4];                   // points to create line x1, y1, x2, y2
        int xRadio, yRadio;                                    //radio for ellipse
        int[] matrixBorder = new int[4];                     // For zoom and translation
        double[] matrixBorderv2 = new double[4];                     // For zoom and translation
        double[] pointsToCreatev2 = new double[4];                   // points to create line x1, y1, x2, y2


        public MSPaint()
        {
            InitializeComponent();
            restartPanel();
        }
        private void restartButton_Click(object sender, EventArgs e) {
            Refresh();
            restartPanel();
        }
        private void gridVisibility_Click(object sender, EventArgs e)
        {
            if (gridVisibility.Text == "Visible Grid")
            {
                gridVisibility.Text = "Invisible Grid";
            }
            else
            {
                gridVisibility.Text = "Visible Grid";
            }
            Refresh();
            gr = gridPanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(colorPicker.BackColor);
            createPictureWithCurrentMatrix(gr, sb, gridPanel.Width, gridPanel.Height, gridVisibility.Text);
            gr.Dispose();
            sb.Dispose();
        }
        private void buttonPaintBox_Click(object sender, EventArgs e)
        {
            chosenMove = (int) SelectedAlg.CLICK;
            countClick = (int) CurrentStateOfClick.FIRSTCLICK; 
        }
        private void buttonDDA_Click(object sender, EventArgs e)
        {
            chosenMove = (int)SelectedAlg.DDA;
            countClick = (int)CurrentStateOfClick.FIRSTCLICK;
        }
        private void bresenhamButton_Click(object sender, EventArgs e)
        {
            chosenMove = (int)SelectedAlg.BRESEN;
            countClick = (int)CurrentStateOfClick.FIRSTCLICK;
        }
        private void midCircleButton_Click(object sender, EventArgs e)
        {
            chosenMove = (int)SelectedAlg.MIDDLECIRCLE;
            countClick = (int)CurrentStateOfClick.FIRSTCLICK;
        }
        private void midEllipseButton_Click(object sender, EventArgs e)
        {
            chosenMove = (int)SelectedAlg.MIDDLEELLIPSE;
            countClick = (int)CurrentStateOfClick.FIRSTCLICK;
        }
        private void zoomButton_Click(object sender, EventArgs e) {
            chosenMove = (int)SelectedAlg.ZOOM;
            countClick = (int)CurrentStateOfClick.FIRSTCLICK;
        }
        private void floodFillButton_Click(object sender, EventArgs e)  {
            chosenMove = (int)SelectedAlg.FILLCOLOR;
            countClick = (int)CurrentStateOfClick.FIRSTCLICK;
        }
        private void translationButton_Click(object sender, EventArgs e) {
            chosenMove = (int)SelectedAlg.TRANSLATION;
            countClick = (int)CurrentStateOfClick.FIRSTCLICK;
        }
        private void rotationButton_Click(object sender, EventArgs e) {
            chosenMove = (int)SelectedAlg.ROTATION;
            countClick = (int)CurrentStateOfClick.FIRSTCLICK;
        }
        private void scaleButton_Click(object sender, EventArgs e)
        {

            chosenMove = (int)SelectedAlg.SCALING;
            countClick = (int)CurrentStateOfClick.FIRSTCLICK;
        }
        private void colorPicker_Click(object sender, EventArgs e)
        {
            if (varColorPicker.ShowDialog() == DialogResult.OK) 
            {
                colorPicker.BackColor = varColorPicker.Color;
            }
        }
        private void leftButton_Click(object sender, EventArgs e)
        {
            rotateClick(true);
            //rotateClickv2(true);
        }
        private void rightButton_Click(object sender, EventArgs e)
        {
            rotateClick(false);
            //rotateClickv2(false);
        }
        private void gridPanel_MouseClick(object sender, MouseEventArgs e)
        {
            switch (chosenMove)
            {
                case (int)SelectedAlg.CLICK:
                    paintFrameWithClick();
                    break;
                case (int)SelectedAlg.DDA:
                    paintWithAlgorithmDDA();
                    break;
                case (int)SelectedAlg.BRESEN:
                    paintWithAlgorithmBres();
                    break;
                case (int)SelectedAlg.MIDDLECIRCLE:
                    paintWithAlgorithmMiddleCircle();
                    break;
                case (int)SelectedAlg.MIDDLEELLIPSE:
                    paintWithAlgorithmMiddleEllipse();
                    break;
                case (int)SelectedAlg.ZOOM:
                    if (e.Button.Equals(MouseButtons.Left))
                    {
                        zoom(true);
                    }
                    else
                    {
                        zoom(false);
                    }
                    break;
                case (int)SelectedAlg.FILLCOLOR:
                    fillColor();
                    break;
                case (int)SelectedAlg.TRANSLATION:
                    if (e.Button.Equals(MouseButtons.Left))
                    {
                        translation();
                    }
                    else 
                    {
                        countClick = (int) CurrentStateOfClick.FIRSTCLICK;
                    }
                    break;
                case (int)SelectedAlg.ROTATION:
                    if (e.Button.Equals(MouseButtons.Left))
                    {
                        //rotationv2();
                        rotation();
                    }
                    else
                    {
                        countClick = (int)CurrentStateOfClick.FIRSTCLICK;
                    }
                    break;
                case (int)SelectedAlg.SCALING:
                    scaleMethod();
                    break;
            }
        }
        private void restartPanel()
        {
            gr = gridPanel.CreateGraphics();
            dimension = Int32.Parse(dimensionGripFrame.Text);
            double xV = (double)gridPanel.Width / dimension;
            double yV = (double)gridPanel.Height / dimension;
            pm.createLinesGrid(dimension,gr,gridPanel.Height,gridPanel.Width,gridVisibility.Text);
            this.normalSizeMatrix = pm.createMatrix((int)Math.Ceiling(xV), (int)Math.Ceiling(yV));
            xDimMatrix = dimension;
            yDimMatrix = dimension;
            widthLabel.Text = "Pixels x: " + (int)Math.Ceiling(xV);
            heightLabel.Text = "Pixels y: " + (int)Math.Ceiling(yV);
            gr.Dispose();
        }
        private void paintFrameWithClick()
        {
            gr = gridPanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(colorPicker.BackColor);
            Point point = gridPanel.PointToClient(Cursor.Position);
            algorithms.paintFrame(gr, xDimMatrix, yDimMatrix, point.X, point.Y, sb, this.normalSizeMatrix);
            setMatrixValue((int)point.X/dimension, (int)point.Y/dimension, sb.Color);
            gr.Dispose();
            sb.Dispose();
            //processMethods.printMatrix(matrixPixelData);
        }
        private void paintWithAlgorithmDDA()
        {
            gr = gridPanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(colorPicker.BackColor);
            Point point = gridPanel.PointToClient(Cursor.Position);
            if (countClick == (int) CurrentStateOfClick.FIRSTCLICK)
            {
                countClick = (int) CurrentStateOfClick.SECONDCLICK;
                pointsToCreate[0] = point.X;
                pointsToCreate[1] = point.Y;
                algorithms.paintFrame(gr, xDimMatrix, yDimMatrix, point.X, point.Y,sb, this.normalSizeMatrix);
                setMatrixValue((int)point.X / dimension, (int)point.Y / dimension, sb.Color);
            }
            else if (countClick == (int) CurrentStateOfClick.SECONDCLICK) 
            {
                countClick = (int) CurrentStateOfClick.FIRSTCLICK;
                pointsToCreate[2] = point.X;
                pointsToCreate[3] = point.Y;
                setMatrix(algorithms.createLineDDA(gr, xDimMatrix, yDimMatrix, pointsToCreate, sb, this.normalSizeMatrix));
            }
            gr.Dispose();
            sb.Dispose();
        }
        private void paintWithAlgorithmBres()
        {
            Point point = gridPanel.PointToClient(Cursor.Position);
            gr = gridPanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(colorPicker.BackColor);
            if (countClick == (int) CurrentStateOfClick.FIRSTCLICK)
            {
                countClick = (int) CurrentStateOfClick.SECONDCLICK;
                pointsToCreate[0] = point.X;
                pointsToCreate[1] = point.Y;
                algorithms.paintFrame(gr, xDimMatrix, yDimMatrix, point.X, point.Y, sb, this.normalSizeMatrix);
                setMatrixValue((int)point.X / dimension, (int)point.Y / dimension, sb.Color);
            }
            else if (countClick == (int) CurrentStateOfClick.SECONDCLICK)
            {
                countClick = (int) CurrentStateOfClick.FIRSTCLICK;
                pointsToCreate[2] = point.X;
                pointsToCreate[3] = point.Y;
                setMatrix(algorithms.createLineBres(gr, xDimMatrix, yDimMatrix, pointsToCreate, sb, this.normalSizeMatrix));
            }
            gr.Dispose();
            sb.Dispose();
        }
        private void paintWithAlgorithmMiddleCircle() {
            Point point = gridPanel.PointToClient(Cursor.Position);
            if (countClick == (int)CurrentStateOfClick.FIRSTCLICK)
            {
                countClick = (int)CurrentStateOfClick.SECONDCLICK;
                pointsToCreate[0] = point.X;
                pointsToCreate[1] = point.Y;
            }
            else if (countClick == (int)CurrentStateOfClick.SECONDCLICK)
            {
                countClick = (int)CurrentStateOfClick.FIRSTCLICK;
                pointsToCreate[2] = point.X;
                pointsToCreate[3] = point.Y;
                int radio = pm.GetDistance(pointsToCreate);
                gr = gridPanel.CreateGraphics();
                SolidBrush sb = new SolidBrush(colorPicker.BackColor);
                setMatrix(algorithms.createCircleMidPoint(gr,sb,pointsToCreate[0], pointsToCreate[1],radio, xDimMatrix, yDimMatrix, this.normalSizeMatrix));
                gr.Dispose();
                sb.Dispose();
            }
        }
        private void paintWithAlgorithmMiddleEllipse()
        {
            gr = gridPanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(colorPicker.BackColor);
            Point point = gridPanel.PointToClient(Cursor.Position);
            if (countClick == (int)CurrentStateOfClick.FIRSTCLICK)
            {
                countClick = (int)CurrentStateOfClick.SECONDCLICK;
                pointsToCreate[0] = point.X; //xcenter
                pointsToCreate[1] = point.Y; //ycenter
            }
            else if (countClick == (int)CurrentStateOfClick.SECONDCLICK)
            {
                countClick = (int)CurrentStateOfClick.THIRDCLICK;
                pointsToCreate[2] = point.X;
                pointsToCreate[3] = point.Y;
                xRadio = pm.GetDistance(pointsToCreate); //xradio
                algorithms.paintFrame(gr, xDimMatrix, yDimMatrix, point.X, point.Y, sb, this.normalSizeMatrix);
                setMatrixValue((int)point.X / dimension, (int)point.Y / dimension, sb.Color);
            }
            else if (countClick == (int)CurrentStateOfClick.THIRDCLICK)
            {
                countClick = (int)CurrentStateOfClick.FIRSTCLICK;
                pointsToCreate[2] = point.X;
                pointsToCreate[3] = point.Y;
                yRadio = pm.GetDistance(pointsToCreate);//yradio
                setMatrix(algorithms.createEllipseMidPoint(gr, sb, xDimMatrix, yDimMatrix, pointsToCreate[0], pointsToCreate[1], xRadio, yRadio, this.normalSizeMatrix));
            }
            gr.Dispose();
            sb.Dispose();
        }
        private void fillColor()
        {
            gr = gridPanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(colorPicker.BackColor);
            Point point = gridPanel.PointToClient(Cursor.Position);
            setMatrix(algorithms.createFillColor(xDimMatrix, yDimMatrix, point.X, point.Y, this.normalSizeMatrix, sb.Color));
            createPictureWithCurrentMatrix(gr, sb, gridPanel.Width, gridPanel.Height, gridVisibility.Text);
            gr.Dispose();
            sb.Dispose();
        }
        private void zoom(Boolean isZoomIn)
        {
            gr = gridPanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Transparent);
            if (isZoomIn)
            {
                Point point = gridPanel.PointToClient(Cursor.Position);
                createZoomVisual(gr, sb, point.X, point.Y);
            }
            else
            {
                xDimMatrix = dimension;
                yDimMatrix = dimension;
                Refresh();
                createPictureWithCurrentMatrix(gr, sb, gridPanel.Width, gridPanel.Height, gridVisibility.Text);
            }
            gr.Dispose();
            sb.Dispose();
        }
        private void createZoomVisual(Graphics gr, SolidBrush sb, int xPoint, int yPoint)
        {
            if (countClick == (int)CurrentStateOfClick.FIRSTCLICK)
            {
                countClick = (int)CurrentStateOfClick.SECONDCLICK;
                pointsToCreate[0] = (int)xPoint;
                pointsToCreate[1] = (int)yPoint;
            }
            else if (countClick == (int)CurrentStateOfClick.SECONDCLICK)
            {
                countClick = (int)CurrentStateOfClick.FIRSTCLICK;
                matrixBorder[0] = pm.getMin(pointsToCreate[0], xPoint) / dimension; //xstart
                matrixBorder[1] = pm.getMin(pointsToCreate[1], yPoint) / dimension; //ystart
                matrixBorder[2] = pm.getMax(pointsToCreate[0], xPoint) / dimension; //xend
                matrixBorder[3] = pm.getMax(pointsToCreate[1], yPoint) / dimension; //yend
                int xPixels = Math.Abs(matrixBorder[0] - matrixBorder[2]) + 1;
                int yPixels = Math.Abs(matrixBorder[1] - matrixBorder[3]) + 1;
                xDimMatrix = (int)gridPanel.Width / xPixels;
                yDimMatrix = (int)gridPanel.Height / yPixels;
                Refresh();
                createZoomPictureWithCurrentMatrix(gr, sb, xPixels, yPixels, gridVisibility.Text);
            }
        }
        public void createZoomPictureWithCurrentMatrix(Graphics gr, SolidBrush sb, int xPixels, int yPixels, string isVisible)
        {
            pm.createLinesGridZoom(xDimMatrix, yDimMatrix, gr, gridPanel.Height, gridPanel.Width, gridVisibility.Text);
            for (int i = matrixBorder[0]; i <= matrixBorder[2]; i++)
            {
                for (int j = matrixBorder[1]; j <= matrixBorder[3]; j++)
                {
                    if (this.normalSizeMatrix[i, j] != Color.Transparent)
                    {
                        sb.Color = this.normalSizeMatrix[i, j];
                        algorithms.paintFrameWithCoordinate(gr, xDimMatrix, yDimMatrix, i - matrixBorder[0], j - matrixBorder[1], sb);
                    }
                }
            }
        }
        private void translation()
        {
            Point point = gridPanel.PointToClient(Cursor.Position);
            if (countClick == (int)CurrentStateOfClick.FIRSTCLICK)
            {
                countClick = (int)CurrentStateOfClick.SECONDCLICK;
                pointsToCreate[0] = (int)point.X / xDimMatrix;
                pointsToCreate[1] = (int)point.Y / yDimMatrix;
            }
            else if (countClick == (int)CurrentStateOfClick.SECONDCLICK)
            {
                countClick = (int)CurrentStateOfClick.THIRDCLICK;
                pointsToCreate[2] = (int)point.X / xDimMatrix;
                pointsToCreate[3] = (int)point.Y / yDimMatrix;
            }
            else if (countClick == (int)CurrentStateOfClick.THIRDCLICK)
            {
                gr = gridPanel.CreateGraphics();
                SolidBrush sb = new SolidBrush(Color.Transparent);
                countClick = (int)CurrentStateOfClick.FIRSTCLICK;
                int xSize = 1 + Math.Abs(pointsToCreate[0] - pointsToCreate[2]);
                int ySize = 1 + Math.Abs(pointsToCreate[1] - pointsToCreate[3]);
                int x = point.X / xDimMatrix;
                int y = point.Y / yDimMatrix;
                recreateSelectedSpaceOfMatrix(gr, sb, x , y, getSelMatrix());
                Refresh();
                createPictureWithCurrentMatrix(gr, sb, gridPanel.Width, gridPanel.Height, gridVisibility.Text);
                gr.Dispose();
                sb.Dispose();
            }
        }
        private void recreateSelectedSpaceOfMatrix(Graphics gr, SolidBrush sb, int xPoint, int yPoint, Color[,] temporalMatrix)
        {
            int xSize = 1 + Math.Abs(pointsToCreate[0] - pointsToCreate[2]);
            int ySize = 1 + Math.Abs(pointsToCreate[1] - pointsToCreate[3]);
            for (int i = xPoint; i < xPoint + xSize; i++)
            {
                for (int j = yPoint; j < yPoint + ySize; j++)
                {
                    if (pm.iCanDraw(i, j, this.normalSizeMatrix.GetLength(0), this.normalSizeMatrix.GetLength(1)))
                    {
                        sb.Color = temporalMatrix[i - xPoint, j - yPoint];
                        //algorithms.paintFrameWithCoordinate(gr, xDimMatrix, yDimMatrix, i, j, sb);
                        setMatrixValue(i, j, sb.Color);
                    }
                }
            }
        }
        private Color[,] getSelMatrix()
        {
            int xSize = 1 + Math.Abs(pointsToCreate[0] - pointsToCreate[2]);
            int ySize = 1 + Math.Abs(pointsToCreate[1] - pointsToCreate[3]);
            matrixBorder[0] = pm.getMin(pointsToCreate[0], pointsToCreate[2]); //xstart
            matrixBorder[1] = pm.getMin(pointsToCreate[1], pointsToCreate[3]); //ystart
            matrixBorder[2] = pm.getMax(pointsToCreate[0], pointsToCreate[2]); //xend
            matrixBorder[3] = pm.getMax(pointsToCreate[1], pointsToCreate[3]); //yend
            Color[,] temporalMatrix = new Color[xSize, ySize];
            for (int i = matrixBorder[0]; i <= matrixBorder[2]; i++)
            {
                for (int j = matrixBorder[1]; j <= matrixBorder[3]; j++)
                {
                    temporalMatrix[i - matrixBorder[0], j - matrixBorder[1]] = this.normalSizeMatrix[i, j];
                    this.normalSizeMatrix[i, j] = Color.Transparent;
                }
            }
            return temporalMatrix;
        }
        private void rotation()
        {
            Point point = gridPanel.PointToClient(Cursor.Position);
            if (countClick == (int)CurrentStateOfClick.FIRSTCLICK)
            {
                countClick = (int)CurrentStateOfClick.SECONDCLICK;
                pointsToCreate[0] = (int)point.X / xDimMatrix;
                pointsToCreate[1] = (int)point.Y / yDimMatrix;
                rotateBox.Visible = false;
                rotateBox.Location = new Point(55, 630); // Hardcoded value to take out of the panel the rotateBox
            }
            else if (countClick == (int)CurrentStateOfClick.SECONDCLICK)
            {
                countClick = (int)CurrentStateOfClick.FIRSTCLICK;
                pointsToCreate[2] = (int)point.X / xDimMatrix;
                pointsToCreate[3] = (int)point.Y / yDimMatrix;
                matrixBorder[0] = pm.getMin(pointsToCreate[0], pointsToCreate[2]); //xstart  
                matrixBorder[1] = pm.getMin(pointsToCreate[1], pointsToCreate[3]); //ystart  
                matrixBorder[2] = pm.getMax(pointsToCreate[0], pointsToCreate[2]); //xend
                matrixBorder[3] = pm.getMax(pointsToCreate[1], pointsToCreate[3]); //yend
                rotateBox.Visible = true;
                rotateBox.Location = new Point(point.X - 25, point.Y - 25); //25 is the initial position of the panel to paint, so -25
            }
        }
        private void rotateClick(bool isLeftClick)
        {
            rotateBox.Visible = false;
            rotateBox.Location = new Point(55, 630); // Hardcoded value to take out of the panel the rotateBox
            gr = gridPanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Transparent);
            if (isLeftClick)
            {
                this.normalSizeMatrix = algorithms.calcNewPointsOfMat(270 + (int)rotateGrades.Value //270 allow to have the right angle for left
                    , getCenterPoint(), getSelMatrix(), matrixBorder, this.normalSizeMatrix);
            }
            else
            {
                this.normalSizeMatrix = algorithms.calcNewPointsOfMat(90 + (int)rotateGrades.Value,//90 allow to have the right angle for right
                    getCenterPoint(), getSelMatrix(), matrixBorder, this.normalSizeMatrix);
            }
            Refresh();
            createPictureWithCurrentMatrix(gr, sb, gridPanel.Width, gridPanel.Height, gridVisibility.Text);
            gr.Dispose();
            sb.Dispose();
        }
        private void rotationv2()
        {
            Point point = gridPanel.PointToClient(Cursor.Position);
            if (countClick == (int)CurrentStateOfClick.FIRSTCLICK)
            {
                countClick = (int)CurrentStateOfClick.SECONDCLICK;
                pointsToCreatev2[0] = point.X;
                pointsToCreatev2[1] = point.Y;
                rotateBox.Visible = false;
                rotateBox.Location = new Point(55, 630); // Hardcoded value to take out of the panel the rotateBox
            }
            else if (countClick == (int)CurrentStateOfClick.SECONDCLICK)
            {
                countClick = (int)CurrentStateOfClick.FIRSTCLICK;
                pointsToCreatev2[2] = point.X;
                pointsToCreatev2[3] = point.Y;
                matrixBorderv2[0] = pm.getMinv2(pointsToCreatev2[0], pointsToCreatev2[2]); //xstart  
                matrixBorderv2[1] = pm.getMinv2(pointsToCreatev2[1], pointsToCreatev2[3]); //ystart  
                matrixBorderv2[2] = pm.getMaxv2(pointsToCreatev2[0], pointsToCreatev2[2]); //xend
                matrixBorderv2[3] = pm.getMaxv2(pointsToCreatev2[1], pointsToCreatev2[3]); //yend
                rotateBox.Visible = true;
                rotateBox.Location = new Point(point.X - 25, point.Y - 25); //25 is the initial position of the panel to paint, so -25
            }
        }
        private void rotateClickv2(bool isLeftClick)
        {
            rotateBox.Visible = false;
            rotateBox.Location = new Point(55, 630); // Hardcoded value to take out of the panel the rotateBox
            gr = gridPanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Transparent);
            if (isLeftClick)
            {
                this.normalSizeMatrix = algorithms.calcNewPointsOfMatv2( (int)rotateGrades.Value //270 allow to have the right angle for left
                    , getCenterPointv2(), getSelMatrixv2(), matrixBorderv2, this.normalSizeMatrix, xDimMatrix, yDimMatrix);
            }
            else
            {
                this.normalSizeMatrix = algorithms.calcNewPointsOfMatv2( (int)rotateGrades.Value,//90 allow to have the right angle for right
                    getCenterPointv2(), getSelMatrixv2(), matrixBorderv2, this.normalSizeMatrix, xDimMatrix, yDimMatrix);
            }
            Refresh();
            createPictureWithCurrentMatrix(gr, sb, gridPanel.Width, gridPanel.Height, gridVisibility.Text);
            gr.Dispose();
            sb.Dispose();
        }
        private Color[,] getSelMatrixv2()
        {

            int xSize = 1 + Math.Abs((int)(pointsToCreatev2[0]/ xDimMatrix) - (int)(pointsToCreatev2[2] / xDimMatrix));
            int ySize = 1 + Math.Abs((int)(pointsToCreatev2[1] / yDimMatrix) - (int)(pointsToCreatev2[3] / yDimMatrix)) ;
            matrixBorderv2[0] = pm.getMinv2(pointsToCreatev2[0], pointsToCreatev2[2]); //xstart
            matrixBorderv2[1] = pm.getMinv2(pointsToCreatev2[1], pointsToCreatev2[3]); //ystart
            matrixBorderv2[2] = pm.getMaxv2(pointsToCreatev2[0], pointsToCreatev2[2]); //xend
            matrixBorderv2[3] = pm.getMaxv2(pointsToCreatev2[1], pointsToCreatev2[3]); //yend
            int xs = (int)matrixBorderv2[0] / xDimMatrix;
            int ys = (int)matrixBorderv2[1] / yDimMatrix;
            int xe = (int)matrixBorderv2[2] / xDimMatrix;
            int ye = (int)matrixBorderv2[3] / yDimMatrix;
            Color[,] temporalMatrix = new Color[xSize, ySize];
            for (int i = xs; i <= xe; i++)
            {
                for (int j = ys; j <= ye; j++)
                {
                    temporalMatrix[i - xs, j - ys] = this.normalSizeMatrix[i, j];
                    this.normalSizeMatrix[i, j] = Color.Transparent;
                }
            }
            return temporalMatrix;
        }
        private void createPictureWithCurrentMatrix(Graphics gr, SolidBrush sb, int width, int height, string isVisible)
        {
            int x = (int)width / dimension;
            int y = (int)height / dimension;
            pm.createLinesGrid(dimension, gr, height, width, isVisible);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (this.normalSizeMatrix[i, j] != Color.Transparent)
                    {
                        sb.Color = this.normalSizeMatrix[i, j];
                        algorithms.paintFrameWithCoordinate(gr, xDimMatrix, yDimMatrix, i, j, sb);
                    }
                }
            }
        }
        private void scaleMethod()
        {
            int xSize = normalSizeMatrix.GetLength(0);
            int ySize = normalSizeMatrix.GetLength(1);
            decimal scaleSize = scaleDrop.Value; //sx, sy
            int xScaledSize = (int) Math.Floor(normalSizeMatrix.GetLength(0) * scaleSize);
            int yScaledSize = (int) Math.Floor(normalSizeMatrix.GetLength(1) * scaleSize);
            int xNewDimMatrix = (int)Math.Ceiling(xDimMatrix*scaleSize);
            int yNewDimMatrix = (int)Math.Ceiling(yDimMatrix*scaleSize);
            Refresh();
            pm.createLinesGrid(dimension, gr,xSize * xDimMatrix,ySize * yDimMatrix, gridVisibility.Text);

            this.scaleSizeMatrix = new Color[xScaledSize, yScaledSize];
            int iScale = 0;
            int jScale = 0;
            bool []cases = new bool[4];
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {

                    if (this.normalSizeMatrix[i, j] != Color.Transparent)
                    {
                        iScale = (int)Math.Floor(i * scaleSize);
                        jScale = (int)Math.Floor(j * scaleSize);
                        //cases[0] = (iScale*xNewDimMatrix > (i*xDimMatrix)) && jScale*yNewDimMatrix > (j*yDimMatrix) ;
                        //cases[1] = (iScale*xNewDimMatrix > (i*xDimMatrix)) && jScale*yNewDimMatrix < (j*yDimMatrix) ;
                        //cases[2] = (iScale*xNewDimMatrix < (i*xDimMatrix)) && jScale*yNewDimMatrix < (j*yDimMatrix) ;
                        //cases[3] = (iScale*xNewDimMatrix < (i*xDimMatrix)) && jScale*yNewDimMatrix > (j*yDimMatrix) ;
                        //if (pm.iCanDraw(iScale, jScale, scaleSizeMatrix.GetLength(0), scaleSizeMatrix.GetLength(1))) 
                        {
                            //this.scaleSizeMatrix[i, j] = this.normalSizeMatrix[i, j];
                        }
                    }
                }
            }
        }

        private int[] getCenterPoint()
        {
            int []centCoor = new int[2];
            centCoor[0] = (matrixBorder[0] + matrixBorder[2]) / 2;
            centCoor[1] = (matrixBorder[1] + matrixBorder[3]) / 2;
            return centCoor;
        }
        private double[] getCenterPointv2()
        {
            double[] centCoor = new double[2]; 

            centCoor[0] = (matrixBorderv2[0] + matrixBorderv2[2]) / 2;
            centCoor[1] = (matrixBorderv2[1] + matrixBorderv2[3]) / 2;
            return centCoor;
        }
        private void setMatrix(Color[,] matrixPixelData)
        {
            this.normalSizeMatrix = matrixPixelData;
        }
        private void setMatrixValue(int x, int y, Color color)
        {
            this.normalSizeMatrix[x, y] = color;
        }
 
    }
}

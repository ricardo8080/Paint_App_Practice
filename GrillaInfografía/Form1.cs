using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectAlg;
using System.Windows.Forms;

namespace GrillaInfografía
{
    public partial class Form1 : Form
    {
        Graphics gr = null; //panel name
        int dimension = 10; //Dimension of the grid boxes
        int countClick = (int) CurrentStateOfClick.FIRSTCLICK; //When DDA alg. used, checks if you clicked one or two times
        int [] pointsToCreate = new int [4]; // points to create line x1, y1, x2, y2
        int xRadio, yRadio; //radio for ellipse
        ColorDialog varColorPicker = new ColorDialog(); //Color of Lines
        Algorithms algorithms = new Algorithms();
        int chosenMove = (int) SelectedAlg.CLICK;
        public Form1()
        {
            InitializeComponent();
        }

        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {
            createLinesGrid();
        }
        private void dimensionGripFrame_ValueChanged(object sender, EventArgs e)
        {
                Refresh();
                createLinesGrid();
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            Refresh();
            createLinesGrid();
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
            createLinesGrid();
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
        private void colorPicker_Click(object sender, EventArgs e)
        {
            if (varColorPicker.ShowDialog() == DialogResult.OK) 
            {
                colorPicker.BackColor = varColorPicker.Color;
            }
        }
        private void gridPanel_Click(object sender, EventArgs e)
        {
            switch (chosenMove)
            {
                case (int) SelectedAlg.CLICK:
                    paintFrameWithClick();
                    break;
                case (int) SelectedAlg.DDA:
                    paintWithAlgorithmDDA();
                    break;
                case (int) SelectedAlg.BRESEN:
                    paintWithAlgorithmBres();
                    break;
                case (int) SelectedAlg.MIDDLECIRCLE:
                    paintWithAlgorithmMiddleCircle();
                    break;
                case (int)SelectedAlg.MIDDLEELLIPSE:
                    paintWithAlgorithmMiddleEllipse();
                    break;

            }
        }
        private void createLinesGrid()
        {
            gr = gridPanel.CreateGraphics();
            dimension = Int32.Parse(dimensionGripFrame.Text);
            algorithms.createLinesGrid(dimension,gr,gridPanel.Height,gridPanel.Width,gridVisibility.Text);
            gr.Dispose();
        }
        private void paintFrameWithClick()
        {
            gr = gridPanel.CreateGraphics();
            SolidBrush sb = new SolidBrush(colorPicker.BackColor);
            Point point = gridPanel.PointToClient(Cursor.Position);
            algorithms.paintFrame(gr,dimension, point.X, point.Y , sb);
            gr.Dispose();
            sb.Dispose();
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
                algorithms.paintFrame(gr,dimension,point.X, point.Y,sb);
            }
            else if (countClick == (int) CurrentStateOfClick.SECONDCLICK) 
            {
                countClick = (int) CurrentStateOfClick.FIRSTCLICK;
                pointsToCreate[2] = point.X;
                pointsToCreate[3] = point.Y;
                algorithms.createLineDDA(gr, dimension, pointsToCreate, sb);
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
                algorithms.paintFrame(gr, dimension, point.X, point.Y, sb);
            }
            else if (countClick == (int) CurrentStateOfClick.SECONDCLICK)
            {
                countClick = (int) CurrentStateOfClick.FIRSTCLICK;
                pointsToCreate[2] = point.X;
                pointsToCreate[3] = point.Y;
                algorithms.createLineBres(gr, dimension, pointsToCreate, sb);
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
                int radio = algorithms.GetDistance(pointsToCreate);
                gr = gridPanel.CreateGraphics();
                SolidBrush sb = new SolidBrush(colorPicker.BackColor);
                algorithms.createCircleMidPoint(gr,sb,pointsToCreate[0], pointsToCreate[1],radio,dimension);
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
                xRadio = algorithms.GetDistance(pointsToCreate); //xradio
                algorithms.paintFrame(gr, dimension, point.X, point.Y, sb);
            }
            else if (countClick == (int)CurrentStateOfClick.THIRDCLICK)
            {
                countClick = (int)CurrentStateOfClick.FIRSTCLICK;
                pointsToCreate[2] = point.X;
                pointsToCreate[3] = point.Y;
                yRadio = algorithms.GetDistance(pointsToCreate);//yradio
                algorithms.createEllipseMidPoint(gr, sb, dimension,pointsToCreate[0], pointsToCreate[1], xRadio, yRadio);
            }
            gr.Dispose();
            sb.Dispose();
        }

    }

}

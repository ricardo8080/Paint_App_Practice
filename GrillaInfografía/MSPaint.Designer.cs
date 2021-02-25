
namespace GrillaInfografía
{
    partial class MSPaint
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.restartButton = new System.Windows.Forms.Button();
            this.buttonPaintBox = new System.Windows.Forms.Button();
            this.colorPicker = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gridVisibility = new System.Windows.Forms.Button();
            this.dimensionGripFrame = new System.Windows.Forms.NumericUpDown();
            this.bresenhamButton = new System.Windows.Forms.Button();
            this.midCircleButton = new System.Windows.Forms.Button();
            this.midEllipseButton = new System.Windows.Forms.Button();
            this.zoomButton = new System.Windows.Forms.Button();
            this.floodFillButton = new System.Windows.Forms.Button();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.translationButton = new System.Windows.Forms.Button();
            this.rotationButton = new System.Windows.Forms.Button();
            this.scaleButton = new System.Windows.Forms.Button();
            this.rotateBox = new System.Windows.Forms.GroupBox();
            this.rotateGrades = new System.Windows.Forms.NumericUpDown();
            this.rightButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionGripFrame)).BeginInit();
            this.rotateBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotateGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 611);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grid Size";
            // 
            // gridPanel
            // 
            this.gridPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridPanel.Location = new System.Drawing.Point(25, 25);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(1000, 600);
            this.gridPanel.TabIndex = 2;
            this.gridPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridPanel_MouseClick);
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(434, 639);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(75, 30);
            this.restartButton.TabIndex = 4;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // buttonPaintBox
            // 
            this.buttonPaintBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPaintBox.Location = new System.Drawing.Point(1104, 18);
            this.buttonPaintBox.Name = "buttonPaintBox";
            this.buttonPaintBox.Size = new System.Drawing.Size(115, 42);
            this.buttonPaintBox.TabIndex = 5;
            this.buttonPaintBox.Text = "Paint Box";
            this.buttonPaintBox.UseVisualStyleBackColor = true;
            this.buttonPaintBox.Click += new System.EventHandler(this.buttonPaintBox_Click);
            // 
            // colorPicker
            // 
            this.colorPicker.BackColor = System.Drawing.Color.Blue;
            this.colorPicker.Location = new System.Drawing.Point(1157, 492);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(25, 25);
            this.colorPicker.TabIndex = 7;
            this.colorPicker.TabStop = false;
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1104, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Alg. DDA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonDDA_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1101, 501);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Color";
            // 
            // gridVisibility
            // 
            this.gridVisibility.Location = new System.Drawing.Point(560, 639);
            this.gridVisibility.Name = "gridVisibility";
            this.gridVisibility.Size = new System.Drawing.Size(95, 30);
            this.gridVisibility.TabIndex = 9;
            this.gridVisibility.Text = "Invisible Grid";
            this.gridVisibility.UseVisualStyleBackColor = true;
            this.gridVisibility.Click += new System.EventHandler(this.gridVisibility_Click);
            // 
            // dimensionGripFrame
            // 
            this.dimensionGripFrame.Location = new System.Drawing.Point(515, 646);
            this.dimensionGripFrame.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dimensionGripFrame.Name = "dimensionGripFrame";
            this.dimensionGripFrame.Size = new System.Drawing.Size(39, 20);
            this.dimensionGripFrame.TabIndex = 10;
            this.dimensionGripFrame.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // bresenhamButton
            // 
            this.bresenhamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bresenhamButton.Location = new System.Drawing.Point(1104, 143);
            this.bresenhamButton.Name = "bresenhamButton";
            this.bresenhamButton.Size = new System.Drawing.Size(115, 42);
            this.bresenhamButton.TabIndex = 11;
            this.bresenhamButton.Text = "Alg. Bresenham";
            this.bresenhamButton.UseVisualStyleBackColor = true;
            this.bresenhamButton.Click += new System.EventHandler(this.bresenhamButton_Click);
            // 
            // midCircleButton
            // 
            this.midCircleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.midCircleButton.Location = new System.Drawing.Point(1104, 204);
            this.midCircleButton.Name = "midCircleButton";
            this.midCircleButton.Size = new System.Drawing.Size(115, 42);
            this.midCircleButton.TabIndex = 12;
            this.midCircleButton.Text = "Alg. Mid. Circle";
            this.midCircleButton.UseVisualStyleBackColor = true;
            this.midCircleButton.Click += new System.EventHandler(this.midCircleButton_Click);
            // 
            // midEllipseButton
            // 
            this.midEllipseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.midEllipseButton.Location = new System.Drawing.Point(1104, 268);
            this.midEllipseButton.Name = "midEllipseButton";
            this.midEllipseButton.Size = new System.Drawing.Size(115, 42);
            this.midEllipseButton.TabIndex = 13;
            this.midEllipseButton.Text = "Alg. Mid. Ellipse";
            this.midEllipseButton.UseVisualStyleBackColor = true;
            this.midEllipseButton.Click += new System.EventHandler(this.midEllipseButton_Click);
            // 
            // zoomButton
            // 
            this.zoomButton.Location = new System.Drawing.Point(763, 639);
            this.zoomButton.Name = "zoomButton";
            this.zoomButton.Size = new System.Drawing.Size(95, 30);
            this.zoomButton.TabIndex = 14;
            this.zoomButton.Text = "Zoom";
            this.zoomButton.UseVisualStyleBackColor = true;
            this.zoomButton.Click += new System.EventHandler(this.zoomButton_Click);
            // 
            // floodFillButton
            // 
            this.floodFillButton.Location = new System.Drawing.Point(662, 639);
            this.floodFillButton.Name = "floodFillButton";
            this.floodFillButton.Size = new System.Drawing.Size(95, 30);
            this.floodFillButton.TabIndex = 15;
            this.floodFillButton.Text = "Paint";
            this.floodFillButton.UseVisualStyleBackColor = true;
            this.floodFillButton.Click += new System.EventHandler(this.floodFillButton_Click);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(1154, 421);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(40, 13);
            this.heightLabel.TabIndex = 16;
            this.heightLabel.Text = "Pixel y:";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(1154, 451);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(40, 13);
            this.widthLabel.TabIndex = 17;
            this.widthLabel.Text = "Pixel x:";
            // 
            // translationButton
            // 
            this.translationButton.Location = new System.Drawing.Point(862, 639);
            this.translationButton.Name = "translationButton";
            this.translationButton.Size = new System.Drawing.Size(95, 30);
            this.translationButton.TabIndex = 18;
            this.translationButton.Text = "Translation";
            this.translationButton.UseVisualStyleBackColor = true;
            this.translationButton.Click += new System.EventHandler(this.translationButton_Click);
            // 
            // rotationButton
            // 
            this.rotationButton.Location = new System.Drawing.Point(963, 639);
            this.rotationButton.Name = "rotationButton";
            this.rotationButton.Size = new System.Drawing.Size(95, 30);
            this.rotationButton.TabIndex = 19;
            this.rotationButton.Text = "Rotation";
            this.rotationButton.UseVisualStyleBackColor = true;
            this.rotationButton.Click += new System.EventHandler(this.rotationButton_Click);
            // 
            // scaleButton
            // 
            this.scaleButton.Location = new System.Drawing.Point(1064, 639);
            this.scaleButton.Name = "scaleButton";
            this.scaleButton.Size = new System.Drawing.Size(95, 30);
            this.scaleButton.TabIndex = 20;
            this.scaleButton.Text = "Scaling";
            this.scaleButton.UseVisualStyleBackColor = true;
            this.scaleButton.Click += new System.EventHandler(this.scaleButton_Click);
            // 
            // rotateBox
            // 
            this.rotateBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rotateBox.Controls.Add(this.rotateGrades);
            this.rotateBox.Controls.Add(this.rightButton);
            this.rotateBox.Controls.Add(this.leftButton);
            this.rotateBox.Location = new System.Drawing.Point(55, 630);
            this.rotateBox.Name = "rotateBox";
            this.rotateBox.Size = new System.Drawing.Size(142, 41);
            this.rotateBox.TabIndex = 21;
            this.rotateBox.TabStop = false;
            this.rotateBox.Text = "Rotate In Grades";
            this.rotateBox.Visible = false;
            // 
            // rotateGrades
            // 
            this.rotateGrades.Location = new System.Drawing.Point(52, 15);
            this.rotateGrades.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rotateGrades.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rotateGrades.Name = "rotateGrades";
            this.rotateGrades.Size = new System.Drawing.Size(39, 20);
            this.rotateGrades.TabIndex = 11;
            this.rotateGrades.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(95, 15);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(41, 23);
            this.rightButton.TabIndex = 1;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(6, 15);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(40, 23);
            this.leftButton.TabIndex = 0;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // MSPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.rotateBox);
            this.Controls.Add(this.scaleButton);
            this.Controls.Add(this.rotationButton);
            this.Controls.Add(this.translationButton);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.floodFillButton);
            this.Controls.Add(this.zoomButton);
            this.Controls.Add(this.midEllipseButton);
            this.Controls.Add(this.midCircleButton);
            this.Controls.Add(this.bresenhamButton);
            this.Controls.Add(this.dimensionGripFrame);
            this.Controls.Add(this.gridVisibility);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.colorPicker);
            this.Controls.Add(this.buttonPaintBox);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.label1);
            this.Name = "MSPaint";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionGripFrame)).EndInit();
            this.rotateBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rotateGrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button buttonPaintBox;
        private System.Windows.Forms.PictureBox colorPicker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button gridVisibility;
        private System.Windows.Forms.NumericUpDown dimensionGripFrame;
        private System.Windows.Forms.Button bresenhamButton;
        private System.Windows.Forms.Button midCircleButton;
        private System.Windows.Forms.Button midEllipseButton;
        private System.Windows.Forms.Button zoomButton;
        private System.Windows.Forms.Button floodFillButton;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Button translationButton;
        private System.Windows.Forms.Button rotationButton;
        private System.Windows.Forms.Button scaleButton;
        private System.Windows.Forms.GroupBox rotateBox;
        private System.Windows.Forms.NumericUpDown rotateGrades;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button leftButton;
    }
}



namespace GrillaInfografía
{
    partial class Form1
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
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionGripFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grid Size";
            // 
            // gridPanel
            // 
            this.gridPanel.AutoSize = true;
            this.gridPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridPanel.Location = new System.Drawing.Point(25, 25);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(500, 500);
            this.gridPanel.TabIndex = 2;
            this.gridPanel.Click += new System.EventHandler(this.gridPanel_Click);
            this.gridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gridPanel_Paint);
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(148, 529);
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
            this.buttonPaintBox.Location = new System.Drawing.Point(560, 51);
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
            this.colorPicker.Location = new System.Drawing.Point(645, 525);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(25, 25);
            this.colorPicker.TabIndex = 7;
            this.colorPicker.TabStop = false;
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(560, 108);
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
            this.label2.Location = new System.Drawing.Point(552, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Color";
            // 
            // gridVisibility
            // 
            this.gridVisibility.Location = new System.Drawing.Point(229, 529);
            this.gridVisibility.Name = "gridVisibility";
            this.gridVisibility.Size = new System.Drawing.Size(95, 30);
            this.gridVisibility.TabIndex = 9;
            this.gridVisibility.Text = "Visible Grid";
            this.gridVisibility.UseVisualStyleBackColor = true;
            this.gridVisibility.Click += new System.EventHandler(this.gridVisibility_Click);
            // 
            // dimensionGripFrame
            // 
            this.dimensionGripFrame.Location = new System.Drawing.Point(90, 536);
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
            this.dimensionGripFrame.ValueChanged += new System.EventHandler(this.dimensionGripFrame_ValueChanged);
            // 
            // bresenhamButton
            // 
            this.bresenhamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bresenhamButton.Location = new System.Drawing.Point(560, 176);
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
            this.midCircleButton.Location = new System.Drawing.Point(560, 237);
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
            this.midEllipseButton.Location = new System.Drawing.Point(560, 301);
            this.midEllipseButton.Name = "midEllipseButton";
            this.midEllipseButton.Size = new System.Drawing.Size(115, 42);
            this.midEllipseButton.TabIndex = 13;
            this.midEllipseButton.Text = "Alg. Mid. Ellipse";
            this.midEllipseButton.UseVisualStyleBackColor = true;
            this.midEllipseButton.Click += new System.EventHandler(this.midEllipseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(711, 561);
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
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionGripFrame)).EndInit();
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
    }
}


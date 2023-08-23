namespace ExperimentSkylightframe
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonInsertSkylightframe = new System.Windows.Forms.Button();
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.textBoxFrameWidth = new System.Windows.Forms.TextBox();
            this.labelFrameWidth = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonInsertSkylightframe
            // 
            this.buttonInsertSkylightframe.Location = new System.Drawing.Point(108, 102);
            this.buttonInsertSkylightframe.Name = "buttonInsertSkylightframe";
            this.buttonInsertSkylightframe.Size = new System.Drawing.Size(187, 23);
            this.buttonInsertSkylightframe.TabIndex = 0;
            this.buttonInsertSkylightframe.Text = "Insert Skylightframe";
            this.buttonInsertSkylightframe.UseVisualStyleBackColor = true;
            this.buttonInsertSkylightframe.Click += new System.EventHandler(this.buttonInsertSkylightFrame_Click);
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.Location = new System.Drawing.Point(108, 52);
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.Size = new System.Drawing.Size(100, 22);
            this.textBoxMaterial.TabIndex = 1;
            // 
            // labelMaterial
            // 
            this.labelMaterial.AutoSize = true;
            this.labelMaterial.Location = new System.Drawing.Point(117, 30);
            this.labelMaterial.Name = "labelMaterial";
            this.labelMaterial.Size = new System.Drawing.Size(55, 16);
            this.labelMaterial.TabIndex = 2;
            this.labelMaterial.Text = "Material";
            // 
            // textBoxFrameWidth
            // 
            this.textBoxFrameWidth.Location = new System.Drawing.Point(274, 52);
            this.textBoxFrameWidth.Name = "textBoxFrameWidth";
            this.textBoxFrameWidth.Size = new System.Drawing.Size(100, 22);
            this.textBoxFrameWidth.TabIndex = 3;
            // 
            // labelFrameWidth
            // 
            this.labelFrameWidth.AutoSize = true;
            this.labelFrameWidth.Location = new System.Drawing.Point(291, 30);
            this.labelFrameWidth.Name = "labelFrameWidth";
            this.labelFrameWidth.Size = new System.Drawing.Size(42, 16);
            this.labelFrameWidth.TabIndex = 4;
            this.labelFrameWidth.Text = "Breite";
            this.labelFrameWidth.UseWaitCursor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 190);
            this.Controls.Add(this.labelFrameWidth);
            this.Controls.Add(this.textBoxFrameWidth);
            this.Controls.Add(this.labelMaterial);
            this.Controls.Add(this.textBoxMaterial);
            this.Controls.Add(this.buttonInsertSkylightframe);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInsertSkylightframe;
        private System.Windows.Forms.TextBox textBoxMaterial;
        private System.Windows.Forms.Label labelMaterial;
        private System.Windows.Forms.TextBox textBoxFrameWidth;
        private System.Windows.Forms.Label labelFrameWidth;
    }
}


namespace multi1
{
    partial class Form2
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
            this.first_image = new System.Windows.Forms.PictureBox();
            this.second_image = new System.Windows.Forms.PictureBox();
            this.firstimage = new System.Windows.Forms.Button();
            this.secondimage = new System.Windows.Forms.Button();
            this.compare = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.first_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.second_image)).BeginInit();
            this.SuspendLayout();
            // 
            // first_image
            // 
            this.first_image.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.first_image.Location = new System.Drawing.Point(53, 22);
            this.first_image.Name = "first_image";
            this.first_image.Size = new System.Drawing.Size(381, 391);
            this.first_image.TabIndex = 0;
            this.first_image.TabStop = false;
            // 
            // second_image
            // 
            this.second_image.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.second_image.Location = new System.Drawing.Point(514, 22);
            this.second_image.Name = "second_image";
            this.second_image.Size = new System.Drawing.Size(381, 391);
            this.second_image.TabIndex = 1;
            this.second_image.TabStop = false;
            // 
            // firstimage
            // 
            this.firstimage.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.firstimage.ForeColor = System.Drawing.Color.Teal;
            this.firstimage.Location = new System.Drawing.Point(101, 441);
            this.firstimage.Name = "firstimage";
            this.firstimage.Size = new System.Drawing.Size(295, 36);
            this.firstimage.TabIndex = 2;
            this.firstimage.Text = "add the first image";
            this.firstimage.UseVisualStyleBackColor = true;
            this.firstimage.Click += new System.EventHandler(this.firstimage_Click);
            // 
            // secondimage
            // 
            this.secondimage.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondimage.ForeColor = System.Drawing.Color.Teal;
            this.secondimage.Location = new System.Drawing.Point(549, 441);
            this.secondimage.Name = "secondimage";
            this.secondimage.Size = new System.Drawing.Size(295, 36);
            this.secondimage.TabIndex = 3;
            this.secondimage.Text = "add the second image";
            this.secondimage.UseVisualStyleBackColor = true;
            this.secondimage.Click += new System.EventHandler(this.secondimage_Click);
            // 
            // compare
            // 
            this.compare.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.compare.ForeColor = System.Drawing.Color.Teal;
            this.compare.Location = new System.Drawing.Point(29, 512);
            this.compare.Name = "compare";
            this.compare.Size = new System.Drawing.Size(123, 45);
            this.compare.TabIndex = 4;
            this.compare.Text = "compare";
            this.compare.UseVisualStyleBackColor = true;
            this.compare.Click += new System.EventHandler(this.compare_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(220, 512);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 20);
            this.resultLabel.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 727);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.compare);
            this.Controls.Add(this.secondimage);
            this.Controls.Add(this.firstimage);
            this.Controls.Add(this.second_image);
            this.Controls.Add(this.first_image);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.first_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.second_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox first_image;
        private System.Windows.Forms.PictureBox second_image;
        private System.Windows.Forms.Button firstimage;
        private System.Windows.Forms.Button secondimage;
        private System.Windows.Forms.Button compare;
        private System.Windows.Forms.Label resultLabel;
    }
}
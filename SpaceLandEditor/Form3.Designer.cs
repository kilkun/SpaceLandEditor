namespace SpaceLandEditor
{
    partial class Form3
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
            this.asda = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // asda
            // 
            this.asda.AutoSize = true;
            this.asda.Location = new System.Drawing.Point(85, 9);
            this.asda.Name = "asda";
            this.asda.Size = new System.Drawing.Size(103, 13);
            this.asda.TabIndex = 0;
            this.asda.Text = "Input a valid number";
            this.asda.Click += new System.EventHandler(this.label1_Click);
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(42, 35);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(202, 20);
            this.inputBox.TabIndex = 1;
            this.inputBox.TextChanged += new System.EventHandler(this.inputBox_TextChanged);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(102, 67);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 2;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 102);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.asda);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label asda;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button OK_Button;
    }
}
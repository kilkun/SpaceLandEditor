namespace SpaceLandEditor
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
            this.acbox = new System.Windows.Forms.TextBox();
            this.actionbox = new System.Windows.Forms.TextBox();
            this.tilebox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // acbox
            // 
            this.acbox.AccessibleDescription = "";
            this.acbox.Location = new System.Drawing.Point(89, 35);
            this.acbox.Name = "acbox";
            this.acbox.Size = new System.Drawing.Size(100, 20);
            this.acbox.TabIndex = 0;
            this.acbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // actionbox
            // 
            this.actionbox.Location = new System.Drawing.Point(89, 94);
            this.actionbox.Name = "actionbox";
            this.actionbox.Size = new System.Drawing.Size(100, 20);
            this.actionbox.TabIndex = 1;
            this.actionbox.TextChanged += new System.EventHandler(this.actionbox_TextChanged);
            // 
            // tilebox
            // 
            this.tilebox.Location = new System.Drawing.Point(89, 152);
            this.tilebox.Name = "tilebox";
            this.tilebox.Size = new System.Drawing.Size(100, 20);
            this.tilebox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Action Class";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Action Number";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tile";
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.Control;
            this.OK.Location = new System.Drawing.Point(92, 227);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 6;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tilebox);
            this.Controls.Add(this.actionbox);
            this.Controls.Add(this.acbox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Edit Tile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox acbox;
        private System.Windows.Forms.TextBox actionbox;
        private System.Windows.Forms.TextBox tilebox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OK;
    }
}
namespace Graphical_Programming_Language__Application
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
            this.rtxt_code = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtxt_split = new System.Windows.Forms.RichTextBox();
            this.btn_split = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxt_code
            // 
            this.rtxt_code.Location = new System.Drawing.Point(12, 374);
            this.rtxt_code.Name = "rtxt_code";
            this.rtxt_code.Size = new System.Drawing.Size(543, 163);
            this.rtxt_code.TabIndex = 0;
            this.rtxt_code.Text = "";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 343);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // rtxt_split
            // 
            this.rtxt_split.Location = new System.Drawing.Point(579, 374);
            this.rtxt_split.Name = "rtxt_split";
            this.rtxt_split.Size = new System.Drawing.Size(201, 163);
            this.rtxt_split.TabIndex = 0;
            this.rtxt_split.Text = "";
            // 
            // btn_split
            // 
            this.btn_split.Location = new System.Drawing.Point(217, 569);
            this.btn_split.Name = "btn_split";
            this.btn_split.Size = new System.Drawing.Size(75, 23);
            this.btn_split.TabIndex = 2;
            this.btn_split.Text = "Split";
            this.btn_split.UseVisualStyleBackColor = true;
            this.btn_split.Click += new System.EventHandler(this.btn_split_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 625);
            this.Controls.Add(this.btn_split);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtxt_split);
            this.Controls.Add(this.rtxt_code);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxt_code;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtxt_split;
        private System.Windows.Forms.Button btn_split;
    }
}


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtxt_code = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtxt_split = new System.Windows.Forms.RichTextBox();
            this.btn_split = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lbl_path = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 343);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(346, 568);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 3;
            this.btn_load.Text = "load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(454, 568);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.Location = new System.Drawing.Point(358, 600);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(0, 13);
            this.lbl_path.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 625);
            this.Controls.Add(this.lbl_path);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_split);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtxt_split);
            this.Controls.Add(this.rtxt_code);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxt_code;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtxt_split;
        private System.Windows.Forms.Button btn_split;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lbl_path;
    }
}


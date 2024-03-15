namespace WindowExplorerUI1
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
            this.Lui = new System.Windows.Forms.Button();
            this.Tien = new System.Windows.Forms.Button();
            this.TaiLai = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.TextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.D1 = new System.Windows.Forms.Button();
            this.C1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.D = new System.Windows.Forms.Button();
            this.C = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Lui
            // 
            this.Lui.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lui.Location = new System.Drawing.Point(0, 8);
            this.Lui.Name = "Lui";
            this.Lui.Size = new System.Drawing.Size(53, 28);
            this.Lui.TabIndex = 0;
            this.Lui.Text = "←";
            this.Lui.UseVisualStyleBackColor = true;
            this.Lui.Click += new System.EventHandler(this.Lui_Click);
            // 
            // Tien
            // 
            this.Tien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tien.Location = new System.Drawing.Point(50, 8);
            this.Tien.Name = "Tien";
            this.Tien.Size = new System.Drawing.Size(53, 28);
            this.Tien.TabIndex = 1;
            this.Tien.Text = "→";
            this.Tien.UseVisualStyleBackColor = true;
            this.Tien.Click += new System.EventHandler(this.Tien_Click);
            // 
            // TaiLai
            // 
            this.TaiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaiLai.Location = new System.Drawing.Point(782, 8);
            this.TaiLai.Name = "TaiLai";
            this.TaiLai.Size = new System.Drawing.Size(75, 29);
            this.TaiLai.TabIndex = 2;
            this.TaiLai.Text = "↻";
            this.TaiLai.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(109, 8);
            this.Search.Multiline = true;
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(667, 28);
            this.Search.TabIndex = 3;
            this.Search.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // splitContainer
            // 
            this.splitContainer.Location = new System.Drawing.Point(0, 42);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.X);
            this.splitContainer.Panel1.Controls.Add(this.D1);
            this.splitContainer.Panel1.Controls.Add(this.C1);
            this.splitContainer.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.D);
            this.splitContainer.Panel2.Controls.Add(this.C);
            this.splitContainer.Panel2.Controls.Add(this.webBrowser);
            this.splitContainer.Size = new System.Drawing.Size(857, 439);
            this.splitContainer.SplitterDistance = 285;
            this.splitContainer.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(285, 439);
            this.treeView1.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(568, 439);
            this.webBrowser.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "PC này ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // D1
            // 
            this.D1.FlatAppearance.BorderSize = 0;
            this.D1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.D1.Image = global::WindowExplorerUI1.Properties.Resources.d;
            this.D1.Location = new System.Drawing.Point(73, 104);
            this.D1.Name = "D1";
            this.D1.Size = new System.Drawing.Size(158, 26);
            this.D1.TabIndex = 8;
            this.D1.UseVisualStyleBackColor = true;
            this.D1.Click += new System.EventHandler(this.D1_Click);
            // 
            // C1
            // 
            this.C1.FlatAppearance.BorderSize = 0;
            this.C1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C1.Image = global::WindowExplorerUI1.Properties.Resources.c1;
            this.C1.Location = new System.Drawing.Point(73, 52);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(158, 31);
            this.C1.TabIndex = 7;
            this.C1.UseVisualStyleBackColor = true;
            this.C1.Click += new System.EventHandler(this.C1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowExplorerUI1.Properties.Resources.PC;
            this.pictureBox1.Location = new System.Drawing.Point(41, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // D
            // 
            this.D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.D.FlatAppearance.BorderSize = 0;
            this.D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.D.Image = global::WindowExplorerUI1.Properties.Resources.D_1;
            this.D.Location = new System.Drawing.Point(27, 115);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(406, 84);
            this.D.TabIndex = 3;
            this.D.UseVisualStyleBackColor = true;
            this.D.Click += new System.EventHandler(this.D_Click);
            // 
            // C
            // 
            this.C.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.C.FlatAppearance.BorderSize = 0;
            this.C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C.Image = global::WindowExplorerUI1.Properties.Resources.C2;
            this.C.Location = new System.Drawing.Point(27, 16);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(416, 78);
            this.C.TabIndex = 2;
            this.C.UseVisualStyleBackColor = true;
            this.C.Click += new System.EventHandler(this.C_Click);
            // 
            // X
            // 
            this.X.FlatAppearance.BorderSize = 0;
            this.X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.X.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.X.Location = new System.Drawing.Point(12, 9);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(23, 23);
            this.X.TabIndex = 9;
            this.X.Text = "∨";
            this.X.UseVisualStyleBackColor = true;
            this.X.Click += new System.EventHandler(this.X_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 484);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.TaiLai);
            this.Controls.Add(this.Tien);
            this.Controls.Add(this.Lui);
            this.Controls.Add(this.splitContainer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Lui;
        private System.Windows.Forms.Button Tien;
        private System.Windows.Forms.Button TaiLai;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.Button D;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button C1;
        private System.Windows.Forms.Button D1;
        private System.Windows.Forms.Button X;
    }
}


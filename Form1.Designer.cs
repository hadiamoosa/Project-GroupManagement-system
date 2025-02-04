
namespace Mid_Project
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblexitstu = new System.Windows.Forms.Label();
            this.lblviewstudent = new System.Windows.Forms.Label();
            this.lbladdstudent = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.picboxchange = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxchange)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.625F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.375F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblexitstu, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblviewstudent, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbladdstudent, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.04505F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.72973F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(199, 444);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblexitstu
            // 
            this.lblexitstu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblexitstu.AutoSize = true;
            this.lblexitstu.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexitstu.ForeColor = System.Drawing.Color.White;
            this.lblexitstu.Location = new System.Drawing.Point(69, 373);
            this.lblexitstu.Name = "lblexitstu";
            this.lblexitstu.Size = new System.Drawing.Size(60, 29);
            this.lblexitstu.TabIndex = 2;
            this.lblexitstu.Text = "EXIT";
            this.lblexitstu.Click += new System.EventHandler(this.lblexitstu_Click);
            // 
            // lblviewstudent
            // 
            this.lblviewstudent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblviewstudent.AutoSize = true;
            this.lblviewstudent.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblviewstudent.ForeColor = System.Drawing.Color.White;
            this.lblviewstudent.Location = new System.Drawing.Point(24, 222);
            this.lblviewstudent.Name = "lblviewstudent";
            this.lblviewstudent.Size = new System.Drawing.Size(151, 87);
            this.lblviewstudent.TabIndex = 1;
            this.lblviewstudent.Text = "VIEW, DELETE,EDIT STUDENT";
            this.lblviewstudent.Click += new System.EventHandler(this.lblviewstudent_Click);
            // 
            // lbladdstudent
            // 
            this.lbladdstudent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbladdstudent.AutoSize = true;
            this.lbladdstudent.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladdstudent.ForeColor = System.Drawing.Color.White;
            this.lbladdstudent.Location = new System.Drawing.Point(18, 141);
            this.lbladdstudent.Name = "lbladdstudent";
            this.lbladdstudent.Size = new System.Drawing.Size(162, 29);
            this.lbladdstudent.TabIndex = 0;
            this.lbladdstudent.Text = "ADD STUDENT";
            this.lbladdstudent.Click += new System.EventHandler(this.lbladdstudent_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Mid_Project.Properties.Resources.studentss;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.picboxchange, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(208, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(589, 444);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // picboxchange
            // 
            this.picboxchange.BackColor = System.Drawing.Color.White;
            this.picboxchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picboxchange.Image = global::Mid_Project.Properties.Resources.student1;
            this.picboxchange.Location = new System.Drawing.Point(3, 3);
            this.picboxchange.Name = "picboxchange";
            this.picboxchange.Size = new System.Drawing.Size(583, 438);
            this.picboxchange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxchange.TabIndex = 0;
            this.picboxchange.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxchange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblexitstu;
        private System.Windows.Forms.Label lblviewstudent;
        private System.Windows.Forms.Label lbladdstudent;
        private System.Windows.Forms.PictureBox picboxchange;
    }
}



namespace Mid_Project
{
    partial class Form5
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
            this.pbchangescreen = new System.Windows.Forms.PictureBox();
            this.pbtitle = new System.Windows.Forms.PictureBox();
            this.lblcreategrp = new System.Windows.Forms.Label();
            this.lblcrud = new System.Windows.Forms.Label();
            this.lblexit = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbchangescreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtitle)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.625F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.375F));
            this.tableLayoutPanel1.Controls.Add(this.pbchangescreen, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblexit, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblcrud, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblcreategrp, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pbtitle, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(167, 436);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // pbchangescreen
            // 
            this.pbchangescreen.BackColor = System.Drawing.Color.White;
            this.pbchangescreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbchangescreen.Image = global::Mid_Project.Properties.Resources.student1;
            this.pbchangescreen.Location = new System.Drawing.Point(176, 3);
            this.pbchangescreen.Name = "pbchangescreen";
            this.pbchangescreen.Size = new System.Drawing.Size(621, 436);
            this.pbchangescreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbchangescreen.TabIndex = 3;
            this.pbchangescreen.TabStop = false;
            // 
            // pbtitle
            // 
            this.pbtitle.BackColor = System.Drawing.Color.White;
            this.pbtitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbtitle.Image = global::Mid_Project.Properties.Resources.group;
            this.pbtitle.Location = new System.Drawing.Point(3, 3);
            this.pbtitle.Name = "pbtitle";
            this.pbtitle.Size = new System.Drawing.Size(161, 103);
            this.pbtitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbtitle.TabIndex = 2;
            this.pbtitle.TabStop = false;
            // 
            // lblcreategrp
            // 
            this.lblcreategrp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcreategrp.AutoSize = true;
            this.lblcreategrp.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold);
            this.lblcreategrp.ForeColor = System.Drawing.Color.White;
            this.lblcreategrp.Location = new System.Drawing.Point(9, 140);
            this.lblcreategrp.Name = "lblcreategrp";
            this.lblcreategrp.Size = new System.Drawing.Size(148, 46);
            this.lblcreategrp.TabIndex = 7;
            this.lblcreategrp.Text = "CREATE GROUP(Student)";
            this.lblcreategrp.Click += new System.EventHandler(this.lblcreategrp_Click);
            // 
            // lblcrud
            // 
            this.lblcrud.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcrud.AutoSize = true;
            this.lblcrud.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold);
            this.lblcrud.ForeColor = System.Drawing.Color.White;
            this.lblcrud.Location = new System.Drawing.Point(3, 249);
            this.lblcrud.Name = "lblcrud";
            this.lblcrud.Size = new System.Drawing.Size(161, 46);
            this.lblcrud.TabIndex = 8;
            this.lblcrud.Text = "VIEW,UPDATE,DELETE";
            this.lblcrud.Click += new System.EventHandler(this.lblcrud_Click);
            // 
            // lblexit
            // 
            this.lblexit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblexit.AutoSize = true;
            this.lblexit.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexit.ForeColor = System.Drawing.Color.White;
            this.lblexit.Location = new System.Drawing.Point(53, 367);
            this.lblexit.Name = "lblexit";
            this.lblexit.Size = new System.Drawing.Size(60, 29);
            this.lblexit.TabIndex = 9;
            this.lblexit.Text = "EXIT";
            this.lblexit.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbchangescreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbchangescreen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pbtitle;
        private System.Windows.Forms.Label lblexit;
        private System.Windows.Forms.Label lblcrud;
        private System.Windows.Forms.Label lblcreategrp;
    }
}
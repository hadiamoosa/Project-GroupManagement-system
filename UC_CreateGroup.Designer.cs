
namespace Mid_Project
{
    partial class UC_CreateGroup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblmain_proj = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.btncreate = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblmain_proj, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btncreate, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbldate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(934, 445);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblmain_proj
            // 
            this.lblmain_proj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblmain_proj.AutoSize = true;
            this.lblmain_proj.Font = new System.Drawing.Font("Castellar", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblmain_proj.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblmain_proj.Location = new System.Drawing.Point(414, 42);
            this.lblmain_proj.Name = "lblmain_proj";
            this.lblmain_proj.Size = new System.Drawing.Size(104, 26);
            this.lblmain_proj.TabIndex = 2;
            this.lblmain_proj.Text = "GROUP";
            // 
            // lbldate
            // 
            this.lbldate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold);
            this.lbldate.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lbldate.Location = new System.Drawing.Point(88, 152);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(135, 29);
            this.lbldate.TabIndex = 32;
            this.lbldate.Text = "Created_On";
            // 
            // btncreate
            // 
            this.btncreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncreate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btncreate.Location = new System.Drawing.Point(731, 366);
            this.btncreate.Name = "btncreate";
            this.btncreate.Size = new System.Drawing.Size(94, 46);
            this.btncreate.TabIndex = 37;
            this.btncreate.Text = "Create";
            this.btncreate.UseVisualStyleBackColor = true;
            this.btncreate.Click += new System.EventHandler(this.btncreate_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.Location = new System.Drawing.Point(341, 156);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 20);
            this.dateTimePicker1.TabIndex = 38;
            // 
            // UC_CreateGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_CreateGroup";
            this.Size = new System.Drawing.Size(934, 445);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblmain_proj;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Button btncreate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

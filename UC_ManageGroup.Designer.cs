
namespace Mid_Project
{
    partial class UC_ManageGroup
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnview = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.lblmain = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.lblcreate = new System.Windows.Forms.Label();
            this.dtpcreate = new System.Windows.Forms.DateTimePicker();
            this.txtid = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.75776F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.24224F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(966, 442);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnview, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnupdate, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btndelete, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblmain, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblid, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblcreate, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpcreate, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtid, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(464, 436);
            this.tableLayoutPanel2.TabIndex = 1;
//            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // btnview
            // 
            this.btnview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnview.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnview.Location = new System.Drawing.Point(30, 358);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(94, 46);
            this.btnview.TabIndex = 40;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnupdate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnupdate.Location = new System.Drawing.Point(184, 358);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(94, 46);
            this.btnupdate.TabIndex = 39;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndelete.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btndelete.Location = new System.Drawing.Point(339, 358);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(94, 46);
            this.btndelete.TabIndex = 38;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // lblmain
            // 
            this.lblmain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblmain.AutoSize = true;
            this.lblmain.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold);
            this.lblmain.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblmain.Location = new System.Drawing.Point(180, 40);
            this.lblmain.Name = "lblmain";
            this.lblmain.Size = new System.Drawing.Size(101, 29);
            this.lblmain.TabIndex = 33;
            this.lblmain.Text = "GROUPS";
            // 
            // lblid
            // 
            this.lblid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold);
            this.lblid.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblid.Location = new System.Drawing.Point(60, 149);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(33, 29);
            this.lblid.TabIndex = 34;
            this.lblid.Text = "Id";
            // 
            // lblcreate
            // 
            this.lblcreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcreate.AutoSize = true;
            this.lblcreate.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold);
            this.lblcreate.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblcreate.Location = new System.Drawing.Point(9, 258);
            this.lblcreate.Name = "lblcreate";
            this.lblcreate.Size = new System.Drawing.Size(135, 29);
            this.lblcreate.TabIndex = 35;
            this.lblcreate.Text = "Created_On";
            // 
            // dtpcreate
            // 
            this.dtpcreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpcreate.Location = new System.Drawing.Point(157, 262);
            this.dtpcreate.Name = "dtpcreate";
            this.dtpcreate.Size = new System.Drawing.Size(148, 20);
            this.dtpcreate.TabIndex = 41;
            // 
            // txtid
            // 
            this.txtid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtid.Location = new System.Drawing.Point(158, 153);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(145, 20);
            this.txtid.TabIndex = 42;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(490, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(456, 178);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // UC_ManageGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_ManageGroup";
            this.Size = new System.Drawing.Size(966, 442);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblmain;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Label lblcreate;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpcreate;
        private System.Windows.Forms.TextBox txtid;
    }
}

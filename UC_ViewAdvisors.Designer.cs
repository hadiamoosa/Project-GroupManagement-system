
namespace Mid_Project
{
    partial class UC_ViewAdvisors
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.datetime_dobadvisor = new System.Windows.Forms.DateTimePicker();
            this.txtfirstname = new System.Windows.Forms.TextBox();
            this.lbldesig_adv = new System.Windows.Forms.Label();
            this.lblsalary_adv = new System.Windows.Forms.Label();
            this.lbldateofbirth = new System.Windows.Forms.Label();
            this.lblgender = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lbllastname = new System.Windows.Forms.Label();
            this.lblcontact = new System.Windows.Forms.Label();
            this.lblfirstname = new System.Windows.Forms.Label();
            this.btnview = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.txtlastname = new System.Windows.Forms.TextBox();
            this.txtcontact = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtsalary = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.71429F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(910, 530);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(514, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(375, 259);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.datetime_dobadvisor, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtfirstname, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbldesig_adv, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblsalary_adv, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbldateofbirth, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblgender, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblemail, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbllastname, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblcontact, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblfirstname, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnview, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnupdate, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.btndelete, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtlastname, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtcontact, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtemail, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtsalary, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblid, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtid, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.comboBox2, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(487, 504);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // datetime_dobadvisor
            // 
            this.datetime_dobadvisor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datetime_dobadvisor.Location = new System.Drawing.Point(124, 280);
            this.datetime_dobadvisor.Name = "datetime_dobadvisor";
            this.datetime_dobadvisor.Size = new System.Drawing.Size(115, 20);
            this.datetime_dobadvisor.TabIndex = 22;
            // 
            // txtfirstname
            // 
            this.txtfirstname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtfirstname.Location = new System.Drawing.Point(124, 114);
            this.txtfirstname.Name = "txtfirstname";
            this.txtfirstname.Size = new System.Drawing.Size(115, 20);
            this.txtfirstname.TabIndex = 17;
            // 
            // lbldesig_adv
            // 
            this.lbldesig_adv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbldesig_adv.AutoSize = true;
            this.lbldesig_adv.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldesig_adv.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lbldesig_adv.Location = new System.Drawing.Point(7, 362);
            this.lbldesig_adv.Name = "lbldesig_adv";
            this.lbldesig_adv.Size = new System.Drawing.Size(107, 23);
            this.lbldesig_adv.TabIndex = 17;
            this.lbldesig_adv.Text = "Designation";
            // 
            // lblsalary_adv
            // 
            this.lblsalary_adv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblsalary_adv.AutoSize = true;
            this.lblsalary_adv.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold);
            this.lblsalary_adv.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblsalary_adv.Location = new System.Drawing.Point(273, 362);
            this.lblsalary_adv.Name = "lblsalary_adv";
            this.lblsalary_adv.Size = new System.Drawing.Size(59, 23);
            this.lblsalary_adv.TabIndex = 18;
            this.lblsalary_adv.Text = "Salary";
            // 
            // lbldateofbirth
            // 
            this.lbldateofbirth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbldateofbirth.AutoSize = true;
            this.lbldateofbirth.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldateofbirth.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lbldateofbirth.Location = new System.Drawing.Point(6, 279);
            this.lbldateofbirth.Name = "lbldateofbirth";
            this.lbldateofbirth.Size = new System.Drawing.Size(108, 23);
            this.lbldateofbirth.TabIndex = 15;
            this.lbldateofbirth.Text = "DateOfBirth";
            // 
            // lblgender
            // 
            this.lblgender.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblgender.AutoSize = true;
            this.lblgender.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgender.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblgender.Location = new System.Drawing.Point(268, 279);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(69, 23);
            this.lblgender.TabIndex = 16;
            this.lblgender.Text = "Gender";
            // 
            // lblemail
            // 
            this.lblemail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblemail.Location = new System.Drawing.Point(275, 196);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(55, 23);
            this.lblemail.TabIndex = 14;
            this.lblemail.Text = "Email";
            // 
            // lbllastname
            // 
            this.lbllastname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbllastname.AutoSize = true;
            this.lbllastname.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllastname.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lbllastname.Location = new System.Drawing.Point(257, 113);
            this.lbllastname.Name = "lbllastname";
            this.lbllastname.Size = new System.Drawing.Size(91, 23);
            this.lbllastname.TabIndex = 12;
            this.lbllastname.Text = "LastName";
            // 
            // lblcontact
            // 
            this.lblcontact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcontact.AutoSize = true;
            this.lblcontact.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcontact.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblcontact.Location = new System.Drawing.Point(24, 196);
            this.lblcontact.Name = "lblcontact";
            this.lblcontact.Size = new System.Drawing.Size(73, 23);
            this.lblcontact.TabIndex = 13;
            this.lblcontact.Text = "Contact";
            // 
            // lblfirstname
            // 
            this.lblfirstname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblfirstname.AutoSize = true;
            this.lblfirstname.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfirstname.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblfirstname.Location = new System.Drawing.Point(13, 113);
            this.lblfirstname.Name = "lblfirstname";
            this.lblfirstname.Size = new System.Drawing.Size(94, 23);
            this.lblfirstname.TabIndex = 11;
            this.lblfirstname.Text = "FirstName";
            // 
            // btnview
            // 
            this.btnview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnview.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnview.Location = new System.Drawing.Point(13, 436);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(94, 46);
            this.btnview.TabIndex = 19;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnadd_adv_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnupdate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnupdate.Location = new System.Drawing.Point(134, 436);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(94, 46);
            this.btnupdate.TabIndex = 20;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndelete.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btndelete.Location = new System.Drawing.Point(255, 436);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(94, 46);
            this.btndelete.TabIndex = 21;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // txtlastname
            // 
            this.txtlastname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtlastname.Location = new System.Drawing.Point(366, 114);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(118, 20);
            this.txtlastname.TabIndex = 23;
            // 
            // txtcontact
            // 
            this.txtcontact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtcontact.Location = new System.Drawing.Point(124, 197);
            this.txtcontact.Name = "txtcontact";
            this.txtcontact.Size = new System.Drawing.Size(115, 20);
            this.txtcontact.TabIndex = 24;
            // 
            // txtemail
            // 
            this.txtemail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtemail.Location = new System.Drawing.Point(366, 197);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(118, 20);
            this.txtemail.TabIndex = 25;
            // 
            // txtsalary
            // 
            this.txtsalary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtsalary.Location = new System.Drawing.Point(366, 363);
            this.txtsalary.Name = "txtsalary";
            this.txtsalary.Size = new System.Drawing.Size(118, 20);
            this.txtsalary.TabIndex = 28;
            // 
            // lblid
            // 
            this.lblid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblid.Location = new System.Drawing.Point(48, 30);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(25, 23);
            this.lblid.TabIndex = 29;
            this.lblid.Text = "Id";
            // 
            // txtid
            // 
            this.txtid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtid.Location = new System.Drawing.Point(124, 31);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(115, 20);
            this.txtid.TabIndex = 30;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.comboBox1.Location = new System.Drawing.Point(366, 280);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 21);
            this.comboBox1.TabIndex = 31;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Professor",
            "Associate Professor",
            "Assisstant Professor",
            "Lecturer",
            "Industry Professional"});
            this.comboBox2.Location = new System.Drawing.Point(124, 363);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(115, 21);
            this.comboBox2.TabIndex = 32;
            // 
            // UC_ViewAdvisors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_ViewAdvisors";
            this.Size = new System.Drawing.Size(910, 530);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblfirstname;
        private System.Windows.Forms.Label lbllastname;
        private System.Windows.Forms.Label lblcontact;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lbldateofbirth;
        private System.Windows.Forms.Label lblgender;
        private System.Windows.Forms.Label lbldesig_adv;
        private System.Windows.Forms.Label lblsalary_adv;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TextBox txtfirstname;
        private System.Windows.Forms.TextBox txtlastname;
        private System.Windows.Forms.TextBox txtcontact;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtsalary;
        private System.Windows.Forms.DateTimePicker datetime_dobadvisor;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

namespace Schooly.Forms
{
    partial class Frm_exam
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_set = new System.Windows.Forms.TabPage();
            this.btn_reset_ex = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_resumee = new System.Windows.Forms.TextBox();
            this.txt_DurationofExam = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_branch = new System.Windows.Forms.ComboBox();
            this.dtp_endtime = new System.Windows.Forms.DateTimePicker();
            this.dtp_dayOfExam = new System.Windows.Forms.DateTimePicker();
            this.dtp_starttime = new System.Windows.Forms.DateTimePicker();
            this.txt_subject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cb_drag_nivs = new System.Windows.Forms.ComboBox();
            this.btn_import_st_excel = new System.Windows.Forms.Button();
            this.btn_import_st_database = new System.Windows.Forms.Button();
            this.tab_docs = new System.Windows.Forms.TabPage();
            this.btn_st_by_age = new System.Windows.Forms.Button();
            this.btn_st_by_name = new System.Windows.Forms.Button();
            this.btn_st_by_massar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tab_set.SuspendLayout();
            this.tab_docs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_set);
            this.tabControl1.Controls.Add(this.tab_docs);
            this.tabControl1.Location = new System.Drawing.Point(12, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(617, 407);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_set
            // 
            this.tab_set.Controls.Add(this.btn_reset_ex);
            this.tab_set.Controls.Add(this.button2);
            this.tab_set.Controls.Add(this.txt_resumee);
            this.tab_set.Controls.Add(this.txt_DurationofExam);
            this.tab_set.Controls.Add(this.button1);
            this.tab_set.Controls.Add(this.cb_branch);
            this.tab_set.Controls.Add(this.dtp_endtime);
            this.tab_set.Controls.Add(this.dtp_dayOfExam);
            this.tab_set.Controls.Add(this.dtp_starttime);
            this.tab_set.Controls.Add(this.txt_subject);
            this.tab_set.Controls.Add(this.label4);
            this.tab_set.Controls.Add(this.label6);
            this.tab_set.Controls.Add(this.label7);
            this.tab_set.Controls.Add(this.label5);
            this.tab_set.Controls.Add(this.label3);
            this.tab_set.Controls.Add(this.label2);
            this.tab_set.Controls.Add(this.label1);
            this.tab_set.Controls.Add(this.listBox1);
            this.tab_set.Controls.Add(this.cb_drag_nivs);
            this.tab_set.Controls.Add(this.btn_import_st_excel);
            this.tab_set.Controls.Add(this.btn_import_st_database);
            this.tab_set.Location = new System.Drawing.Point(4, 22);
            this.tab_set.Name = "tab_set";
            this.tab_set.Padding = new System.Windows.Forms.Padding(3);
            this.tab_set.Size = new System.Drawing.Size(609, 381);
            this.tab_set.TabIndex = 0;
            this.tab_set.Text = "تهيئة";
            this.tab_set.UseVisualStyleBackColor = true;
            // 
            // btn_reset_ex
            // 
            this.btn_reset_ex.Location = new System.Drawing.Point(62, 289);
            this.btn_reset_ex.Name = "btn_reset_ex";
            this.btn_reset_ex.Size = new System.Drawing.Size(75, 23);
            this.btn_reset_ex.TabIndex = 17;
            this.btn_reset_ex.Text = "reset";
            this.btn_reset_ex.UseVisualStyleBackColor = true;
            this.btn_reset_ex.Click += new System.EventHandler(this.btn_reset_ex_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(62, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_resumee
            // 
            this.txt_resumee.Location = new System.Drawing.Point(31, 343);
            this.txt_resumee.Name = "txt_resumee";
            this.txt_resumee.Size = new System.Drawing.Size(397, 20);
            this.txt_resumee.TabIndex = 15;
            // 
            // txt_DurationofExam
            // 
            this.txt_DurationofExam.Location = new System.Drawing.Point(284, 267);
            this.txt_DurationofExam.Name = "txt_DurationofExam";
            this.txt_DurationofExam.Size = new System.Drawing.Size(100, 20);
            this.txt_DurationofExam.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "إضافة مادة الإمتحان";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_branch
            // 
            this.cb_branch.FormattingEnabled = true;
            this.cb_branch.Location = new System.Drawing.Point(299, 163);
            this.cb_branch.Name = "cb_branch";
            this.cb_branch.Size = new System.Drawing.Size(203, 21);
            this.cb_branch.TabIndex = 12;
            // 
            // dtp_endtime
            // 
            this.dtp_endtime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_endtime.Location = new System.Drawing.Point(399, 300);
            this.dtp_endtime.Name = "dtp_endtime";
            this.dtp_endtime.Size = new System.Drawing.Size(103, 20);
            this.dtp_endtime.TabIndex = 11;
            this.dtp_endtime.ValueChanged += new System.EventHandler(this.dtp_endtime_ValueChanged);
            // 
            // dtp_dayOfExam
            // 
            this.dtp_dayOfExam.Location = new System.Drawing.Point(302, 208);
            this.dtp_dayOfExam.Name = "dtp_dayOfExam";
            this.dtp_dayOfExam.Size = new System.Drawing.Size(200, 20);
            this.dtp_dayOfExam.TabIndex = 11;
            // 
            // dtp_starttime
            // 
            this.dtp_starttime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_starttime.Location = new System.Drawing.Point(399, 251);
            this.dtp_starttime.Name = "dtp_starttime";
            this.dtp_starttime.Size = new System.Drawing.Size(103, 20);
            this.dtp_starttime.TabIndex = 11;
            this.dtp_starttime.ValueChanged += new System.EventHandler(this.dtp_starttime_ValueChanged);
            // 
            // txt_subject
            // 
            this.txt_subject.Location = new System.Drawing.Point(299, 121);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.Size = new System.Drawing.Size(203, 20);
            this.txt_subject.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "إلى";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "مدة الإمتحان";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(508, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "التاريخ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "الشعبة/المستوى";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "من";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "إضافة المادة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "جميع الشعب / المستويات";
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(17, 140);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(159, 108);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // cb_drag_nivs
            // 
            this.cb_drag_nivs.AllowDrop = true;
            this.cb_drag_nivs.FormattingEnabled = true;
            this.cb_drag_nivs.Location = new System.Drawing.Point(17, 39);
            this.cb_drag_nivs.Name = "cb_drag_nivs";
            this.cb_drag_nivs.Size = new System.Drawing.Size(192, 21);
            this.cb_drag_nivs.TabIndex = 6;
            // 
            // btn_import_st_excel
            // 
            this.btn_import_st_excel.Location = new System.Drawing.Point(492, 17);
            this.btn_import_st_excel.Name = "btn_import_st_excel";
            this.btn_import_st_excel.Size = new System.Drawing.Size(111, 63);
            this.btn_import_st_excel.TabIndex = 4;
            this.btn_import_st_excel.Text = "جلب التلاميذ المعنيين بالإمتحان من لائحة اكسل";
            this.btn_import_st_excel.UseVisualStyleBackColor = true;
            this.btn_import_st_excel.Click += new System.EventHandler(this.btn_import_st_excel_Click);
            // 
            // btn_import_st_database
            // 
            this.btn_import_st_database.Location = new System.Drawing.Point(332, 17);
            this.btn_import_st_database.Name = "btn_import_st_database";
            this.btn_import_st_database.Size = new System.Drawing.Size(111, 63);
            this.btn_import_st_database.TabIndex = 4;
            this.btn_import_st_database.Text = "جلب التلاميذ المعنيين بالإمتحان من قاعدة معطيات البرنامج";
            this.btn_import_st_database.UseVisualStyleBackColor = true;
            this.btn_import_st_database.Click += new System.EventHandler(this.btn_import_st_database_Click);
            // 
            // tab_docs
            // 
            this.tab_docs.Controls.Add(this.btn_st_by_age);
            this.tab_docs.Controls.Add(this.btn_st_by_name);
            this.tab_docs.Controls.Add(this.btn_st_by_massar);
            this.tab_docs.Location = new System.Drawing.Point(4, 22);
            this.tab_docs.Name = "tab_docs";
            this.tab_docs.Padding = new System.Windows.Forms.Padding(3);
            this.tab_docs.Size = new System.Drawing.Size(609, 381);
            this.tab_docs.TabIndex = 1;
            this.tab_docs.Text = "مطبوعات";
            this.tab_docs.UseVisualStyleBackColor = true;
            // 
            // btn_st_by_age
            // 
            this.btn_st_by_age.Location = new System.Drawing.Point(268, 36);
            this.btn_st_by_age.Name = "btn_st_by_age";
            this.btn_st_by_age.Size = new System.Drawing.Size(95, 46);
            this.btn_st_by_age.TabIndex = 6;
            this.btn_st_by_age.Text = "فرز التلاميذ حسب السن";
            this.btn_st_by_age.UseVisualStyleBackColor = true;
            // 
            // btn_st_by_name
            // 
            this.btn_st_by_name.Location = new System.Drawing.Point(384, 36);
            this.btn_st_by_name.Name = "btn_st_by_name";
            this.btn_st_by_name.Size = new System.Drawing.Size(95, 46);
            this.btn_st_by_name.TabIndex = 7;
            this.btn_st_by_name.Text = "فرز التلاميذ حسب الإسم";
            this.btn_st_by_name.UseVisualStyleBackColor = true;
            // 
            // btn_st_by_massar
            // 
            this.btn_st_by_massar.Location = new System.Drawing.Point(493, 36);
            this.btn_st_by_massar.Name = "btn_st_by_massar";
            this.btn_st_by_massar.Size = new System.Drawing.Size(95, 46);
            this.btn_st_by_massar.TabIndex = 8;
            this.btn_st_by_massar.Text = "فرز التلاميذ حسب رمز مسار";
            this.btn_st_by_massar.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(588, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Frm_exam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 483);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_exam";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Frm_exam";
            this.Load += new System.EventHandler(this.Frm_exam_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_set.ResumeLayout(false);
            this.tab_set.PerformLayout();
            this.tab_docs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_set;
        private System.Windows.Forms.Button btn_import_st_excel;
        private System.Windows.Forms.Button btn_import_st_database;
        private System.Windows.Forms.TabPage tab_docs;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cb_drag_nivs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_st_by_age;
        private System.Windows.Forms.Button btn_st_by_name;
        private System.Windows.Forms.Button btn_st_by_massar;
        private System.Windows.Forms.ComboBox cb_branch;
        private System.Windows.Forms.DateTimePicker dtp_endtime;
        private System.Windows.Forms.DateTimePicker dtp_starttime;
        private System.Windows.Forms.TextBox txt_subject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtp_dayOfExam;
        private System.Windows.Forms.TextBox txt_DurationofExam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_resumee;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_reset_ex;
    }
}
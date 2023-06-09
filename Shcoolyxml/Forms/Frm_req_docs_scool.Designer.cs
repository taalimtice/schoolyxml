namespace Schooly.Forms
{
    partial class Frm_req_docs_scool
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_send_docs_st = new System.Windows.Forms.RadioButton();
            this.rb_req_docs_st = new System.Windows.Forms.RadioButton();
            this.btn_close = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_nivs = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_num_corres = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_corres = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_selected_niv = new System.Windows.Forms.RadioButton();
            this.rb_all_nivs = new System.Windows.Forms.RadioButton();
            this.btn_print_selected = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_nb_Jrs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_print_result = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_second_req = new System.Windows.Forms.Button();
            this.btn_last_req = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.rb_send_docs_st);
            this.groupBox1.Controls.Add(this.rb_req_docs_st);
            this.groupBox1.Location = new System.Drawing.Point(118, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rb_send_docs_st
            // 
            this.rb_send_docs_st.AutoSize = true;
            this.rb_send_docs_st.Location = new System.Drawing.Point(257, 19);
            this.rb_send_docs_st.Name = "rb_send_docs_st";
            this.rb_send_docs_st.Size = new System.Drawing.Size(187, 17);
            this.rb_send_docs_st.TabIndex = 0;
            this.rb_send_docs_st.Text = "إرسال ملف مدرسي (تدبير المغادرين)";
            this.rb_send_docs_st.UseVisualStyleBackColor = true;
            this.rb_send_docs_st.CheckedChanged += new System.EventHandler(this.rb_send_docs_st_CheckedChanged);
            // 
            // rb_req_docs_st
            // 
            this.rb_req_docs_st.AutoSize = true;
            this.rb_req_docs_st.Location = new System.Drawing.Point(6, 19);
            this.rb_req_docs_st.Name = "rb_req_docs_st";
            this.rb_req_docs_st.Size = new System.Drawing.Size(171, 17);
            this.rb_req_docs_st.TabIndex = 0;
            this.rb_req_docs_st.Text = "طلب ملف مدرسي (تدبير الوافدين)";
            this.rb_req_docs_st.UseVisualStyleBackColor = true;
            this.rb_req_docs_st.CheckedChanged += new System.EventHandler(this.rb_req_docs_st_CheckedChanged);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_close.Location = new System.Drawing.Point(590, 9);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(35, 28);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "X";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // txt_search
            // 
            this.txt_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txt_search.Location = new System.Drawing.Point(21, 46);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(148, 20);
            this.txt_search.TabIndex = 2;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "بحث ";
            // 
            // cb_nivs
            // 
            this.cb_nivs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_nivs.Enabled = false;
            this.cb_nivs.FormattingEnabled = true;
            this.cb_nivs.Location = new System.Drawing.Point(8, 19);
            this.cb_nivs.Name = "cb_nivs";
            this.cb_nivs.Size = new System.Drawing.Size(161, 21);
            this.cb_nivs.TabIndex = 4;
            this.cb_nivs.SelectedIndexChanged += new System.EventHandler(this.cb_nivs_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "اختر المستوى";
            // 
            // txt_num_corres
            // 
            this.txt_num_corres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_num_corres.Location = new System.Drawing.Point(366, 13);
            this.txt_num_corres.Name = "txt_num_corres";
            this.txt_num_corres.Size = new System.Drawing.Size(117, 20);
            this.txt_num_corres.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "رقم الإرسال";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "تاريخ الإرسال";
            // 
            // dtp_corres
            // 
            this.dtp_corres.Checked = false;
            this.dtp_corres.Location = new System.Drawing.Point(8, 13);
            this.dtp_corres.Name = "dtp_corres";
            this.dtp_corres.ShowCheckBox = true;
            this.dtp_corres.Size = new System.Drawing.Size(200, 20);
            this.dtp_corres.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(595, 305);
            this.dataGridView1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.rb_selected_niv);
            this.groupBox2.Controls.Add(this.rb_all_nivs);
            this.groupBox2.Location = new System.Drawing.Point(274, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 74);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // rb_selected_niv
            // 
            this.rb_selected_niv.AutoSize = true;
            this.rb_selected_niv.Location = new System.Drawing.Point(27, 38);
            this.rb_selected_niv.Name = "rb_selected_niv";
            this.rb_selected_niv.Size = new System.Drawing.Size(115, 17);
            this.rb_selected_niv.TabIndex = 0;
            this.rb_selected_niv.TabStop = true;
            this.rb_selected_niv.Text = "في المستوى المحدد";
            this.rb_selected_niv.UseVisualStyleBackColor = true;
            // 
            // rb_all_nivs
            // 
            this.rb_all_nivs.AutoSize = true;
            this.rb_all_nivs.Checked = true;
            this.rb_all_nivs.Location = new System.Drawing.Point(23, 10);
            this.rb_all_nivs.Name = "rb_all_nivs";
            this.rb_all_nivs.Size = new System.Drawing.Size(119, 17);
            this.rb_all_nivs.TabIndex = 0;
            this.rb_all_nivs.TabStop = true;
            this.rb_all_nivs.Text = " في جميع المستويات";
            this.rb_all_nivs.UseVisualStyleBackColor = true;
            this.rb_all_nivs.CheckedChanged += new System.EventHandler(this.rb_all_nivs_CheckedChanged);
            // 
            // btn_print_selected
            // 
            this.btn_print_selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_print_selected.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_print_selected.Location = new System.Drawing.Point(309, 39);
            this.btn_print_selected.Name = "btn_print_selected";
            this.btn_print_selected.Size = new System.Drawing.Size(146, 23);
            this.btn_print_selected.TabIndex = 9;
            this.btn_print_selected.Text = "طبع المحدد في نتيجة البحث";
            this.btn_print_selected.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.btn_last_req);
            this.groupBox3.Controls.Add(this.btn_second_req);
            this.groupBox3.Controls.Add(this.txt_nb_Jrs);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(445, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 77);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // txt_nb_Jrs
            // 
            this.txt_nb_Jrs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txt_nb_Jrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nb_Jrs.Location = new System.Drawing.Point(3, 50);
            this.txt_nb_Jrs.Name = "txt_nb_Jrs";
            this.txt_nb_Jrs.Size = new System.Drawing.Size(46, 20);
            this.txt_nb_Jrs.TabIndex = 2;
            this.txt_nb_Jrs.Text = "60";
            this.txt_nb_Jrs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nb_Jrs_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "بعد عدد الأيام من الطلب السابق";
            // 
            // btn_print_result
            // 
            this.btn_print_result.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_print_result.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_print_result.Location = new System.Drawing.Point(86, 39);
            this.btn_print_result.Name = "btn_print_result";
            this.btn_print_result.Size = new System.Drawing.Size(122, 23);
            this.btn_print_result.TabIndex = 9;
            this.btn_print_result.Text = "طبع كل نتيجة البحث";
            this.btn_print_result.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox4.Controls.Add(this.cb_nivs);
            this.groupBox4.Controls.Add(this.txt_search);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(9, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(259, 77);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txt_num_corres);
            this.groupBox5.Controls.Add(this.btn_print_result);
            this.groupBox5.Controls.Add(this.dtp_corres);
            this.groupBox5.Controls.Add(this.btn_print_selected);
            this.groupBox5.Location = new System.Drawing.Point(50, 454);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(573, 64);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            // 
            // btn_second_req
            // 
            this.btn_second_req.Location = new System.Drawing.Point(108, 10);
            this.btn_second_req.Name = "btn_second_req";
            this.btn_second_req.Size = new System.Drawing.Size(75, 40);
            this.btn_second_req.TabIndex = 3;
            this.btn_second_req.Text = "الطلب الثاني";
            this.btn_second_req.UseVisualStyleBackColor = true;
            this.btn_second_req.Click += new System.EventHandler(this.btn_second_req_Click);
            // 
            // btn_last_req
            // 
            this.btn_last_req.Location = new System.Drawing.Point(20, 10);
            this.btn_last_req.Name = "btn_last_req";
            this.btn_last_req.Size = new System.Drawing.Size(75, 40);
            this.btn_last_req.TabIndex = 3;
            this.btn_last_req.Text = "تدخل المدير الإقليمي";
            this.btn_last_req.UseVisualStyleBackColor = true;
            // 
            // Frm_req_docs_scool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(657, 522);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_req_docs_scool";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "إرسال طلب وثائق مدرسية";
            this.Load += new System.EventHandler(this.Frm_req_docs_scool_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_send_docs_st;
        private System.Windows.Forms.RadioButton rb_req_docs_st;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_nivs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_num_corres;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_corres;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_selected_niv;
        private System.Windows.Forms.RadioButton rb_all_nivs;
        private System.Windows.Forms.Button btn_print_selected;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_nb_Jrs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_print_result;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_last_req;
        private System.Windows.Forms.Button btn_second_req;
    }
}
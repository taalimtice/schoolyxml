namespace Schooly.Forms
{
    partial class Frm_name_esise_fet
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
            this.btn_rect_add_sub = new System.Windows.Forms.Button();
            this.btn_rect_add_classe = new System.Windows.Forms.Button();
            this.btn_rect_add_niv = new System.Windows.Forms.Button();
            this.chb_rect_isSub = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cb_rect_subcl_frt = new System.Windows.Forms.ComboBox();
            this.cb_rect_cl_frt = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_rect_niv_fet = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_rect_subcl_mass = new System.Windows.Forms.ComboBox();
            this.lbl_rect_counter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_rect_cl_mass = new System.Windows.Forms.ComboBox();
            this.cb_rect_niv_mass = new System.Windows.Forms.ComboBox();
            this.btn_rect_close = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_rect_add_prof = new System.Windows.Forms.Button();
            this.cb_rect_prof_fet = new System.Windows.Forms.ComboBox();
            this.cb_rect_prof_esise = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_rect_add_sub);
            this.groupBox1.Controls.Add(this.btn_rect_add_classe);
            this.groupBox1.Controls.Add(this.btn_rect_add_niv);
            this.groupBox1.Controls.Add(this.chb_rect_isSub);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cb_rect_subcl_frt);
            this.groupBox1.Controls.Add(this.cb_rect_cl_frt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_rect_niv_fet);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_rect_subcl_mass);
            this.groupBox1.Controls.Add(this.lbl_rect_counter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_rect_cl_mass);
            this.groupBox1.Controls.Add(this.cb_rect_niv_mass);
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(626, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مطابقة تسميات الأقسام بين fet و Massar";
            // 
            // btn_rect_add_sub
            // 
            this.btn_rect_add_sub.Location = new System.Drawing.Point(234, 160);
            this.btn_rect_add_sub.Name = "btn_rect_add_sub";
            this.btn_rect_add_sub.Size = new System.Drawing.Size(75, 23);
            this.btn_rect_add_sub.TabIndex = 7;
            this.btn_rect_add_sub.Text = "طابق";
            this.btn_rect_add_sub.UseVisualStyleBackColor = true;
            this.btn_rect_add_sub.Click += new System.EventHandler(this.btn_rect_add_sub_Click);
            // 
            // btn_rect_add_classe
            // 
            this.btn_rect_add_classe.Location = new System.Drawing.Point(234, 110);
            this.btn_rect_add_classe.Name = "btn_rect_add_classe";
            this.btn_rect_add_classe.Size = new System.Drawing.Size(75, 23);
            this.btn_rect_add_classe.TabIndex = 6;
            this.btn_rect_add_classe.Text = "طابق";
            this.btn_rect_add_classe.UseVisualStyleBackColor = true;
            this.btn_rect_add_classe.Click += new System.EventHandler(this.btn_rect_add_classe_Click);
            // 
            // btn_rect_add_niv
            // 
            this.btn_rect_add_niv.Location = new System.Drawing.Point(234, 63);
            this.btn_rect_add_niv.Name = "btn_rect_add_niv";
            this.btn_rect_add_niv.Size = new System.Drawing.Size(75, 23);
            this.btn_rect_add_niv.TabIndex = 5;
            this.btn_rect_add_niv.Text = "طابق";
            this.btn_rect_add_niv.UseVisualStyleBackColor = true;
            this.btn_rect_add_niv.Click += new System.EventHandler(this.btn_rect_add_Click);
            // 
            // chb_rect_isSub
            // 
            this.chb_rect_isSub.AutoSize = true;
            this.chb_rect_isSub.Location = new System.Drawing.Point(250, 136);
            this.chb_rect_isSub.Name = "chb_rect_isSub";
            this.chb_rect_isSub.Size = new System.Drawing.Size(119, 17);
            this.chb_rect_isSub.TabIndex = 4;
            this.chb_rect_isSub.Text = "قسم له أقسام فرعية";
            this.chb_rect_isSub.UseVisualStyleBackColor = true;
            this.chb_rect_isSub.CheckedChanged += new System.EventHandler(this.chb_rect_isSub_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox2.Location = new System.Drawing.Point(335, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(235, 23);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "قاعدة معطيات مسار";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "قاعدة معطيات فيت";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_rect_subcl_frt
            // 
            this.cb_rect_subcl_frt.FormattingEnabled = true;
            this.cb_rect_subcl_frt.Location = new System.Drawing.Point(26, 163);
            this.cb_rect_subcl_frt.Name = "cb_rect_subcl_frt";
            this.cb_rect_subcl_frt.Size = new System.Drawing.Size(158, 21);
            this.cb_rect_subcl_frt.TabIndex = 2;
            // 
            // cb_rect_cl_frt
            // 
            this.cb_rect_cl_frt.FormattingEnabled = true;
            this.cb_rect_cl_frt.Location = new System.Drawing.Point(24, 112);
            this.cb_rect_cl_frt.Name = "cb_rect_cl_frt";
            this.cb_rect_cl_frt.Size = new System.Drawing.Size(204, 21);
            this.cb_rect_cl_frt.TabIndex = 0;
            this.cb_rect_cl_frt.SelectedIndexChanged += new System.EventHandler(this.cb_rect_cl_frt_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "القسم الفرعي";
            // 
            // cb_rect_niv_fet
            // 
            this.cb_rect_niv_fet.FormattingEnabled = true;
            this.cb_rect_niv_fet.Location = new System.Drawing.Point(24, 65);
            this.cb_rect_niv_fet.Name = "cb_rect_niv_fet";
            this.cb_rect_niv_fet.Size = new System.Drawing.Size(204, 21);
            this.cb_rect_niv_fet.TabIndex = 0;
            this.cb_rect_niv_fet.SelectedIndexChanged += new System.EventHandler(this.cb_rect_niv_fet_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "القسم";
            // 
            // cb_rect_subcl_mass
            // 
            this.cb_rect_subcl_mass.FormattingEnabled = true;
            this.cb_rect_subcl_mass.Items.AddRange(new object[] {
            "_G1",
            "_G2",
            "_G3",
            "_G4"});
            this.cb_rect_subcl_mass.Location = new System.Drawing.Point(348, 160);
            this.cb_rect_subcl_mass.Name = "cb_rect_subcl_mass";
            this.cb_rect_subcl_mass.Size = new System.Drawing.Size(155, 21);
            this.cb_rect_subcl_mass.TabIndex = 0;
            // 
            // lbl_rect_counter
            // 
            this.lbl_rect_counter.AutoSize = true;
            this.lbl_rect_counter.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rect_counter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_rect_counter.Location = new System.Drawing.Point(288, 41);
            this.lbl_rect_counter.Name = "lbl_rect_counter";
            this.lbl_rect_counter.Size = new System.Drawing.Size(0, 23);
            this.lbl_rect_counter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(543, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "المستوى";
            // 
            // cb_rect_cl_mass
            // 
            this.cb_rect_cl_mass.FormattingEnabled = true;
            this.cb_rect_cl_mass.Location = new System.Drawing.Point(315, 108);
            this.cb_rect_cl_mass.Name = "cb_rect_cl_mass";
            this.cb_rect_cl_mass.Size = new System.Drawing.Size(222, 21);
            this.cb_rect_cl_mass.TabIndex = 0;
            // 
            // cb_rect_niv_mass
            // 
            this.cb_rect_niv_mass.FormattingEnabled = true;
            this.cb_rect_niv_mass.Location = new System.Drawing.Point(315, 65);
            this.cb_rect_niv_mass.Name = "cb_rect_niv_mass";
            this.cb_rect_niv_mass.Size = new System.Drawing.Size(222, 21);
            this.cb_rect_niv_mass.TabIndex = 0;
            this.cb_rect_niv_mass.SelectedIndexChanged += new System.EventHandler(this.cb_rect_niv_mass_SelectedIndexChanged);
            // 
            // btn_rect_close
            // 
            this.btn_rect_close.Location = new System.Drawing.Point(12, 42);
            this.btn_rect_close.Name = "btn_rect_close";
            this.btn_rect_close.Size = new System.Drawing.Size(39, 23);
            this.btn_rect_close.TabIndex = 5;
            this.btn_rect_close.Text = "X";
            this.btn_rect_close.UseVisualStyleBackColor = true;
            this.btn_rect_close.Click += new System.EventHandler(this.btn_rect_close_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btn_rect_add_prof);
            this.groupBox2.Controls.Add(this.cb_rect_prof_fet);
            this.groupBox2.Controls.Add(this.cb_rect_prof_esise);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مطابقة أسماء الموظفين بين fet و esise ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "إسم الموظف(ة)";
            // 
            // btn_rect_add_prof
            // 
            this.btn_rect_add_prof.Location = new System.Drawing.Point(234, 55);
            this.btn_rect_add_prof.Name = "btn_rect_add_prof";
            this.btn_rect_add_prof.Size = new System.Drawing.Size(75, 23);
            this.btn_rect_add_prof.TabIndex = 8;
            this.btn_rect_add_prof.Text = "طابق";
            this.btn_rect_add_prof.UseVisualStyleBackColor = true;
            this.btn_rect_add_prof.Click += new System.EventHandler(this.btn_rect_add_prof_Click);
            // 
            // cb_rect_prof_fet
            // 
            this.cb_rect_prof_fet.FormattingEnabled = true;
            this.cb_rect_prof_fet.Location = new System.Drawing.Point(24, 57);
            this.cb_rect_prof_fet.Name = "cb_rect_prof_fet";
            this.cb_rect_prof_fet.Size = new System.Drawing.Size(204, 21);
            this.cb_rect_prof_fet.TabIndex = 6;
            // 
            // cb_rect_prof_esise
            // 
            this.cb_rect_prof_esise.FormattingEnabled = true;
            this.cb_rect_prof_esise.Location = new System.Drawing.Point(315, 57);
            this.cb_rect_prof_esise.Name = "cb_rect_prof_esise";
            this.cb_rect_prof_esise.Size = new System.Drawing.Size(222, 21);
            this.cb_rect_prof_esise.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox4.Location = new System.Drawing.Point(24, 18);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(235, 23);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "قاعدة معطيات فيت";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox3.Location = new System.Drawing.Point(348, 18);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(235, 23);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "قاعدة معطيات أوسايز";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Frm_name_esise_fet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 522);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_rect_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_name_esise_fet";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "مطابقة التسميات";
            this.Load += new System.EventHandler(this.Frm_tt_rectf_cl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cb_rect_subcl_frt;
        private System.Windows.Forms.ComboBox cb_rect_cl_frt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_rect_niv_fet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_rect_subcl_mass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_rect_cl_mass;
        private System.Windows.Forms.ComboBox cb_rect_niv_mass;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_rect_close;
        private System.Windows.Forms.CheckBox chb_rect_isSub;
        private System.Windows.Forms.Button btn_rect_add_niv;
        private System.Windows.Forms.Label lbl_rect_counter;
        private System.Windows.Forms.Button btn_rect_add_sub;
        private System.Windows.Forms.Button btn_rect_add_classe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btn_rect_add_prof;
        private System.Windows.Forms.ComboBox cb_rect_prof_fet;
        private System.Windows.Forms.ComboBox cb_rect_prof_esise;
        private System.Windows.Forms.Label label4;
    }
}
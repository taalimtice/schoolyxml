namespace Schooly.Forms
{
    partial class Frm_list_controls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_list_controls));
            this.rb_cc_prof = new System.Windows.Forms.RadioButton();
            this.rb_cc_cl = new System.Windows.Forms.RadioButton();
            this.rb_cc_mat = new System.Windows.Forms.RadioButton();
            this.cb_radio_select = new System.Windows.Forms.ComboBox();
            this.cb_check_select = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_cc = new System.Windows.Forms.Button();
            this.ch_rb_select = new System.Windows.Forms.CheckBox();
            this.lbl_what_tt = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rb_cc_prof
            // 
            this.rb_cc_prof.AutoSize = true;
            this.rb_cc_prof.Checked = true;
            this.rb_cc_prof.Location = new System.Drawing.Point(156, 29);
            this.rb_cc_prof.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_cc_prof.Name = "rb_cc_prof";
            this.rb_cc_prof.Size = new System.Drawing.Size(110, 24);
            this.rb_cc_prof.TabIndex = 0;
            this.rb_cc_prof.TabStop = true;
            this.rb_cc_prof.Text = "الخاصة بالأستاذ";
            this.rb_cc_prof.UseVisualStyleBackColor = true;
            this.rb_cc_prof.CheckedChanged += new System.EventHandler(this.rb_cc_prof_CheckedChanged);
            // 
            // rb_cc_cl
            // 
            this.rb_cc_cl.AutoSize = true;
            this.rb_cc_cl.Location = new System.Drawing.Point(165, 80);
            this.rb_cc_cl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_cc_cl.Name = "rb_cc_cl";
            this.rb_cc_cl.Size = new System.Drawing.Size(101, 24);
            this.rb_cc_cl.TabIndex = 0;
            this.rb_cc_cl.Text = "الخاصة بالقسم";
            this.rb_cc_cl.UseVisualStyleBackColor = true;
            this.rb_cc_cl.CheckedChanged += new System.EventHandler(this.rb_cc_cl_CheckedChanged);
            // 
            // rb_cc_mat
            // 
            this.rb_cc_mat.AutoSize = true;
            this.rb_cc_mat.Location = new System.Drawing.Point(165, 130);
            this.rb_cc_mat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_cc_mat.Name = "rb_cc_mat";
            this.rb_cc_mat.Size = new System.Drawing.Size(101, 24);
            this.rb_cc_mat.TabIndex = 0;
            this.rb_cc_mat.Text = "الخاصة بالمادة";
            this.rb_cc_mat.UseVisualStyleBackColor = true;
            this.rb_cc_mat.CheckedChanged += new System.EventHandler(this.rb_cc_mat_CheckedChanged);
            // 
            // cb_radio_select
            // 
            this.cb_radio_select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cb_radio_select.FormattingEnabled = true;
            this.cb_radio_select.Location = new System.Drawing.Point(32, 178);
            this.cb_radio_select.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_radio_select.Name = "cb_radio_select";
            this.cb_radio_select.Size = new System.Drawing.Size(258, 28);
            this.cb_radio_select.TabIndex = 1;
            this.cb_radio_select.SelectedIndexChanged += new System.EventHandler(this.cb_radio_select_SelectedIndexChanged);
            // 
            // cb_check_select
            // 
            this.cb_check_select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cb_check_select.FormattingEnabled = true;
            this.cb_check_select.Location = new System.Drawing.Point(32, 252);
            this.cb_check_select.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_check_select.Name = "cb_check_select";
            this.cb_check_select.Size = new System.Drawing.Size(258, 28);
            this.cb_check_select.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.cb_check_select);
            this.groupBox1.Controls.Add(this.btn_cc);
            this.groupBox1.Controls.Add(this.ch_rb_select);
            this.groupBox1.Controls.Add(this.rb_cc_cl);
            this.groupBox1.Controls.Add(this.rb_cc_prof);
            this.groupBox1.Controls.Add(this.cb_radio_select);
            this.groupBox1.Controls.Add(this.rb_cc_mat);
            this.groupBox1.Location = new System.Drawing.Point(36, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(345, 384);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btn_cc
            // 
            this.btn_cc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_cc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_cc.Location = new System.Drawing.Point(92, 303);
            this.btn_cc.Name = "btn_cc";
            this.btn_cc.Size = new System.Drawing.Size(129, 63);
            this.btn_cc.TabIndex = 5;
            this.btn_cc.Text = "طبع";
            this.btn_cc.UseVisualStyleBackColor = false;
            this.btn_cc.Click += new System.EventHandler(this.btn_tt_Click);
            // 
            // ch_rb_select
            // 
            this.ch_rb_select.AutoSize = true;
            this.ch_rb_select.Location = new System.Drawing.Point(32, 230);
            this.ch_rb_select.Name = "ch_rb_select";
            this.ch_rb_select.Size = new System.Drawing.Size(15, 14);
            this.ch_rb_select.TabIndex = 2;
            this.ch_rb_select.UseVisualStyleBackColor = true;
            this.ch_rb_select.CheckedChanged += new System.EventHandler(this.ch_rb_select_CheckedChanged);
            // 
            // lbl_what_tt
            // 
            this.lbl_what_tt.AutoSize = true;
            this.lbl_what_tt.Location = new System.Drawing.Point(250, 18);
            this.lbl_what_tt.Name = "lbl_what_tt";
            this.lbl_what_tt.Size = new System.Drawing.Size(0, 20);
            this.lbl_what_tt.TabIndex = 6;
            // 
            // Frm_list_controls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(410, 441);
            this.Controls.Add(this.lbl_what_tt);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_list_controls";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "اختيار وثيقة المراقبة المستمرة";
            this.Load += new System.EventHandler(this.Frm_list_controls_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_cc_prof;
        private System.Windows.Forms.RadioButton rb_cc_cl;
        private System.Windows.Forms.RadioButton rb_cc_mat;
        private System.Windows.Forms.ComboBox cb_radio_select;
        private System.Windows.Forms.ComboBox cb_check_select;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_cc;
        private System.Windows.Forms.Label lbl_what_tt;
        private System.Windows.Forms.CheckBox ch_rb_select;
    }
}
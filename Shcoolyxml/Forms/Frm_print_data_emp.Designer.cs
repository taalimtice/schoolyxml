namespace Schooly.Forms
{
    partial class Frm_print_data_emp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_print_data_emp));
            this.cb_report_select_emp = new System.Windows.Forms.ComboBox();
            this.btn_view_cert_ar = new System.Windows.Forms.Button();
            this.btn_view_cert_fr = new System.Windows.Forms.Button();
            this.btn_print_cert_ar = new System.Windows.Forms.Button();
            this.btn_print_cert_fr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_report_select_emp
            // 
            this.cb_report_select_emp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cb_report_select_emp.FormattingEnabled = true;
            this.cb_report_select_emp.Location = new System.Drawing.Point(22, 60);
            this.cb_report_select_emp.Name = "cb_report_select_emp";
            this.cb_report_select_emp.Size = new System.Drawing.Size(223, 21);
            this.cb_report_select_emp.TabIndex = 0;
            // 
            // btn_view_cert_ar
            // 
            this.btn_view_cert_ar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_view_cert_ar.Location = new System.Drawing.Point(155, 98);
            this.btn_view_cert_ar.Name = "btn_view_cert_ar";
            this.btn_view_cert_ar.Size = new System.Drawing.Size(102, 42);
            this.btn_view_cert_ar.TabIndex = 1;
            this.btn_view_cert_ar.Text = "معاينة شهادة العمل عربية";
            this.btn_view_cert_ar.UseVisualStyleBackColor = false;
            this.btn_view_cert_ar.Click += new System.EventHandler(this.btn_view_cert_ar_Click);
            // 
            // btn_view_cert_fr
            // 
            this.btn_view_cert_fr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_view_cert_fr.Location = new System.Drawing.Point(12, 98);
            this.btn_view_cert_fr.Name = "btn_view_cert_fr";
            this.btn_view_cert_fr.Size = new System.Drawing.Size(102, 42);
            this.btn_view_cert_fr.TabIndex = 1;
            this.btn_view_cert_fr.Text = "معاينة شهادة العمل فرنسية";
            this.btn_view_cert_fr.UseVisualStyleBackColor = false;
            this.btn_view_cert_fr.Click += new System.EventHandler(this.btn_view_cert_fr_Click);
            // 
            // btn_print_cert_ar
            // 
            this.btn_print_cert_ar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_print_cert_ar.Location = new System.Drawing.Point(155, 165);
            this.btn_print_cert_ar.Name = "btn_print_cert_ar";
            this.btn_print_cert_ar.Size = new System.Drawing.Size(102, 49);
            this.btn_print_cert_ar.TabIndex = 1;
            this.btn_print_cert_ar.Text = "طبع شهادة العمل عربية";
            this.btn_print_cert_ar.UseVisualStyleBackColor = false;
            this.btn_print_cert_ar.Click += new System.EventHandler(this.btn_print_cert_ar_Click);
            // 
            // btn_print_cert_fr
            // 
            this.btn_print_cert_fr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_print_cert_fr.Location = new System.Drawing.Point(12, 165);
            this.btn_print_cert_fr.Name = "btn_print_cert_fr";
            this.btn_print_cert_fr.Size = new System.Drawing.Size(102, 49);
            this.btn_print_cert_fr.TabIndex = 1;
            this.btn_print_cert_fr.Text = "طبع شهادة العمل فرنسية";
            this.btn_print_cert_fr.UseVisualStyleBackColor = false;
            this.btn_print_cert_fr.Click += new System.EventHandler(this.btn_print_cert_fr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(102, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "شهادة العمل";
            // 
            // Frm_print_data_emp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_print_cert_fr);
            this.Controls.Add(this.btn_print_cert_ar);
            this.Controls.Add(this.btn_view_cert_fr);
            this.Controls.Add(this.btn_view_cert_ar);
            this.Controls.Add(this.cb_report_select_emp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_print_data_emp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "اختيار الموظف من القائمة";
            this.Load += new System.EventHandler(this.Frm_print_data_emp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_report_select_emp;
        private System.Windows.Forms.Button btn_view_cert_ar;
        private System.Windows.Forms.Button btn_view_cert_fr;
        private System.Windows.Forms.Button btn_print_cert_ar;
        private System.Windows.Forms.Button btn_print_cert_fr;
        private System.Windows.Forms.Label label1;
    }
}
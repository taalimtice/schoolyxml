namespace Schooly.Forms
{
    partial class Frm_set_Scrap
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
       

        #endregion

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_set_Scrap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_gresa = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_clrear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_selectetab_in_card = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_usr = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "مستخدم مسار";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "كلمة المرور";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "GRESA";
            // 
            // txt_gresa
            // 
            this.txt_gresa.Enabled = false;
            this.txt_gresa.Location = new System.Drawing.Point(347, 164);
            this.txt_gresa.Margin = new System.Windows.Forms.Padding(6);
            this.txt_gresa.Name = "txt_gresa";
            this.txt_gresa.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_gresa.Size = new System.Drawing.Size(321, 29);
            this.txt_gresa.TabIndex = 1;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_login.Location = new System.Drawing.Point(460, 249);
            this.btn_login.Margin = new System.Windows.Forms.Padding(6);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(229, 96);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "تسجيل الدخول";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(493, 351);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "سيتم حفظ كلمة المرور ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(609, 116);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 37);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(609, 116);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 39);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_close.Location = new System.Drawing.Point(224, 264);
            this.btn_close.Margin = new System.Windows.Forms.Padding(6);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(128, 68);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "خروج";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_clrear
            // 
            this.btn_clrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_clrear.Location = new System.Drawing.Point(79, 264);
            this.btn_clrear.Margin = new System.Windows.Forms.Padding(6);
            this.btn_clrear.Name = "btn_clrear";
            this.btn_clrear.Size = new System.Drawing.Size(128, 68);
            this.btn_clrear.TabIndex = 2;
            this.btn_clrear.Text = "تفريغ الحقول";
            this.btn_clrear.UseVisualStyleBackColor = false;
            this.btn_clrear.Click += new System.EventHandler(this.btn_clrear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(447, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "إذا كان الحساب به أكتر من حساب، اختر رقم المؤسسة: 1 أو 2 أو 3 أو 4";
            // 
            // cb_selectetab_in_card
            // 
            this.cb_selectetab_in_card.FormattingEnabled = true;
            this.cb_selectetab_in_card.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cb_selectetab_in_card.Location = new System.Drawing.Point(547, 208);
            this.cb_selectetab_in_card.Name = "cb_selectetab_in_card";
            this.cb_selectetab_in_card.Size = new System.Drawing.Size(82, 32);
            this.cb_selectetab_in_card.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(160, 356);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(245, 37);
            this.button3.TabIndex = 10;
            this.button3.Text = "check driver version";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_usr
            // 
            this.txt_usr.Location = new System.Drawing.Point(151, 78);
            this.txt_usr.Name = "txt_usr";
            this.txt_usr.Size = new System.Drawing.Size(449, 29);
            this.txt_usr.TabIndex = 11;
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(151, 124);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(449, 29);
            this.txt_pass.TabIndex = 11;
            // 
            // Frm_set_Scrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(711, 399);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_usr);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cb_selectetab_in_card);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_clrear);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_gresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Frm_set_Scrap";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "جلب معلومات المؤسسة و الأقسام";
            this.Load += new System.EventHandler(this.Frm_set_Scrap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

         //   #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_gresa;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_clrear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_selectetab_in_card;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_usr;
        private System.Windows.Forms.TextBox txt_pass;
    }
}
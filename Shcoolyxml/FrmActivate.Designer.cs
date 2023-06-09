namespace Schooly
{
    partial class FrmActivate
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActivate));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ProductId = new System.Windows.Forms.TextBox();
            this.txt_date = new System.Windows.Forms.TextBox();
            this.txt_KeyCrypt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Key = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_creationDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_expirationDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_daysLeft = new System.Windows.Forms.TextBox();
            this.rbTrial = new System.Windows.Forms.RadioButton();
            this.rbFull = new System.Windows.Forms.RadioButton();
            this.btn_Activate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "معرف المنتج";
            // 
            // txt_ProductId
            // 
            this.txt_ProductId.Location = new System.Drawing.Point(205, 35);
            this.txt_ProductId.Margin = new System.Windows.Forms.Padding(6);
            this.txt_ProductId.Name = "txt_ProductId";
            this.txt_ProductId.ReadOnly = true;
            this.txt_ProductId.Size = new System.Drawing.Size(561, 29);
            this.txt_ProductId.TabIndex = 1;
            // 
            // txt_date
            // 
            this.txt_date.Location = new System.Drawing.Point(446, 83);
            this.txt_date.Margin = new System.Windows.Forms.Padding(6);
            this.txt_date.Name = "txt_date";
            this.txt_date.ReadOnly = true;
            this.txt_date.Size = new System.Drawing.Size(67, 29);
            this.txt_date.TabIndex = 1;
            // 
            // txt_KeyCrypt
            // 
            this.txt_KeyCrypt.Location = new System.Drawing.Point(205, 131);
            this.txt_KeyCrypt.Margin = new System.Windows.Forms.Padding(6);
            this.txt_KeyCrypt.Name = "txt_KeyCrypt";
            this.txt_KeyCrypt.Size = new System.Drawing.Size(561, 29);
            this.txt_KeyCrypt.TabIndex = 1;
            this.txt_KeyCrypt.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "المفتاح";
            // 
            // txt_Key
            // 
            this.txt_Key.Location = new System.Drawing.Point(205, 131);
            this.txt_Key.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Key.Name = "txt_Key";
            this.txt_Key.Size = new System.Drawing.Size(561, 29);
            this.txt_Key.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 181);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "تاريخ الإنشاء";
            // 
            // txt_creationDate
            // 
            this.txt_creationDate.Location = new System.Drawing.Point(205, 181);
            this.txt_creationDate.Margin = new System.Windows.Forms.Padding(6);
            this.txt_creationDate.Name = "txt_creationDate";
            this.txt_creationDate.ReadOnly = true;
            this.txt_creationDate.Size = new System.Drawing.Size(561, 29);
            this.txt_creationDate.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 229);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "تاريخ انتهاء الصلاحية";
            // 
            // txt_expirationDate
            // 
            this.txt_expirationDate.Location = new System.Drawing.Point(205, 229);
            this.txt_expirationDate.Margin = new System.Windows.Forms.Padding(6);
            this.txt_expirationDate.Name = "txt_expirationDate";
            this.txt_expirationDate.ReadOnly = true;
            this.txt_expirationDate.Size = new System.Drawing.Size(561, 29);
            this.txt_expirationDate.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 277);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "الأيام المتبقية";
            // 
            // txt_daysLeft
            // 
            this.txt_daysLeft.Location = new System.Drawing.Point(205, 275);
            this.txt_daysLeft.Margin = new System.Windows.Forms.Padding(6);
            this.txt_daysLeft.Name = "txt_daysLeft";
            this.txt_daysLeft.ReadOnly = true;
            this.txt_daysLeft.Size = new System.Drawing.Size(123, 29);
            this.txt_daysLeft.TabIndex = 1;
            // 
            // rbTrial
            // 
            this.rbTrial.AutoSize = true;
            this.rbTrial.Checked = true;
            this.rbTrial.Location = new System.Drawing.Point(205, 83);
            this.rbTrial.Name = "rbTrial";
            this.rbTrial.Size = new System.Drawing.Size(80, 28);
            this.rbTrial.TabIndex = 2;
            this.rbTrial.TabStop = true;
            this.rbTrial.Text = "TRIAL";
            this.rbTrial.UseVisualStyleBackColor = true;
            this.rbTrial.CheckedChanged += new System.EventHandler(this.rbTrial_CheckedChanged);
            // 
            // rbFull
            // 
            this.rbFull.AutoSize = true;
            this.rbFull.Location = new System.Drawing.Point(324, 83);
            this.rbFull.Name = "rbFull";
            this.rbFull.Size = new System.Drawing.Size(73, 28);
            this.rbFull.TabIndex = 2;
            this.rbFull.Text = "FULL";
            this.rbFull.UseVisualStyleBackColor = true;
            this.rbFull.CheckedChanged += new System.EventHandler(this.rbFull_CheckedChanged);
            // 
            // btn_Activate
            // 
            this.btn_Activate.Location = new System.Drawing.Point(527, 277);
            this.btn_Activate.Name = "btn_Activate";
            this.btn_Activate.Size = new System.Drawing.Size(115, 45);
            this.btn_Activate.TabIndex = 3;
            this.btn_Activate.Text = "Activate";
            this.btn_Activate.UseVisualStyleBackColor = true;
            this.btn_Activate.Click += new System.EventHandler(this.btn_Activate_Click);
            // 
            // FrmActivate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 347);
            this.Controls.Add(this.btn_Activate);
            this.Controls.Add(this.rbFull);
            this.Controls.Add(this.rbTrial);
            this.Controls.Add(this.txt_daysLeft);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_expirationDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_creationDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Key);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_KeyCrypt);
            this.Controls.Add(this.txt_date);
            this.Controls.Add(this.txt_ProductId);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmActivate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "تفعيل المنتج";
            this.Load += new System.EventHandler(this.FrmActivate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_ProductId;
        private System.Windows.Forms.TextBox txt_date;
        public System.Windows.Forms.TextBox txt_KeyCrypt;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_Key;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txt_creationDate;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_expirationDate;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txt_daysLeft;
        private System.Windows.Forms.RadioButton rbTrial;
        private System.Windows.Forms.RadioButton rbFull;
        private System.Windows.Forms.Button btn_Activate;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
       

        #endregion
    }
}
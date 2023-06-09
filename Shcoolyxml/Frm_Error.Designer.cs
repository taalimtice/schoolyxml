namespace Schooly
{
    partial class Frm_Error
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
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_restart
            // 
            this.btn_restart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_restart.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_restart.Location = new System.Drawing.Point(231, 58);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(151, 60);
            this.btn_restart.TabIndex = 0;
            this.btn_restart.Text = "إعادة تشغيل البرنامج";
            this.btn_restart.UseVisualStyleBackColor = false;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_exit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_exit.Location = new System.Drawing.Point(53, 58);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(151, 60);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "إغلاق البرنامج تشغيل البرنامج";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Frm_Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(421, 161);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_restart);
            this.Name = "Frm_Error";
            this.Text = "ERROR";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.Button btn_exit;
    }
}
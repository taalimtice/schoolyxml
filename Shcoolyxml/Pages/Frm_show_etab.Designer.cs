namespace Schooly.Pages
{
    partial class Frm_show_etab
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
            this.tabControl_show_et = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgv_etabs = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgv_empl = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtgv_st = new System.Windows.Forms.DataGridView();
            this.cb_select_etab = new System.Windows.Forms.ComboBox();
            this.btn_showAll = new System.Windows.Forms.Button();
            this.tabControl_show_et.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_etabs)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_empl)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_st)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_show_et
            // 
            this.tabControl_show_et.Controls.Add(this.tabPage1);
            this.tabControl_show_et.Controls.Add(this.tabPage2);
            this.tabControl_show_et.Controls.Add(this.tabPage3);
            this.tabControl_show_et.Location = new System.Drawing.Point(13, 42);
            this.tabControl_show_et.Name = "tabControl_show_et";
            this.tabControl_show_et.SelectedIndex = 0;
            this.tabControl_show_et.Size = new System.Drawing.Size(584, 386);
            this.tabControl_show_et.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtgv_etabs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 360);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "المؤسسات";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgv_etabs
            // 
            this.dtgv_etabs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_etabs.Location = new System.Drawing.Point(6, 17);
            this.dtgv_etabs.Name = "dtgv_etabs";
            this.dtgv_etabs.Size = new System.Drawing.Size(564, 337);
            this.dtgv_etabs.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtgv_empl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "الموظفين";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtgv_empl
            // 
            this.dtgv_empl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_empl.Location = new System.Drawing.Point(6, 12);
            this.dtgv_empl.Name = "dtgv_empl";
            this.dtgv_empl.Size = new System.Drawing.Size(564, 337);
            this.dtgv_empl.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dtgv_st);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(576, 360);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "التلاميذ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtgv_st
            // 
            this.dtgv_st.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_st.Location = new System.Drawing.Point(6, 12);
            this.dtgv_st.Name = "dtgv_st";
            this.dtgv_st.Size = new System.Drawing.Size(564, 337);
            this.dtgv_st.TabIndex = 1;
            // 
            // cb_select_etab
            // 
            this.cb_select_etab.FormattingEnabled = true;
            this.cb_select_etab.Location = new System.Drawing.Point(249, 15);
            this.cb_select_etab.Name = "cb_select_etab";
            this.cb_select_etab.Size = new System.Drawing.Size(121, 21);
            this.cb_select_etab.TabIndex = 1;
            this.cb_select_etab.SelectedIndexChanged += new System.EventHandler(this.cb_select_etab_SelectedIndexChanged);
            // 
            // btn_showAll
            // 
            this.btn_showAll.Location = new System.Drawing.Point(480, 13);
            this.btn_showAll.Name = "btn_showAll";
            this.btn_showAll.Size = new System.Drawing.Size(75, 33);
            this.btn_showAll.TabIndex = 2;
            this.btn_showAll.Text = "عرض الكل";
            this.btn_showAll.UseVisualStyleBackColor = true;
            this.btn_showAll.Click += new System.EventHandler(this.btn_showAll_Click);
            // 
            // Frm_show_etab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 440);
            this.Controls.Add(this.btn_showAll);
            this.Controls.Add(this.cb_select_etab);
            this.Controls.Add(this.tabControl_show_et);
            this.Name = "Frm_show_etab";
            this.Text = "Frm_show_etab";
            this.Load += new System.EventHandler(this.Frm_show_etab_Load);
            this.tabControl_show_et.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_etabs)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_empl)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_st)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_show_et;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dtgv_etabs;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtgv_empl;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dtgv_st;
        private System.Windows.Forms.ComboBox cb_select_etab;
        private System.Windows.Forms.Button btn_showAll;
    }
}
namespace Schooly.Pages
{
    partial class Frm_Statistic_new_list_st
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Statistic_new_list_st));
            this.button1 = new System.Windows.Forms.Button();
            this.btn_chart_default = new System.Windows.Forms.Button();
            this.btn_chart_m = new System.Windows.Forms.Button();
            this.btn_chart_f = new System.Windows.Forms.Button();
            this.btn_chart_mf = new System.Windows.Forms.Button();
            this.btn_chart_niveau = new System.Windows.Forms.Button();
            this.btn_chart_etab = new System.Windows.Forms.Button();
            this.cb_chart_niv_cl = new System.Windows.Forms.ComboBox();
            this.lbl_cart_niv_etab = new System.Windows.Forms.Label();
            this.chart_dateNaiss_st = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_chart_count = new System.Windows.Forms.Label();
            this.cb_chart_choice_select = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_m_f = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_dateNaiss_st)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(23, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_chart_default
            // 
            this.btn_chart_default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_chart_default.Location = new System.Drawing.Point(262, 487);
            this.btn_chart_default.Name = "btn_chart_default";
            this.btn_chart_default.Size = new System.Drawing.Size(75, 23);
            this.btn_chart_default.TabIndex = 2;
            this.btn_chart_default.Text = "افتراضي";
            this.btn_chart_default.UseVisualStyleBackColor = true;
            this.btn_chart_default.Click += new System.EventHandler(this.btn_chart_default_Click);
            // 
            // btn_chart_m
            // 
            this.btn_chart_m.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_chart_m.Location = new System.Drawing.Point(181, 487);
            this.btn_chart_m.Name = "btn_chart_m";
            this.btn_chart_m.Size = new System.Drawing.Size(75, 23);
            this.btn_chart_m.TabIndex = 2;
            this.btn_chart_m.Text = "ذكور";
            this.btn_chart_m.UseVisualStyleBackColor = true;
            this.btn_chart_m.Click += new System.EventHandler(this.btn_chart_m_Click);
            // 
            // btn_chart_f
            // 
            this.btn_chart_f.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_chart_f.Location = new System.Drawing.Point(100, 487);
            this.btn_chart_f.Name = "btn_chart_f";
            this.btn_chart_f.Size = new System.Drawing.Size(75, 23);
            this.btn_chart_f.TabIndex = 2;
            this.btn_chart_f.Text = "إناث";
            this.btn_chart_f.UseVisualStyleBackColor = true;
            this.btn_chart_f.Click += new System.EventHandler(this.btn_chart_f_Click);
            // 
            // btn_chart_mf
            // 
            this.btn_chart_mf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_chart_mf.Location = new System.Drawing.Point(19, 487);
            this.btn_chart_mf.Name = "btn_chart_mf";
            this.btn_chart_mf.Size = new System.Drawing.Size(75, 23);
            this.btn_chart_mf.TabIndex = 2;
            this.btn_chart_mf.Text = "ذكور و إناث";
            this.btn_chart_mf.UseVisualStyleBackColor = true;
            this.btn_chart_mf.Click += new System.EventHandler(this.btn_chart_mf_Click);
            // 
            // btn_chart_niveau
            // 
            this.btn_chart_niveau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_chart_niveau.Location = new System.Drawing.Point(479, 473);
            this.btn_chart_niveau.Name = "btn_chart_niveau";
            this.btn_chart_niveau.Size = new System.Drawing.Size(75, 37);
            this.btn_chart_niveau.TabIndex = 2;
            this.btn_chart_niveau.Text = "حسب المستوى";
            this.btn_chart_niveau.UseVisualStyleBackColor = true;
            this.btn_chart_niveau.Click += new System.EventHandler(this.btn_chart_niveau_Click);
            // 
            // btn_chart_etab
            // 
            this.btn_chart_etab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_chart_etab.Location = new System.Drawing.Point(570, 473);
            this.btn_chart_etab.Name = "btn_chart_etab";
            this.btn_chart_etab.Size = new System.Drawing.Size(75, 37);
            this.btn_chart_etab.TabIndex = 2;
            this.btn_chart_etab.Text = "حسب المؤسسة";
            this.btn_chart_etab.UseVisualStyleBackColor = true;
            this.btn_chart_etab.Click += new System.EventHandler(this.btn_chart_etab_Click);
            // 
            // cb_chart_niv_cl
            // 
            this.cb_chart_niv_cl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_chart_niv_cl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_chart_niv_cl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_chart_niv_cl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_chart_niv_cl.FormattingEnabled = true;
            this.cb_chart_niv_cl.Location = new System.Drawing.Point(100, 447);
            this.cb_chart_niv_cl.Name = "cb_chart_niv_cl";
            this.cb_chart_niv_cl.Size = new System.Drawing.Size(141, 21);
            this.cb_chart_niv_cl.TabIndex = 3;
            this.cb_chart_niv_cl.SelectedIndexChanged += new System.EventHandler(this.cb_chart_niv_cl_SelectedIndexChanged);
            // 
            // lbl_cart_niv_etab
            // 
            this.lbl_cart_niv_etab.AutoSize = true;
            this.lbl_cart_niv_etab.Location = new System.Drawing.Point(97, 22);
            this.lbl_cart_niv_etab.Name = "lbl_cart_niv_etab";
            this.lbl_cart_niv_etab.Size = new System.Drawing.Size(35, 13);
            this.lbl_cart_niv_etab.TabIndex = 4;
            this.lbl_cart_niv_etab.Text = "label1";
            this.lbl_cart_niv_etab.Visible = false;
            // 
            // chart_dateNaiss_st
            // 
            this.chart_dateNaiss_st.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_dateNaiss_st.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chart_dateNaiss_st.BorderSkin.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart_dateNaiss_st.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_dateNaiss_st.Legends.Add(legend1);
            this.chart_dateNaiss_st.Location = new System.Drawing.Point(12, 38);
            this.chart_dateNaiss_st.Name = "chart_dateNaiss_st";
            this.chart_dateNaiss_st.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "الذكور و الإناث";
            series1.YValuesPerPoint = 2;
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "ذكور";
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Fuchsia;
            series3.Legend = "Legend1";
            series3.Name = "إناث";
            this.chart_dateNaiss_st.Series.Add(series1);
            this.chart_dateNaiss_st.Series.Add(series2);
            this.chart_dateNaiss_st.Series.Add(series3);
            this.chart_dateNaiss_st.Size = new System.Drawing.Size(644, 399);
            this.chart_dateNaiss_st.TabIndex = 0;
            this.chart_dateNaiss_st.Text = "chart_dnaiss";
            title1.Name = "Title1";
            this.chart_dateNaiss_st.Titles.Add(title1);
            // 
            // lbl_chart_count
            // 
            this.lbl_chart_count.AutoSize = true;
            this.lbl_chart_count.Location = new System.Drawing.Point(157, 9);
            this.lbl_chart_count.Name = "lbl_chart_count";
            this.lbl_chart_count.Size = new System.Drawing.Size(35, 13);
            this.lbl_chart_count.TabIndex = 5;
            this.lbl_chart_count.Text = "label1";
            // 
            // cb_chart_choice_select
            // 
            this.cb_chart_choice_select.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_chart_choice_select.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_chart_choice_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_chart_choice_select.FormattingEnabled = true;
            this.cb_chart_choice_select.Items.AddRange(new object[] {
            "حسب تاريخ الإزدياد",
            "حسب الجنس",
            "حسب المستوى"});
            this.cb_chart_choice_select.Location = new System.Drawing.Point(409, 10);
            this.cb_chart_choice_select.Name = "cb_chart_choice_select";
            this.cb_chart_choice_select.Size = new System.Drawing.Size(121, 21);
            this.cb_chart_choice_select.TabIndex = 6;
            this.cb_chart_choice_select.SelectedIndexChanged += new System.EventHandler(this.cb_chart_choice_select_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(546, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "تحديد نوع الإختيار";
            // 
            // lbl_m_f
            // 
            this.lbl_m_f.AutoSize = true;
            this.lbl_m_f.Location = new System.Drawing.Point(205, 21);
            this.lbl_m_f.Name = "lbl_m_f";
            this.lbl_m_f.Size = new System.Drawing.Size(35, 13);
            this.lbl_m_f.TabIndex = 8;
            this.lbl_m_f.Text = "label2";
            this.lbl_m_f.Visible = false;
            // 
            // Frm_Statistic_new_list_st
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(657, 522);
            this.Controls.Add(this.lbl_m_f);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_chart_choice_select);
            this.Controls.Add(this.lbl_chart_count);
            this.Controls.Add(this.lbl_cart_niv_etab);
            this.Controls.Add(this.cb_chart_niv_cl);
            this.Controls.Add(this.btn_chart_etab);
            this.Controls.Add(this.btn_chart_niveau);
            this.Controls.Add(this.btn_chart_mf);
            this.Controls.Add(this.btn_chart_f);
            this.Controls.Add(this.btn_chart_m);
            this.Controls.Add(this.btn_chart_default);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart_dateNaiss_st);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Statistic_new_list_st";
            this.Text = "Frm_Statistic_new_list_st";
            this.Load += new System.EventHandler(this.Frm_Statistic_new_list_st_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_dateNaiss_st)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_chart_default;
        private System.Windows.Forms.Button btn_chart_m;
        private System.Windows.Forms.Button btn_chart_f;
        private System.Windows.Forms.Button btn_chart_mf;
        private System.Windows.Forms.Button btn_chart_niveau;
        private System.Windows.Forms.Button btn_chart_etab;
        private System.Windows.Forms.ComboBox cb_chart_niv_cl;
        private System.Windows.Forms.Label lbl_cart_niv_etab;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart_dateNaiss_st;
        internal System.Windows.Forms.Label lbl_chart_count;
        private System.Windows.Forms.ComboBox cb_chart_choice_select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_m_f;
    }
}
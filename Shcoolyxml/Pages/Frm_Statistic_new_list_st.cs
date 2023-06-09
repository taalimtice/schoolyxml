using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Schooly.Pages
{
    public partial class Frm_Statistic_new_list_st : Form
    {


      
        
        public Frm_Statistic_new_list_st()
        {
            InitializeComponent();
           
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Statistic_new_list_st_Load(object sender, EventArgs e)
        {
            cb_chart_choice_select.SelectedIndex = 0;
            StudentsListDataContext sdc = new StudentsListDataContext();

            var nivs = (from et in sdc.StudentListUpdates
                        where et.gresa_Up ==Tools.Globals.GRESA
                        orderby et.classe_Up
                        select et.niveau_Up).Distinct().ToList();
            cb_chart_niv_cl.Visible = false;
            cb_chart_niv_cl.DataSource=nivs;
           

            var dnaissCal = (from x in sdc.StudentListUpdates
                             where x.gresa_Up == Tools.Globals.GRESA
                             group x by x.dateNaiss_Up.Value.Year into g
                             let countAll = g.Count()
                             let countM = g.Where(m => m.genre_Up == "ذكر").Count()
                             let countF = g.Where(m => m.genre_Up == "أنثى").Count()
                             select new { Value = g.Key, CountAll = countAll, CountM = countM, CountF = countF }).ToList();

            Clear_series();
           

            chart_dateNaiss_st.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart_dateNaiss_st.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            lbl_cart_niv_etab.Text = "etab";
            cb_chart_niv_cl.Visible = false;

            chart_dateNaiss_st.Series[0].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountAll");
            chart_dateNaiss_st.Series[1].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountM");
            chart_dateNaiss_st.Series[2].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountF");

            lbl_chart_count.Text = "عدد تلاميذ المؤسسة:" + "   " + dnaissCal.Sum(x => x.CountAll).ToString();

           // chart_dateNaiss_st.DataBind();

            Customize_chart_dateNaiss_st();

        }

        private void Date_Etab_all()
        {

         

            Clear_series();
               
                    StudentsListDataContext sdc = new StudentsListDataContext();

                    var dnaissCal = (from x in sdc.StudentListUpdates
                                     where x.gresa_Up == Tools.Globals.GRESA
                                     group x by x.dateNaiss_Up.Value.Year into g
                                     let countAll = g.Count()
                                     let countM = g.Where(m => m.genre_Up == "ذكر").Count()
                                     let countF = g.Where(m => m.genre_Up == "أنثى").Count()
                                     select new { Value = g.Key, CountAll = countAll, CountM = countM, CountF = countF }).ToList();

                    chart_dateNaiss_st.Series[0].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountAll");
                    chart_dateNaiss_st.Series[1].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountM");
                    chart_dateNaiss_st.Series[2].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountF");


            Customize_chart_dateNaiss_st();
        }
        private void Date_niv_all(string niv)
        {
           
            Clear_series();
            StudentsListDataContext sdc = new StudentsListDataContext();

            var dnaissCal = (from x in sdc.StudentListUpdates
                             where x.gresa_Up == Tools.Globals.GRESA & x.niveau_Up == niv
                             group x by x.dateNaiss_Up.Value.Year into g
                             let countM = g.Where(m => m.genre_Up == "ذكر").Count()
                             let countF = g.Where(m => m.genre_Up == "أنثى").Count()
                             let countAll = g.Count()
                             select new { Value = g.Key, CountM = countM, CountF = countF, CountAll = countAll }).ToList();
            

            chart_dateNaiss_st.Series[0].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountAll");
            chart_dateNaiss_st.Series[1].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountM");
            chart_dateNaiss_st.Series[2].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountF");

            lbl_chart_count.Text = "عدد التلاميذ  بالمستوى: " + "  " + cb_chart_niv_cl.Text + "" + dnaissCal.Sum(x => x.CountAll).ToString();
            Customize_chart_dateNaiss_st();
        }
      
        private void Date_Etab_m()
        {

            Clear_series();

            StudentsListDataContext sdc = new StudentsListDataContext();

            var dnaissCal = (from x in sdc.StudentListUpdates
                             where x.gresa_Up == Tools.Globals.GRESA
                             group x by x.dateNaiss_Up.Value.Year into g
                             let countM = g.Where(m => m.genre_Up == "ذكر").Count()
                            
                             select new { Value = g.Key,  CountM = countM }).ToList();

            chart_dateNaiss_st.Series[1].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountM");

            Customize_chart_dateNaiss_st();
        }

        private void Date_Etab_f()
        {
           
            Clear_series();

            StudentsListDataContext sdc = new StudentsListDataContext();

            var dnaissCal = (from x in sdc.StudentListUpdates
                             where x.gresa_Up == Tools.Globals.GRESA
                             group x by x.dateNaiss_Up.Value.Year into g
                             let countAll = g.Count()
                             let countF = g.Where(m => m.genre_Up == "أنثى").Count()

                             select new { Value = g.Key, CountF = countF }).ToList();

            chart_dateNaiss_st.Series[2].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountF");

            Customize_chart_dateNaiss_st();

        }

        private void Date_niv_m(string niv)
        {
           
            Clear_series();
            StudentsListDataContext sdc = new StudentsListDataContext();

            var dnaissCal = (from x in sdc.StudentListUpdates
                             where x.gresa_Up == Tools.Globals.GRESA & x.niveau_Up == niv
                             group x by x.dateNaiss_Up.Value.Year into g
                             let countM = g.Where(m => m.genre_Up == "ذكر").Count()
                           
                             select new { Value = g.Key, CountM = countM }).ToList();



            chart_dateNaiss_st.Series[1].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountM");

            Customize_chart_dateNaiss_st();
        }
        private void Date_niv_f(string niv)
        {
            Clear_series();
           

            StudentsListDataContext sdc = new StudentsListDataContext();



            var dnaissCal = (from x in sdc.StudentListUpdates
                             where x.gresa_Up == Tools.Globals.GRESA & x.niveau_Up == niv
                             group x by x.dateNaiss_Up.Value.Year into g
                             let countF = g.Where(m => m.genre_Up == "أنثى").Count()
                             select new { Value = g.Key, CountF = countF }).ToList();



          
            chart_dateNaiss_st.Series[2].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountF");

            Customize_chart_dateNaiss_st();
        }
        private void Genre_Etab()
        {

            Clear_series();
           

            StudentsListDataContext sdc = new StudentsListDataContext();

            var dnaissCal = (from x in sdc.StudentListUpdates
                             where x.gresa_Up == Tools.Globals.GRESA
                             group x by x.genre_Up into g
                             let countM = g.Where(m => m.genre_Up == "ذكر").Count()
                             let countF = g.Where(m => m.genre_Up == "أنثى").Count()
                             select new { Value = g.Key, CountM = countM, CountF = countF }).ToList();

            chart_dateNaiss_st.Series[1].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountM");
            chart_dateNaiss_st.Series[2].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountF");

            Customize_chart_dateNaiss_st();
        }
        private void Genre_niv(string niv)
        {
           
            Clear_series();

            StudentsListDataContext sdc = new StudentsListDataContext();

            var dnaissCal = (from x in sdc.StudentListUpdates
                             where x.gresa_Up == Tools.Globals.GRESA & x.niveau_Up==niv
                             group x by x.genre_Up into g
                             let countM = g.Where(m => m.genre_Up == "ذكر").Count()
                             let countF = g.Where(m => m.genre_Up == "أنثى").Count()
                             select new { Value = g.Key, CountM = countM, CountF = countF }).ToList();

            chart_dateNaiss_st.Series[1].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountM");
            chart_dateNaiss_st.Series[2].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountF");

            Customize_chart_dateNaiss_st();
        }


        private void btn_chart_default_Click(object sender, EventArgs e)
        {
            lbl_m_f.Text = "d";
            if (cb_chart_choice_select.SelectedIndex == 0) // by date
            {
                if (lbl_cart_niv_etab.Text == "niv")
                {
                    Date_niv_all(cb_chart_niv_cl.Text);
                }
                if (lbl_cart_niv_etab.Text == "etab")
                {
                    Date_Etab_all();
                }
            }
            if (cb_chart_choice_select.SelectedIndex == 1) // by sex
            {
                if (lbl_cart_niv_etab.Text == "niv")
                {
                    Genre_niv(cb_chart_niv_cl.Text);
                }
                if (lbl_cart_niv_etab.Text == "etab")
                {
                    Genre_Etab();
                }
            }
            if (cb_chart_choice_select.SelectedIndex == 2)
            {

            }
        }

        private void btn_chart_etab_Click(object sender, EventArgs e)
        {
            cb_chart_niv_cl.Visible = false;
            lbl_cart_niv_etab.Text = "etab";


           

            if (cb_chart_choice_select.SelectedIndex == 0)
            {
                btn_chart_default.Visible = true;
                btn_chart_m.Visible = true;
                btn_chart_f.Visible = true;
                btn_chart_mf.Visible = true;
                chart_dateNaiss_st.Titles[0].Text = "حسب تاريخ الإزدياد";
                Date_Etab_all();
            }
            if (cb_chart_choice_select.SelectedIndex == 1)
            {
               
                btn_chart_default.Visible = false;
                btn_chart_m.Visible = false;
                btn_chart_f.Visible = false;
                btn_chart_mf.Visible = false;
                chart_dateNaiss_st.Titles[0].Text = "حسب النوع";
                Genre_Etab();
            }


        }

        private void btn_chart_m_Click(object sender, EventArgs e)
        {
            lbl_m_f.Text = "m";
            if (cb_chart_choice_select.SelectedIndex == 0)
            {
                chart_dateNaiss_st.Titles[0].Text = "حسب تاريخ الإزدياد";
                if (lbl_cart_niv_etab.Text == "etab")
                {
                    Date_Etab_m();
                }
                if (lbl_cart_niv_etab.Text == "niv")
                {
                    Date_niv_m(cb_chart_niv_cl.Text);
                }
            }
            if (cb_chart_choice_select.SelectedIndex == 1)
            {
                chart_dateNaiss_st.Titles[0].Text = "حسب النوع";
            }

        }

        private void btn_chart_f_Click(object sender, EventArgs e)
        {
            lbl_m_f.Text = "f";
            if (cb_chart_choice_select.SelectedIndex == 0)
            {
                chart_dateNaiss_st.Titles[0].Text = "حسب تاريخ الإزدياد";
                if (lbl_cart_niv_etab.Text == "etab")
                {
                    Date_Etab_f();
                }
                if (lbl_cart_niv_etab.Text == "niv")
                {
                    Date_niv_f(cb_chart_niv_cl.Text);
                }
            }

            if (cb_chart_choice_select.SelectedIndex == 1)
            {
                chart_dateNaiss_st.Titles[0].Text = "حسب النوع";
            }

        }

        private void btn_chart_mf_Click(object sender, EventArgs e)
        {
            Clear_series();
            lbl_m_f.Text = "mf";
            if (cb_chart_choice_select.SelectedIndex == 0)
            {
                chart_dateNaiss_st.Titles[0].Text = "حسب تاريخ الإزدياد";
                if (lbl_cart_niv_etab.Text == "etab")
                {
                    StudentsListDataContext sdc = new StudentsListDataContext();

                    var dnaissCal = (from x in sdc.StudentListUpdates
                                     where x.gresa_Up == Tools.Globals.GRESA
                                     group x by x.dateNaiss_Up.Value.Year into g
                                     let countM = g.Where(m => m.genre_Up == "ذكر").Count()
                                     let countF = g.Where(m => m.genre_Up == "أنثى").Count()
                                     select new { Value = g.Key, CountM = countM, CountF = countF }).ToList();




                    chart_dateNaiss_st.Series[1].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountM");
                    chart_dateNaiss_st.Series[2].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountF");

                    lbl_chart_count.Text = "عدد التلاميذ  بالمؤسسة: " + "  " + dnaissCal.Sum(x => x.CountM + x.CountF).ToString(); ;

                }
                if (lbl_cart_niv_etab.Text == "niv")
                {
                    StudentsListDataContext sdc = new StudentsListDataContext();

                    var dnaissCal = (from x in sdc.StudentListUpdates
                                     where x.gresa_Up == Tools.Globals.GRESA & x.niveau_Up == cb_chart_niv_cl.Text
                                     group x by x.dateNaiss_Up.Value.Year into g
                                     let countM = g.Where(m => m.genre_Up == "ذكر").Count()
                                     let countF = g.Where(m => m.genre_Up == "أنثى").Count()
                                     select new { Value = g.Key, CountM = countM, CountF = countF }).ToList();




                    chart_dateNaiss_st.Series[1].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountM");
                    chart_dateNaiss_st.Series[2].Points.DataBindXY(dnaissCal, "Value", dnaissCal, "CountF");

                    lbl_chart_count.Text = " عدد التلاميذ  بالمستوى: " + "  " + cb_chart_niv_cl.Text + " " + dnaissCal.Sum(x => x.CountM + x.CountF).ToString();
                }
            }
            Customize_chart_dateNaiss_st();
        }

        private void btn_chart_niveau_Click(object sender, EventArgs e)
        {
            cb_chart_niv_cl.Visible = true;
            lbl_cart_niv_etab.Text = "niv";
            lbl_m_f.Text = "d";
           
            if (cb_chart_choice_select.SelectedIndex == 0)
            {
                Date_niv_all(cb_chart_niv_cl.Text);
            }
            if (cb_chart_choice_select.SelectedIndex == 1)
            {
                cb_chart_niv_cl.Visible = true;
                Genre_niv(cb_chart_niv_cl.Text);
            }

        }

       

      
        private void cb_chart_niv_cl_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            if (cb_chart_choice_select.SelectedIndex == 0)
                {
                chart_dateNaiss_st.Titles[0].Text = "حسب تاريخ الإزدياد";
                if (lbl_m_f.Text == "d")
                    {
                        Date_niv_all(cb_chart_niv_cl.Text);
                    }
                    if (lbl_m_f.Text == "m")
                    {
                        Date_niv_m(cb_chart_niv_cl.Text);
                    }
                    if (lbl_m_f.Text == "f")
                    {
                        Date_niv_f(cb_chart_niv_cl.Text);
                    }
                    if (lbl_m_f.Text == "mf")
                    {
                        btn_chart_mf_Click(sender, e);
                    }

                }
                if (cb_chart_choice_select.SelectedIndex == 1)
                {
                chart_dateNaiss_st.Titles[0].Text = "حسب النوع";
                Genre_niv(cb_chart_niv_cl.Text);
                }
          
           
           
        }

        private void cb_chart_choice_select_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                btn_chart_etab_Click(sender, e);
           
           
        }
        private void Clear_series()
        {
            chart_dateNaiss_st.Series[0].Points.Clear();
            chart_dateNaiss_st.Series[1].Points.Clear();
            chart_dateNaiss_st.Series[2].Points.Clear();
        }
        private void Customize_chart_dateNaiss_st()
        {
            if (chart_dateNaiss_st.Series[0].Points.Count == 0)
            {
                chart_dateNaiss_st.Series[0].IsVisibleInLegend=false;
                chart_dateNaiss_st.Series[0].IsValueShownAsLabel = false;

            }
                else
                {
                    chart_dateNaiss_st.Series[0].IsVisibleInLegend = true;
                    chart_dateNaiss_st.Series[0].IsValueShownAsLabel = true;
            }
            if (chart_dateNaiss_st.Series[1].Points.Count == 0)
            {
                chart_dateNaiss_st.Series[1].IsVisibleInLegend = false;
                chart_dateNaiss_st.Series[1].IsValueShownAsLabel = false;
            }
                else
                {
                    chart_dateNaiss_st.Series[1].IsVisibleInLegend = true;
                    chart_dateNaiss_st.Series[1].IsValueShownAsLabel = true;
            }
            if (chart_dateNaiss_st.Series[2].Points.Count == 0)
            {
                chart_dateNaiss_st.Series[2].IsVisibleInLegend = false;
                chart_dateNaiss_st.Series[2].IsValueShownAsLabel = false;
            }
                else
                {
                    chart_dateNaiss_st.Series[2].IsVisibleInLegend = true;
                    chart_dateNaiss_st.Series[2].IsValueShownAsLabel = true;
            }

        }
    }
}

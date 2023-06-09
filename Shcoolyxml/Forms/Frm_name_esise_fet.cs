using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly.Forms
{
    public partial class Frm_name_esise_fet : Form
    {
        public Frm_name_esise_fet()
        {
            InitializeComponent();
        }

        string lblText = " مستوى مغير"; int lblCounter = 0;
        private void Frm_tt_rectf_cl_Load(object sender, EventArgs e)
        {
            try
            {

          
          
            StudentsListDataContext db = new StudentsListDataContext();

            fetDataContext dbfet = new fetDataContext();

            EmployeeDataContext dbEsise = new EmployeeDataContext();

            var td = (from s in db.StudentListUpdates where s.gresa_Up==Tools.Globals.GRESA
                      select new
                      {
                          s.classe_Up,
                          s.niveau_Up,
                      }).ToList();
            var tdniv = td.GroupBy(x => x.niveau_Up).Select(x => x.First()).ToList();

                var bindingSource1 = new BindingSource();
                bindingSource1.DataSource = tdniv;

                cb_rect_niv_mass.DataSource = bindingSource1.DataSource;

                cb_rect_niv_mass.DisplayMember = "niveau_Up";
                cb_rect_niv_mass.ValueMember = "niveau_Up";


            //    foreach (var item in tdniv)
            //{
            //    if(item.niveau_Up!=null)
            //    cb_rect_niv_mass.Items.Add(item.niveau_Up);
            //}

            if (cb_rect_niv_mass.Items.Count > 0)
            {
                cb_rect_niv_mass.SelectedItem = cb_rect_niv_mass.Items[0];
                var tdcl = td.Where(y => y.niveau_Up.Equals(cb_rect_niv_mass.Text)).GroupBy(x => x.classe_Up).Select(x => x.First()).ToList();
                     // cb_rect_cl_mass.DataSource=null;

                    var bindingSource2 = new BindingSource();
                    bindingSource2.DataSource = tdcl;

                    cb_rect_cl_mass.DataSource = bindingSource2.DataSource;

                    cb_rect_cl_mass.DisplayMember = "classe_Up";
                    cb_rect_cl_mass.ValueMember = "classe_Up";

                    //foreach (var item in tdcl)
                    //{

                    //    cb_rect_cl_mass.Items.Add(item.classe_Up);
                    //}


                    if (cb_rect_cl_mass.Items.Count > 0)
                {
                    cb_rect_cl_mass.SelectedItem = cb_rect_cl_mass.Items[0];

                }



            }

            //***********************************
            var tf = (from s in dbfet.elevesses
                      where s.gresa_el_fet == Tools.Globals.GRESA
                      select new
                      {
                          s.Year,
                          s.groups,
                          s.Subgroup
                      }).Distinct().ToList();
            var tfniv = tf.Select(x => new {year=x.Year }).Distinct().ToList();

                

                var bindingSource3 = new BindingSource();
                bindingSource3.DataSource = tfniv;
                cb_rect_niv_fet.DataSource = bindingSource3.DataSource;
                cb_rect_niv_fet.DisplayMember = "year";
                cb_rect_niv_fet.ValueMember = "year";

                //foreach (var item in tfniv)
                //{

                //    cb_rect_niv_fet.Items.Add(item.Year);
                //}

                if (cb_rect_niv_fet.Items.Count > 0)
            {
                if (cb_rect_niv_fet.Items.Contains(cb_rect_niv_mass.Text))
                {
                    cb_rect_niv_fet.SelectedItem = cb_rect_niv_mass.Text;
                }
                cb_rect_niv_fet.SelectedItem = cb_rect_niv_fet.Items[0];
                var tfcl = tf.Where(y => y.Year.Equals(cb_rect_niv_fet.Text) && !string.IsNullOrEmpty(y.groups)).GroupBy(x => x.groups).Select(x => x.First()).ToList();
                //  cb_rect_cl_frt.Items.Clear();

                var bindingSource4 = new BindingSource();
                bindingSource4.DataSource = tfcl;

                cb_rect_cl_frt.DataSource = bindingSource4.DataSource;

                cb_rect_cl_frt.DisplayMember = "groups";
                cb_rect_cl_frt.ValueMember = "groups";

                //foreach (var item in tfcl)
                //{

                //    cb_rect_cl_frt.Items.Add(item.groups);
                //}
                if (cb_rect_cl_frt.Items.Count > 0)
                {
                    cb_rect_cl_frt.SelectedItem = cb_rect_cl_frt.Items[0];

                }


                chb_rect_isSub.Checked = true;
                btn_rect_add_sub.Enabled = false;




            }
            //*********************************************
            //var tdprofs = (from s in dbEsise.DATAIDENTIFPERSONNELs
            var tdprofs = (from s in dbEsise.Emp_Datas
                           join ss in dbEsise.Emp_Acts on s.ppr_dat equals ss.ppr_act
                          where ss.CD_ETAB == Tools.Globals.GRESA

                           select new
                           {
                               nom = s.NOMA + " " + s.PRENOMA,
                               som = s.ppr_dat
                              
                           }).ToList();
            //var tdpr = tdprofs.GroupBy(x => x.PPR).Select(x => x.First()).ToList();



            cb_rect_prof_esise.DataSource = tdprofs;
            cb_rect_prof_esise.DisplayMember = "nom";
            cb_rect_prof_esise.ValueMember = "som";




            //foreach (var item in tdprofs)
            //{

            //    cb_rect_prof_esise.Items.Add(item.NOMA + " " + item.PRENOMA);
            //}


            var lst_techers_fet = (from t in dbfet.timeTables
                                   where t.gresa_tt_fet==Tools.Globals.GRESA
                                   select t.Teachers).Distinct().ToList();

            cb_rect_prof_fet.DataSource = lst_techers_fet;

            //foreach (var item in lst_techers_fet)
            //{

            //    cb_rect_prof_fet.Items.Add(item);
            //}

            if(lst_techers_fet.Count>0)
            cb_rect_prof_fet.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cb_rect_niv_mass_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentsListDataContext db = new StudentsListDataContext();
            var td = (from s in db.StudentListUpdates
                      where s.gresa_Up==Tools.Globals.GRESA
                      select new
                      {
                         cl= s.classe_Up,
                         nv= s.niveau_Up,
                      }).Distinct().ToList();

          
            
            var tdcl = td.Where(y => y.nv.Equals(cb_rect_niv_mass.Text)).ToList();

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = tdcl;

            cb_rect_cl_mass.DataSource = bindingSource1.DataSource;
            cb_rect_cl_mass.DisplayMember = "cl";
            cb_rect_cl_mass.ValueMember = "cl";

            if (cb_rect_cl_mass.Items.Count > 0)
            { cb_rect_cl_mass.SelectedItem = cb_rect_cl_mass.Items[0]; }

            if (cb_rect_niv_fet.Items.Contains(cb_rect_niv_mass.Text))
            {
                cb_rect_niv_fet.SelectedItem = cb_rect_niv_mass.Text;
            }
        }

        private void cb_rect_niv_fet_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetDataContext dbfet = new fetDataContext();

            var tf = (from s in dbfet.elevesses
                      where s.gresa_el_fet == Tools.Globals.GRESA
                      select new
                      {
                          s.Year,
                          s.groups,
                          s.Subgroup
                      }).ToList();

            var tfcl = tf.Where(y => y.Year.Equals(cb_rect_niv_fet.Text) & !string.IsNullOrEmpty(y.groups)).Distinct().ToList();
            // cb_rect_cl_frt.Items.Clear();

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = tfcl;

            cb_rect_cl_frt.DataSource = bindingSource1.DataSource;

            cb_rect_cl_frt.DisplayMember = "groups";
            cb_rect_cl_frt.ValueMember = "groups";

            //foreach (var item in tfcl)
            //{
            //    if (item.groups != string.Empty)
            //    {
            //        cb_rect_cl_frt.Items.Add(item.groups);
            //    }

            //  }
            if (cb_rect_cl_frt.Items.Count > 0)
            { cb_rect_cl_frt.SelectedItem = cb_rect_cl_frt.Items[0]; }

            if (cb_rect_niv_mass.Items.Contains(cb_rect_niv_fet.Text))
            {
                cb_rect_niv_mass.SelectedItem = cb_rect_niv_fet.Text;
            }

        }

        private void cb_rect_cl_frt_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetDataContext dbfet = new fetDataContext();

            var tf = (from s in dbfet.elevesses
                      where s.gresa_el_fet == Tools.Globals.GRESA
                      select new
                      {
                          s.Year,
                          s.groups,
                          s.Subgroup
                      }).Distinct().ToList();

            var tfcl = tf.Where(y => y.groups.Equals(cb_rect_cl_frt.Text) & !string.IsNullOrWhiteSpace(y.Subgroup)).ToList();

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = tfcl;
            cb_rect_subcl_frt.DataSource = bindingSource1.DataSource;
            cb_rect_subcl_frt.DisplayMember = "Subgroup";
            cb_rect_subcl_frt.ValueMember = "Subgroup";

           
            if (cb_rect_subcl_frt.Items.Count > 0)
            {
                btn_rect_add_sub.Enabled = true;

                cb_rect_subcl_frt.SelectedItem = cb_rect_subcl_frt.Items[0];
            }
            else { btn_rect_add_sub.Enabled = false; }
        }

        private void btn_rect_add_Click(object sender, EventArgs e)
        {
            try
            {


                fetDataContext dbfet = new fetDataContext();
                string oldNiveau = cb_rect_niv_fet.Text;
            string newNiveau = cb_rect_niv_mass.Text;

            var tk = (from k in dbfet.elevesses
                      where k.gresa_el_fet ==Tools.Globals.GRESA
                      select k.Year).ToList().Distinct();

            if (!tk.Contains(oldNiveau))
            {
                    (from p in dbfet.elevesses

                     where p.gresa_el_fet == Tools.Globals.GRESA & p.Year == oldNiveau 
                     select p).ToList()
                              .ForEach(x => x.Year = newNiveau);

                    dbfet.SubmitChanges();

                    tk = (from s in dbfet.elevesses
                          where s.gresa_el_fet == Tools.Globals.GRESA
                          select s.Year).Distinct().ToList();

                var bindingSource1 = new BindingSource();
                bindingSource1.DataSource = tk;

                cb_rect_niv_fet.DataSource = bindingSource1.DataSource;

                cb_rect_niv_fet.DisplayMember = "Year";
                cb_rect_niv_fet.ValueMember = "Year";


                cb_rect_niv_fet.SelectedItem = cb_rect_niv_mass.Text;



                MessageBox.Show("تم التغيير بنجاح");
               
            }
            else { MessageBox.Show(" المستوى "+" "+newNiveau+" "+"لايحتاج إلى مطابقة"); }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_rect_add_classe_Click(object sender, EventArgs e)
        {
            try
            {
                fetDataContext dbfet = new fetDataContext();
                string oldClasse = cb_rect_cl_frt.Text;
            string newClasse = cb_rect_cl_mass.Text;

            var tk = (from k in dbfet.elevesses
                      where k.gresa_el_fet == Tools.Globals.GRESA && k.Year == cb_rect_niv_fet.Text
                      select k.groups).Distinct().ToList();

            if (!tk.Contains(newClasse))
            {

                    (from p in dbfet.elevesses
                     where p.gresa_el_fet==Tools.Globals.GRESA && p.groups == oldClasse
                     select p).ToList()
                              .ForEach(x => x.groups = newClasse);

                (from p in dbfet.timeTables
                 where p.gresa_tt_fet==Tools.Globals.GRESA && p.StudentsSets == oldClasse
                 select p).ToList()
                              .ForEach(x => x.StudentsSets = newClasse);

                dbfet.SubmitChanges();

                var tf = (from s in dbfet.elevesses
                          where s.gresa_el_fet == Tools.Globals.GRESA && s.Year == cb_rect_niv_fet.Text
                          select s.groups).Distinct().ToList();
              
                var bindingSource1 = new BindingSource();
                bindingSource1.DataSource = tf;

                cb_rect_cl_frt.DataSource = bindingSource1.DataSource;

                cb_rect_cl_frt.DisplayMember = "groups";
                cb_rect_cl_frt.ValueMember = "groups";
              
                cb_rect_cl_frt.SelectedItem = cb_rect_cl_mass.Text;



                MessageBox.Show("تم التغيير بنجاح");
              
            }
            else { MessageBox.Show(" الفسم "+" "+newClasse+" "+ "لا يحتاج إلى متطابقة"); }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void chb_rect_isSub_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_rect_isSub.Checked == false) { btn_rect_add_sub.Enabled = true; }
            if (chb_rect_isSub.Checked == true) { btn_rect_add_sub.Enabled = false; }
        }

        private void btn_rect_add_sub_Click(object sender, EventArgs e)
        {
            try
            {
            string oldsubcl = cb_rect_subcl_frt.Text;
            string newsubcl = cb_rect_subcl_mass.Text;

            fetDataContext dbfet = new fetDataContext();

            if (cb_rect_subcl_frt.Text != cb_rect_cl_mass.Text + cb_rect_subcl_mass.Text)
            {

                (from p in dbfet.elevesses
                 where p.gresa_el_fet == Tools.Globals.GRESA && p.Subgroup == oldsubcl
                 select p).ToList()
                          .ForEach(x => x.Subgroup = cb_rect_cl_mass.Text + newsubcl);

                    (from p in dbfet.timeTables
                     where p.gresa_tt_fet == Tools.Globals.GRESA && p.StudentsSets == oldsubcl
                     select p).ToList()
                          .ForEach(x => x.StudentsSets = cb_rect_cl_mass.Text + newsubcl);

                    dbfet.SubmitChanges();


                var tf = (from s in dbfet.elevesses
                          where s.gresa_el_fet == Tools.Globals.GRESA && s.groups == cb_rect_cl_frt.Text
                          select s.Subgroup).Distinct().ToList();

                var bindingSource1 = new BindingSource();
                bindingSource1.DataSource = tf;
                cb_rect_subcl_frt.DataSource = bindingSource1.DataSource;
                cb_rect_subcl_frt.DisplayMember = "Subgroup";
                cb_rect_subcl_frt.ValueMember = "Subgroup";

                
                cb_rect_subcl_frt.Text = cb_rect_cl_mass.Text + cb_rect_subcl_mass.Text;



                MessageBox.Show("تم التغيير بنجاح");
               
            }
            else { MessageBox.Show("هذا الفسم الفرعي متطابق"); }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_rect_reset_Click(object sender, EventArgs e)
        {
            //frm_Tt_D tt = new frm_Tt_D();
            //tt.ShowDialog();
            //this.Close();
        }

        private void btn_rect_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_rect_add_prof_Click(object sender, EventArgs e)
        {
            try
            {

          
            EmployeeDataContext dbEsise = new EmployeeDataContext();
                fetDataContext dbfet = new fetDataContext();

                string oldProf = cb_rect_prof_fet.Text;
                string newProf = cb_rect_prof_esise.Text;

                if(dbfet.techers.Where(w=>w.Teacher==newProf).FirstOrDefault() == null)
                {
                    (from p in dbfet.timeTables
                     where p.gresa_tt_fet == Tools.Globals.GRESA && p.Teachers == oldProf
                     select p).ToList()
                     .ForEach(x => x.Teachers = newProf);


                    techer tech = (from t in dbfet.techers where t.Teacher == oldProf select t).FirstOrDefault();
                    tech.Teacher = newProf;
                    tech.ppr = int.Parse(cb_rect_prof_esise.GetItemText(cb_rect_prof_esise.SelectedValue));


                    //var tech_temp = (from t in dbfet.techers
                    //                 where t.gresa_tech_fet == Tools.Globals.GRESA & t.Teacher == oldProf
                    //                 select t).ToList();

                    //foreach (var item in tech_temp)
                    //{
                    //    item.Teacher = newProf;
                    //    item.ppr = int.Parse(cb_rect_prof_esise.GetItemText(cb_rect_prof_esise.SelectedValue));
                    //}


                    dbfet.SubmitChanges();

                    // cb_rect_niv_fet.Items.Clear();

                    var tf = (from s in dbfet.timeTables
                              where s.gresa_tt_fet == Tools.Globals.GRESA
                              select s.Teachers).Distinct().ToList();
                    cb_rect_prof_fet.DataSource = tf;
                    cb_rect_prof_fet.DisplayMember = "Teachers";


                    //foreach (var item in tf)
                    //{

                    //    cb_rect_prof_fet.Items.Add(item);
                    //}
                    cb_rect_prof_fet.SelectedItem = cb_rect_prof_esise.Text;



                    MessageBox.Show("تم التغيير بنجاح");
                    //lblCounter++;
                    //lbl_rect_counter.Text = lblText + " " + lblCounter;
                }else
                {

                    MessageBox.Show(" الموظف "+" "+newProf+" "+ "لا يحتاج ‘لى مطابقة");
                }

           

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

      
    }
}

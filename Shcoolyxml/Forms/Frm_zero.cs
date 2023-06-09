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
    public partial class Frm_zero : Form
    {
        public Frm_zero()
        {
            InitializeComponent();
        }

        private void Frm_zero_Load(object sender, EventArgs e)
        {
            EtablissementDataContext edc = new EtablissementDataContext();
            StudentsListDataContext stdc = new StudentsListDataContext();
            EmployeeDataContext emdc = new EmployeeDataContext();
            var etabinf = edc.InfoEtabs.Where(i => i.gresa_info == Tools.Globals.GRESA).Select(inf => new
            {
                ac = inf.academieAr_info,
                dir = inf.directionAr_info,
                com=inf.comuneAr_info,
                et = inf.etabNameAr_info,
                gre = inf.gresa_info
            }).FirstOrDefault();

            lbl_etab_ac_dir.Text = etabinf?.ac + "  "+etabinf?.com+"  " + etabinf?.dir;
            lbl_etab_et_gr.Text = etabinf?.et +"  "+ "(" + etabinf?.gre + ")";

            
            var emp = (from a in emdc.Emp_Acts where a.CD_ETAB == Tools.Globals.GRESA
                       join d in emdc.Emp_Datas on a.ppr_act equals d.ppr_dat
                       join f in emdc.fonctions on a.CD_FONC equals f.CD_Fonc
                       join c in emdc.cadres on d.CD_CADRE equals c.CD_CADRE
                       
                       select new
                       {
                           d,a,f,c
                       }
                       );

            int nb_em = emp.Count();
            int nb_tech = emp.Where(w => w.f.LL_FONC.StartsWith("Enseig")).Count();
            int nb_tech_f = emp.Where(w => w.f.LL_FONC.StartsWith("Enseig") && w.d.GENRE=="F").Count();
            int nb_tech_m = emp.Where(w => w.f.LL_FONC.StartsWith("Enseig") && w.d.GENRE == "M ").Count();
            int nb_admin = emp.Where(w => w.f.LL_FONC.StartsWith("Direct")).Count() + emp.Where(w => w.f.LL_FONC.StartsWith("Secret")).Count() + emp.Where(w => w.f.LL_FONC.StartsWith("Survei")).Count() + emp.Where(w => w.f.LL_FONC.StartsWith("Agent")).Count() + emp.Where(w => w.f.LL_FONC.StartsWith("Adjoin")).Count()+ emp.Where(w => w.f.LL_FONC.StartsWith("Cense")).Count()+ emp.Where(w => w.f.LL_FONC.StartsWith("Comtab")).Count();
            int nb_autre = nb_em - (nb_tech + nb_admin);
            int nb_minst = emp.Where(w => w.d.CD_STATUT == "1").Count();
            int nb_cadr_ac = emp.Where(w => w.d.CD_STATUT == "9").Count();
            int nb_auxi = emp.Where(w => w.c.LL_CADRE.Contains("Adjoint") | w.c.LL_CADRE.Contains("Agents")).Count();
            //**********

            var stud = (from st in stdc.StudentListUpdates where st.gresa_Up==Tools.Globals.GRESA select st);
            int nb_st = stud.Count();
            int nb_st_m = stud.Where(w => w.genre_Up == "ذكر").Count();
            int nb_st_F = stud.Where(w => w.genre_Up == "أنثى").Count();
            int nb_niv = stud.Select(s => s.niveau_Up).Distinct().Count();
            int nb_cl = stud.Select(s => s.classe_Up).Distinct().Count();
            int nb_part = stdc.Transactions.Where(t => t.gresa_trans==Tools.Globals.GRESA && t.part_entr_trans_ == -1).Count();
            int nb_entr = stdc.Transactions.Where(t => t.gresa_trans == Tools.Globals.GRESA && t.part_entr_trans_ == 1).Count();

            //******************
            lbl_0_nb_empl.Text = nb_em.ToString();
            lbl_0_nb_techers.Text = nb_tech.ToString();
            lbl_0_nb_tech_m.Text = nb_tech_m.ToString();
            lbl_0_nb_tech_f.Text = nb_tech_f.ToString();
            lbl_0_nb_admin.Text = nb_admin.ToString();
            lbl_0_nb_ministr.Text = nb_minst.ToString();
            lbl_0_nb_acade.Text = nb_cadr_ac.ToString();
            lbl_0_nb_auxi.Text = nb_auxi.ToString();

            lbl_0_nb_st.Text = nb_st.ToString();
            lbl_0_nb_st_m.Text = nb_st_m.ToString();
            lbl_0_nb_st_f.Text = nb_st_F.ToString();
            lbl_0_nb_niv.Text = nb_niv.ToString();
            lbl_0_nb_cl.Text = nb_cl.ToString();
            lbl_0_nb_st_partants.Text = nb_part.ToString();
            lbl_0_nb_entrants.Text = nb_entr.ToString();
            lbl_0_nb_cycle.Text = edc.pathclasses.Where(w => w.greasa_path == Tools.Globals.GRESA).Select(s => s.cycle_path).Distinct().Count().ToString();


        }

       

      
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Schooly.Pages
{
    public partial class Frm_Emp_Fiche : Form
    {
        public Frm_Emp_Fiche()
        {
            InitializeComponent();
        }


        private void tabControl_emp_DrawItem(object sender, DrawItemEventArgs e)
        {

            try
            {
                // Draw the background of the control for each item.
                // e.DrawBackground();

                if (e.Index == this.tabControl_emp.SelectedIndex)
                {
                    Brush _BackBrush = new SolidBrush(tabControl_emp.TabPages[e.Index].BackColor);


                   System.Drawing.Rectangle rect = e.Bounds;
                    e.Graphics.FillRectangle(_BackBrush, (rect.X) + 4, rect.Y, (rect.Width) - 4, rect.Height);

                    SizeF sz = e.Graphics.MeasureString(tabControl_emp.TabPages[e.Index].Text, e.Font);
                    if (e.Index == 0)
                    {
                        e.Graphics.DrawString(tabControl_emp.TabPages[e.Index].Text, e.Font, Brushes.Green,
                                                      e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2,
                                                      e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);
                    }
                    if (e.Index == 1)
                    {
                        e.Graphics.DrawString(tabControl_emp.TabPages[e.Index].Text, e.Font, Brushes.Red,
                                                      e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2,
                                                      e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);
                    }
                    if (e.Index == 2)
                    {
                        e.Graphics.DrawString(tabControl_emp.TabPages[e.Index].Text, e.Font, Brushes.Blue,
                              e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2,
                              e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);
                    }
                    if (e.Index == 3)
                    {
                        e.Graphics.DrawString(tabControl_emp.TabPages[e.Index].Text, e.Font, Brushes.Maroon,
                              e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2,
                              e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);
                    }


                }
                else
                {
                    Brush _BackBrush = new SolidBrush(Color.FromArgb(50, tabControl_emp.TabPages[e.Index].BackColor));

                   System.Drawing.Rectangle rect = e.Bounds;
                    e.Graphics.FillRectangle(_BackBrush, rect.X, (rect.Y) - 0, rect.Width, (rect.Height) + 6);

                    SizeF sz = e.Graphics.MeasureString(tabControl_emp.TabPages[e.Index].Text, e.Font);
                    e.Graphics.DrawString(tabControl_emp.TabPages[e.Index].Text, e.Font, Brushes.Black,
                    e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2,
                              e.Bounds.Top + 5);

                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        string gresa = Tools.Globals.GRESA;

        private void Frm_Emp_Fiche_Load(object sender, EventArgs e)
        {
           
            this.tabControl_emp.DrawMode = TabDrawMode.OwnerDrawFixed;

            EmployeeDataContext edc = new EmployeeDataContext();


            var checkdata = edc.sitfams.Select(x => x);
         
            if (checkdata==null)
            {
                try
                {
                    //string currentApplicationpath = Application.UserAppDataPath;

                    //string mypath = Path.GetFullPath(currentApplicationpath + "\\" + "\\Models");
                    //// MessageBox.Show(mypath);
                    //Tools.Tools_XML xml = new Tools.Tools_XML();
                    //xml.GetEmployeesData(mypath + "\\XML_emp.xml");
                }
                catch (Exception)
                {

                   
                }
               
            }
               fillcombo_emp_select();

        }
        private void fillcombo_emp_select()
        {

           
            EmployeeDataContext edc = new EmployeeDataContext();
            var employees = (from emD in edc.Emp_Datas
                             join emA in edc.Emp_Acts on emD.ppr_dat equals emA.ppr_act
                             where emA.CD_ETAB.Equals(gresa)
                             select new
                             {
                                 ppr = emD.ppr_dat,
                                 nom = emD.NOMA + " " + emD.PRENOMA
                             }).ToList();
            cb_emp_select_emp.DataSource = new BindingSource(employees, null);
            cb_emp_select_emp.DisplayMember = "nom";
            cb_emp_select_emp.ValueMember = "ppr";

            rb_em_data_FR.Checked = true;
            if (cb_emp_select_emp.Items.Count > 0)
                cb_emp_select_emp.SelectedIndex = 0;
            FillCombosFR();
            FillControls_Emp_LL();
        }

        private void FillCombosFR()
        {
            EmployeeDataContext edc = new EmployeeDataContext();

            //*******fil sitfam
            var sitfams = (from sit in edc.sitfams
                           join emD in edc.Emp_Datas on sit.Sit_Fam equals emD.SIT_FAM
                           select new
                           {
                               cd = sit.Sit_Fam,
                               ll = sit.LL_SitFam,
                           }).Distinct().ToList();


            cb_emp_sitfam.DataSource = new BindingSource(sitfams, null);
            cb_emp_sitfam.DisplayMember = "ll";
            cb_emp_sitfam.ValueMember = "cd";

            //************* fil nation
            var nations = (from nat in edc.nations
                           join emD in edc.Emp_Datas on nat.CD_NATION equals emD.CD_NATION
                           select new
                           {
                               cd = nat.CD_NATION,
                               ll = nat.LL_NATION,
                           }).Distinct().ToList();


            cb_emp_nat.DataSource = new BindingSource(nations, null);
            cb_emp_nat.DisplayMember = "ll";
            cb_emp_nat.ValueMember = "cd";

            //***************fil cadre 
            var cadres = (from cad in edc.cadres
                          join emD in edc.Emp_Datas on cad.CD_CADRE equals emD.CD_CADRE
                          select new
                          {
                              cd = cad.CD_CADRE,
                              ll = cad.LL_CADRE,
                          }).Distinct().ToList();


            cb_emp_cadre.DataSource = new BindingSource(cadres, null);
            cb_emp_cadre.DisplayMember = "ll";
            cb_emp_cadre.ValueMember = "cd";

            //*********** fil grade
            var grades = (from gra in edc.grades
                          join emd in edc.Emp_Datas on gra.CD_GRADE equals emd.CD_GRADE
                          select new
                          {
                              cd = gra.CD_GRADE,
                              ll = gra.LL_GRADE,
                          }).Distinct().ToList();


            cb_emp_grad.DataSource = new BindingSource(grades, null);
            cb_emp_grad.DisplayMember = "ll";
            cb_emp_grad.ValueMember = "cd";


            //*********** fil mode accsess au grade
            var modAcssesgrade = (from mag in edc.mode_accsses_grads
                                  join emD in edc.Emp_Datas on mag.MODAVGRA equals emD.MODAVGRA
                                  select new
                                  {
                                      cd = mag.MODAVGRA,
                                      ll = mag.LL_DESLMODAV,
                                  }).Distinct().ToList();


            cb_emp_acces_grad.DataSource = new BindingSource(modAcssesgrade, null);
            cb_emp_acces_grad.DisplayMember = "ll";
            cb_emp_acces_grad.ValueMember = "cd";

            //************ stuation statituaire
            var sitStatuts = (from stat in edc.sit_statuts
                              join emd in edc.Emp_Datas on stat.CD_Statut equals emd.CD_STATUT
                              select new
                              {
                                  cd = stat.CD_Statut,
                                  ll = stat.LL_STATUT,
                              }).Distinct().ToList();


            cb_emp_sit_statut.DataSource = new BindingSource(sitStatuts, null);
            cb_emp_sit_statut.DisplayMember = "ll";
            cb_emp_sit_statut.ValueMember = "cd";

            //********** code posistion

            var positions = (from pos in edc.positions
                             join emD in edc.Emp_Datas on pos.CD_Position equals emD.CD_POSITION
                             select new
                             {
                                 cd = pos.CD_Position,
                                 ll = pos.LL_POSITION,
                             }).Distinct().ToList();


            cb_emp_pos.DataSource = new BindingSource(positions, null);
            cb_emp_pos.DisplayMember = "ll";
            cb_emp_pos.ValueMember = "cd";

            //*********** fonction
            var fonctions = (from fon in edc.fonctions
                             join emA in edc.Emp_Acts on fon.CD_Fonc equals emA.CD_FONC
                             select new
                             {
                                 cd = fon.CD_Fonc,
                                 ll = fon.LL_FONC,
                             }).Distinct().ToList();


            cb_emp_fonct.DataSource = new BindingSource(fonctions, null);
            cb_emp_fonct.DisplayMember = "ll";
            cb_emp_fonct.ValueMember = "cd";

            //********** cycle d origine
            var cycles = (from cy in edc.cycles
                          join emA in edc.Emp_Acts on cy.CD_CYCLE equals emA.CD_CYCLE
                          select new
                          {
                              cd = cy.CD_CYCLE,
                              ll = cy.LL_CYCLE,
                          }).Distinct().ToList();


            cb_emp_cycle.DataSource = new BindingSource(cycles, null);
            cb_emp_cycle.DisplayMember = "ll";
            cb_emp_cycle.ValueMember = "cd";

            //************ dips scol
            var diplomscol = (from dips in edc.dipscols
                              join emD in edc.Emp_Datas on dips.CD_DIPS equals emD.CD_DIPS
                              select new
                              {
                                  cd = dips.CD_DIPS,
                                  ll = dips.LL_DIPS,
                              }).Distinct().ToList();


            cb_emp_dip_scol.DataSource = new BindingSource(diplomscol, null);
            cb_emp_dip_scol.DisplayMember = "ll";
            cb_emp_dip_scol.ValueMember = "cd";
            //************* dips prof
            var diplomprof = (from diipp in edc.dippros
                              join emD in edc.Emp_Datas on diipp.CD_DIPP equals emD.CD_DIPP
                              select new
                              {
                                  cd = diipp.CD_DIPP,
                                  ll = diipp.LL_DIPP,
                              }).Distinct().ToList();


            cb_emp_dip_prof.DataSource = new BindingSource(diplomprof, null);
            cb_emp_dip_prof.DisplayMember = "ll";
            cb_emp_dip_prof.ValueMember = "cd";
            //**************** fill specialit dips prof
            var spesilalitDiplomPro = (from disc in edc.disciplines
                                       join emD in edc.Emp_Datas on disc.CD_Discip equals emD.CD_DISCIP
                                       select new
                                       {
                                           cd = disc.CD_Discip,
                                           ll = disc.LL_DISCIP,
                                       }).Distinct().ToList();


            cb_emp_spec_diplo.DataSource = new BindingSource(spesilalitDiplomPro, null);
            cb_emp_spec_diplo.DisplayMember = "ll";
            cb_emp_spec_diplo.ValueMember = "cd";
            //****************** fill centre formation
            var centres = (from cen in edc.Emp_Datas

                           select new
                           {
                               ll = cen.VILLEFORM
                           }).Distinct().ToList();


            cb_emp_centrFormation.DataSource = new BindingSource(centres, null);
            cb_emp_centrFormation.DisplayMember = "ll";
            // cb_emp_centrFormation.ValueMember = "cd";

           // FillControls_Emp_LL();
        }
        private void FillCombosFR_Add_Upd()
        {
            EmployeeDataContext edc = new EmployeeDataContext();

            //*******fil sitfam
            var sitfams = (from sit in edc.sitfams
                           select new
                           {
                               cd = sit.Sit_Fam,
                               ll = sit.LL_SitFam,
                           }).Distinct().ToList();


            cb_emp_sitfam.DataSource = new BindingSource(sitfams, null);
            cb_emp_sitfam.DisplayMember = "ll";
            cb_emp_sitfam.ValueMember = "cd";

            //************* fil nation
            var nations = (from nat in edc.nations
                           select new
                           {
                               cd = nat.CD_NATION,
                               ll = nat.LL_NATION,
                           }).Distinct().ToList();


            cb_emp_nat.DataSource = new BindingSource(nations, null);
            cb_emp_nat.DisplayMember = "ll";
            cb_emp_nat.ValueMember = "cd";

            //***************fil cadre 
            var cadres = (from cad in edc.cadres
                          select new
                          {
                              cd = cad.CD_CADRE,
                              ll = cad.LL_CADRE,
                          }).Distinct().ToList();


            cb_emp_cadre.DataSource = new BindingSource(cadres, null);
            cb_emp_cadre.DisplayMember = "ll";
            cb_emp_cadre.ValueMember = "cd";

            //*********** fil grade
            var grades = (from gra in edc.grades
                          select new
                          {
                              cd = gra.CD_GRADE,
                              ll = gra.LL_GRADE,
                          }).Distinct().ToList();


            cb_emp_grad.DataSource = new BindingSource(grades, null);
            cb_emp_grad.DisplayMember = "ll";
            cb_emp_grad.ValueMember = "cd";


            //*********** fil mode accsess au grade
            var modAcssesgrade = (from mag in edc.mode_accsses_grads
                                  select new
                                  {
                                      cd = mag.MODAVGRA,
                                      ll = mag.LL_DESLMODAV,
                                  }).Distinct().ToList();


            cb_emp_acces_grad.DataSource = new BindingSource(modAcssesgrade, null);
            cb_emp_acces_grad.DisplayMember = "ll";
            cb_emp_acces_grad.ValueMember = "cd";

            //************ stuation statituaire
            var sitStatuts = (from stat in edc.sit_statuts
                              select new
                              {
                                  cd = stat.CD_Statut,
                                  ll = stat.LL_STATUT,
                              }).Distinct().ToList();


            cb_emp_sit_statut.DataSource = new BindingSource(sitStatuts, null);
            cb_emp_sit_statut.DisplayMember = "ll";
            cb_emp_sit_statut.ValueMember = "cd";

            //********** code posistion

            var positions = (from pos in edc.positions
                             select new
                             {
                                 cd = pos.CD_Position,
                                 ll = pos.LL_POSITION,
                             }).Distinct().ToList();


            cb_emp_pos.DataSource = new BindingSource(positions, null);
            cb_emp_pos.DisplayMember = "ll";
            cb_emp_pos.ValueMember = "cd";

            //*********** fonction
            var fonctions = (from fon in edc.fonctions
                             select new
                             {
                                 cd = fon.CD_Fonc,
                                 ll = fon.LL_FONC,
                             }).Distinct().ToList();


            cb_emp_fonct.DataSource = new BindingSource(fonctions, null);
            cb_emp_fonct.DisplayMember = "ll";
            cb_emp_fonct.ValueMember = "cd";

            //********** cycle d origine
            var cycles = (from cy in edc.cycles
                          select new
                          {
                              cd = cy.CD_CYCLE,
                              ll = cy.LL_CYCLE,
                          }).Distinct().ToList();


            cb_emp_cycle.DataSource = new BindingSource(cycles, null);
            cb_emp_cycle.DisplayMember = "ll";
            cb_emp_cycle.ValueMember = "cd";

            //************ dips scol
            var diplomscol = (from dips in edc.dipscols
                              select new
                              {
                                  cd = dips.CD_DIPS,
                                  ll = dips.LL_DIPS,
                              }).Distinct().ToList();


            cb_emp_dip_scol.DataSource = new BindingSource(diplomscol, null);
            cb_emp_dip_scol.DisplayMember = "ll";
            cb_emp_dip_scol.ValueMember = "cd";
            //************* dips prof
            var diplomprof = (from diipp in edc.dippros
                              select new
                              {
                                  cd = diipp.CD_DIPP,
                                  ll = diipp.LL_DIPP,
                              }).Distinct().ToList();


            cb_emp_dip_prof.DataSource = new BindingSource(diplomprof, null);
            cb_emp_dip_prof.DisplayMember = "ll";
            cb_emp_dip_prof.ValueMember = "cd";
            //**************** fill specialit dips prof
            var spesilalitDiplomPro = (from disc in edc.disciplines
                                       select new
                                       {
                                           cd = disc.CD_Discip,
                                           ll = disc.LL_DISCIP,
                                       }).Distinct().ToList();


            cb_emp_spec_diplo.DataSource = new BindingSource(spesilalitDiplomPro, null);
            cb_emp_spec_diplo.DisplayMember = "ll";
            cb_emp_spec_diplo.ValueMember = "cd";
            //****************** fill centre formation
            var centres = (from cen in edc.centre_formations
                           select new
                           {
                               ll = cen.NOM_ETABL
                           }).Distinct().ToList();


            cb_emp_centrFormation.DataSource = new BindingSource(centres, null);
            cb_emp_centrFormation.DisplayMember = "ll";
           
        }

        private void FillCombosAr_Add_Update()
        {
            EmployeeDataContext edc = new EmployeeDataContext();

            //*******fil sitfam
            var sitfams = (from sit in edc.sitfams
                           select new
                           {
                               cd = sit.Sit_Fam.ToString(),
                               lA = sit.LA_SitFam,
                           }).Distinct().ToList();


            cb_emp_sitfam.DataSource = new BindingSource(sitfams, null);
            cb_emp_sitfam.DisplayMember = "lA";
            cb_emp_sitfam.ValueMember = "cd";

            //************* fil nation
            var nations = (from nat in edc.nations
                           select new
                           {
                               cd = nat.CD_NATION,
                               lA = nat.LA_NATION,
                           }).Distinct().ToList();


            cb_emp_nat.DataSource = new BindingSource(sitfams, null);
            cb_emp_nat.DisplayMember = "lA";
            cb_emp_nat.ValueMember = "cd";

            //***************fil cadre 
            var cadres = (from cad in edc.cadres
                          select new
                          {
                              cd = cad.CD_CADRE,
                              lA = cad.LA_CADRE,
                          }).Distinct().ToList();


            cb_emp_cadre.DataSource = new BindingSource(cadres, null);
            cb_emp_cadre.DisplayMember = "lA";
            cb_emp_cadre.ValueMember = "cd";


            //*********** fil grade
            var grades = (from gra in edc.grades
                          select new
                          {
                              cd = gra.CD_GRADE,
                              lA = gra.LA_GRADE,
                          }).Distinct().ToList();


            cb_emp_grad.DataSource = new BindingSource(grades, null);
            cb_emp_grad.DisplayMember = "lA";
            cb_emp_grad.ValueMember = "cd";


            //*********** fil mode accsess au grade
            var modAcssesgrade = (from mag in edc.mode_accsses_grads
                                  select new
                                  {
                                      cd = mag.MODAVGRA,
                                      lL = mag.LA_DESLMODAV,
                                  }).Distinct().ToList();


            cb_emp_acces_grad.DataSource = new BindingSource(modAcssesgrade, null);
            cb_emp_acces_grad.DisplayMember = "lA";
            cb_emp_acces_grad.ValueMember = "cd";

            //************ stuation statituaire
            var sitStatuts = (from stat in edc.sit_statuts
                              select new
                              {
                                  cd = stat.CD_Statut,
                                  lA = stat.LA_STATUT,
                              }).Distinct().ToList();


            cb_emp_sit_statut.DataSource = new BindingSource(sitStatuts, null);
            cb_emp_sit_statut.DisplayMember = "lA";
            cb_emp_sit_statut.ValueMember = "cd";

            //********** code posistion

            var positions = (from pos in edc.positions
                             select new
                             {
                                 cd = pos.CD_Position,
                                 lA = pos.LA_POSITION,
                             }).Distinct().ToList();


            cb_emp_pos.DataSource = new BindingSource(positions, null);
            cb_emp_pos.DisplayMember = "lA";
            cb_emp_pos.ValueMember = "cd";

            //*********** fonction
            var fonctions = (from fon in edc.fonctions
                             select new
                             {
                                 cd = fon.CD_Fonc,
                                 lA = fon.LA_Fonc,
                             }).Distinct().ToList();


            cb_emp_fonct.DataSource = new BindingSource(fonctions, null);
            cb_emp_fonct.DisplayMember = "lA";
            cb_emp_fonct.ValueMember = "cd";

            //********** cycle d origine
            var cycles = (from cy in edc.cycles
                          select new
                          {
                              cd = cy.CD_CYCLE,
                              lA = cy.LA_CYCLE,
                          }).Distinct().ToList();


            cb_emp_cycle.DataSource = new BindingSource(cycles, null);
            cb_emp_cycle.DisplayMember = "lA";
            cb_emp_cycle.ValueMember = "cd";

            //************ dips scol
            var diplomscol = (from dips in edc.dipscols
                              select new
                              {
                                  cd = dips.CD_DIPS,
                                  lA = dips.LA_DIPS,
                              }).Distinct().ToList();


            cb_emp_dip_scol.DataSource = new BindingSource(diplomscol, null);
            cb_emp_dip_scol.DisplayMember = "lA";
            cb_emp_dip_scol.ValueMember = "cd";
            //************* dips prof
            var diplomprof = (from diipp in edc.dippros
                              select new
                              {
                                  cd = diipp.CD_DIPP,
                                  lA = diipp.LA_DIPP,
                              }).Distinct().ToList();


            cb_emp_dip_prof.DataSource = new BindingSource(diplomprof, null);
            cb_emp_dip_prof.DisplayMember = "lA";
            cb_emp_dip_prof.ValueMember = "cd";
            //**************** fill specialit dips prof
            var spesilalitDiplomPro = (from disc in edc.disciplines
                                       select new
                                       {
                                           cd = disc.CD_Discip,
                                           lA = disc.LA_DISCIP,
                                       }).Distinct().ToList();


            cb_emp_spec_diplo.DataSource = new BindingSource(spesilalitDiplomPro, null);
            cb_emp_spec_diplo.DisplayMember = "lA";
            cb_emp_spec_diplo.ValueMember = "cd";
            //****************** fill centre formation
            var centres = (from cen in edc.centre_formations

                           select new
                           {
                               lA = cen.NOM_ETABL
                           }).Distinct().ToList();


            cb_emp_centrFormation.DataSource = new BindingSource(centres, null);
            cb_emp_centrFormation.DisplayMember = "lA";
         
        }

        private void FillCombosAr()
        {
            EmployeeDataContext edc = new EmployeeDataContext();

            //*******fil sitfam
            var sitfams = (from sit in edc.sitfams
                           join emD in edc.Emp_Datas on sit.Sit_Fam.Trim() equals emD.SIT_FAM.Trim()
                           select new
                           {
                               cd = sit.Sit_Fam.ToString(),
                               lA = sit.LA_SitFam,
                           }).Distinct().ToList();


            cb_emp_sitfam.DataSource = new BindingSource(sitfams, null);
            cb_emp_sitfam.DisplayMember = "lA";
            cb_emp_sitfam.ValueMember = "cd";

            //************* fil nation
            var nations = (from nat in edc.nations
                           join emD in edc.Emp_Datas on nat.CD_NATION.Trim() equals emD.CD_NATION.Trim()
                           select new
                           {
                               cd = nat.CD_NATION,
                               lA = nat.LA_NATION,
                           }).Distinct().ToList();


            cb_emp_nat.DataSource = new BindingSource(sitfams, null);
            cb_emp_nat.DisplayMember = "lA";
            cb_emp_nat.ValueMember = "cd";

            //***************fil cadre 
            var cadres = (from cad in edc.cadres
                          join emD in edc.Emp_Datas on cad.CD_CADRE equals emD.CD_CADRE
                          select new
                          {
                              cd = cad.CD_CADRE,
                              lA = cad.LA_CADRE,
                          }).Distinct().ToList();


            cb_emp_cadre.DataSource = new BindingSource(cadres, null);
            cb_emp_cadre.DisplayMember = "lA";
            cb_emp_cadre.ValueMember = "cd";


            //*********** fil grade
            var grades = (from gra in edc.grades
                          join emd in edc.Emp_Datas on gra.CD_GRADE equals emd.CD_GRADE
                          select new
                          {
                              cd = gra.CD_GRADE,
                              lA = gra.LA_GRADE,
                          }).Distinct().ToList();


            cb_emp_grad.DataSource = new BindingSource(grades, null);
            cb_emp_grad.DisplayMember = "lA";
            cb_emp_grad.ValueMember = "cd";


            //*********** fil mode accsess au grade
            var modAcssesgrade = (from mag in edc.mode_accsses_grads
                                  join emD in edc.Emp_Datas on mag.MODAVGRA equals emD.MODAVGRA
                                  select new
                                  {
                                      cd = mag.MODAVGRA,
                                      lL = mag.LA_DESLMODAV,
                                  }).Distinct().ToList();


            cb_emp_acces_grad.DataSource = new BindingSource(modAcssesgrade, null);
            cb_emp_acces_grad.DisplayMember = "lA";
            cb_emp_acces_grad.ValueMember = "cd";

            //************ stuation statituaire
            var sitStatuts = (from stat in edc.sit_statuts
                              join emd in edc.Emp_Datas on stat.CD_Statut equals emd.CD_STATUT
                              select new
                              {
                                  cd = stat.CD_Statut,
                                  lA = stat.LA_STATUT,
                              }).Distinct().ToList();


            cb_emp_sit_statut.DataSource = new BindingSource(sitStatuts, null);
            cb_emp_sit_statut.DisplayMember = "lA";
            cb_emp_sit_statut.ValueMember = "cd";

            //********** code posistion

            var positions = (from pos in edc.positions
                             join emD in edc.Emp_Datas on pos.CD_Position equals emD.CD_POSITION
                             select new
                             {
                                 cd = pos.CD_Position,
                                 lA = pos.LA_POSITION,
                             }).Distinct().ToList();


            cb_emp_pos.DataSource = new BindingSource(positions, null);
            cb_emp_pos.DisplayMember = "lA";
            cb_emp_pos.ValueMember = "cd";

            //*********** fonction
            var fonctions = (from fon in edc.fonctions
                             join emA in edc.Emp_Acts on fon.CD_Fonc equals emA.CD_FONC
                             select new
                             {
                                 cd = fon.CD_Fonc,
                                 lA = fon.LA_Fonc,
                             }).Distinct().ToList();


            cb_emp_fonct.DataSource = new BindingSource(fonctions, null);
            cb_emp_fonct.DisplayMember = "lA";
            cb_emp_fonct.ValueMember = "cd";

            //********** cycle d origine
            var cycles = (from cy in edc.cycles
                          join emA in edc.Emp_Acts on cy.CD_CYCLE equals emA.CD_CYCLE
                          select new
                          {
                              cd = cy.CD_CYCLE,
                              lA = cy.LA_CYCLE,
                          }).Distinct().ToList();


            cb_emp_cycle.DataSource = new BindingSource(cycles, null);
            cb_emp_cycle.DisplayMember = "lA";
            cb_emp_cycle.ValueMember = "cd";

            //************ dips scol
            var diplomscol = (from dips in edc.dipscols
                              join emD in edc.Emp_Datas on dips.CD_DIPS equals emD.CD_DIPS
                              select new
                              {
                                  cd = dips.CD_DIPS,
                                  lA = dips.LA_DIPS,
                              }).Distinct().ToList();


            cb_emp_dip_scol.DataSource = new BindingSource(diplomscol, null);
            cb_emp_dip_scol.DisplayMember = "lA";
            cb_emp_dip_scol.ValueMember = "cd";
            //************* dips prof
            var diplomprof = (from diipp in edc.dippros
                              join emD in edc.Emp_Datas on diipp.CD_DIPP equals emD.CD_DIPP
                              select new
                              {
                                  cd = diipp.CD_DIPP,
                                  lA = diipp.LA_DIPP,
                              }).Distinct().ToList();


            cb_emp_dip_prof.DataSource = new BindingSource(diplomprof, null);
            cb_emp_dip_prof.DisplayMember = "lA";
            cb_emp_dip_prof.ValueMember = "cd";
            //**************** fill specialit dips prof
            var spesilalitDiplomPro = (from disc in edc.disciplines
                                       join emD in edc.Emp_Datas on disc.CD_Discip equals emD.CD_DISCIP
                                       select new
                                       {
                                           cd = disc.CD_Discip,
                                           lA = disc.LA_DISCIP,
                                       }).Distinct().ToList();


            cb_emp_spec_diplo.DataSource = new BindingSource(spesilalitDiplomPro, null);
            cb_emp_spec_diplo.DisplayMember = "lA";
            cb_emp_spec_diplo.ValueMember = "cd";
            //****************** fill centre formation
            var centres = (from cen in edc.Emp_Datas

                           select new
                           {
                               lA = cen.VILLEFORM
                           }).Distinct().ToList();


            cb_emp_centrFormation.DataSource = new BindingSource(centres, null);
            cb_emp_centrFormation.DisplayMember = "lA";
            //  cb_emp_centrFormation.ValueMember = "cd";

            //FillControls_Emp_LA();
           // FillControls_Emp_LL();
        }

        private void FillCombosTradFR()
        {
            EmployeeDataContext edc = new EmployeeDataContext();

            // *******fil sitfam
            var sitfams = (from sit in edc.sitfams
                           join emD in edc.Emp_Datas on sit.Sit_Fam equals emD.SIT_FAM
                           select new
                           {
                               cd = sit.Sit_Fam,
                               ll = sit.LL_SitFam,
                           }).Distinct().ToList();


            cb_em_tra_sitfam.DataSource = new BindingSource(sitfams, null);
            cb_em_tra_sitfam.DisplayMember = "ll";
            cb_em_tra_sitfam.ValueMember = "cd";

            //***************fil cadre 
            var cadres = (from cad in edc.cadres
                          join emD in edc.Emp_Datas on cad.CD_CADRE equals emD.CD_CADRE
                          select new
                          {
                              cd = cad.CD_CADRE,
                              ll = cad.LL_CADRE,
                          }).Distinct().ToList();


            cb_em_tra_cadre.DataSource = new BindingSource(cadres, null);
            cb_em_tra_cadre.DisplayMember = "ll";
            cb_em_tra_cadre.ValueMember = "cd";

            //*********** fil grade
            var grades = (from gra in edc.grades
                          join emD in edc.Emp_Datas on gra.CD_GRADE equals emD.CD_GRADE
                          select new
                          {
                              cd = gra.CD_GRADE,
                              ll = gra.LL_GRADE,
                          }).Distinct().ToList();


            cb_em_tra_grad.DataSource = new BindingSource(grades, null);
            cb_em_tra_grad.DisplayMember = "ll";
            cb_em_tra_grad.ValueMember = "cd";


            //*********** fil mode accsess au grade
            var modAcssesgrade = (from mag in edc.mode_accsses_grads
                                  join emD in edc.Emp_Datas on mag.MODAVGRA equals emD.MODAVGRA
                                  select new
                                  {
                                      cd = mag.MODAVGRA,
                                      ll = mag.LL_DESLMODAV,
                                  }).Distinct().ToList();


            cb_em_tra_modAcces.DataSource = new BindingSource(modAcssesgrade, null);
            cb_em_tra_modAcces.DisplayMember = "ll";
            cb_em_tra_modAcces.ValueMember = "cd";

            //************ stuation statituaire
            var sitStatuts = (from stat in edc.sit_statuts
                              join emD in edc.Emp_Datas on stat.CD_Statut equals emD.CD_STATUT
                              select new
                              {
                                  cd = stat.CD_Statut,
                                  ll = stat.LL_STATUT,
                              }).Distinct().ToList();


            cb_em_tra_sitStatut.DataSource = new BindingSource(sitStatuts, null);
            cb_em_tra_sitStatut.DisplayMember = "ll";
            cb_em_tra_sitStatut.ValueMember = "cd";

            //********** code posistion

            var positions = (from pos in edc.positions
                             join emD in edc.Emp_Datas on pos.CD_Position equals emD.CD_POSITION
                             select new
                             {
                                 cd = pos.CD_Position,
                                 ll = pos.LL_POSITION,
                             }).Distinct().ToList();


            cb_em_tra_position.DataSource = new BindingSource(positions, null);
            cb_em_tra_position.DisplayMember = "ll";
            cb_em_tra_position.ValueMember = "cd";

            //*********** fonction
            var fonctions = (from fonc in edc.fonctions
                             join emA in edc.Emp_Acts on fonc.CD_Fonc equals emA.CD_FONC
                             select new
                             {
                                 cd = fonc.CD_Fonc,
                                 ll = fonc.LL_FONC,
                             }).Distinct().ToList();


            cb_em_tra_fonction.DataSource = new BindingSource(fonctions, null);
            cb_em_tra_fonction.DisplayMember = "ll";
            cb_em_tra_fonction.ValueMember = "cd";

            //********** cycle d origine
            var cycles = (from cyc in edc.cycles
                          join emA in edc.Emp_Acts on cyc.CD_CYCLE equals emA.CD_CYCLE
                          select new
                          {
                              cd = cyc.CD_CYCLE,
                              ll = cyc.LL_CYCLE,
                          }).Distinct().ToList();


            cb_em_tra_cycle.DataSource = new BindingSource(cycles, null);
            cb_em_tra_cycle.DisplayMember = "ll";
            cb_em_tra_cycle.ValueMember = "cd";

            //************ dips scol
            var diplomscol = (from dips in edc.dipscols
                              join emD in edc.Emp_Datas on dips.CD_DIPS equals emD.CD_DIPS
                              select new
                              {
                                  cd = dips.CD_DIPS,
                                  ll = dips.LL_DIPS,
                              }).Distinct().ToList();


            cb_em_tra_dipdcol.DataSource = new BindingSource(diplomscol, null);
            cb_em_tra_dipdcol.DisplayMember = "ll";
            cb_em_tra_dipdcol.ValueMember = "cd";
            //************* dips prof
            var diplomprof = (from diipp in edc.dippros
                              join emD in edc.Emp_Datas on diipp.CD_DIPP equals emD.CD_DIPP
                              select new
                              {
                                  cd = diipp.CD_DIPP,
                                  ll = diipp.LL_DIPP,
                              }).Distinct().ToList();


            cb_em_tra_dippro.DataSource = new BindingSource(diplomprof, null);
            cb_em_tra_dippro.DisplayMember = "ll";
            cb_em_tra_dippro.ValueMember = "cd";
            //**************** fill specialit dips prof
            var spesilalitDiplomPro = (from spdipps in edc.disciplines
                                       join emD in edc.Emp_Datas on spdipps.CD_Discip equals emD.CD_DISCIP
                                       select new
                                       {
                                           cd = spdipps.CD_Discip,
                                           ll = spdipps.LL_DISCIP,
                                       }).Distinct().ToList();


            cb_em_tra_specialite.DataSource = new BindingSource(spesilalitDiplomPro, null);
            cb_em_tra_specialite.DisplayMember = "ll";
            cb_em_tra_specialite.ValueMember = "cd";
            //****************** fill centre formation
            var centres = (from emD in edc.Emp_Datas
                           select new
                           {
                               ll = emD.VILLEFORM
                           }).Distinct().ToList();


            cb_em_tra_centre.DataSource = new BindingSource(centres, null);
            cb_em_tra_centre.DisplayMember = "ll";
            // cb_em_tra_centre.ValueMember = "cd";
        }

        private void SelectItemCb(ComboBox cb, string value)
        {
            
            if (value != null)
            {
                int index = cb.Items.IndexOf(value);
                cb.SelectedIndex = index;
            }

        }
        private void SelectItemCbValue(ComboBox cb, string value)
        {

           
                cb.SelectedValue = cb.GetItemText(value);
  

        }
        private void FillDatepicker2(DateTimePicker dtp, DateTime? date)
        {
            
            if (date == null)
                    {
                        dtp.Format = DateTimePickerFormat.Custom;
                        dtp.CustomFormat = " ";
                        dtp.Value = DateTime.FromOADate(0);
                    }

                else
                {
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = "dd-MM-yyyy";
                dtp.Value = (DateTime)date;
              
            }
 
        }

        private void LoadDatePickerVide()
        {
            
                foreach (Control ctrl in tabControl_emp.SelectedTab.Controls)
                {
                    if (ctrl is DateTimePicker)
                {
                   ( (DateTimePicker)ctrl).Format = DateTimePickerFormat.Custom;
                     ((DateTimePicker)ctrl).CustomFormat = " ";
                   // ((DateTimePicker)ctrl).Value = DateTime.FromOADate(0);
                }
            }
           


        }


        private void FillControls_Emp_LL()
        {
           
            EmployeeDataContext edc = new EmployeeDataContext();
            Emp_Data employeeData = edc.Emp_Datas.Where(p => p.ppr_dat.Equals(cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedValue))).FirstOrDefault();
            Emp_Act employeeAct = edc.Emp_Acts.Where(p => p.ppr_act.Equals(cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedValue))).FirstOrDefault();
            if (employeeData != null)
            {   
                if (tabControl_emp.SelectedIndex == 0)// tab perso
                {
                    txt_emp_cin.Text =(( employeeData.CINA!="" | employeeData.CINA!= null) ?employeeData.CINA:string.Empty)  + ((employeeData.CINN != "" | employeeData.CINN != null) ? employeeData.CINN : string.Empty);
                    txt_emp_ppr.Text = cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedValue);
                    txt_emp_name_ar.Text = ((employeeData.NOMA != "" | employeeData.NOMA != null) ? employeeData.NOMA : string.Empty) +" "+ ((employeeData.PRENOMA != "" | employeeData.PRENOMA != null) ? employeeData.PRENOMA : string.Empty); ;
                    txt_emp_name_fr.Text = ((employeeData.NOML != "" | employeeData.NOML != null) ? employeeData.NOML : string.Empty) + " " + ((employeeData.PRENOML != "" | employeeData.PRENOML != null) ? employeeData.PRENOML : string.Empty); ;
                    txt_emp_naiss_D.Text = employeeData.JOUR_NAIS;
                    txt_emp_naiss_M.Text = employeeData.MOIS_NAIS;
                    txt_emp_naiss_Y.Text = employeeData.AN_NAIS;

                    txt_emp_lnaiss.Text = employeeData.LIEU_NAIS;
                    txt_emp_genre.Text = employeeData.GENRE;
                    SelectItemCbValue(cb_emp_nat, employeeData.CD_NATION); 
                    SelectItemCbValue(cb_emp_sitfam, employeeData.SIT_FAM);  //<<<<<<<<<<<
                    FillDatepicker2(dt_emp_sitfam, employeeData.DATE_SITFAM);
                    richTex_emp_adress.Text = employeeData.ADRESSE;
                    txt_emp_email.Text = employeeData.ADRESSE_ELEC;
                    txt_emp_tel.Text = employeeData.TEL_PORTABLE;
                    FillDatepicker2(dt_emp_affect_fonction, employeeAct.DATEAFFECT);
                    FillDatepicker2(dt_emp_recrut, employeeData.DATE_REC);
                    FillDatepicker2(dt_emp_titul, employeeData.DT_TITUL);
                    rb_emp_afiliation_yes.Checked = Convert.ToBoolean(employeeData.AFFILIE);
                    if (rb_emp_afiliation_yes.Checked == false) { rb_emp_afiliation_nn.Checked = true; }
                    FillDatepicker2(dt_emp_filiation, employeeData.DATEAFFIL);
                   
                    txt_emp_num_filiat_cnops.Text = employeeData.NumAFFIL;
                    txt_emp_num_imatric_cnops.Text = employeeData.NumImma;
                }
                if (tabControl_emp.SelectedIndex == 1)// tab administration
                {
                    FillDatepicker2(dt_emp_enc_adminis, employeeData.ANC_ADM);
                    SelectItemCbValue(cb_emp_cadre, employeeData.CD_CADRE);
                    FillDatepicker2(dt_emp_effet_cadre, employeeData.DT_CADRE);
                    SelectItemCbValue(cb_emp_grad, employeeData.CD_GRADE);
                    SelectItemCbValue(cb_emp_grad, employeeData.CD_GRADE); //joint
                    FillDatepicker2(dt_emp_enc_grad, employeeData.DT_GRADE);
                    SelectItemCbValue(cb_emp_acces_grad, employeeData.MODAVGRA);
                    txt_emp_echelon.Text = employeeData.ECHELON;
                    FillDatepicker2(dt_emp_enc_echelon, employeeData.DT_ECHELON);
                    SelectItemCbValue(cb_emp_sit_statut, employeeData.CD_STATUT);
                    FillDatepicker2(dt_emp_sit_statut, employeeData.DT_SITSTAT);
                    SelectItemCbValue(cb_emp_pos, employeeData.CD_POSITION);
                    FillDatepicker2(dt_emp_position, employeeData.DATE_POSITION);

                }
                if (tabControl_emp.SelectedIndex == 2)// tab professional
                {
                    txt_emp_gresa.Text = employeeAct.CD_ETAB;
                    FillDatepicker2(dt_emp_affect_etab, employeeAct.DT_AFF_ETAB);
                    FillDatepicker2(dt_emp_affect_deleg, employeeAct.DT_AFF_PROV);
                    FillDatepicker2(dt_emp_affect_aref, employeeAct.DT_AFF_REG);
                    FillDatepicker2(dt_emp_affect_post, employeeAct.DT_AFF_POSTE);
                    SelectItemCbValue(cb_emp_fonct, employeeAct.CD_FONC);
                    SelectItemCbValue(cb_emp_cycle, employeeAct.CD_CYCLE);
                }
                if (tabControl_emp.SelectedIndex == 3) // diplomes
                {
                    SelectItemCbValue(cb_emp_dip_scol, employeeData.CD_DIPS);
                    FillDatepicker2(dt_emp_dip_scol, employeeData.DT_DIPSCOL);
                    SelectItemCbValue(cb_emp_dip_prof, employeeData.CD_DIPP);
                    SelectItemCbValue(cb_emp_spec_diplo, employeeData.CD_DISCIP);
                    FillDatepicker2(dt_emp_dip_prof, employeeData.DT_DIPPROF);
                    cb_emp_centrFormation.Text = employeeData.VILLEFORM;
                }
            }

           
           

        }

        

        

        private void cb_emp_select_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillControls_Emp_LL();
           


        }

      

        private void rb_em_data_AR_CheckedChanged(object sender, EventArgs e)
        {
            FillCombosAr();
            FillControls_Emp_LL();


        }

        private void rb_em_data_FR_CheckedChanged(object sender, EventArgs e)
        {
            FillCombosFR();
            FillControls_Emp_LL();


        }

        private void btn_emp_add_Click(object sender, EventArgs e)
        {

            if (txt_emp_ppr.Text != "")
            {
                Excel.Application oXL;
                Excel._Workbook oWB;
                Excel._Worksheet oSheet;

                oXL = new Excel.Application();
                oXL.Visible = true;

                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.Sheets[1];

                EmployeeDataContext edtc = new EmployeeDataContext();

                var emp = (from ac in edtc.Emp_Acts
                           where ac.ppr_act == txt_emp_ppr.Text
                           join dat in edtc.Emp_Datas
                           on ac.ppr_act equals dat.ppr_dat
                           select new
                           {
                               ppr = ac.ppr_act,
                               cycle = ac.CD_CYCLE,
                               fonction = ac.CD_FONC,
                               mod = ac.CD_MODAFFE,
                               dtaffedt = ac.DATEAFFECT,
                               etabAfeect = ac.DT_AFF_ETAB,
                               nom = dat.NOMA + " " + dat.NOML
                           }
                           ).FirstOrDefault();

                if (emp != null)
                {
                    try
                    {
                        int row = 1;
                        foreach (PropertyInfo prop in emp.GetType().GetProperties())
                        {
                            var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                            //  prop.GetValue(emp, null).ToString();

                            oSheet.Cells[row, 1] = prop.GetValue(emp, null).ToString();
                            row++;


                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                   





                    System.Windows.Forms.SaveFileDialog saveFileDialog1;
                    saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                    DialogResult dr = saveFileDialog1.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        string filename = saveFileDialog1.FileName;
                        //save file using stream.
                        oXL.Visible = true;
                        oXL.UserControl = true;

                        oWB.SaveAs(filename,
                            AccessMode: Excel.XlSaveAsAccessMode.xlShared);
                        MessageBox.Show("sucess saved");
                    }

                }
                else
                {
                    MessageBox.Show("No data to export");
                }


            }
        }

        private void btn_enp_previ_Click(object sender, EventArgs e)
        {
            if (comboboxIndex > 0)
            {
                comboboxIndex--;
                cb_emp_select_emp.SelectedIndex = comboboxIndex;
            }

        }
        int comboboxIndex = 0;
        private void btn_enp_next_Click(object sender, EventArgs e)
        {
            if (comboboxIndex < cb_emp_select_emp.Items.Count - 1)
            {
                comboboxIndex++;
                cb_emp_select_emp.SelectedIndex = comboboxIndex;
            }
        }



        private void tabControl_emp_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex != 0)
            {
                btn_enp_Add.Visible = false;
            }
            else
            {
                btn_enp_Add.Visible = true;
            }

            if (e.TabPage.Name == "tab_traduc")
            {
                rb_em_data_AR.Visible = false;
                rb_em_data_FR.Visible = false;
                btn_enp_Add.Visible = false;
                btn_enp_delete.Visible = false;
                btn_enp_next.Visible = false;
                btn_enp_previ.Visible = false;
                btn_enp_Update.Visible = false;
                btn_emp_add.Visible = false;
                cb_emp_select_emp.Visible = false;
                btn_enp_save.Visible = true;
                lbl_emp_Toadd.Visible = false;
                btn_enp_cancel.Visible = false;
                btn_enp_save.Text = "حفظ الترجمة";

                //btn_emp_add_Click(sender, e);
                btn_enp_save.Text = "حفظ الترجمة";
                tabControl_emp.SelectedTab = tab_traduc;
                FillCombosTradFR();
            }
            else
            {
                //if (rb_em_data_AR.Checked) { FillCombosAr(); }
                //if (rb_em_data_FR.Checked) { FillCombosFR(); }
                rb_em_data_AR.Visible = true;
                rb_em_data_FR.Visible = true;
               // btn_enp_Add.Visible = true;
                btn_enp_Update.Visible = true;
                btn_enp_delete.Visible = true;
                btn_enp_next.Visible = true;
                btn_enp_previ.Visible = true;
                btn_emp_add.Visible = true;
                cb_emp_select_emp.Visible = true;
                btn_enp_save.Visible = false;
                btn_enp_cancel_Click(sender, e);
                if (btn_enp_Add.Text=="حفظ المسك"| btn_enp_Add.Text == "حفظ التعديل")
                {
                    clearToSave(false);
                }
                else
                {
                    clearToSave(true);
                }


                if (cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedValue) == savedppr& savedppr != "")
                {

                    cb_emp_select_emp.SelectedValue = savedppr;
                }
                if (tabControl_emp.SelectedTab == tab_profes)
                {
                    txt_emp_gresa.Text = gresa;
                }
              
                cb_emp_select_emp_SelectedIndexChanged(sender, e);
                //if (btn_enp_save.Text == "حفظ المسك" )
                //{
                //    if (e.TabPage.Name == "tab_perso")
                //    {
                //        Tools.extenstions.ClearControls(tab_perso.Controls);
                //    }
                //    if (e.TabPage.Name == "tab_admi")
                //    {
                //        Tools.extenstions.ClearControls(tab_admi.Controls);
                //    }
                //    if (e.TabPage.Name == "tab_profes")
                //    {
                //        Tools.extenstions.ClearControls(tab_profes.Controls);
                //    }
                //    if (e.TabPage.Name == "tab_diplom")
                //    {
                //        Tools.extenstions.ClearControls(tab_diplom.Controls);
                //    }
                   
                    
                   
                   
               // }
              
               

            }
        }

        private void btn_emp_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ch_em_tra_sitfam_CheckedChanged(object sender, EventArgs e)
        {
            EmployeeDataContext edtc = new EmployeeDataContext();
           System.Windows.Forms.CheckBox sendercheck = sender as System.Windows.Forms.CheckBox;
            System.Windows.Forms.TextBox sendertxt = sender as System.Windows.Forms.TextBox;

            string sub = sendercheck.Name.Substring(2, sendercheck.Name.Length - 2);


            if (sendercheck.Checked)
            {
                foreach (var c in tab_traduc.Controls)
                {
                    System.Windows.Forms.CheckBox check = c as System.Windows.Forms.CheckBox;


                    if (check != null)
                    {
                        if (check.Name != sendercheck.Name)
                        {
                            check.Checked = false;
                        }
                    }
                }
                foreach (var t in tab_traduc.Controls)
                {
                    System.Windows.Forms.TextBox txt = t as System.Windows.Forms.TextBox;


                    if (txt != null)
                    {
                        if (txt.Name != "txt" + sub)
                        {
                            txt.Text = string.Empty;
                            txt.Enabled = false;
                        }
                        if (txt.Name == "txt" + sub)
                        {
                            txt.Enabled = true;
                            try
                            {
                                fillTextboxTra();
                            }
                            catch (Exception)
                            {


                            }


                        }
                    }
                }

            }



        }

        private void fillTextboxTra()
        {
            EmployeeDataContext edtc = new EmployeeDataContext();
            if (txt_em_tra_sitfam.Enabled)
            {
                string val = cb_em_tra_sitfam.GetItemText(cb_em_tra_sitfam.SelectedValue);
                txt_em_tra_sitfam.Text = edtc.sitfams.Where(s => s.Sit_Fam.Equals(val)).FirstOrDefault().LA_SitFam;

            }
            if (txt_em_tra_cadre.Enabled)
            {
                string val = cb_em_tra_cadre.GetItemText(cb_em_tra_cadre.SelectedValue);
                txt_em_tra_cadre.Text = edtc.cadres.Where(s => s.CD_CADRE.Equals(val)).FirstOrDefault().LA_CADRE;

            }
            if (txt_em_tra_grad.Enabled)
            {
                string val = cb_em_tra_grad.GetItemText(cb_em_tra_grad.SelectedValue);
                txt_em_tra_grad.Text = edtc.grades.Where(s => s.CD_GRADE.Equals(val)).FirstOrDefault().LA_GRADE;
            }
            if (txt_em_tra_modAcces.Text != string.Empty)
            {
                string val = cb_em_tra_modAcces.GetItemText(cb_em_tra_modAcces.SelectedValue);
                txt_em_tra_modAcces.Text = edtc.mode_accsses_grads.Where(s => s.MODAVGRA.Equals(val)).FirstOrDefault().LA_DESLMODAV;
            }
            if (txt_em_tra_sitStatut.Enabled)
            {
                string val = cb_em_tra_sitStatut.GetItemText(cb_em_tra_sitStatut.SelectedValue);
                txt_em_tra_sitStatut.Text = edtc.sit_statuts.Where(s => s.CD_Statut.Equals(val)).FirstOrDefault().LA_STATUT;
            }
            if (txt_em_tra_position.Enabled)
            {
                string val = cb_em_tra_position.GetItemText(cb_em_tra_position.SelectedValue);
                txt_em_tra_position.Text = edtc.positions.Where(s => s.CD_Position.Equals(val)).FirstOrDefault().LA_POSITION;
            }
            if (txt_em_tra_fonction.Enabled)
            {
                string val = cb_em_tra_fonction.GetItemText(cb_em_tra_fonction.SelectedValue);
                txt_em_tra_fonction.Text = edtc.fonctions.Where(s => s.CD_Fonc.Equals(val)).FirstOrDefault().LA_Fonc;
            }
            if (txt_em_tra_cycle.Enabled)
            {
                string val = cb_em_tra_cycle.GetItemText(cb_em_tra_cycle.SelectedValue);
                txt_em_tra_cycle.Text = edtc.cycles.Where(s => s.CD_CYCLE.Equals(val)).FirstOrDefault().LA_CYCLE;
            }
            if (txt_em_tra_dipdcol.Enabled)
            {
                string val = cb_em_tra_dipdcol.GetItemText(cb_em_tra_dipdcol.SelectedValue);
                txt_em_tra_dipdcol.Text = edtc.dipscols.Where(s => s.CD_DIPS.Equals(val)).FirstOrDefault().LA_DIPS;
            }
            if (txt_em_tra_dippro.Enabled)
            {
                string val = cb_em_tra_dippro.GetItemText(cb_em_tra_dippro.SelectedValue);
                txt_em_tra_dippro.Text = edtc.dippros.Where(s => s.CD_DIPP.Equals(val)).FirstOrDefault().LA_DIPP;
            }
            if (txt_em_tra_specialite.Enabled)
            {
                string val = cb_em_tra_specialite.GetItemText(cb_em_tra_specialite.SelectedValue);
                txt_em_tra_specialite.Text = edtc.disciplines.Where(s => s.CD_Discip.Equals(val)).FirstOrDefault().LA_DISCIP;
            }
            if (txt_em_tra_centre.Enabled)
            {

            }
        }
        string savedppr = "";
        private void btn_enp_save_Click(object sender, EventArgs e)
        {
            try
            {

           
            if (tabControl_emp.SelectedTab.Name == tab_traduc.Name)
            {
                EmployeeDataContext edtc = new EmployeeDataContext();

                //****** tab traduct
                if (txt_em_tra_sitfam.Text != string.Empty)
                {
                    string val = cb_em_tra_sitfam.GetItemText(cb_em_tra_sitfam.SelectedValue).Trim();
                    sitfam sit = edtc.sitfams.Where(s => s.Sit_Fam.Trim().Equals(val)).FirstOrDefault();
                    sit.LA_SitFam = txt_em_tra_sitfam.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");

                }
                if (txt_em_tra_cadre.Text != string.Empty)
                {
                    cadre cad = edtc.cadres.Where(s => s.CD_CADRE == cb_em_tra_cadre.GetItemText(cb_em_tra_cadre.SelectedValue)).FirstOrDefault();
                    cad.LA_CADRE = txt_em_tra_cadre.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");

                }
                if (txt_em_tra_grad.Text != string.Empty)
                {
                    grade gra = edtc.grades.Where(s => s.CD_GRADE == cb_em_tra_grad.GetItemText(cb_em_tra_grad.SelectedValue)).FirstOrDefault();
                    gra.LA_GRADE = txt_em_tra_grad.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");
                    edtc.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues,
                   edtc.sitfams);
                }
                if (txt_em_tra_modAcces.Text != string.Empty)
                {
                    mode_accsses_grad mag = edtc.mode_accsses_grads.Where(s => s.MODAVGRA == cb_em_tra_modAcces.GetItemText(cb_em_tra_modAcces.SelectedValue)).FirstOrDefault();
                    mag.LA_DESLMODAV = txt_em_tra_modAcces.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");
                }
                if (txt_em_tra_sitStatut.Text != string.Empty)
                {
                    string val = cb_em_tra_sitStatut.GetItemText(cb_em_tra_sitStatut.SelectedValue).Trim();
                    sit_statut sit = edtc.sit_statuts.Where(s => s.CD_Statut.Trim().Equals(val)).FirstOrDefault();
                    sit.LA_STATUT = txt_em_tra_sitStatut.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");
                }
                if (txt_em_tra_position.Text != string.Empty)
                {
                    string val = cb_em_tra_position.GetItemText(cb_em_tra_position.SelectedValue).Trim();
                    position pos = edtc.positions.Where(s => s.CD_Position.Trim().Equals(val)).FirstOrDefault();
                    pos.LA_POSITION = txt_em_tra_position.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");
                }
                if (txt_em_tra_fonction.Text != string.Empty)
                {
                    string val = cb_em_tra_fonction.GetItemText(cb_em_tra_fonction.SelectedValue).Trim();
                    fonction fon = edtc.fonctions.Where(s => s.CD_Fonc.Trim().Equals(val)).FirstOrDefault();
                    fon.LA_Fonc = txt_em_tra_fonction.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");
                }
                if (txt_em_tra_cycle.Text != string.Empty)
                {
                    string val = cb_em_tra_cycle.GetItemText(cb_em_tra_cycle.SelectedValue).Trim();
                    cycle cy = edtc.cycles.Where(s => s.CD_CYCLE.Trim().Equals(val)).FirstOrDefault();
                    cy.LA_CYCLE = txt_em_tra_cycle.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");
                }
                if (txt_em_tra_dipdcol.Text != string.Empty)
                {
                    string val = cb_em_tra_dipdcol.GetItemText(cb_em_tra_dipdcol.SelectedValue).Trim();
                    dipscol dips = edtc.dipscols.Where(s => s.CD_DIPS.Trim().Equals(val)).FirstOrDefault();
                    dips.LA_DIPS = txt_em_tra_dipdcol.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");
                }
                if (txt_em_tra_dippro.Text != string.Empty)
                {
                    string val = cb_em_tra_dippro.GetItemText(cb_em_tra_dippro.SelectedValue).Trim();
                    dippro dipp = edtc.dippros.Where(s => s.CD_DIPP.Trim().Equals(val)).FirstOrDefault();
                    dipp.LA_DIPP = txt_em_tra_dippro.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");
                }
                if (txt_em_tra_specialite.Text != string.Empty)
                {
                    string val = cb_em_tra_specialite.GetItemText(cb_em_tra_specialite.SelectedValue).Trim();
                    discipline disc = edtc.disciplines.Where(s => s.CD_Discip.Trim().Equals(val)).FirstOrDefault();
                    disc.LA_DISCIP = txt_em_tra_specialite.Text;
                    edtc.SubmitChanges();
                    MessageBox.Show("تم بنجاح");
                }
                if (txt_em_tra_centre.Text != string.Empty)
                {
                    //string val = cb_em_tra_centre.GetItemText(cb_em_tra_centre.SelectedValue).Trim();
                    //centre_formation cen = edtc.centre_formations.Where(s => s.NOM_ETABL.Trim().Equals(val)).FirstOrDefault();
                    //cen. = txt_em_tra_centre.Text;//<<<<<<<
                    //edtc.SubmitChanges();
                    //MessageBox.Show("تم بنجاح");
                }
                if (rb_em_data_FR.Checked)
                {
                    rb_em_data_AR.Checked = true;
                }
                else
                {
                    FillCombosAr();
                }

            }
            Nullable<DateTime> MyNullableDate = null;

            // ************* btn save add
            if (btn_enp_save.Text == "حفظ المسك")
            {

                savedppr = txt_emp_ppr.Text.Trim();
                //****************** tab perso
                if (tabControl_emp.SelectedTab == tab_perso)
                {
                   

                    EmployeeDataContext edtc = new EmployeeDataContext();
                    Emp_Data emp = edtc.Emp_Datas.Where(p => p.ppr_dat.Trim().Equals(txt_emp_ppr.Text.Trim())).FirstOrDefault();

                    if (emp == null)
                    {
                      
                        string cin = Regex.Replace(txt_emp_cin.Text.Trim(), @"\s+", "");

                        var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");
                       
                        var match = numAlpha.Match(cin);

                        var alpha = match.Groups["Alpha"].Value;
                        var num = match.Groups["Numeric"].Value;

                        string[] nameAR = txt_emp_name_ar.Text.Split(null);
                        string[] nameFR = txt_emp_name_fr.Text.Split(null);

                        Emp_Data em = new Emp_Data
                        {
                            ppr_dat = txt_emp_ppr.Text,
                            CINA = alpha,
                            CINN = num,
                            PRENOMA = nameAR.Count()>1? txt_emp_name_ar.Text.Split(null)[1]:string.Empty, //Or myStr.Split() //txt_emp_name_ar.Text,
                            PRENOML = nameFR.Count()>1?txt_emp_name_fr.Text.Split(null)[1]:string.Empty,//txt_emp_name_fr.Text,
                            NOMA = nameAR.Count() > 0 ? txt_emp_name_ar.Text.Split(null)[0]:string.Empty,
                            NOML =nameFR.Count()>0? txt_emp_name_fr.Text.Split(null)[0]:string.Empty,
                            AN_NAIS = txt_emp_naiss_Y.Text,
                            MOIS_NAIS = txt_emp_naiss_M.Text,
                            JOUR_NAIS = txt_emp_naiss_D.Text,
                            LIEU_NAIS = txt_emp_lnaiss.Text.Trim(),
                            GENRE = txt_emp_genre.Text.Trim(),
                            CD_NATION = cb_emp_nat.GetItemText(cb_emp_nat.SelectedValue),
                            SIT_FAM = cb_emp_sitfam.GetItemText(cb_emp_sitfam.SelectedValue),
                            DATE_SITFAM = dt_emp_sitfam.Text.Trim() != string.Empty ? dt_emp_sitfam.Value : MyNullableDate,
                            ADRESSE = richTex_emp_adress.Text.Trim(),
                            ADRESSE_ELEC = txt_emp_email.Text.Trim(),
                            TEL_PORTABLE = txt_emp_tel.Text.Trim(),
                            AFFILIE = rb_emp_afiliation_yes.Checked ? "true" : "false",
                            DATEAFFIL = dt_emp_filiation.Text.Trim() != string.Empty ? dt_emp_filiation.Value : MyNullableDate,
                            NumAFFIL = txt_emp_num_filiat_cnops.Text.Trim(),
                            NumImma = txt_emp_num_imatric_cnops.Text.Trim(),
                            

                        };

                        Emp_Act ac = new Emp_Act
                        {
                            ppr_act = txt_emp_ppr.Text.Trim(),
                            CD_ETAB = gresa

                        };

                        edtc.Emp_Datas.InsertOnSubmit(em);
                        edtc.Emp_Acts.InsertOnSubmit(ac);
                        edtc.SubmitChanges();
                    
                      

                        Frm_Emp_Fiche_Load(sender, e);
                        btn_enp_cancel_Click(sender, e);

                     
                        if (savedppr != "")
                        {
                            cb_emp_select_emp.SelectedValue = savedppr;
                        }
                        rb_em_data_AR.Visible=true;
                    }
                    else
                    {
                        MessageBox.Show("هذا الموظف(ة) موجود في قاعدة البيانات، ربما تريد تعديل البيانات");
                    }
                }// ************** end tab perso
            }
            if (btn_enp_save.Text == "حفظ التعديل")
            {
                if (tabControl_emp.SelectedTab.Name != tab_traduc.Name) {

                if (tabControl_emp.SelectedTab == tab_perso)
                {
                    EmployeeDataContext edtc = new EmployeeDataContext();
                    Emp_Data emp = edtc.Emp_Datas.Where(p => p.ppr_dat.Trim().Equals(txt_emp_ppr.Text.Trim())).FirstOrDefault();
                    if (emp != null)
                    {

                        string cin = Regex.Replace(txt_emp_cin.Text.Trim(), @"\s+", "");

                        var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");

                        var match = numAlpha.Match(cin);

                        var alpha = match.Groups["Alpha"].Value;
                        var num = match.Groups["Numeric"].Value;

                        emp.CINA = alpha; 
                        emp.CINN = num;
                        emp.PRENOMA = txt_emp_name_ar.Text;


                        emp.PRENOML = txt_emp_name_fr.Text;
                        emp.NOMA = string.Empty;
                        emp.NOML = string.Empty;

                        emp.AN_NAIS = txt_emp_naiss_Y.Text;
                        emp.MOIS_NAIS = txt_emp_naiss_M.Text;

                        emp.JOUR_NAIS = txt_emp_naiss_D.Text;
                        emp.LIEU_NAIS = txt_emp_lnaiss.Text.Trim();
                        emp.GENRE = txt_emp_genre.Text.Trim();
                        emp.CD_NATION = cb_emp_nat.GetItemText(cb_emp_nat.SelectedValue);


                        emp.SIT_FAM = cb_emp_sitfam.GetItemText(cb_emp_sitfam.SelectedValue);
                        emp.DATE_SITFAM = dt_emp_sitfam.Text.Trim() != string.Empty ? dt_emp_sitfam.Value : MyNullableDate;
                        emp.ADRESSE = richTex_emp_adress.Text.Trim();
                        emp.ADRESSE_ELEC = txt_emp_email.Text.Trim();

                        emp.TEL_PORTABLE = txt_emp_tel.Text.Trim();
                        emp.AFFILIE = rb_emp_afiliation_yes.Checked ? "true" : "false";
                        emp.DATEAFFIL = dt_emp_filiation.Text.Trim() != string.Empty ? dt_emp_filiation.Value : MyNullableDate;
                        emp.NumAFFIL = txt_emp_num_filiat_cnops.Text.Trim();
                        emp.NumImma = txt_emp_num_imatric_cnops.Text.Trim();
                        ///*******************
                        edtc.SubmitChanges();
                        MessageBox.Show("تم حفظ التعديل بنجاح");
                        btn_enp_cancel_Click(sender, e);
                        if (savedppr != "")
                        {
                            cb_emp_select_emp.SelectedItem = savedppr;
                        }
                    }
                    else
                    {
                        MessageBox.Show("عليك أن تبدأ بالمعطيات الشخصية أولا");
                        tabControl_emp.SelectedIndex = 0;
                    }


                }
                if (tabControl_emp.SelectedTab == tab_admi)
                {
                    if (txt_emp_ppr.Text != string.Empty)
                    {
                        EmployeeDataContext edtc = new EmployeeDataContext();
                        Emp_Data emp = edtc.Emp_Datas.Where(p => p.ppr_dat.Trim().Equals(txt_emp_ppr.Text.Trim())).FirstOrDefault();
                        if (emp != null)
                        {
                            emp.DATE_REC = dt_emp_recrut.Text.Trim() != string.Empty ? dt_emp_recrut.Value : MyNullableDate;//dt_emp_recrut.Value;
                            emp.DT_TITUL = dt_emp_titul.Text.Trim() != string.Empty ? dt_emp_titul.Value : MyNullableDate;//dt_emp_titul.Value;
                            emp.ANC_ADM = dt_emp_enc_adminis.Text.Trim() != string.Empty ? dt_emp_enc_adminis.Value : MyNullableDate;//dt_emp_enc_adminis.Value;
                            emp.CD_CADRE = cb_emp_cadre.GetItemText(cb_emp_cadre.SelectedValue);
                            emp.DT_CADRE = dt_emp_effet_cadre.Text.Trim() != string.Empty ? dt_emp_effet_cadre.Value : MyNullableDate; //dt_emp_effet_cadre.Value;
                            emp.CD_GRADE = cb_emp_grad.GetItemText(cb_emp_grad.SelectedValue);
                            emp.ANC_GRADE = dt_emp_enc_grad.Text.Trim() != string.Empty ? dt_emp_enc_grad.Value : MyNullableDate; //dt_emp_enc_grad.Value;
                            emp.MODAVGRA = cb_emp_acces_grad.GetItemText(cb_emp_acces_grad.SelectedValue);
                            emp.ECHELON = txt_emp_echelon.Text;
                            emp.ANC_ECHELON = dt_emp_enc_echelon.Text.Trim() != string.Empty ? dt_emp_enc_echelon.Value : MyNullableDate; //dt_emp_enc_echelon.Value;
                            emp.CD_STATUT = cb_emp_sit_statut.GetItemText(cb_emp_sit_statut.SelectedValue);
                            emp.DT_SITSTAT = dt_emp_sit_statut.Text.Trim() != string.Empty ? dt_emp_sit_statut.Value : MyNullableDate; //dt_emp_sit_statut.Value;
                            emp.CD_POSITION = cb_emp_pos.GetItemText(cb_emp_pos.SelectedValue);
                            emp.DATE_POSITION = dt_emp_position.Text.Trim() != string.Empty ? dt_emp_position.Value : MyNullableDate;//dt_emp_position.Value;

                            edtc.SubmitChanges();
                            MessageBox.Show("تم حفظ التعديل بنجاح");
                            btn_enp_cancel_Click(sender, e);
                            if (savedppr != "")
                            {
                                cb_emp_select_emp.SelectedItem = savedppr;
                            }
                        }
                        else
                        {
                            MessageBox.Show("عليك أن تبدأ بالمعطيات الشخصية أولا");
                            tabControl_emp.SelectedIndex = 0;
                        }
                    }else
                    {
                        tabControl_emp.SelectedIndex = 0;
                        txt_emp_ppr.Focus();
                    }

                   
                }
                if (tabControl_emp.SelectedTab == tab_profes)
                {

                    if (txt_emp_ppr.Text != string.Empty)
                    {


                        EmployeeDataContext edtc = new EmployeeDataContext();
                        Emp_Act emp = edtc.Emp_Acts.Where(p => p.ppr_act.Trim().Equals(txt_emp_ppr.Text.Trim())).FirstOrDefault();
                        if (emp != null)
                        {
                            emp.CD_ETAB = txt_emp_gresa.Text;
                            // gipe     //  emp.
                            emp.DT_AFF_ETAB = dt_emp_affect_etab.Text.Trim() != string.Empty ? dt_emp_affect_etab.Value : MyNullableDate; // dt_emp_affect_etab.Value;
                            emp.DT_AFF_PROV = dt_emp_affect_deleg.Text.Trim() != string.Empty ? dt_emp_affect_deleg.Value : MyNullableDate;// dt_emp_affect_deleg.Value;
                            emp.DT_AFF_REG = dt_emp_affect_aref.Text.Trim() != string.Empty ? dt_emp_affect_aref.Value : MyNullableDate;// dt_emp_affect_aref.Value;
                            emp.DT_AFF_POSTE = dt_emp_affect_post.Text.Trim() != string.Empty ? dt_emp_affect_post.Value : MyNullableDate;//dt_emp_affect_post.Value;
                            emp.CD_FONC = cb_emp_fonct.GetItemText(cb_emp_fonct.SelectedValue);
                            emp.DATEAFFECT = dt_emp_affect_fonction.Text.Trim() != string.Empty ? dt_emp_affect_fonction.Value : MyNullableDate; //dt_emp_affect_fonction.Value;
                            emp.CD_CYCLE = cb_emp_cycle.GetItemText(cb_emp_cycle.SelectedValue);

                            edtc.SubmitChanges();
                            MessageBox.Show("تم حفظ التعديل بنجاح");
                            btn_enp_cancel_Click(sender, e);
                            if (savedppr != "")
                            {
                                cb_emp_select_emp.SelectedItem = savedppr;
                            }
                        }
                        else
                        {
                            MessageBox.Show("عليك أن تبدأ بالمعطيات الشخصية أولا");
                            tabControl_emp.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        tabControl_emp.SelectedIndex = 0;
                        txt_emp_ppr.Focus();
                    }

                }
                if (tabControl_emp.SelectedTab == tab_diplom)
                {
                    if (txt_emp_ppr.Text != string.Empty)
                    {

                        EmployeeDataContext edtc = new EmployeeDataContext();
                    Emp_Data emp = edtc.Emp_Datas.Where(p => p.ppr_dat.Trim().Equals(txt_emp_ppr.Text.Trim())).FirstOrDefault();
                    if (emp != null)
                    {
                        emp.CD_DIPS = cb_emp_dip_scol.GetItemText(cb_emp_dip_scol.SelectedValue);
                        emp.DT_DIPSCOL = dt_emp_dip_scol.Value;
                        emp.CD_DIPP = cb_emp_dip_prof.GetItemText(cb_emp_dip_prof.SelectedValue);
                        emp.CD_DISCIP = cb_emp_spec_diplo.GetItemText(cb_emp_spec_diplo.SelectedValue);
                        emp.DT_DIPPROF = dt_emp_dip_prof.Text.Trim() != string.Empty ? dt_emp_dip_prof.Value : MyNullableDate; //dt_emp_dip_prof.Value;
                        emp.VILLEFORM = cb_emp_centrFormation.GetItemText(cb_emp_centrFormation.SelectedValue);

                        edtc.SubmitChanges();
                            MessageBox.Show("تم حفظ التعديل بنجاح");
                            btn_enp_cancel_Click(sender, e);
                                if (savedppr != "")
                            {
                                cb_emp_select_emp.SelectedItem = savedppr;
                            }
                        }
                    else
                    {
                        MessageBox.Show("عليك أن تبدأ بالمعطيات الشخصية أولا");
                        tabControl_emp.SelectedIndex = 0;
                    }
                }
                }
                else
                {
                    tabControl_emp.SelectedIndex = 0;
                    txt_emp_ppr.Focus();
                }
                btn_enp_save.Visible = false;
                fillcombo_emp_select();
                rb_em_data_AR.Visible = true;
            } //************ end btn add

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void cb_em_tra_sitfam_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox senderCheck = sender as System.Windows.Forms.CheckBox;
            System.Windows.Forms.TextBox senderTxt = sender as System.Windows.Forms.TextBox;
            ComboBox senderCombo = sender as ComboBox;

            string subCombo = senderCombo.Name.Substring(2, senderCombo.Name.Length - 2);
            foreach (var c in tab_traduc.Controls)
            {
                System.Windows.Forms.CheckBox check = c as System.Windows.Forms.CheckBox;


                if (check != null)
                {
                    if (check.Name == "ch" + subCombo)
                    {
                        check.Checked = true;
                        try
                        {
                            fillTextboxTra();
                        }
                        catch (Exception)
                        {


                        }

                    }
                }
            }

        }

        private void clearToSave(bool tf)
        {
            btn_enp_Add.Enabled = tf;
            btn_enp_delete.Enabled = tf;
            btn_enp_Update.Enabled = tf;
            btn_enp_previ.Enabled = tf;
            btn_enp_next.Enabled = tf;
            cb_emp_select_emp.Visible = tf;
            btn_enp_cancel.Visible = !tf;
            lbl_emp_Toadd.Visible = !tf;
            if (tabControl_emp.SelectedTab != tab_perso)
                btn_enp_delete.Visible = false;
            else
                btn_enp_delete.Visible = true;
        }
        
        private void btn_enp_Add_Click(object sender, EventArgs e)
        {
           

                btn_enp_save.Text = "حفظ المسك";
                btn_enp_save.Visible = true;
                rb_em_data_FR.Checked = true;
            rb_em_data_AR.Visible = false;

            FillCombosFR_Add_Upd();
            if (tabControl_emp.SelectedTab.Name == "tab_perso")
            {
                clearToSave(false);
                lbl_emp_Toadd.Visible = false;
                LoadDatePickerVide();

                Tools.extenstions.ClearControls(tab_perso.Controls);
                dt_emp_sitfam.Format = DateTimePickerFormat.Custom;
                dt_emp_sitfam.CustomFormat = " ";





            }
            if (tabControl_emp.SelectedTab.Name == "tab_admi")
            {
                clearToSave(false);

                LoadDatePickerVide();
                Tools.extenstions.ClearControls(tab_admi.Controls);
                lbl_emp_Toadd.Text = cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedItem) + "[" + cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedValue) + "]";
            }
            if (tabControl_emp.SelectedTab.Name == "tab_profes")
            {
                clearToSave(false);
                LoadDatePickerVide();
                Tools.extenstions.ClearControls(tab_profes.Controls);
                lbl_emp_Toadd.Text = cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedItem) + "[" + cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedValue) + "]";

            }
            if (tabControl_emp.SelectedTab.Name == "tab_diplom")
            {
                clearToSave(false);
                LoadDatePickerVide();
                Tools.extenstions.ClearControls(tab_diplom.Controls);
                lbl_emp_Toadd.Text = cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedItem) + "[" + cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedValue) + "]";



            }





        }

        private void btn_enp_Update_Click(object sender, EventArgs e)
        {
            btn_enp_save.Text = "حفظ التعديل";
            btn_enp_save.Visible = true;
            rb_em_data_FR.Checked = true;
            clearToSave(false);
            lbl_emp_Toadd.Text = cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedItem) + "[" + cb_emp_select_emp.GetItemText(cb_emp_select_emp.SelectedValue) + "]";
            cb_emp_select_emp.Visible = false;
            rb_em_data_FR.Checked = true;
            rb_em_data_AR.Visible = false;
            FillCombosFR_Add_Upd();
            FillControls_Emp_LL();

        }

      

        private void dt_emp_sitfam_CloseUp(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            if (dtp.Text != " ")
            {
                dtp.CustomFormat = "dd/MM/yyyy";
               
            }else
            {
                dtp.CustomFormat = " ";
              
            }
                
        }

        private void dt_emp_sitfam_Enter(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            dtp.CustomFormat = "dd/MM/yyyy";
        }

        private void btn_enp_cancel_Click(object sender, EventArgs e)
        {
            clearToSave(true);
            if (rb_em_data_FR.Checked) { FillCombosFR(); FillControls_Emp_LL(); }
            if (rb_em_data_AR.Checked) { FillCombosAr(); FillControls_Emp_LL(); }

            btn_enp_save.Visible = false;
            rb_em_data_AR.Visible = true;
            cb_emp_select_emp_SelectedIndexChanged(sender, e);

        }

        private void txt_emp_ppr_Leave(object sender, EventArgs e)
        {
            savedppr = txt_emp_ppr.Text.Trim();
        }

        private void btn_enp_delete_Click(object sender, EventArgs e)
        {
            try
            {

            if (txt_emp_ppr.Text != "")
            {
                EmployeeDataContext edc = new EmployeeDataContext();
                Emp_Act empA = edc.Emp_Acts.Where(p => p.ppr_act.Equals(txt_emp_ppr.Text.Trim())).FirstOrDefault();
                Emp_Data empD = edc.Emp_Datas.Where(p => p.ppr_dat.Equals(txt_emp_ppr.Text.Trim())).FirstOrDefault();
                edc.Emp_Acts.DeleteOnSubmit(empA);
                edc.Emp_Datas.DeleteOnSubmit(empD);
                DialogResult dialogResult = MessageBox.Show("حذف?", "تأكيد الحذف", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    edc.SubmitChanges();
                    MessageBox.Show(txt_emp_name_ar.Text + "بنجاح" + "تم حذف");
                    var employees = (from emD in edc.Emp_Datas
                                     select new
                                     {
                                         ppr = emD.ppr_dat,
                                         nom = emD.NOMA + " " + emD.PRENOMA
                                     }).ToList();


                    cb_emp_select_emp.DataSource = new BindingSource(employees, null);
                    cb_emp_select_emp.DisplayMember = "nom";
                    cb_emp_select_emp.ValueMember = "ppr";
                }
                else if (dialogResult == DialogResult.No)
                {
                    btn_enp_cancel_Click(sender, e);
                }

            }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Schooly.Forms
{
    public partial class Frm_fet_import : Form
    {
        public Frm_fet_import()
        {
            InitializeComponent();
        }
        List<string> filesNames = new List<string> { };
        string fileToOpen = string.Empty;

        private void Frm_fet_import_Load(object sender, EventArgs e)
        {
            prbar_tt.Visible = false;

            if (cb_tt_D_lm1.Items.Count == 0)
            {
                btn_tt_imTT.Enabled = false;
            }
        }
         private void btn_tt_DS_Click(object sender, EventArgs e)
        {
            List<string> lstD = new List<string> { };
            List<string> lstS = new List<string> { };
            Workbook wb = null;

            if (btn_tt_imTT.Enabled == true)
            {
                cb_tt_D_lm1.Items.Clear();
                cb_tt_D_ls2.Items.Clear();
                cb_tt_D_mm3.Items.Clear();
                cb_tt_D_ms4.Items.Clear();
                cb_tt_D_mrm5.Items.Clear();
                cb_tt_D_mrs6.Items.Clear();
                cb_tt_D_jm7.Items.Clear();
                cb_tt_D_js8.Items.Clear();
                cb_tt_D_vm9.Items.Clear();
                cb_tt_D_vs10.Items.Clear();
                cb_tt_D_sm11.Items.Clear();
                cb_tt_D_ss12.Items.Clear();

                cb_tt_S_1.Items.Clear();
                cb_tt_S_2.Items.Clear();
                cb_tt_S_3.Items.Clear(); ;
                cb_tt_S_4.Items.Clear();
                filesNames.Clear();
                btn_tt_imTT.Enabled = false;
            }


            var FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                string dirToFet = FBD.SelectedPath;

                

                foreach (string f in Directory.GetFiles(dirToFet))
                {
                    if (f.EndsWith("_timetable.csv")) { filesNames.Add(f); }
                    if (f.EndsWith("_teachers.csv")) { filesNames.Add(f); }
                    if (f.EndsWith("_subjects.csv")) { filesNames.Add(f); }
                    if (f.EndsWith("_students.csv")) { filesNames.Add(f); }
                }
                string fileTt = string.Empty;


                if (filesNames != null && filesNames.Count == 4)
                {
                    fileTt = filesNames.Where(p => p.EndsWith("_timetable.csv")).ToList().FirstOrDefault();

                    var excapp = new Microsoft.Office.Interop.Excel.Application();
                    wb = excapp.Workbooks.Open(fileTt);
                    Worksheet sh0 = wb.Worksheets[1];
                    int l = sh0.UsedRange.Value2.GetLength(0);
                    var vcD = sh0.Range["B2:B" + l].Value2;
                    var vcS = sh0.Range["C2:C" + l].Value2;

                    for (int i = 1; i < l; i++)
                    {
                        for (int j = 1; j < vcD.GetLength(1) + 1; j++)
                        {
                            lstD.Add(vcD[i, j].ToString());
                        }
                    }
                    lstD = lstD.Distinct().ToList();
                    lstD.Add("فارغ");

                    for (int i = 1; i < l; i++)
                    {
                        for (int j = 1; j < vcS.GetLength(1) + 1; j++)
                        {
                            lstS.Add(vcS[i, j].ToString());
                        }
                    }
                    lstS = lstS.Distinct().ToList();
                    lstS.Add("فارغ");
                    wb.Close();
                    object item = string.Empty;

                    cb_tt_D_lm1.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_ls2.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_mm3.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_ms4.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_mrm5.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_mrs6.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_jm7.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_js8.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_vm9.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_vs10.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_sm11.Items.AddRange(lstD.ToArray<String>());
                    cb_tt_D_ss12.Items.AddRange(lstD.ToArray<String>());

                    cb_tt_S_1.Items.AddRange(lstS.ToArray<String>());
                    cb_tt_S_2.Items.AddRange(lstS.ToArray<String>());
                    cb_tt_S_3.Items.AddRange(lstS.ToArray<String>()); ;
                    cb_tt_S_4.Items.AddRange(lstS.ToArray<String>());

                    btn_tt_imTT.Enabled = true;
                    MessageBox.Show("تفضل بترتيب أنصاف الأيام و الحصص");

                    var allItems = cb_tt_S_1.Items.Cast<string>()
                                 .Select(i => i.ToString()).ToList();

                    object selectedItem = cb_tt_S_1.SelectedItem;




                    allItems.Sort();

                    try
                    {
                        cb_tt_S_1.SelectedItem = allItems[0];
                        cb_tt_S_2.SelectedItem = allItems[1];
                        cb_tt_S_3.SelectedItem = allItems[2];
                        cb_tt_S_4.SelectedItem = allItems[3];
                        lstD.Clear();
                        lstS.Clear();
                    }
                    catch (Exception)
                    {


                    }




                }







            }


        }







        private void cb_tt_D_lm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var allItems = cb_tt_D_lm1.Items.Cast<string>()
            .Select(item => item.ToString()).ToList();
            object selectedItem = cb_tt_D_lm1.SelectedItem;

            if (selectedItem.ToString() != allItems[allItems.Count - 1])
            {

                var searchRsult = (from name in allItems
                                   where name.StartsWith(selectedItem.ToString().Substring(0, 4))
                                   select name).ToList();

                cb_tt_D_ls2.SelectedItem = (searchRsult != null && searchRsult.Count > 1) ? (selectedItem.Equals(searchRsult[0]) ? searchRsult[1] : searchRsult[0]) : allItems[allItems.Count - 1];



            }
        }

        private void cb_tt_D_mm3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var allItems = cb_tt_D_lm1.Items.Cast<string>()
            .Select(item => item.ToString()).ToList();
            object selectedItem = cb_tt_D_mm3.SelectedItem;

            if (selectedItem.ToString() != allItems[allItems.Count - 1])
            {

                var searchRsult = (from name in allItems
                                   where name.StartsWith(selectedItem.ToString().Substring(0, 4))
                                   select name).ToList();

                cb_tt_D_ms4.SelectedItem = (searchRsult != null && searchRsult.Count > 1) ? (selectedItem.Equals(searchRsult[0]) ? searchRsult[1] : searchRsult[0]) : allItems[allItems.Count - 1];

            }
        }

        private void cb_tt_D_mrm5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var allItems = cb_tt_D_lm1.Items.Cast<string>()
           .Select(item => item.ToString()).ToList();
            object selectedItem = cb_tt_D_mrm5.SelectedItem;

            if (selectedItem.ToString() != allItems[allItems.Count - 1])
            {

                var searchRsult = (from name in allItems
                                   where name.StartsWith(selectedItem.ToString().Substring(0, 4))
                                   select name).ToList();


                cb_tt_D_mrs6.SelectedItem = (searchRsult != null && searchRsult.Count > 1) ? (selectedItem.Equals(searchRsult[0]) ? searchRsult[1] : searchRsult[0]) : allItems[allItems.Count - 1];

            }
        }

        private void cb_tt_D_jm7_SelectedIndexChanged(object sender, EventArgs e)
        {
            var allItems = cb_tt_D_lm1.Items.Cast<string>()
           .Select(item => item.ToString()).ToList();

            object selectedItem = cb_tt_D_jm7.SelectedItem;

            if (selectedItem.ToString() != allItems[allItems.Count - 1])
            {

                var searchRsult = (from name in allItems
                                   where name.StartsWith(selectedItem.ToString().Substring(0, 4))
                                   select name).ToList();

                cb_tt_D_js8.SelectedItem = (searchRsult != null && searchRsult.Count > 1) ? (selectedItem.Equals(searchRsult[0]) ? searchRsult[1] : searchRsult[0]) : allItems[allItems.Count - 1];

            }
        }

        private void cb_tt_D_vm9_SelectedIndexChanged(object sender, EventArgs e)
        {
            var allItems = cb_tt_D_lm1.Items.Cast<string>()
           .Select(item => item.ToString()).ToList();

            object selectedItem = cb_tt_D_vm9.SelectedItem;

            if (selectedItem.ToString() != allItems[allItems.Count - 1])
            {
                var searchRsult = (from name in allItems
                                   where name.StartsWith(selectedItem.ToString().Substring(0, 4))
                                   select name).ToList();

                foreach (string res in searchRsult)
                {
                    if (searchRsult != null && res != cb_tt_D_vm9.SelectedItem.ToString())
                    {
                        cb_tt_D_vs10.SelectedItem = res;

                    }
                    else
                    {
                        cb_tt_D_vs10.SelectedItem = allItems[allItems.Count - 1];
                    }
                }
            }
        }

        private void cb_tt_D_sm11_SelectedIndexChanged(object sender, EventArgs e)
        {
            var allItems = cb_tt_D_lm1.Items.Cast<string>()
           .Select(item => item.ToString()).ToList();

            object selectedItem = cb_tt_D_sm11.SelectedItem;

            if (selectedItem.ToString() != "فارغ")
            {
                var searchRsult = (from name in allItems
                                   where name.StartsWith(selectedItem.ToString().Substring(0, 4))
                                   select name).ToList();

                cb_tt_D_ss12.SelectedItem = (searchRsult != null && searchRsult.Count > 1) ? (selectedItem.Equals(searchRsult[0]) ? searchRsult[1] : searchRsult[0]) : allItems[allItems.Count - 1];

            }

        }

        private void btn_tt_imTT_Click(object sender, EventArgs e)
        {
            try
            {


                //   string con = "Data Source =.; Initial Catalog = forfet; Integrated Security = True";
                fetDataContext db = new fetDataContext();

            db.ExecuteCommand("TRUNCATE TABLE elevess");
            db.ExecuteCommand("TRUNCATE TABLE subjects");
            db.ExecuteCommand("TRUNCATE TABLE techers");
            db.ExecuteCommand("TRUNCATE TABLE timetable");

            var excapp = new Microsoft.Office.Interop.Excel.Application();
            string filett = filesNames.Where(p => p.EndsWith("_timetable.csv")).ToList().FirstOrDefault();
            string fileSt = filesNames.Where(p => p.EndsWith("_students.csv")).ToList().FirstOrDefault();
            string filetech = filesNames.Where(p => p.EndsWith("_teachers.csv")).ToList().FirstOrDefault();
            string filesub = filesNames.Where(p => p.EndsWith("_subjects.csv")).ToList().FirstOrDefault();


            if (cb_tt_D_lm1.Text != string.Empty &&
                cb_tt_D_ls2.Text != string.Empty &&
                cb_tt_D_mm3.Text != string.Empty &&
                cb_tt_D_ms4.Text != string.Empty &&
                cb_tt_D_mrm5.Text != string.Empty &&
                cb_tt_D_mrs6.Text != string.Empty &&
                cb_tt_D_jm7.Text != string.Empty &&
                cb_tt_D_js8.Text != string.Empty &&
                cb_tt_D_vm9.Text != string.Empty &&
                cb_tt_D_vs10.Text != string.Empty &&
                cb_tt_D_sm11.Text != string.Empty &&
                cb_tt_D_ss12.Text != string.Empty &&
                cb_tt_S_1.Text != string.Empty &&
                cb_tt_S_2.Text != string.Empty &&
                cb_tt_S_3.Text != string.Empty &&
                cb_tt_S_4.Text != string.Empty
                )
            {
                List<string> its = new List<string> { };



                its.Add(cb_tt_D_lm1.Text);
                its.Add(cb_tt_D_ls2.Text);
                its.Add(cb_tt_D_mm3.Text);
                its.Add(cb_tt_D_ms4.Text);
                its.Add(cb_tt_D_mrm5.Text);
                its.Add(cb_tt_D_mrs6.Text);
                its.Add(cb_tt_D_jm7.Text);
                its.Add(cb_tt_D_js8.Text);
                its.Add(cb_tt_D_vm9.Text);
                its.Add(cb_tt_D_vs10.Text);
                its.Add(cb_tt_D_sm11.Text);
                its.Add(cb_tt_D_ss12.Text);
                its.Add(cb_tt_S_1.Text);
                its.Add(cb_tt_S_2.Text);
                its.Add(cb_tt_S_3.Text);
                its.Add(cb_tt_S_4.Text);

                var query = its.GroupBy(x => x)
               .Where(g => g.Count() > 1)
               .Select(y => new { Element = y.Key, Counter = y.Count() })
               .ToList();

              

                if (query.Count > 0)
                {
                    var notEmpty = query.Where(p => !p.Element.Equals("فارغ")).ToList();
                    var notGr3 = query.Where(p => p.Counter > 3).ToList();
                    if (notEmpty.Count > 0 | notGr3.Count > 0)
                    {
                        MessageBox.Show("هناك أنصاف أيام مكررة أو غير مدرجة");

                        foreach (var item in notGr3)
                        {
                            var comboBoxes = this.Controls
                          .OfType<ComboBox>()
                          .Where(x => x.SelectedItem.Equals(item.Element));
                            foreach (var cmbBox in comboBoxes)
                            {
                                cmbBox.SelectedItem = string.Empty;

                            }

                        }
                        foreach (var item in notEmpty)
                        {
                            var comboBoxes = this.Controls
                          .OfType<ComboBox>()
                          .Where(x => x.SelectedItem.Equals(item.Element));
                            foreach (var cmbBox in comboBoxes)
                            {
                                cmbBox.SelectedItem = string.Empty;
                            }

                        }


                    }
                    else
                    {
                        string message = "هل ترتيب الأيام و الحصص صحيح؟، إذا كان هناك خطأ فإن جداول الحصص لن تكون منظمة ";
                        string title = "تأكيد الترتيب";
                        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.OK)
                        {

                            ////******************** timetable  ***************
                            System.IO.FileInfo ftt = new System.IO.FileInfo(filett);


                            if (ftt.Exists)
                            {

                                Workbook wb = excapp.Workbooks.Open(filett);
                                Worksheet sh0 = wb.Worksheets[1];
                                var lstTT = sh0.UsedRange.Value2;


                                for (int i = 2; i <= lstTT.GetLength(0); i++)
                                {
                                    prbar_tt.Visible = true;
                                    prbar_tt.Maximum = 2;
                                    prbar_tt.Maximum = lstTT.GetLength(0);
                                    if (lstTT[i, 2] == cb_tt_D_lm1.Text) { lstTT[i, 2] = "1"; }
                                    if (lstTT[i, 2] == cb_tt_D_ls2.Text) { lstTT[i, 2] = "2"; }
                                    if (lstTT[i, 2] == cb_tt_D_mm3.Text) { lstTT[i, 2] = "3"; }
                                    if (lstTT[i, 2] == cb_tt_D_ms4.Text) { lstTT[i, 2] = "4"; }
                                    if (lstTT[i, 2] == cb_tt_D_mrm5.Text) { lstTT[i, 2] = "5"; }
                                    if (lstTT[i, 2] == cb_tt_D_mrs6.Text) { lstTT[i, 2] = "6"; }
                                    if (lstTT[i, 2] == cb_tt_D_jm7.Text) { lstTT[i, 2] = "7"; }
                                    if (lstTT[i, 2] == cb_tt_D_js8.Text) { lstTT[i, 2] = "8"; }
                                    if (lstTT[i, 2] == cb_tt_D_vm9.Text) { lstTT[i, 2] = "9"; }
                                    if (lstTT[i, 2] == cb_tt_D_vs10.Text) { lstTT[i, 2] = "10"; }
                                    if (lstTT[i, 2] == cb_tt_D_sm11.Text) { lstTT[i, 2] = "11"; }
                                    if (lstTT[i, 2] == cb_tt_D_ss12.Text) { lstTT[i, 2] = "12"; }

                                    if (lstTT[i, 3] == cb_tt_S_1.Text) { lstTT[i, 3] = "1"; }
                                    if (lstTT[i, 3] == cb_tt_S_2.Text) { lstTT[i, 3] = "2"; }
                                    if (lstTT[i, 3] == cb_tt_S_3.Text) { lstTT[i, 3] = "3"; }
                                    if (lstTT[i, 3] == cb_tt_S_4.Text) { lstTT[i, 3] = "4"; }
                                    prbar_tt.Value = i;
                                }

                                prbar_tt.Visible = false;
                                for (int i = 2; i <= lstTT.GetLength(0); i++)
                                {

                                    string col1 = lstTT[i, 1] != null ? lstTT[i, 1].ToString() : string.Empty;
                                    int col2 = lstTT[i, 2] != null ? int.Parse(lstTT[i, 2].ToString()) : 0;
                                    int col3 = lstTT[i, 3] != null ? int.Parse(lstTT[i, 3].ToString()) : 0;
                                    string col4 = lstTT[i, 4] != null ? lstTT[i, 4].ToString() : string.Empty;
                                    string col5 = lstTT[i, 5] != null ? lstTT[i, 5].ToString() : string.Empty;
                                    string col6 = lstTT[i, 6] != null ? lstTT[i, 6].ToString() : string.Empty;
                                    string col7 = lstTT[i, 7] != null ? lstTT[i, 7].ToString() : string.Empty;
                                    string col8 = lstTT[i, 8] != null ? lstTT[i, 8].ToString() : string.Empty;
                                    string col9 = lstTT[i, 9] != null ? lstTT[i, 9].ToString() : string.Empty;


                                    prbar_tt.Visible = true;
                                    prbar_tt.Maximum = 2;
                                    prbar_tt.Maximum = lstTT.GetLength(0);
                                    timeTable tt = new timeTable
                                    {
                                        ActivityId = col1,
                                        Day = int.Parse(col2.ToString()),
                                        Hour = int.Parse(col3.ToString()),
                                        StudentsSets = col4,
                                        Subject = col5,
                                        Teachers = col6,
                                        ActivityTags = col7,
                                        Room = col8,
                                        Comments = col9,
                                        gresa_tt_fet = Tools.Globals.GRESA
                                    };

                                    db.timeTables.InsertOnSubmit(tt);
                                    prbar_tt.Value = i;
                                }

                                db.SubmitChanges();
                                wb.Close();
                                //lstTT.Clear();
                            }
                            //**************end timtable ***************
                            //*************studentsSet ***************


                            System.IO.FileInfo fst = new System.IO.FileInfo(fileSt);

                            if (fst.Exists)
                            {

                                Workbook wb = excapp.Workbooks.Open(fileSt);
                                Worksheet shst = wb.Worksheets[1];
                                var lstSt = shst.UsedRange.Value2;

                                prbar_tt.Visible = false;

                                for (int i = 2; i <= lstSt.GetLength(0); i++)
                                {
                                    prbar_tt.Visible = true;
                                    prbar_tt.Maximum = 2;
                                    prbar_tt.Maximum = lstSt.GetLength(0);
                                    string col1 = lstSt[i, 1] != null ? lstSt[i, 1].ToString() : string.Empty;
                                    int col2 = lstSt[i, 2] != null ? int.Parse(lstSt[i, 2].ToString()) : 0;
                                    string col3 = lstSt[i, 3] != null ? lstSt[i, 3].ToString() : string.Empty;
                                    int col4 = lstSt[i, 4] != null ? int.Parse(lstSt[i, 4].ToString()) : 0;
                                    string col5 = lstSt[i, 5] != null ? lstSt[i, 5].ToString() : string.Empty;
                                    int col6 = lstSt[i, 6] != null ? int.Parse(lstSt[i, 6].ToString()) : 0;




                                    elevess st = new elevess
                                    {
                                        Year = col1,
                                        NuOfStPerYear = col2,
                                        groups = col3,
                                        NuOfStPerGroup = col4,
                                        Subgroup = col5,
                                        NuOfStPerSubgroup = col6,
                                        gresa_el_fet = Tools.Globals.GRESA

                                    };

                                    db.elevesses.InsertOnSubmit(st);
                                    prbar_tt.Value = i;
                                }
                                db.SubmitChanges();
                                wb.Close();
                            }
                            prbar_tt.Visible = false;

                            //******************end studentsSet *********

                            //****************subject **********************


                            System.IO.FileInfo fsub = new System.IO.FileInfo(filesub);

                            if (fsub.Exists)
                            {
                                Workbook wb = excapp.Workbooks.Open(filesub);
                                Worksheet sh_Subject = wb.Worksheets[1];
                                var lstSub = sh_Subject.UsedRange.Value2;

                                for (int i = 2; i <= lstSub.GetLength(0); i++)
                                {
                                    string col1 = lstSub[i, 1] != null ? lstSub[i, 1].ToString() : string.Empty;


                                    prbar_tt.Visible = true;
                                    prbar_tt.Maximum = 2;
                                    prbar_tt.Maximum = lstSub.GetLength(0);
                                    subject sub = new subject
                                    {
                                        Subject1 = col1,
                                        gresa_sub_fet = Tools.Globals.GRESA

                                    };

                                    db.subjects.InsertOnSubmit(sub);
                                    prbar_tt.Value = i;
                                }
                                db.SubmitChanges();
                                //lstSub.Clear();
                            }
                            prbar_tt.Visible = false;


                            //************** end subject **************

                            //***************************teachers **********************
                            System.IO.FileInfo fteach = new System.IO.FileInfo(filetech);

                            if (fteach.Exists)
                            {
                                Workbook wb = excapp.Workbooks.Open(filetech);
                                Worksheet sh_Teachear = wb.Worksheets[1];
                                var lstteach = sh_Teachear.UsedRange.Value2;

                                for (int i = 2; i <= lstteach.GetLength(0); i++)
                                {
                                    string col1 = lstteach[i, 1] != null ? lstteach[i, 1].ToString() : string.Empty;

                                    prbar_tt.Visible = true;
                                    prbar_tt.Maximum = 2;
                                    prbar_tt.Maximum = lstteach.GetLength(0);
                                    techer tech = new techer
                                    {
                                        Teacher = col1,
                                        gresa_tech_fet = Tools.Globals.GRESA

                                    };

                                    db.techers.InsertOnSubmit(tech);
                                    prbar_tt.Value = i;
                                }
                                db.SubmitChanges();
                                //lstteach.Clear();
                                //*************************end teachers ***********
                                wb.Close();
                                this.Close();
                                MessageBox.Show("تم مسك مخرجات فيت بنجاح");
                            }
                        }


                    }
                }


            }
            else { MessageBox.Show("هناك خانة أو  خانات فارغة"); }


        }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
}

        private void btn_tt_clos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

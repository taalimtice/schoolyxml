using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly.Tools
{

   public  class Tool
    {
        public void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore non-digit characters
            }
        }


        public void closeChild(Form formToClose)
        {
            foreach (Form form in Application.OpenForms)
            {

                if (form.Name == formToClose.Name)
                {
                    form.Close();
                    break;
                }
            }
        }

        public Form GetForm(Form formToGet)
        {
            Form frmToget = null;
            foreach (Form form in Application.OpenForms)
            {

                if (form.Name == formToGet.Name)
                {
                    frmToget = form;
                    break;
                }
            }
            return frmToget;
        }
       
        public void FillDatepicker(DateTimePicker dtp ,string dt)
        {   
            DateTime date = DateTime.Parse(dt, new CultureInfo("ar-MA", true));
            if (date > DateTime.FromOADate(0))
            {
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = "dd-MM-yyyy";
                dtp.Value = date;
                dtp.Enabled = true;
            }
            else
            {
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = " ";
                dtp.Value = DateTime.FromOADate(0);
                dtp.Enabled = false;
            }



        }
        public void FillDatepickerChecked(DateTimePicker dtp, DateTime? dt)
        {
            if (dt == null)
            {
                dtp.Checked = false;

            }else
            {
                dtp.Checked = true;
                dtp.Value =(DateTime )dt;
            }



        }

        public DateTime? GetDate(DateTimePicker dtp)
        {
            if (dtp.Text.Trim() == string.Empty)
            { return (DateTime?)null; }
            else
            {
                return dtp.Value.Date;
            }
        }
        public TimeSpan? GetTimeOfDay(DateTimePicker dtp)
        {
            if (dtp.Text.Trim() == string.Empty)
            { return (TimeSpan?)null; }
            else
            {
                return dtp.Value.TimeOfDay;
            }
        }
        public DateTime? GetDateChecked(DateTimePicker dtp)
        {
            if (dtp.Checked==false)
            { return (DateTime?)null; }
            else
            {
                return dtp.Value.Date;
            }
        }

        public TimeSpan? GetTimeOfDayChecked(DateTimePicker dtp)
        {
            if (dtp.Checked==false)
            { return (TimeSpan ?)null; }
            else
            {
                return dtp.Value.TimeOfDay;
            }
        }
       
        public string getselectedComboifZero(ComboBox cb)
        {
            if (cb.Items.Count > 0)
            {
                return cb.GetItemText(cb.SelectedItem);
            }else
            {
                return string.Empty;
            }
        }

    }


    //public class MyDateTimePicker : DateTimePicker
    //{
    //    // ... some stuff

    //    protected override void OnValueChanged(EventArgs eventargs)
    //    {
    //        //System.Diagnostics.Debug.Write("Clicked -  ");
    //        // System.Diagnostics.Debug.WriteLine(this.Value);
    //        // MessageBox.Show("Clicked -  ");
    //        // MessageBox.Show(this.Value.ToString());
    //       // base.OnValueChanged(eventargs);
    //    }

    //    protected override void OnCloseUp(EventArgs eventargs)
    //    {
    //        //System.Diagnostics.Debug.Write("Closed -  ");
    //        //System.Diagnostics.Debug.WriteLine(this.Value);
    //        //base.OnCloseUp(eventargs);
    //    }

    //    // some more stuff ...
    //}

    public static class extenstions
    {
        private static Dictionary<Type, Action<Control>> controldefaults = new Dictionary<Type, Action<Control>>() {
            {typeof(TextBox), c => ((TextBox)c).Clear()},
            {typeof(RichTextBox), c => ((RichTextBox)c).Clear()},
            {typeof(CheckBox), c => ((CheckBox)c).Checked = false},
            {typeof(ListBox), c => ((ListBox)c).Items.Clear()},
            {typeof(RadioButton), c => ((RadioButton)c).Checked = false},
            {typeof(GroupBox), c => ((GroupBox)c).Controls.ClearControls()},
            {typeof(Panel), c => ((Panel)c).Controls.ClearControls()},
            {typeof(ComboBox), c => ((ComboBox)c).Text="اختر الخيار المناسب"},
           // {typeof(DateTimePicker), c => ((DateTimePicker)c).Format=DateTimePickerFormat.Custom},
             {typeof(DateTimePicker), c => ((DateTimePicker)c).CustomFormat=" "}

    };

        private static void FindAndInvoke(Type type, Control control)
        {
            if (controldefaults.ContainsKey(type))
            {
                controldefaults[type].Invoke(control);
            }
        }

        public static void ClearControls(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                FindAndInvoke(control.GetType(), control);
            }
        }

        public static void ClearControls<T>(this Control.ControlCollection controls) where T : class
        {
            if (!controldefaults.ContainsKey(typeof(T))) return;

            foreach (Control control in controls)
            {
                if (control.GetType().Equals(typeof(T)))
                {
                    FindAndInvoke(typeof(T), control);
                }
            }

        }

        //public static void Truncate<TEntity>(this Table<TEntity> table) where TEntity : class
        //{
        //    var rowType = table.GetType().GetGenericArguments()[0];
        //    var tableName = table.Context.Mapping.GetTable(rowType).TableName;
        //    var sqlCommand = String.Format("TRUNCATE TABLE {0}", tableName);
        //    table.Context.ExecuteCommand(sqlCommand);
        //}

    }
    public class Globals
        {
            private static string _GRESA;
            public static string GRESA
            {
                get
                {
                    // Reads are usually simple
                    return _GRESA;
                }
                set
                {
                    // You can add logic here for race conditions,
                    // or other measurements
                    _GRESA = value;
                }
            }
            // Perhaps extend this to have Read-Modify-Write static methods
            // for data integrity during concurrency? Situational.



        }
   
    }


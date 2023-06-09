using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace Schooly.Forms
{
    public partial class Frm_exam : Form
    {
        public Frm_exam()
        {
            InitializeComponent();
        }
     
       
        private void btn_import_st_database_Click(object sender, EventArgs e)
        {
            cb_drag_nivs.Visible = true;
            listBox1.Visible = true;

            StudentsListDataContext stdc = new StudentsListDataContext();
            var st = stdc.StudentListUpdates.Where(w => w.gresa_Up == Tools.Globals.GRESA).Select(s => s.niveau_Up).Distinct().ToList();

            using (var db = new examenDataContext())
            {
                var restlvls = db.level_exes;
                db.level_exes.DeleteAllOnSubmit(restlvls);
                db.SubmitChanges();
            }

            cb_drag_nivs.DataSource = st;
            cb_drag_nivs.DisplayMember = "niveau_Up"; // Display the category name
            // cb_drag_nivs.ValueMember = "CategoryId"; // Set the category ID as the value
            if (cb_drag_nivs.Items.Count > 0)
                cb_drag_nivs.SelectedIndex = 0;
        }

        private void btn_import_st_excel_Click(object sender, EventArgs e)
        {
            cb_drag_nivs.Visible = false;
            listBox1.Visible = false;
        }


        private void Frm_exam_Load(object sender, EventArgs e)
        {
            // Set the Format property to Time
            dtp_starttime.Format = DateTimePickerFormat.Custom;
            dtp_endtime.Format = DateTimePickerFormat.Custom;

            // Set the CustomFormat property to specify the time format
            dtp_starttime.CustomFormat = "HH:mm";
            dtp_endtime.CustomFormat = "HH:mm";

            // Hide the up-down control used for changing the date
            dtp_starttime.ShowUpDown = true;
            dtp_endtime.ShowUpDown = true;



            cb_drag_nivs.MouseDown += ComboBox1_MouseDown;
            cb_drag_nivs.GiveFeedback += ComboBox1_GiveFeedback;
            listBox1.MouseDoubleClick += ListBox1_MouseDoubleClick;

            // Enable drag and drop for the ListBox
            listBox1.AllowDrop = true;
            listBox1.DragEnter += ListBox1_DragEnter;
            listBox1.DragDrop += ListBox1_DragDrop;

        }
        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Check if an item is selected
            if (listBox1.SelectedItem != null)
            {
                var item = listBox1.SelectedItem;
                   

                    // Remove the item from the ComboBox's data source
                    List<string> dataSource = (List<string>)cb_drag_nivs.DataSource;
                    dataSource.Add(item.ToString());
                    cb_drag_nivs.DataSource = null;
                    cb_drag_nivs.DataSource = dataSource;
                if (cb_drag_nivs.Items.Count > 0)
                    cb_drag_nivs.SelectedIndex = 0;

             
                // cb_drag_nivs.Items.Add(listBox1.SelectedItem);

                // Remove the item from listBox1
                listBox1.Items.Remove(item);
                cb_branch.Items.Remove(item);

                // remve item from database
                using (var db = new examenDataContext())
                {
                    level_ex lvlToDelete = db.level_exes.Where(w => w.level_name == item.ToString()).FirstOrDefault();
                    db.level_exes.DeleteOnSubmit(lvlToDelete);
                    db.SubmitChanges();
                }


            }
        }
        private void ComboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (cb_drag_nivs.SelectedItem != null)
            {
                // Perform the drag-and-drop operation only if the ComboBox is not in the dropped-down state
                if (!cb_drag_nivs.DroppedDown)
                {
                    cb_drag_nivs.DoDragDrop(cb_drag_nivs.SelectedItem, DragDropEffects.Move);
                }
            }
        }

        private void ComboBox1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = true;
        }

        private void ListBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ListBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                string item = (string)e.Data.GetData(typeof(string));
                listBox1.Items.Add(item);

                // Remove the item from the ComboBox's data source
                List<string> dataSource = (List<string>)cb_drag_nivs.DataSource;
                dataSource.Remove(item);
                cb_drag_nivs.DataSource = null;
                cb_drag_nivs.DataSource = dataSource;
                if (cb_drag_nivs.Items.Count > 0)
                    cb_drag_nivs.SelectedIndex = 0;
            }

           


        }


        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Assuming you have a DateTimePicker named dtp_dayOfExam and a DateTimePicker named dtp_starttime and dtp_endtime

            // Retrieve the selected date from DateTimePicker
            DateTime selectedDate = dtp_dayOfExam.Value;

            // Retrieve the selected time range from DateTimePicker
            TimeSpan startTime = dtp_starttime.Value.TimeOfDay;
            TimeSpan endTime = dtp_endtime.Value.TimeOfDay;

            // Create an instance of the CultureInfo class for Arabic
            CultureInfo arabicCulture = new CultureInfo("ar-SA");
            // Set the calendar to the Gregorian calendar
            arabicCulture.DateTimeFormat.Calendar = new GregorianCalendar();


            // Extract the day, start time, and end time
            string day = selectedDate.ToString("dddd", arabicCulture); // Full day name in Arabic
            string month = selectedDate.ToString("MMMM", arabicCulture);
            string startTimeString = startTime.ToString(); // Start time in TimeSpan format
            string endTimeString = endTime.ToString(); // End time in TimeSpan format

            // Extract the hour and minute from the start time
            int startHour = startTime.Hours;
            int startMinute = startTime.Minutes;

            // Extract the hour and minute from the end time
            int endHour = endTime.Hours;
            int endMinute = endTime.Minutes;

            // Remove the seconds component from the start time
            TimeSpan startTimeWithoutSeconds = new TimeSpan(startTime.Hours, startTime.Minutes, 0);

            // Remove the seconds component from the end time
            TimeSpan endTimeWithoutSeconds = new TimeSpan(endTime.Hours, endTime.Minutes, 0);

            // Calculate the time difference
            TimeSpan duration = endTimeWithoutSeconds - startTimeWithoutSeconds;

            // Remove the seconds component from the start time
            //startTime = startTime.AddSeconds(-startTime.Second);

            // Remove the seconds component from the end time
           // endTime = endTime.AddSeconds(-endTime.Second);


           // TimeSpan duration = endTime - startTime;
            int hours = (int)duration.TotalHours;
            int minutes = (int)duration.TotalMinutes % 60;

            examenDataContext exdc = new examenDataContext();
            subject_ex sub = new subject_ex
            {
                subject_name_ex = txt_subject.Text,
                day_ex = day,
                start_hour_ex = startHour,
                start_minute_ex = startMinute,
                end_hour_ex = endHour,
                end_minute_ex = endMinute,
              //  level_id = Convert.ToInt16(cb_branch.GetItemText(cb_branch.SelectedValue))

            };

            exdc.subject_exes.InsertOnSubmit(sub);
            exdc.SubmitChanges();


            txt_DurationofExam.Text = hours.ToString("00") + ":" + minutes.ToString("00");
           string resumee = $"المادة {txt_subject} تجري بالنسبة للمستوى/الشعبة {cb_branch.GetItemText(cb_branch.SelectedItem)} من {startHour.ToString("00")}:{startMinute.ToString("00")} إلى {endHour.ToString("00")}:{endMinute.ToString("00")}.";

          //  // string resumee = $"المادة <span style=\"color:green\"></span>{txt_subject}</span> تجري بالنسبة للمستوى/الشعبة  <span style=\"color:green\">{cb_branch.GetItemText(cb_branch.SelectedItem)}</span> من  <span style=\"color:green\">{startHour.ToString("00")}:{startMinute.ToString("00")}</span> إلى  <span style=\"color:green\">{endHour.ToString("00")}:{endMinute.ToString("00")}</span>.";
          //  // string resumee = $"المادة \u001b[32m{txt_subject.Text}\u001b[0m تجري بالنسبة للمستوى//الشعبة \u001b[32m{cb_branch.GetItemText(cb_branch.SelectedItem)}\u001b[0m من \u001b[32m{startHour.ToString("00")}:{startMinute.ToString("00")}\u001b[0m إلى \u001b[32m{endHour.ToString("00")}:{endMinute.ToString("00")}\u001b[0m.";
          ////  string resumee = $"لمادة <span style=\"color:green\">{txt_subject}</span> تجري بالنسبة للمستوى/الشعبة  <span style=\"color:green\">{cb_branch.GetItemText(cb_branch.SelectedItem)}</span> من  <span style=\"color:green\">{startTime}</span> إلى  <span style=\"color:green\">{endTime}</span>.";


            txt_resumee.Text = resumee;

          //  // Display the values using MessageBox
          //  MessageBox.Show("Day (Arabic): " + day);
          //  MessageBox.Show("month (Arabic): " + month);
          //  MessageBox.Show("Start Time: " + startHour.ToString("00") + ":" + startMinute.ToString("00"));
          //  MessageBox.Show("End Time: " + endHour.ToString("00") + ":" + endMinute.ToString("00"));

        }

        private void dtp_starttime_ValueChanged(object sender, EventArgs e)
        {
            // Assuming you have a DateTimePicker named dateTimePicker1

            // Retrieve the selected date and time from the DateTimePicker
            DateTime selectedDateTime = dtp_starttime.Value;

            // Add one hour to the selected DateTime
            DateTime updatedDateTime = selectedDateTime.AddHours(1);

            // Set the updated DateTime back to the DateTimePicker
            dtp_endtime.Value = updatedDateTime;

        }

        private void dtp_endtime_ValueChanged(object sender, EventArgs e)
        {
            // Assuming you have a DateTimePicker named dateTimePicker1 and dateTimePicker2

            // Retrieve the selected date from DateTimePicker1
            DateTime selectedDate1 = dtp_starttime.Value;

            // Retrieve the selected date and time from DateTimePicker2
            DateTime selectedDate2 = dtp_endtime.Value;

            // Check if the selected date from DateTimePicker2 is the same as the selected date from DateTimePicker1
            if (selectedDate2.Date != selectedDate1.Date)
            {

                // The selected date from DateTimePicker2 is not the same day as the selected date from DateTimePicker1
                MessageBox.Show("Please select a date in the same day as DateTimePicker1.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                return; // Exit the method or perform necessary actions based on your requirement
            }
            // Assuming you have DateTimePicker controls named dateTimePicker1 and dateTimePicker2

           

            // Check if the selected DateTime from DateTimePicker2 is before or equal to DateTimePicker1
            if (selectedDate2 <= selectedDate1)
            {
                // Assuming you have a DateTimePicker named dateTimePicker1

                // Retrieve the selected date and time from the DateTimePicker
                DateTime selectedDateTime = dtp_starttime.Value;

                // Add one hour to the selected DateTime
                DateTime updatedDateTime = selectedDateTime.AddHours(1);

                // Set the updated DateTime back to the DateTimePicker
                dtp_endtime.Value = updatedDateTime;
                // The selected DateTime from DateTimePicker2 is before or equal to DateTimePicker1
                MessageBox.Show("Please select a date and time after DateTimePicker1.", "Invalid Date and Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return; // Exit the method or perform necessary actions based on your requirement
            }




        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cb_branch.Items.Count > 0)
                cb_branch.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selected_level = cb_drag_nivs.GetItemText(cb_drag_nivs.SelectedItem);
            if (!listBox1.Items.Contains(selected_level))
            {
                listBox1.Items.Add(selected_level);

                // insert new level of exam
                using (var db = new examenDataContext())
                {

                    if (selected_level != string.Empty)
                    {
                        // Create a new instance of the entity class
                        var newRecord = new level_ex
                        {
                            level_name = selected_level

                            // Assign other properties as needed
                        };

                        // Insert the record into the database
                        db.level_exes.InsertOnSubmit(newRecord);

                    }


                    // Submit all changes to the database
                    db.SubmitChanges();

                   
                   
                    bool containsValue = false;

                    foreach (var item in cb_branch.Items)
                    {
                     
                        var displayValue = item.GetType().GetProperty("DisplayValue")?.GetValue(item)?.ToString();

                        if (displayValue == selected_level)
                        {
                            containsValue = true;
                            break;
                        }
                    }

                    if (!containsValue)
                    {
                        var data = db.level_exes.ToList();
                        MessageBox.Show(data.Count.ToString());
                        // Iterate through the data and add items to the ComboBox
                        foreach (var item in data)
                        {
                            // Access the display and value members
                            var displayValue = item.level_name;
                            var value = item.level_id;


                            // Create a new ComboBox item and add it to the ComboBox
                            cb_branch.Items.Add(new { DisplayValue = displayValue, ID = value });
                        }

                        // Set the DisplayMember and ValueMember properties
                        cb_branch.DisplayMember = "DisplayValue";
                        cb_branch.ValueMember = "ID";

                        cb_branch.SelectedIndex = 0;

                    }



                }

            }
        
        }

        private void btn_reset_ex_Click(object sender, EventArgs e)
        {
            using (var db = new examenDataContext())
            {
                // Retrieve all records from the table
                var lvls = db.level_exes.ToList();
                var subjets = db.subject_exes.ToList();
                var students = db.students_exes.ToList();

                // Delete all records from the table
                db.level_exes.DeleteAllOnSubmit(lvls);
                db.subject_exes.DeleteAllOnSubmit(subjets);
                db.students_exes.DeleteAllOnSubmit(students);


                // Submit the changes to the database
                db.SubmitChanges();
            }

            listBox1.Items.Clear();
            cb_branch.Items.Clear();
            cb_branch.Text = "";
        }
    }
}



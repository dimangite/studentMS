using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class ClassSettting : Form
    {
        public ClassSettting()
        {
            InitializeComponent();
        }
        List<Class> c = new List<Class>();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //(this.Owner as ToolMenu).btnHome_Click(sender, e);
        }

        private void ClassSettting_Load(object sender, EventArgs e)
        {
            Database.Open();
            LoadClass();
        }

        public void LoadClass()
        {
            c = Class.GetAllClasses();
            dataGridViewClass.Rows.Clear();
            foreach (Class s in c)
            {
                dataGridViewClass.Rows.Add(s.subUserId, s.ClassName, s.StartDate ,s.Year, s.Semester,s.SessionNumber);
            }

        }

        public void LoadEdit(int id)
        {
            Class c = new Class();
            c = Class.GetSelected(id);
            label3.Text = c.subUserId.ToString();
            txtClassName.Text = c.ClassName;
            txtSession.Text = c.SessionNumber.ToString();
            dateTimePickerStartDate.Text = c.StartDate.ToShortDateString();
            comboBoxYear.Text = c.Year.ToString();
            comboBoxSemseter.Text = c.Semester.ToString();
        }

        private void ClassSettting_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }
        public int rowIndex;
        private void dataGridViewClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewClass.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            dataGridViewClass.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            rowIndex = Int16.Parse(dataGridViewClass.SelectedCells[0].Value.ToString());
            LoadEdit(rowIndex);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Class c = new Class();
            c.subUserId = Int16.Parse(label3.Text);
            c.ClassName = txtClassName.Text;
            c.Semester = Int16.Parse(comboBoxSemseter.Text);
            c.SessionNumber = Int16.Parse(txtSession.Text);
            c.StartDate = Convert.ToDateTime(dateTimePickerStartDate.Text);
            c.Year = Int16.Parse(comboBoxYear.Text);
            Class.Update(c);
            LoadClass();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to delete: Class" +txtClassName.Text , "Delete Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
            Class.Delete(Int16.Parse(label3.Text));
            InitInfo();
            LoadClass();
            }

        }
        public void InitInfo()
        {
            label3.Text = "0";
            txtClassName.Text = "";
            txtSession.Text = "";
            dateTimePickerStartDate.Text = "";
            comboBoxYear.Text = "";
            comboBoxSemseter.Text = "";
        }
    }


}

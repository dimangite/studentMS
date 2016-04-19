using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class SC_Edit : Form
    {
        public SC_Edit()
        {
            InitializeComponent();
        }
        private void SC_List_Load(object sender, EventArgs e)
        {
            Database.Open();
            StudentScoreDB.EditLoad();
            lbName.Text = StudentScoreDB.Fullname;
            txtHomework.Text = StudentScoreDB.Homework;
            txtQuiz.Text = StudentScoreDB.Quiz;
            txtAssignment.Text = StudentScoreDB.Assignment;
            txtMidterm.Text = StudentScoreDB.Midterm;
            txtAttendent.Text = StudentScoreDB.Attendent;
            txtFinal.Text = StudentScoreDB.Final;
        }
        public void btnCencel_Click(object sender, EventArgs e)
        {
            (this.Owner as StudentScore).btnList_Click(sender, e);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {

                float Homework = float.Parse(txtHomework.Text);
                float Quiz = float.Parse(txtQuiz.Text);
                float Assignment = float.Parse(txtAssignment.Text);
                float Midterm = float.Parse(txtMidterm.Text);
                float Attendent = float.Parse(txtAttendent.Text);
                float Final = float.Parse(txtFinal.Text);
                StudentScoreDB.EditUpdate(Homework, Quiz, Assignment, Midterm, Attendent, Final);
                (this.Owner as StudentScore).btnList_Click(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all score", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void SC_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            ///
            txtHomework.MaxLength = 3;
            txtQuiz.MaxLength = 3;
            txtAssignment.MaxLength = 3;
            txtMidterm.MaxLength = 3;
            txtAttendent.MaxLength = 3;
            txtFinal.MaxLength = 3;
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void SC_Edit_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }
    }
}

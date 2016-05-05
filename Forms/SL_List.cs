using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using StudentManagementSystem.Forms;

namespace StudentManagementSystem
{
    public partial class SL_List : Form
    {
        static List<StudentListDB> Mystudent;
        public string PhotoPath;

        public SL_List()
        {
            InitializeComponent();
        }

        public void LoadStudent()
        {
            Mystudent = StudentListDB.GetAllStudents();
            string gender;
            dataGridViewScore.Rows.Clear();
            foreach (StudentListDB s in Mystudent)
	        {
                if (s.Gender==true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }
                dataGridViewScore.Rows.Add(s.Id, s.Name, gender, s.Phone);
	        }
           
        }

        private void SL_List_Load(object sender, EventArgs e)
        {
            Database.Open();
            LoadStudent();
        }

        private void SL_List_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }
        public static int rowIndex = -1;
        private void dataGridViewScore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewScore.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            dataGridViewScore.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            rowIndex = Int16.Parse(dataGridViewScore.SelectedCells[0].Value.ToString());
            pictureCircle.ImageLocation = GetSelected().PhotoPath;
        }
        //private StudentListDB student = new StudentListDB();
        public StudentListDB GetSelected()
        {
            if (rowIndex<0)
            {
                return null;
               // (this.Owner as StudentList)
            }
            else
            {
                int id=-1;
                foreach (StudentListDB s in Mystudent)
                {
                    if (s.Id==rowIndex)
                    {
                        id= Int16.Parse (Mystudent.IndexOf(s).ToString());
                    }
                }
                StudentListDB ss = new StudentListDB();
                try
                {
                ss= Mystudent.ElementAt(id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                return ss;
            }
        }

        private void SL_List_FormClosed(object sender, FormClosedEventArgs e)
        {
            Database.Close();
        }
        List<StudentListDB> student = new List<StudentListDB>();
        public void LoadSearch(string keyword)
        {
            student = StudentListDB.Search(keyword);
            string gender;
            dataGridViewScore.Rows.Clear();
            foreach (StudentListDB s in student)
            {
                if (s.Gender == true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }
                dataGridViewScore.Rows.Add(s.Id, s.Name, gender, s.Phone);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewScore.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            dataGridViewScore.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;

            if (!(string.IsNullOrEmpty(txtSearch.Text)))
            {
                LoadSearch(txtSearch.Text);
            }
            else LoadStudent();
        }
    }
}

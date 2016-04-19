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
using MySql.Data;

namespace StudentManagementSystem
{
    public partial class SC_List : Form
    {
        public static int ID = 0;
        public SC_List()
        {
            InitializeComponent();
            ttSearch.SetToolTip(btnSearch, "Search");
        }
        private void SC_List_Load(object sender, EventArgs e)
        {
            int id = 0;
            Database.Open();
            StudentScoreList.DataSource = StudentScoreDB.LoadStudent();
            ColumnDesign();
            for (int i = 0; i < StudentScoreDB.GetRow(); i++)
            {
                id = Convert.ToInt32(StudentScoreList.Rows[i].Cells[0].Value.ToString());
                StudentScoreDB.UpdateStudentTotal(id);
            }
            ChangeLanguage();
        }
        private void StudentScoreList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            StudentScoreList.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            StudentScoreList.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            try
            {
                ID = Convert.ToInt32(StudentScoreList.Rows[e.RowIndex].Cells[0].Value.ToString());
                ///Send Value of ID to Form SC_Edit to Edit Score////////////////////////////////
                if (ID > 0)
                {
                    StudentScoreDB.GetID = ID;
                    (this.Owner as StudentScore).btnEdit.Enabled = true;
                    (this.Owner as StudentScore).btnDelete.Enabled = true;
                }       
            }
            catch (Exception) { }
        }
        public void ColumnDesign()
        {
            StudentScoreList.Columns["ID"].Visible = false;
            StudentScoreList.Columns["StudentID"].Width = 170;
            StudentScoreList.Columns["FullName"].Width = 170;
            StudentScoreList.Columns["Gender"].Width = 80;
            StudentScoreList.Columns["Homework"].Width = 110;
            StudentScoreList.Columns["Quiz"].Width = 80;
            StudentScoreList.Columns["Status"].Visible = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            StudentScoreList.RowsDefaultCellStyle.SelectionBackColor = Color.DarkGray;
            StudentScoreList.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            string KeyWord = txtSearch.Text;

            StudentScoreList.DataSource = StudentScoreDB.Search(KeyWord);
            ColumnDesign();
        }
        private void ChangeLanguage()
        {
             if ((this.Owner as StudentScore).btnList.Text == "បញ្ជីឈ្មោះសិស្ស")
             {
                StudentScoreList.ColumnHeadersDefaultCellStyle.Font = new Font("Khmer OS Bokor", 11, FontStyle.Regular);
                StudentScoreList.Columns[1].HeaderText = "លេខសម្គាល់សិស្ស";
                StudentScoreList.Columns[2].HeaderText = "ឈ្មោះ";
                StudentScoreList.Columns[3].HeaderText = "ភេទ";
                StudentScoreList.Columns[4].HeaderText = "កិច្ចការផ្ទះ";
                StudentScoreList.Columns[5].HeaderText = "ប្រលងខ្លីៗ";
                StudentScoreList.Columns[6].HeaderText = "កិច្ចការស្រាវជ្រាវ";
                StudentScoreList.Columns[7].HeaderText = "ប្រលងពាក់កណ្ដាលឆមាស";
                StudentScoreList.Columns[8].HeaderText = "វត្តមាន";
                StudentScoreList.Columns[9].HeaderText = "ប្រលងបញ្ចប់ឆមាស";
                StudentScoreList.Columns[10].HeaderText = "ពិន្ទុសរុប";
            }
        }

        private void SC_List_Leave(object sender, EventArgs e)
        {
            Database.Close();
        }
    }
}

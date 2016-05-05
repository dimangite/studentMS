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
using StudentManagementSystem;

namespace StudentManagementSystem
{
    public partial class AttendanceForm : Form
    {
        List<Attendance> students;

        public AttendanceForm()
        {
            InitializeComponent();
        }
        private void Attendent_Load(object sender, EventArgs e)
        {
            Database.Open();
            dgvColumn(Attendance.NumberSession());
            dataGridViewAtd.Columns[0].ReadOnly = true;
            dataGridViewAtd.Columns[1].ReadOnly = true;
            dataGridViewAtd.Columns[2].ReadOnly = true;
            dataGridViewAtd.Columns[3].ReadOnly = true;
            LoadStudent();
        } 
   
        public void LoadStudent()
        {
            int k=0;
            
            students = Attendance.GetAllAttendances();
            dataGridViewAtd.Rows.Clear();
            string gender="";
            foreach (Attendance s in students)
            {
                if (s.Gender==true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }
                dataGridViewAtd.Rows.Add(s.AtdId, s.StdId, s.StdName, gender);
                int session = Attendance.NumberSession() ;
                bool[] isCheck= new bool[session];
                string[] a = s.Atd.Split('-');
                for (int i = 0; i < session; i++)
                {
                    if (Int16.Parse(a[i]) == 1)
                    {
                        dataGridViewAtd.Rows[k].Cells[i+4].Value = true;
                    }
                    else dataGridViewAtd.Rows[k].Cells[i+4].Value = false;
                }
                k++;
            }
        }
 
        private void btnSave_Click(object sender, EventArgs e)
        {
            Attendance a = new Attendance();
            foreach (DataGridViewRow row in dataGridViewAtd.Rows)
            {
                a.AtdId = Int16.Parse(row.Cells[0].Value.ToString());
                string tmp = ConvertTo10(row.Cells[4].Value.ToString()).ToString(); 
                for (int i = 1; i < Attendance.NumberSession(); i++)
                {
                    tmp = tmp + "-" + ConvertTo10(row.Cells[i + 4].Value.ToString()).ToString();
                }
                a.Atd = tmp;
                Attendance.AssignAttendance(a);
            }
            dataGridViewAtd.Rows.Clear();
            
            MessageBox.Show("Done");
            LoadStudent();
            //LoadAttendance();
        }
        public int ConvertTo10(string s){
            if (s== "True")
	        {
                return 1;
	        }
            else
            {
                return 0;
            }
        }
      
        public void dgvColumn(int session)
        {

            for (int i = 0; i < session ; i++)
            {
                DataGridViewCheckBoxColumn cb1 = new DataGridViewCheckBoxColumn();
                cb1.HeaderText = (i+1).ToString();
                cb1.Width = 50;
                dataGridViewAtd.Columns.Add(cb1);
            }   //end for loop i
        }


        private void dataGridViewAtd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewAtd.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridViewAtd.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
        }

  //end dgvColumn   
    }   //end class AttedanceForm
}   //end StudentMangementSystem
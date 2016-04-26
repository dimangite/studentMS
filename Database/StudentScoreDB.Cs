using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using MySql.Data;
using System.Data;

namespace StudentManagementSystem
{
    class StudentScoreDB
    {
        public static int ID = 0;
        public static int GetID
        {
            get { return ID; }
            set { ID = value; }
        }
        public static string Fullname = "";
        public static string Homework = "";
        public static string Quiz = "";
        public static string Assignment = "";
        public static string Midterm = "";
        public static string Attendent = "";
        public static string Final = "";
        /// <summary>
        /// //////////Percentage Value///////////////
        public static int HomeworkPct = 0;
        public static int QuizPct = 0;
        public static int AssignmentPct = 0;
        public static int MidtermPct = 0;
        public static int AttendentPct = 0;
        public static int FinalPct = 0;
        /// </summary>
        public static float HwPct = 0;
        public static float QPct = 0;
        public static float AssPct = 0;
        public static float MtPct = 0;
        public static float AttPct = 0;
        public static float FnPct = 0;
        /// <summary>
        /// //////
        public static float Hw = 0;
        public static float Q = 0;
        public static float Ass = 0;
        public static float Mid = 0;
        public static float Att = 0;
        public static float Fn = 0;
        public static float Total = 0;
        public static float[] ArrayTotal = new float[1000];
        /////
        static int i = 0;
        /// </summary>
        /// <param name="KeyWord"></param>
        /// <returns></returns>
        public static object Search(string KeyWord)
        {
            //DataBase.DB();
            string query = "SELECT * FROM studentscore Where FullName like '" + KeyWord + "%' or StudentID like '" + KeyWord + "%' or Total like '" + KeyWord + "%'";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            DataTable tb = new DataTable();
            MySqlDataAdapter adapter;
            tb.Clear();
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(tb);
            return tb;
        }
        public static object LoadStudent()
        {
            MySqlDataAdapter adapter;
            DataTable tb = new DataTable();
            //DataBase.DB();
            //////////Show Student Score in DataGridView
            string query = "SELECT * FROM studentscore";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            //DataBase.Open();
            StudentScoreDB s = new StudentScoreDB();

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(tb);
            //Database.Close();
            return tb;

        }

        public static void GetPecertage()
        {

            //DataBase.DB();
            MySqlCommand cmdPct = new MySqlCommand();
            cmdPct.Connection = Database.connection;
            cmdPct.CommandText = "Select * From percentage";
            try
            {
                /////////////////////////////////Start Get Percentage Of Score//////////////////////////////////////

                //DataBase.Open();
                MySqlDataReader readPct = cmdPct.ExecuteReader();
                while (readPct.Read() == true)
                {
                    HwPct = readPct.GetFloat(readPct.GetOrdinal("HomeworkPct"));
                    QPct = readPct.GetFloat(readPct.GetOrdinal("QuizPct"));
                    AssPct = readPct.GetFloat(readPct.GetOrdinal("AssignmentPct"));
                    MtPct = readPct.GetFloat(readPct.GetOrdinal("MidtermPct"));
                    AttPct = readPct.GetFloat(readPct.GetOrdinal("AttendentPct"));
                    FnPct = readPct.GetFloat(readPct.GetOrdinal("FinalPct"));
                    //////////////////////////////////////////////////////////////                   
                }
                readPct.Close();
            }
            catch (Exception) { }
            //DataBase.Close();
        }
        public static void GetItemInEachRow()
        {
            //DataBase.DB();
            ////////////////////////////////////Update Total Score By Percentage That User Limit/////////////////////////////////////////////////
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Database.connection;
            cmd.CommandText = "SELECT Homework,Quiz,Assignment,Midterm,Attendent,Final FROM studentscore Where Status =1";
            /////////////////////////////////////////////////////////////////////////////////////
            try
            {
                //DataBase.Open();
                /////////////////////////////////Start of Get Value Of Score//////////////////////////////////////////
                int i = 0;
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read() == true)
                {
                    Hw = read.GetFloat(read.GetOrdinal("Homework"));
                    Q = read.GetFloat(read.GetOrdinal("Quiz"));
                    Ass = read.GetFloat(read.GetOrdinal("Assignment"));
                    Mid = read.GetFloat(read.GetOrdinal("Midterm"));
                    Att = read.GetFloat(read.GetOrdinal("Attendent"));
                    Fn = read.GetFloat(read.GetOrdinal("Final"));
                    Total = (Hw * HwPct) / 100 + (Q * QPct) / 100 + (Ass * AssPct) / 100 + (Mid * MtPct) / 100 + (Att * AttPct) / 100 + (Fn * FnPct) / 100;
                    ArrayTotal[i] = Total;
                    i++;
                }
                read.Close();
                //DataBase.Close();
                ///////////////////////////////////End of Get Value Of Score//////////////////////////////////////
            }
            catch (Exception) { }
        }
        public static void UpdateStudentTotal(int id)
        {

           // DataBase.DB();

            GetPecertage();
            GetItemInEachRow();
            /////////////////////////////////////////////////////////////////////////////////////
            MySqlCommand cmdTotal = new MySqlCommand();
            cmdTotal.Connection = Database.connection;
            cmdTotal.CommandText = "Update studentscore set Total=@Total Where ID = @id";
            try
            {
                if (i < GetRow())
                {
                   // DataBase.Open();
                    cmdTotal.Parameters.AddWithValue("@ID", id);
                    Total = ArrayTotal[i];
                    cmdTotal.Parameters.AddWithValue("Total", Total);
                    cmdTotal.ExecuteNonQuery();
                    cmdTotal.Parameters.Clear();
                    i++;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            //DataBase.Close();
            // MessageBox.Show(i.ToString());
        }
        public static int GetRow()
        {
            int Index = 0;
            ////////////////////////////////////////////////////////////////////////////////////
            MySqlCommand cmdRow = new MySqlCommand();
            cmdRow.Connection = Database.connection;
            cmdRow.CommandText = "Select count(*) From studentscore";
            ////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////Count Number of Row//////////////////////////////////////////////////
            //DataBase.Open();
            Index = Convert.ToInt32(cmdRow.ExecuteScalar());
            //DataBase.Close();
            /////////////////////////////finish count////////////////////////////////////////////////////////////
            return Index;
        }
        public static void EditLoad()
        {
            //DataBase.DB();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Database.connection;
            cmd.CommandText = "SELECT FullName,Homework,Quiz,Assignment,Midterm,Attendent,Final,Total FROM studentscore Where ID = @ID";
            cmd.Parameters.AddWithValue("ID", ID);
            try
            {
                //DataBase.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read() == true)
                {
                    Fullname = read.GetString(read.GetOrdinal("FullName"));
                    Homework = read.GetFloat(read.GetOrdinal("Homework")).ToString();
                    Quiz = read.GetFloat(read.GetOrdinal("Quiz")).ToString();
                    Assignment = read.GetFloat(read.GetOrdinal("Assignment")).ToString();
                    Midterm = read.GetFloat(read.GetOrdinal("Midterm")).ToString();
                    Attendent = read.GetFloat(read.GetOrdinal("Attendent")).ToString();
                    Final = read.GetFloat(read.GetOrdinal("Final")).ToString();
                }
                read.Close();
            }
            catch (Exception) { }
            //DataBase.Close();

        }
        public static void EditUpdate(float Homework, float Quiz, float Assignment, float Midterm, float Attendent, float Final)
        {
            //DataBase.DB();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Database.connection;
            string MySpl = "UPDATE studentscore SET Homework=@Homework,Quiz=@Quiz,Assignment=@Assignment,Midterm=@Midterm,Attendent=@Attendent,Final=@Final WHERE ID = @ID";
            cmd.CommandText = MySpl;
            cmd.Parameters.AddWithValue("ID", ID);
            try
            {
                cmd.Parameters.AddWithValue("Homework", Homework);
                cmd.Parameters.AddWithValue("Quiz", Quiz);
                cmd.Parameters.AddWithValue("Assignment", Assignment);
                cmd.Parameters.AddWithValue("Midterm", Midterm);
                cmd.Parameters.AddWithValue("Attendent", Attendent);
                cmd.Parameters.AddWithValue("Final", Final);
                //DataBase.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //DataBase.Close();
            }
            catch (Exception) { MessageBox.Show("Please fill All Information"); }
        }
        public static void Delete()
        {
            //DataBase.DB();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Database.connection;
            cmd.CommandText = "SELECT FullName FROM studentscore Where ID = @ID";
            cmd.Parameters.AddWithValue("ID", ID);
           // MessageBox.Show(ID.ToString());
            String FullName = "";
            try
            {
                Database.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read() == true)
                {
                    FullName = read.GetString(read.GetOrdinal("FullName"));
                }
                read.Close();
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            //DataBase.Close();
            //////////////////////Delete
            var result = MessageBox.Show("Are you sure want to delete student name : " + FullName + " From this Class ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //DataBase.Open();
                MySqlCommand cmd1 = new MySqlCommand();
                cmd1.Connection = Database.connection;
                cmd1.CommandText = "Delete FROM studentscore Where ID = @ID";
                cmd1.Parameters.AddWithValue("ID", ID);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Data Deleted", "Delect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //DataBase.Close();
        }
        public static void SettingLoad()
        {
            //DataBase.DB();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Database.connection;
            cmd.CommandText = "Select * From percentage";
            try
            {
                //DataBase.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read() == true)
                {
                    //
                    HomeworkPct = read.GetInt32(read.GetOrdinal("HomeworkPct"));
                    QuizPct = read.GetInt32(read.GetOrdinal("QuizPct"));
                    AssignmentPct = read.GetInt32(read.GetOrdinal("AssignmentPct"));
                    MidtermPct = read.GetInt32(read.GetOrdinal("MidtermPct"));
                    AttendentPct = read.GetInt32(read.GetOrdinal("AttendentPct"));
                    FinalPct = read.GetInt32(read.GetOrdinal("FinalPct"));
                    //
                }
                read.Close();
            }
            catch (Exception) { }
            //DataBase.Close();
        }
        public static void Setting(float HomeworkPct, float QuizPct, float AssignmentPct, float MidtermPct, float AttendentPct, float FinalPct)
        {
            //DataBase.DB();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Database.connection;
            cmd.CommandText = "Update percentage Set HomeworkPct=@HomeworkPct,QuizPct=@QuizPct,AssignmentPct=@AssignmentPct,MidtermPct=@MidtermPct,AttendentPct=@AttendentPct,FinalPct=@FinalPct";
            cmd.Parameters.AddWithValue("HomeworkPct", HomeworkPct);
            cmd.Parameters.AddWithValue("QuizPct", QuizPct);
            cmd.Parameters.AddWithValue("AssignmentPct", AssignmentPct);
            cmd.Parameters.AddWithValue("MidtermPct", MidtermPct);
            cmd.Parameters.AddWithValue("AttendentPct", AttendentPct);
            cmd.Parameters.AddWithValue("FinalPct", FinalPct);
            try
            {
                //DataBase.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception) { }
            //DataBase.Close();
        }
    }
}

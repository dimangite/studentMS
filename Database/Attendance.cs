using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public class Attendance
    {
        private int atdId;

        public int AtdId
        {
            get { return atdId; }
            set { atdId = value; }
        }
        private int stdId;

        public int StdId
        {
            get { return stdId; }
            set { stdId = value; }
        }
        private bool gender;

        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private bool isAtd;

        public bool IsAtd
        {
            get { return isAtd; }
            set { isAtd = value; }
        }
        private int session;

        public int Session
        {
            get { return session; }
            set { session = value; }
        }

        private string stdName;

        public string StdName
        {
            get { return stdName; }
            set { stdName = value; }
        }

        private string atd;

        public string Atd
        {
            get { return atd; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    atd = "0-0-0-0-0-0-0-0-0-0-0-0-0-0-0";
                }
                else atd = value;
            }
        }


        public static int GetSubId(string name)
        {
            int subId = 0;
            string query = "SELECT subId FROM subject WHERE subName=@subName";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Parameters.AddWithValue("@subName", name);
            cmd.Prepare();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                subId = Int16.Parse(reader["subId"].ToString());
            }
            reader.Close();
            return subId;
        }

        public static int GetSubUserId()
        {
            // get subUserId from subUser
            int subUserId = 0;
            string querySubUserId = "SELECT subUserId FROM subjectuser WHERE userId=@userId AND subId= @subId";
            MySqlCommand cmdSubUserId = new MySqlCommand(querySubUserId, Database.connection);
            cmdSubUserId.Parameters.AddWithValue("@userId", User.userId);
            cmdSubUserId.Parameters.AddWithValue("@subId", GetSubId(Home.ClassName));
            cmdSubUserId.Prepare();
            MySqlDataReader readerSubUserId = cmdSubUserId.ExecuteReader();
            while (readerSubUserId.Read())
            {
                subUserId = Int16.Parse(readerSubUserId["subUserId"].ToString());
            }
            readerSubUserId.Close();
            return subUserId;
        }

        public static List<Attendance> GetAllAttendances()
        {
            List<Attendance> attendance = new List<Attendance>();

            try
            {
                string query = "SELECT s.name, s.gender, s.stdId ,a.session, a.attendance, a.id FROM attendance a INNER JOIN student s ON s.stdId= a.stdId WHERE a.subUserId=@subUserId";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Attendance s = new Attendance();
                    s.AtdId = Int16.Parse(reader["id"].ToString());
                    s.Session = Int16.Parse(reader["session"].ToString());
                    s.StdId = Int16.Parse(reader["stdId"].ToString());
                    s.StdName = reader["name"].ToString();
                    s.Gender = Convert.ToBoolean(reader["gender"].ToString());
                    s.Atd = reader["attendance"].ToString();
                    attendance.Add(s);
                }
                reader.Close();
            }
            catch(Exception ex){ MessageBox.Show(ex.ToString()); }
            return attendance;

        }        
        //----------------------------------------------------------------------------------------------------------------

        public static int NumberSession()
        {
            int s=0;
            string query = "SELECT sessionNumber FROM subjectUser WHERE subUserId= @id";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", GetSubUserId());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s = Int16.Parse(reader["sessionNumber"].ToString());
            }
            reader.Close();
            return s;
        }

        public static void AssignAttendance(Attendance s)
        {
            string query= "UPDATE attendance SET attendance= @attendace WHERE id= @atdId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@attendace", s.Atd);
            cmd.Parameters.AddWithValue("@atdId", s.AtdId);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }//end class Attendance
}//end StudentMangementSystem

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StudentManagementSystem;
using System.Windows.Forms;
namespace StudentManagementSystem
{
    public class StudentScore1
    {
        public int scoreId;
        public int stdId;
        public string stdName;
        public bool gender;
        private int quiz;
        public static int getScoreId;
        public int Quiz
        {
            get { return quiz; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    quiz = 0;
                }
                else quiz = value;
            }
        }
        private int homework;

        public int Homework
        {
            get { return homework; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    homework = 0;
                }
                else homework = value;
            }
        }
        private int assignment;

        public int Assignment
        {
            get { return assignment; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    assignment = 0;
                }
                else assignment = value;
            }
        }
        private int midterm;

        public int Midterm
        {
            get { return midterm; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    midterm = 0;
                }
                else midterm = value;
            }
        }
        private int final;

        public int Final
        {
            get { return final; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    final = 0;
                }
                else final = value;
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
        public static string controlNULL(string n)
        {
            if (string.IsNullOrEmpty(n))
            {
                return "0";
            }
            else return n;
        }

        public static List<StudentScore1> GetAllScores()
        {
            List<StudentScore1> score = new List<StudentScore1>();
            int subUserId = GetSubUserId();
            try
            {
                string query = "SELECT s.stdId,s.name,s.gender,sc.scoreId, sc.quiz, sc.homework, sc.assignment, sc.midterm,sc.final FROM score sc INNER JOIN student s ON s.stdId= sc.stdId WHERE s.subUserId= @subUserId";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@subUserId", subUserId);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentScore1 p = new StudentScore1();
                    p.scoreId = Int16.Parse(controlNULL(reader["scoreId"].ToString()));
                    p.stdId = Int16.Parse(reader["stdId"].ToString());
                    p.stdName = reader["name"].ToString();
                    p.gender = Convert.ToBoolean(reader["gender"].ToString());
                    p.quiz = Int16.Parse(controlNULL(reader["quiz"].ToString()));
                    p.homework = Int16.Parse(controlNULL(reader["homework"].ToString()));
                    p.assignment = Int16.Parse(controlNULL(reader["assignment"].ToString()));
                    p.midterm = Int16.Parse(controlNULL(reader["midterm"].ToString()));
                    p.final = Int16.Parse(controlNULL(reader["final"].ToString()));
                    score.Add(p);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return score;
        }

        public static List<StudentScore1> Search(string KeyWord)
        {
            //DataBase.DB();
            List<StudentScore1> scoreSearch = new List<StudentScore1>() ;
            int subUserId = GetSubUserId();
            try{
                string query = "SELECT s.stdId,s.name,s.gender,sc.scoreId, sc.quiz, sc.homework, sc.assignment, sc.midterm,sc.final FROM score sc INNER JOIN student s ON s.stdId= sc.stdId WHERE s.subUserId= @subUserid AND s.name like '" + KeyWord + "%' or s.stdId like '" + KeyWord + "%' ";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@subUserId", subUserId);
                MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StudentScore1 p = new StudentScore1();
                        p.scoreId = Int16.Parse(reader["scoreId"].ToString());
                        p.stdId = Int16.Parse(reader["stdId"].ToString());
                        p.stdName = reader["name"].ToString();
                        p.gender = Convert.ToBoolean(reader["gender"].ToString());
                        p.quiz = Int16.Parse(controlNULL(reader["quiz"].ToString()));
                        p.homework = Int16.Parse(controlNULL(reader["homework"].ToString()));
                        p.assignment = Int16.Parse(controlNULL(reader["assignment"].ToString()));
                        p.midterm = Int16.Parse(controlNULL(reader["midterm"].ToString()));
                        p.final = Int16.Parse(controlNULL(reader["final"].ToString()));
                        scoreSearch.Add(p);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            return scoreSearch;
        }

        public static void Update(StudentScore1 score)
        {
            string query = "UPDATE score SET quiz=@quiz, homework=@homework, assignment=@assignment, midterm=@midterm, final=@final WHERE scoreId=@scoreId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@scoreId", score.scoreId);
            cmd.Parameters.AddWithValue("@quiz", score.Quiz);
            cmd.Parameters.AddWithValue("@homework", score.Homework);
            cmd.Parameters.AddWithValue("@assignment", score.Assignment);
            cmd.Parameters.AddWithValue("@midterm", score.Midterm);
            cmd.Parameters.AddWithValue("@final", score.Final);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static StudentScore1 getSelected(int id)
        {
            StudentScore1 s = new StudentScore1();
            string query = "SELECT s.name, sc.scoreId ,sc.quiz,sc.homework, sc.assignment, sc.midterm, sc.final FROM score sc INNER JOIN student s ON s.stdId= sc.stdId WHERE sc.scoreId=@scoreId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@scoreId", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s.scoreId = Int16.Parse(controlNULL(reader["scoreId"].ToString()));
                s.stdName = reader["name"].ToString();
                s.quiz = Int16.Parse(controlNULL(reader["quiz"].ToString()));
                s.homework = Int16.Parse(controlNULL(reader["homework"].ToString()));
                s.assignment = Int16.Parse(controlNULL(reader["assignment"].ToString()));
                s.midterm = Int16.Parse(controlNULL(reader["midterm"].ToString()));
                s.final = Int16.Parse(controlNULL(reader["final"].ToString()));
            }
            reader.Close();
            return s;
        }
    }
}

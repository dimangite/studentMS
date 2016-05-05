using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace StudentManagementSystem
{
    public class Class
    {
        public int subUserId;
        public string UserName;
        public string ClassName;
        public DateTime StartDate;
        public int SessionNumber;
        public int Year;
        public int Semester;

        public static List<Class> GetAllClasses()
        {
            List<Class> c = new List<Class>();
            try
            {
                string query = "SELECT u.username, s.subName,us.subUserId, us.startDate, us.sessionNumber, us.year, us.semester FROM subjectUser us INNER JOIN user u on u.userId= us.userId INNER JOIN subject s on s.subId= us.subId WHERE u.userId=@userId";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@userId", User.userId);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Class p = new Class();
                    p.subUserId = Int16.Parse(reader["subUserId"].ToString());
                    p.UserName = reader["username"].ToString();
                    p.ClassName = reader["subName"].ToString();
                    p.StartDate = Convert.ToDateTime(reader["startDate"].ToString());
                    p.Year = Int16.Parse(reader["year"].ToString());
                    p.SessionNumber = Int16.Parse(reader["sessionNumber"].ToString());
                    p.Semester = Int16.Parse(reader["semester"].ToString());

                    c.Add(p);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
            return c;
        }

        public static void Insert(Class c){
            // insert into database subject
            string query = "INSERT INTO subject(subName) VALUES(@subName)";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@subName", c.ClassName);
            cmd.ExecuteNonQuery();
            // read from subject to get id of subject

            string querySubId = "SELECT subId FROM subject WHERE subName= @subName";
            MySqlCommand cmdSubId = new MySqlCommand(querySubId, Database.connection);
            cmdSubId.Prepare();
            cmdSubId.Parameters.AddWithValue("@subName", c.ClassName);
            MySqlDataReader reader = cmdSubId.ExecuteReader();
            int SubId=0;
            while (reader.Read())
            {
                SubId = Int16.Parse(reader["subId"].ToString());
            }
            reader.Close();
            // insert into subUser
            string querySubUser = "INSERT INTO subjectUser(userId, subId, startDate, sessionNumber, year, semester) VALUES(@userId, @subId, @startDate, @sessionNumber, @year, @semester)";
            MySqlCommand cmdSubUser = new MySqlCommand(querySubUser, Database.connection);
            cmdSubUser.Prepare();
            cmdSubUser.Parameters.AddWithValue("@userId", User.userId);
            cmdSubUser.Parameters.AddWithValue("@subId", SubId);
            cmdSubUser.Parameters.AddWithValue("@startDate", c.StartDate);
            cmdSubUser.Parameters.AddWithValue("@sessionNumber", c.SessionNumber);
            cmdSubUser.Parameters.AddWithValue("@year", c.Year);
            cmdSubUser.Parameters.AddWithValue("@semester", c.SessionNumber);
            cmdSubUser.ExecuteNonQuery();

        }

        public static int GetSubId(int id)
        {
            int re=0;
            string query = "SELECT subId FROM subjectuser WHERE subUserId=@subUserId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@subUserId", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                re = Int16.Parse(reader["subId"].ToString());
            }
            reader.Close();
            return re;
        }

        public static void Update(Class c)
        {
            string query = "UPDATE subject SET subName=@name WHERE subId=@subId;UPDATE subjectuser SET startDate= @startDate, year= @year, semester=@semester, sessionNumber=@numberSession WHERE subUserId=@subUserId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", c.ClassName);
            cmd.Parameters.AddWithValue("@subId", GetSubId(c.subUserId)) ;
            cmd.Parameters.AddWithValue("@startDate", c.StartDate);
            cmd.Parameters.AddWithValue("@year", c.Year);
            cmd.Parameters.AddWithValue("@semester", c.Semester);
            cmd.Parameters.AddWithValue("@numberSession", c.SessionNumber);
            cmd.Parameters.AddWithValue("@subUserId", c.subUserId);
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int ID)
        {
            // delete from database
            string query = "DELETE FROM subjectuser WHERE subUserid = @subUserId; DELETE FROM subject WHERE subId = @subId;DELETE FROM score WHERE subUserId = @subUserid;DELETE FROM attendance WHERE subUserId = @subUserid ;DELETE FROM student WHERE subUserId = @subUserid ";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@subId", GetSubId(ID));
            cmd.Parameters.AddWithValue("@subUserId", ID);
            cmd.ExecuteNonQuery();
        }

        public static Class GetSelected(int gid)
        {
            Class p = new Class();
            try
            {
                string query = "SELECT u.username, s.subName,us.subUserId, us.startDate, us.sessionNumber, us.year, us.semester FROM subjectUser us INNER JOIN user u on u.userId= us.userId INNER JOIN subject s on s.subId= us.subId WHERE us.subUserId= @subUserId";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@subUserId", gid);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    p.subUserId = Int16.Parse(reader["subUserId"].ToString());
                    p.UserName = reader["username"].ToString();
                    p.ClassName = reader["subName"].ToString();
                    p.StartDate = Convert.ToDateTime(reader["startDate"].ToString());
                    p.Year = Int16.Parse(reader["year"].ToString());
                    p.SessionNumber = Int16.Parse(reader["sessionNumber"].ToString());
                    p.Semester = Int16.Parse(reader["semester"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            return p;
        }
    }
}

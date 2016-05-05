using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using StudentManagementSystem.Forms;
namespace StudentManagementSystem
{
            
    public class StudentListDB
    {

        public int Id;
        public int ClassID;
        public string Name;
        public bool Gender;
        public int TotalScore;
        public DateTime DOB;
        public string POB;
        public string MotherName;
        public string FatherName;
        public string Address;
        public string Phone;
        public string PhotoPath;
        public Image Photo;
        public static int ID = 0;

        public static int GetSubId(string name)
        {
            int subId=0;
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

        public static List<StudentListDB> GetAllStudents()
        {
            int subUserId = GetSubUserId();

            List<StudentListDB> student = new List<StudentListDB>();
            try
            {
                string query = "SELECT * FROM student WHERE subUserId= @subUserId";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Parameters.AddWithValue("@subUserId", subUserId);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentListDB p = new StudentListDB();
                    p.Id = Int16.Parse(reader["stdId"].ToString());
                    p.Name = reader["name"].ToString();
                    p.Gender = Convert.ToBoolean(reader["gender"].ToString());
                    p.Phone = reader["phone"].ToString();
                    p.PhotoPath = reader["photoPath"].ToString();
                    student.Add(p);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return student;
        }

        public static List<StudentListDB> Search(string KeyWord)
        {
            //DataBase.DB();
            List<StudentListDB> scoreSearch = new List<StudentListDB>();
            int subUserId = GetSubUserId();
            try
            {
                string query = "SELECT stdId, name, gender,phone, photoPath FROM student WHERE subUserId= @subUserid AND name like '" + KeyWord + "%' or stdId like '" + KeyWord + "%' ";
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@subUserId", subUserId);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentListDB p = new StudentListDB();
                    p.Id = Int16.Parse(reader["stdId"].ToString());
                    p.Name = reader["name"].ToString();
                    p.Gender = Convert.ToBoolean(reader["gender"].ToString());
                    p.Phone = reader["phone"].ToString();
                    p.PhotoPath = reader["photoPath"].ToString();
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
        
        public static void Insert(StudentListDB student)
        {

            string query = "INSERT INTO student(name, gender, subUserId,phone, photo, photoPath) VALUES(@name, @gender, @subUserId,@phone, @photo, @photoPath)";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@gender", student.Gender);
            cmd.Parameters.AddWithValue("@subUserId", GetSubUserId());
            cmd.Parameters.AddWithValue("@phone", student.Phone);
            cmd.Parameters.AddWithValue("@photo", student.Photo);
            cmd.Parameters.AddWithValue("@photoPath", student.PhotoPath);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            // insert get last id from student
            string queryGetLastId = "SELECT LAST_INSERT_ID() FROM student";
            MySqlCommand cmdGetLastId = new MySqlCommand(queryGetLastId, Database.connection);
            MySqlDataReader reader = cmdGetLastId.ExecuteReader();
            int LastId=-1;
            while (reader.Read())
            {
                LastId = Int16.Parse(reader["LAST_INSERT_ID()"].ToString());
            }
            reader.Close();
            // insert into score and attendance

            string queryInsertToScore = "INSERT INTO score(stdId, subUserId) VALUE(@stdId, @subUserId) ;INSERT INTO attendance(stdId, subUserId) VALUE(@stdId, @subUserId) ";
            MySqlCommand cmdInsertToScore = new MySqlCommand(queryInsertToScore, Database.connection);
            cmdInsertToScore.Prepare();
            cmdInsertToScore.Parameters.AddWithValue("@stdId", LastId);
            cmdInsertToScore.Parameters.AddWithValue("@subUserId", GetSubUserId());

            try
            {
                cmdInsertToScore.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public static void Update(StudentListDB student)
        {
            string query = "UPDATE student SET name=@name, gender= @gender, phone=@phone, photo=@photo, photoPath=@photoPath WHERE stdId=@stdId";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@stdId", student.Id);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@gender", student.Gender);
            cmd.Parameters.AddWithValue("@phone", student.Phone);
            cmd.Parameters.AddWithValue("@photo", student.Photo);
            cmd.Parameters.AddWithValue("@photoPath", student.PhotoPath);
            try
            {
            cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void Delete(int id)
        {
            // delete from database
            string query = "DELETE FROM student WHERE stdId = @id ; DELETE FROM score WHERE stdId = @id; DELETE FROM attendance WHERE stdId = @id";
            MySqlCommand cmd = new MySqlCommand(query, Database.connection);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}

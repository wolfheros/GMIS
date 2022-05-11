/**
 * @auther Shengya Ji
 * @date 09/05/2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GMIS
{
    /**
     *  Main database operation class, this class main job is fetching
     *  data from database and auth the user is valid or not.
     */
    public class DatabaseContorller
    {
        private static StudentBean? student { get; set; }

        // auth the user is in the database or not?
        // @User user to store the input data.
        // @return bool value.
        public static bool AuthUser(User user)
        {
            FetchStudentDataFromDatabase(user);
            return student != null;
        }

        /**
         *  Fech data from database during the login.
         *  @User user for the datafeching.
         */
        private static void FetchStudentDataFromDatabase(User user)
        {
            MySqlConnection connection = DatabaseHelper.Instance.Connection;
            MySqlDataReader reader = null;
            try
            {
                connection.Open();

                MySqlCommand mySqlCommand =
                    new MySqlCommand("SELECT student_id," +
                    "given_name," +
                    "family_name," +
                    "group_id," +
                    "title," +
                    "campus," +
                    "phone," +
                    "email," +
                    "photo," +
                    "category" +
                    " FROM student WHERE student_id=?id", connection);
                mySqlCommand.Parameters.AddWithValue("id", user.StudentId);
                reader = mySqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    student = new StudentBean();
                    student.StudentId = reader.GetString(0);
                    student.FirstName = reader.GetString(1);
                    student.FamilyName = reader.GetString(2);
                    student.GroupID = reader.GetString(3);
                    student.Title = reader.GetString(4);
                    student.Campus = reader.GetString(5);
                    student.Phone = reader.GetString(6);
                    student.Email = reader.GetString(7);
                    student.PhotoURL = reader.GetString(8);
                    student.Category = reader.GetString(9);
                }
            }
            catch (MySqlException e)
            {
                //do nothing;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /**
         *  Public fuction for the use of student detail,
         *  @Nullable
         *  @return StudentBean
         */
        public static StudentBean? GetStudent()
        {
            return student;
        }

        /**
         *  Fetching data from database 
         *  @sqlString the string to use search or as parameters for database fetching data.
         *  @DataType is the identify for the type that the database operation will operate.
         *  @return List<ClassBean> object
         */
        public static List<ClassBean> FetchClassDataFromDatabase(string sqlString, int DataType)
        {
            MySqlConnection connection = DatabaseHelper.Instance.Connection;
            MySqlDataReader reader = null;
            List<ClassBean> list = new List<ClassBean>();
            MySqlCommand mySqlCommand = null;
            try
            {
                connection.Open();
                switch (DataType)
                {
                    // show class data
                    case 0:
                        {
                           mySqlCommand = new MySqlCommand("SELECT class_id," +
                                        "group_id," +
                                        "day," +
                                        "start," +
                                        "end," +
                                        "room FROM class WHERE group_id=?id", connection);
                            mySqlCommand.Parameters.AddWithValue("id", sqlString);
                            break;
                        }
                    // show all class data
                    case 1:
                        {
                            mySqlCommand = new MySqlCommand("SELECT class_id, " +
                                        "group_id," +
                                        "day," +
                                        "start," +
                                        "end," +
                                        "room FROM class", connection);
                            break;
                        }
                    // custom search class table data
                    case 2:
                        {
                            mySqlCommand = new MySqlCommand("SELECT class_id, " +
                                        "group_id," +
                                        "day," +
                                        "start," +
                                        "end," +
                                        "room FROM class WHERE day LIKE @daySearch " +
                                        "OR class_id LIKE @classSearch " +
                                        "OR room LIKE @roomSearch", connection);
                            mySqlCommand.Parameters.AddWithValue("@daySearch","%" + sqlString + "%");   
                            mySqlCommand.Parameters.AddWithValue("@classSearch","%" + sqlString + "%");   
                            mySqlCommand.Parameters.AddWithValue("@roomSearch","%" + sqlString + "%");   
                            break;
                        }
                }
                 
                reader = mySqlCommand.ExecuteReader();
                
                while (reader.Read())
                {
                    ClassBean bean = new ClassBean();
                    bean.class_id = reader.GetString(0);
                    bean.group_id = reader.GetString(1);
                    bean.day = reader.GetString(2);
                    bean.start = reader.GetString(3);
                    bean.end = reader.GetString(4);
                    bean.room = reader.GetString(5);
                    list.Add(bean);
                }

            }
            catch (MySqlException e)
            {
                //do nothing;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return list;
        }

        /**
         *  Fetching data from database 
         *  @sqlString the string to use search or as parameters for database fetching data.
         *  @DataType is the identify for the type that the database operation will operate.
         *  @return List<MeetingBean> object
         */
        public static List<MeetingBean> FetchMeetingDataFromDatabase(string sqlString, int DataType)
        {
            MySqlConnection connection = DatabaseHelper.Instance.Connection;
            MySqlDataReader reader = null;
            List<MeetingBean> list = new List<MeetingBean>();
            MySqlCommand mySqlCommand = null;
            try
            {
                connection.Open();
                switch (DataType)
                {
                    // show meeting data
                    case 0:
                        {
                            mySqlCommand = new MySqlCommand("SELECT meeting_id," +
                                         "group_id," +
                                         "day," +
                                         "start," +
                                         "end," +
                                         "room FROM meeting WHERE group_id=?id", connection);
                            mySqlCommand.Parameters.AddWithValue("id", sqlString);
                            break;
                        }
                    // show all meeting data
                    case 1:
                        {
                            mySqlCommand = new MySqlCommand("SELECT meeting_id, " +
                                        "group_id," +
                                        "day," +
                                        "start," +
                                        "end," +
                                        "room FROM meeting", connection);
                            break;
                        }
                    // custom search meeting table data
                    case 2:
                        {
                            mySqlCommand = new MySqlCommand("SELECT meeting_id, " +
                                        "group_id," +
                                        "day," +
                                        "start," +
                                        "end," +
                                        "room FROM meeting WHERE day LIKE @daySearch " +
                                        "OR meeting_id LIKE @meetingSearch " +
                                        "OR room LIKE @roomSearch", connection);
                            mySqlCommand.Parameters.AddWithValue("@daySearch", "%" + sqlString + "%");
                            mySqlCommand.Parameters.AddWithValue("@meetingSearch", "%" + sqlString + "%");
                            mySqlCommand.Parameters.AddWithValue("@roomSearch", "%" + sqlString + "%");
                            break;
                        }
                }

                reader = mySqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    MeetingBean bean = new MeetingBean();
                    bean.meeting_id = reader.GetString(0);
                    bean.group_id = reader.GetString(1);
                    bean.day = reader.GetString(2);
                    bean.start = reader.GetString(3);
                    bean.end = reader.GetString(4);
                    bean.room = reader.GetString(5);
                    list.Add(bean);
                }

            }
            catch (MySqlException e)
            {
                //do nothing;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return list;
        }
    }
}

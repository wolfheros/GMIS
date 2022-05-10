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
    public class DatabaseContorller
    {
        private static StudentBean? student { get; set; }

        // auth the user is in the database or not?
        // @User user to store the input data.
        public static bool AuthUser(User user)
        {
            FetchDataFromDatabase(user);
            return student != null;
        }

        /**
         *  Fech data from database during the login.
         *  @User user for the datafeching.
         */
        private static void FetchDataFromDatabase(User user)
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
    }
}

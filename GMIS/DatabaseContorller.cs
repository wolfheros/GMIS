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

        // Auther the user is in the Database
        // @user User instance
        public static bool AuthUser(User user)
        {
            MySqlDataReader reader = GetReader(user);
            if (reader == null)
            {
                return false;
            }
            return reader.HasRows;
        }


        // Get the database reader from the connection.
        // @user User instance for user id
        private static MySqlDataReader GetReader(User user)
        {
            MySqlConnection connection = DatabaseHelper.Instance.Connection;
            MySqlDataReader reader = null;
            try
            {
                connection.Open();

                MySqlCommand mySqlCommand =
                    new MySqlCommand("SELECT * FROM student WHERE student_id=?id", connection);
                mySqlCommand.Parameters.AddWithValue("id", user.StudentId);
                reader = mySqlCommand.ExecuteReader();
            }
            catch (MySqlException e)
            {
                //ReportError("loading training sessions", e);
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
            return reader;
        }
    }
}

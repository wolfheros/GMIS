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
        public static bool AuthUser(User user)
        {
            bool auth = false;

            MySqlConnection connection = DatabaseHelper.Instance.Connection;
            MySqlDataReader reader = null;
            try
            {
                connection.Open();

                MySqlCommand mySqlCommand =
                    new MySqlCommand("SELECT * FROM student WHERE student_id=?id", connection);
                mySqlCommand.Parameters.AddWithValue("id", user.StudentId);
                reader = mySqlCommand.ExecuteReader();
                auth = reader.HasRows;
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
            return auth;
        }
    }
}

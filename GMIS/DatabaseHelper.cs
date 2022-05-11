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
     *  Singleton class for building MysqlConnection object.
     */
    public sealed class DatabaseHelper
    {
        private MySqlConnection _connection;
        public MySqlConnection Connection
        {
            get {
                if (_connection == null)
                {
                    string severString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}"
                        , GlobalsValue.DB
                        , GlobalsValue.SEVER
                        , GlobalsValue.USER
                        , GlobalsValue.PASSWD);
                    _connection = new MySqlConnection(severString);
                }
                return _connection; 
            }
        }
        private DatabaseHelper()
        {

        }

        private static DatabaseHelper instance = null;
        public static DatabaseHelper Instance
        { 
            get { 
                if(instance == null)
                {
                    instance = new DatabaseHelper();
                }
                return instance; 
            }
        }
    }
}

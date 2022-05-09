/**
 * @auther Shengya Ji
 * @date 09/05/2022
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMIS
{
    public class User
    {
        public User(string _firstname, string _familyName, string _studentID) 
        {
            FirsName = _firstname;
            FamilyName = _familyName;
            StudentId = _studentID;
        }
        public string FirsName { get; set; }
        public string FamilyName { get; set; }
        public string StudentId { get; set; }

    }
}

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
    /**
     *  Const class for data type idenity.
     */
    public static class GlobalsType
    {
        public static readonly int ClassManagementType = 0;
        public static readonly int MeettingManagementType = 1;
        public static readonly int StudentManagementType = 2;
        public static readonly int GroupManagementType = 3;
    }

    public static class GlobalsValue
    {
        public const string DB = "gmis";
        public const string USER = "gmis";
        public const string PASSWD = "gmis";
        public const string SEVER = "alacritas.cis.utas.edu.au";
    }

    /**
     *  Const value for type varified
     */
    public static class GlobalsClassDatatype
    {
        public static readonly int ClassData = 0;
        public static readonly int AllClassData = 1;
        public static readonly int CustomerSearchData = 2;
    }

    /**
     *  Const value for type varified
     */
    public static class GlobalsMeetingDatatype
    {
        public static readonly int ShowMeetingData = 0;
        public static readonly int ShowAllMeetingData = 1;
        public static readonly int ShowCustomerSearchData = 2;
    }
}

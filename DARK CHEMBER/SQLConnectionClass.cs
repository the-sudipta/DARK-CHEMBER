using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARK_CHEMBER
{
    internal class SQLConnectionClass
    {
        public static string conReturn()
        {
            try
            {
                return @"Data Source=(LocalDB)\v11.0; AttachDbFilename=" + System.IO.Path.GetFullPath("Dark_Chember_DataBase.mdf") + "; Integrated Security=True; Connect Timeout=30";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            


        }
        //public static string temporaryConReturn()
        //{
        // return @"Data Source=(LocalDB)\v11.0;Initial Catalog=Dark_Chember_DataBase;Integrated Security=True";
        //}
    }
}

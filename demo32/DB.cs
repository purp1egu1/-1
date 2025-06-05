using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo32
{
    internal class DB
    {
        public static SqlConnection sqlcon = new SqlConnection($@"Data Source=10.193.168.164;Initial Catalog=demo123;Persist Security Info=True;User ID=student;Password=1234");
    }
}

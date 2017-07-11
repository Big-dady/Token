using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Token.Models
{
    public class delete
    {
        public int Delete(int id)
        {
            int i;
            Data data = new Data();

                using (SqlCommand cmd = new SqlCommand("update issue set delid=0 Where id=" + id))
                {
                    i = data.executeCommand(cmd);
                    return i;
                }
            
        }
    }
}
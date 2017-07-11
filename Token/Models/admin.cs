using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Token.Models
{
    public class admin
    {
        Data data = new Data();
        DataSet ds= new DataSet();
        public DataSet getTable()
        {
            SqlCommand cmd = new SqlCommand("Select * from issue where delid=1");
            ds = data.getDataSet(cmd);
            return ds;
        }
    }
}
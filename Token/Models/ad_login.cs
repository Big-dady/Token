using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace Token.Models
{
    public class ad_login
    {
        Data data = new Data();
        [Required]
        [Display(Name = "userid")]
        public string userid { get; set; }
        [Required]
        public string Password { get; set; }

        public int login(string userid, string password)
        {
            int n;
            SqlCommand cmd = new SqlCommand("select * from login where userid='" + userid + "' and password='"+password+"'");
            DataSet ds = new DataSet();
            ds = data.getDataSet(cmd);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            n = ds.Tables[0].Rows.Count;
             return n;
        }
    }
}
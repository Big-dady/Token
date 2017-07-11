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
    public class account
    {
        Data data = new Data();
        [Required]
        [Display(Name="number")]
        public int number { get; set; }
        [Required]
        public string Password { get; set; }
        public string issue { get; set; }
        //public int Count{get;}
        public int login(int number, string password)
        {
            
            int n;
            SqlCommand cmd = new SqlCommand("select * from ad_login where number='" + number + "' and password='"+password+"'");
            DataSet ds = new DataSet();
            ds=data.getDataSet(cmd);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
               n= ds.Tables[0].Rows.Count;

            return n;
        }

        //public int getIssue()
        //{

        //}
                
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Token.Models
{
    public class Register
    {
        Data data = new Data();

        [Required]
        [Display(Name = "number")]
        public int number { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public int insert(int number, string password)
        {
            using (SqlCommand cmd = new SqlCommand("Insert Into ad_login  (number,Password) Values('" + number + "','" + password + "')"))
            {

                return data.executeCommand(cmd);
            }
        }
    }
}
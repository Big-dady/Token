using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Web.Routing;
using System.Windows;
using System.Web.ApplicationServices;

namespace Token.Controllers
{
    public class HomeController : Controller
    {
        Data data = new Data();
        List<string> online= new List<string>();
        // GET: Home

        public ActionResult Index(Models.account user)
        {
            if(ModelState.IsValid)
            {
                int k= user.login(user.number,user.Password);
                if (k > 0)
                {

                    //TempData.Add("issue", user.issue.ToString());
                    //Session[user.number.ToString()] = user.issue;
                    SqlCommand c = new SqlCommand("insert into issue (number,issue,delid) values('"+user.number+"','" +user.issue+ "', 1)");
                    data.executeCommand(c);
                    Session["token"] = (Convert.ToInt32(Session["token"]) + 1).ToString();

                    //int n = Convert.ToInt32(Session["token"]) + 1;
                    //Session["thistoken"] = n;

                    //HttpApplicationState c = new HttpApplicationState();
                    //int i = c.Count;
                    //Response.Write("app state"+i);
                    return RedirectToAction("token");

                 }
                else ModelState.AddModelError("", "Login error");
            }   
            return View(user); 
        }

        public ActionResult ad_login(Models.ad_login ad)
        {
            if (ModelState.IsValid) 
            {
                int k= ad.login(ad.userid, ad.Password);
                if (k > 0)
                {
                    return RedirectToAction("admin");
                }
                else ModelState.AddModelError("", "Login error");

            }
            return View(ad);
        }

        public ActionResult Register(Models.Register user)
        {
           if (ModelState.IsValid)
            {
                int _records = user.insert(user.number, user.Password);
                if (_records > 0)
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Can Not Register");
                }
            }
            return View(user);
        }

        public ActionResult admin(Models.admin ad)
        {
            DataSet ds = ad.getTable();
            ViewBag.issue = ds.Tables[0];
            return View(ad);                                                                  
        }

        public ActionResult Delete(int id, Token.Models.delete deletemodel)
        {

            int records = deletemodel.Delete(id);
            if (records > 0)
            {
                Session["token"] = ((int)Session["token"] - 1).ToString();
                return RedirectToAction("admin", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Can Not Delete");
                return View("admin");
            }
        }
        public ActionResult token(Token.Models.account user)
        {
            SqlCommand c = new SqlCommand("select issue from issue where number='"+user.number+"'");
            data.executeCommand(c);

              return View();
        }
    }
}
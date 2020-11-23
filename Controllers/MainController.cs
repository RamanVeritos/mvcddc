using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
   [Authorize]
    public class MainController : Controller
    {
        // GET: Main
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            using (var ctx = new ddc1Entities1())
            {

                // List<getapplicationcountdata_Result1> data = ctx.getapplicationcountdata().ToList();
                ViewBag.count1 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='FIRST REGISTRATION' group by reg_type").FirstOrDefault();
                ViewBag.count2 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='TRANSFER OF REGISTRATION FORM OTHER STATE' group by reg_type").FirstOrDefault();
                ViewBag.count3 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='Addition of Qualification' group by reg_type").FirstOrDefault();
                ViewBag.count4 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='RENEWAL REGISTRATION' group by reg_type ").FirstOrDefault();
                ViewBag.count5 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='TRANSFER OF REGISTRATION FROM OTHER STATE' group by reg_type ").FirstOrDefault();
                ViewBag.count6 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='SMART CARD' group by reg_type ").FirstOrDefault();
                ViewBag.count7 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='INITIAL REGISTRATION' group by reg_type ").FirstOrDefault();
                return View();
            }
        }

        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Ad_Seach_Prac()
        {
            return View();
        }
    }
}
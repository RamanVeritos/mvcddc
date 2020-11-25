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

                //var query = context.People
                //   .GroupBy(p => p.name)
                //   .Select(g => new { name = g.Key, count = g.Count() });

                // var b=from ab in ctx.Tb_candidate where a
                // List<getapplicationcountdata_Result1> data = ctx.getapplicationcountdata().ToList();
                //ViewBag.count1  =ctx. ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='FIRST REGISTRATION' group by reg_type").FirstOrDefault();
                ViewBag.count1 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "FIRST REGISTRATION").Count();
                ViewBag.count2 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "TRANSFER OF REGISTRATION FORM OTHER STATE").Count();
                ViewBag.count3 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "Addition of Qualification").Count();
                ViewBag.count4 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "RENEWAL REGISTRATION").Count();
                ViewBag.count5 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "TRANSFER OF REGISTRATION FROM OTHER STATE").Count();
                ViewBag.count6 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "SMART CARD").Count();
                ViewBag.count7 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "INITIAL REGISTRATION").Count();
                //ViewBag.count2 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='' group by reg_type").FirstOrDefault();
                //ViewBag.count3 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='' group by reg_type").FirstOrDefault();
                //ViewBag.count4 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='' group by reg_type ").FirstOrDefault();
                //ViewBag.count5 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='' group by reg_type ").FirstOrDefault();
                //ViewBag.count6 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='SMART CARD' group by reg_type ").FirstOrDefault();
                //ViewBag.count7 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='INITIAL REGISTRATION' group by reg_type ").FirstOrDefault();
                //ViewBag.count1 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "TRANSFER OF REGISTRATION FORM OTHER STATE").Count();
                return View();
            }
        }

        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Ad_Seach_Prac()
        {
            using (var Context = new ddc_login2Entities())
            {
               
                var ab = Context.tbdocs.Select(x => x.docrescty).Distinct().ToList();
                ViewBag.Residential=Context.tbdocs.Select(x => x.docprocty).Distinct().ToList();
                ViewBag.ProfessionalCity = new SelectList(ab, "Id", "Name");
            }
           return View();
        }
    }
}
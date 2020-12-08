﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [Authorize]
    [HandleError]
    public class MainController : Controller
    {
        // GET: Main
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            using (var ctx = new ddc1Entities1())
            {
                ViewBag.count1 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "FIRST REGISTRATION").Count();
                ViewBag.count2 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "TRANSFER OF REGISTRATION FORM OTHER STATE").Count();
                ViewBag.count3 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "Addition of Qualification").Count();
                ViewBag.count4 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "RENEWAL REGISTRATION").Count();
                ViewBag.count5 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "TRANSFER OF REGISTRATION FROM OTHER STATE").Count();
                ViewBag.count6 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "SMART CARD").Count();
                ViewBag.count7 = ctx.Tb_candidate.Where(s => s.udf2_v == "5" && s.reg_type == "INITIAL REGISTRATION").Count();
                //ViewBag.count2 = ctx.Database.SqlQuery<showdata>("select reg_type as Regtype,count(reg_type) as Totalcount from tb_candidate where udf2_v=5 and reg_type='' group by reg_type").FirstOrDefault();

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

                Binddropdowndata();
                //var data = Context.search_pract(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty).ToList();
                return View();
            }
        }
        [HttpPost]
        public ActionResult Ad_Seach_Prac(FormCollection formdata)
        {
            using (var Context = new ddc_login2Entities())
            {
                Binddropdowndata();
                //var  data= Context.search_pract("", "", "", "", "1351").ToList();
                var data = Context.search_pract(Convert.ToString(formdata["fname"]),Convert.ToString(formdata["lname"]), Convert.ToString(formdata["RegistrationNumber"]), Convert.ToString(formdata["Residential"]), Convert.ToString(formdata["ProfessionalCity"])).ToList();
                return View(data);
            }
        }

        private void Binddropdowndata()
        {
            using (var Context = new ddc_login2Entities())
            {

  
                TempData["ProfessionalCity"] = Context.tbdocs.Where(z => z.docprocty != null).Select(i => new SelectListItem() { Text = i.docprocty, Value = i.docprocty.ToString() }).Distinct().ToList();
                TempData["Residential"] = Context.tbdocs.Where(z => z.docrescty != null).Select(i => new SelectListItem() { Text = i.docrescty, Value = i.docrescty.ToString() }).Distinct().ToList();
                //ViewBag.ProfessionalCity = TempData["ProfessionalCity"];
                //ViewBag.Residential = TempData["Residential"];
                //ViewBag.ProfessionalCity = Context.tbdocs.Where(z => z.docrescty != null).Select(i => new SelectListItem() { Text = i.docrescty, Value = i.docrescty.ToString() }).Distinct().ToList();
                //ViewBag.Residential = Context.tbdocs.Where(z => z.docprocty != null).Select(i => new SelectListItem() { Text = i.docprocty, Value = i.docprocty.ToString() }).Distinct().ToList();
            }
        }

        public ActionResult Getexcelreport(FormCollection formdata)
        {
            Binddropdowndata();
            using (var Context = new ddc_login2Entities())
            {
                //var  data= Context.search_pract("", "", "", "", "1351").ToList();
                var data = Context.search_pract(Convert.ToString(formdata["fname"]), Convert.ToString(formdata["lname"]), Convert.ToString(formdata["RegistrationNumber"]), Convert.ToString(formdata["Residential"]), Convert.ToString(formdata["ProfessionalCity"])).ToList();
                var gv = new GridView();
                gv.DataSource = data;//this.GetEmployeeList();
                gv.DataBind();
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "";
                StringWriter objStringWriter = new StringWriter();
                HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
                gv.RenderControl(objHtmlTextWriter);
                Response.Output.Write(objStringWriter.ToString());
                Response.Flush();
                Response.End();
                return View("Ad_Seach_Prac");
            }
        }
    }
}
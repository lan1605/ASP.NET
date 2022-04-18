using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTap5_61133848.Models;

namespace BaiTap5_61133848.Controllers
{
    public class Bai5_61133848Controller : Controller
    {
        // GET: Bai5_61133848
        //
        //Banner
        public ActionResult ChangeBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangeBanner(HttpPostedFileBase banner)
        {
            string postedFileName = System.IO.Path.GetFileName(banner.FileName);
            var path = Server.MapPath("/Images/" + postedFileName);
            banner.SaveAs(path);
            string fSave = Server.MapPath("/Banner.txt");
            System.IO.File.WriteAllText(fSave, postedFileName);
            return View();
        }
        //Email
        public ActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(MailInfo model)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress(model.From);
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new System.Net.NetworkCredential(model.From, model.Password),
                EnableSsl = true
            };
            smtp.Send(mail);
            return RedirectToAction("Index", "Mail");
        }
    }
}
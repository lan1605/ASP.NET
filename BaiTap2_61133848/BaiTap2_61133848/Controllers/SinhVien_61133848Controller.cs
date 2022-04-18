using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTap2_61133848.Models;

namespace BaiTap2_61133848.Controllers
{
    public class SinhVien_61133848Controller : Controller
    {
        // GET: SinhVien_61133848
        //Use Action
        public ActionResult UseActionIndex()
        {
            return View();
        }
        public ActionResult UseAction(string Id, string Name,double Marks)
        {
            ViewBag.Id = Id;
            ViewBag.Name = Name;
            ViewBag.Marks = Marks;
            return View();
        }
        //-------------------------------------------
        //FormCollection
        public ActionResult UseFormCollectionIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UseFormCollection(FormCollection form)
        {
            ViewBag.Id = form["Id"];
            ViewBag.Name = form["Name"];
            ViewBag.Marks = form["Marks"];
            return View(ViewBag);
        }
        //--------------------------------------------
        //Request
        public ActionResult UseRequestIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UseRequest()
        {
            string Id = Request["Id"];
            string Name = Request["Name"];
            double Marks = double.Parse(Request["Marks"]);
            ViewBag.Id = Id;
            ViewBag.Name = Name;
            ViewBag.Marks = Marks;
            return View(ViewBag);
        }

        //---------------------------------------
        //UseModels

        public ActionResult UseModelIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UseModel(InfoModel info)
        {
            ViewBag.Id = info.Id;
            ViewBag.Name = info.Name;
            ViewBag.Marks = info.Marks;
            return View(ViewBag);
        }
    }
}
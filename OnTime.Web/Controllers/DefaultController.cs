using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnTime.DataLayer;
using OnTime.DataLayer.Entities;
using System.Configuration;

namespace OnTime.Web.Controllers
{
    public class DefaultController : Controller
    {
        private OnTimeContext db=new OnTimeContext();
        // GET: Default
        public ActionResult Index()
        {
            int totalRows = db.WeChatAccounts.Count();
           // int index=new Random().Next(totalRows);
            List<PageImage> images = db.Images.ToList();
            Session["images"] = images;
            ViewBag.ResourceRootPath= ConfigurationManager.AppSettings["admindomain"];
            return View(db.WeChatAccounts.Where(t=>t.Valid==true).OrderBy(c=>Guid.NewGuid()).FirstOrDefault());
           // return View(model);
        }
    }
}
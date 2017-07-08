using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnTime.DataLayer;
using OnTime.DataLayer.Entities;

namespace OnTime.Web.Controllers
{
    public class DefaultController : Controller
    {
        private OnTimeContext db=new OnTimeContext();
        // GET: Default
        public ActionResult Index()
        {
            int totalRows = db.WeChatAccounts.Count();
            int index=new Random().Next(totalRows);
            List<PageImage> images = db.Images.ToList();
            Session["images"] = images;
            return View(db.WeChatAccounts.OrderBy(c=>Guid.NewGuid()).Skip(index).FirstOrDefault());
           // return View(model);
        }
    }
}
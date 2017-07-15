using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnTime.DataLayer;
using OnTime.DataLayer.Entities;
using System.Configuration;
using System.Text.RegularExpressions;

namespace OnTime.Web.Controllers
{
    public class DefaultController : Controller
    {
        private OnTimeContext db=new OnTimeContext();
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

        public ActionResult JoinQQ()
        {
           
            return View(db.QQGroups.Where(t=>t.Valid==true).FirstOrDefault());
        }

        [HttpGet]
        public ActionResult DiagnosisStock()
        {
           // if (Request.Browser.IsMobileDevice)
           if(IsMobileBrowser())
            {
                return View("DiagnosisStockMobile");
            }
            else
            {
                return View("DiagnosisStock");
            }
        }

        [HttpPost]
        public ActionResult DiagnosisStock(string phone,string code)
        {
            //db.Customers.Any(t=>t.PhoneNum==phone)
            db.Customers.Add(new Customer()
            {
                PhoneNum = phone,
                StockCode=code,
                CreateTime = DateTime.Now
            });
            db.SaveChanges();
            return new EmptyResult();
        }

        public bool IsMobileBrowser()
        {
            Regex b= new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (b.IsMatch(Request.Headers["User-Agent"]))
            {
                return true;
            }
            return false;
        }
    }
}
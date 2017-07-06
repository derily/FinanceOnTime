using OnTime.AdminUI.Models;
using OnTime.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnTime.DataLayer.Entities;

namespace OnTime.AdminUI.Controllers
{
    public class WeChatManageController : Controller
    {
        private OnTimeContext db = new OnTimeContext();

        // GET: WeChatManage
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(Pagination pagination, string search)
        {
            //string[] _order = pagination.sidx.Split(',');
            int totalRows = db.WeChatAccounts.Count();
            pagination.records = totalRows;
            ViewPagerModel<WeChatAccount> list = new ViewPagerModel<WeChatAccount>();
            list.rows = db.WeChatAccounts.OrderBy(t => t.NickName).Skip(pagination.rows * (pagination.page - 1))
                .Take(pagination.rows).ToList();
            list.records =totalRows;
            list.total = pagination.total;
            list.page = pagination.page;
            //{
            //    rows = db.WeChatAccounts.OrderBy(t => t.NickName).Skip(pagination.rows * (pagination.page - 1))
            //        .Take(pagination.rows).ToList(),
            //    records = db.WeChatAccounts.Count(),
            //    total = pagination.total,
            //    page = pagination.page

            //};
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
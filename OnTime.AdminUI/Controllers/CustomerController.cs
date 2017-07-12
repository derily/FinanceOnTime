using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnTime.AdminUI.Models;
using OnTime.DataLayer;
using OnTime.DataLayer.Entities;

namespace OnTime.AdminUI.Controllers
{
    public class CustomerController : Controller
    {
        private OnTimeContext db = new OnTimeContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(Pagination pagination, string search)
        {
            int totalRows = db.Customers.Count();
            pagination.records = totalRows;
            ViewPagerModel<Customer> list = new ViewPagerModel<Customer>()
            {
                rows = db.Customers.OrderBy(t => t.CreateTime).Skip(pagination.rows * (pagination.page - 1))
                    .Take(pagination.rows).ToList(),
                records = totalRows,
                total = pagination.total,
                page = pagination.page
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
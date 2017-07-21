using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnTime.AdminUI.Models;
using OnTime.DataLayer;
using OnTime.DataLayer.Entities;

namespace OnTime.AdminUI.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private OnTimeContext db = new OnTimeContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(Pagination pagination, DateTime? startDate,DateTime? endDate)
        {
            int totalRows = 0;
            List<Customer> _rows = null;
            if (startDate.HasValue)
            {
                if (!endDate.HasValue)//假如结束日期没有值自动设置为当前日期
                {
                    endDate = DateTime.Now;
                }
                totalRows = db.Customers.Count(t => t.CreateTime >= startDate && t.CreateTime <= endDate);
                pagination.records = totalRows;
                _rows = db.Customers.Where(t => t.CreateTime >= startDate && t.CreateTime <= endDate)
                    .OrderByDescending(t => t.CreateTime).Skip(pagination.rows * (pagination.page - 1))
                    .Take(pagination.rows).ToList();
            }
            else
            {
                totalRows = db.Customers.Count();
                pagination.records = totalRows;
                _rows = db.Customers.OrderByDescending(t => t.CreateTime).Skip(pagination.rows * (pagination.page - 1))
                    .Take(pagination.rows).ToList();
            }

            ViewPagerModel<Customer> list = new ViewPagerModel<Customer>()
            {
                rows = _rows,
                records = totalRows,
                total = pagination.total,
                page = pagination.page
            };


            //int totalRows = db.Customers.Count();
            //pagination.records = totalRows;
            //ViewPagerModel<Customer> list = new ViewPagerModel<Customer>()
            //{
            //    rows = db.Customers.OrderByDescending(t => t.CreateTime).Skip(pagination.rows * (pagination.page - 1))
            //        .Take(pagination.rows).ToList(),
            //    records = totalRows,
            //    total = pagination.total,
            //    page = pagination.page
            //};

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExportExcel(Pagination pagination, DateTime? startDate, DateTime? endDate)
        {
            IEnumerable<Customer> data = null;
            if (startDate.HasValue)
            {

                if (!endDate.HasValue) //假如结束日期没有值自动设置为当前日期
                {
                    endDate = DateTime.Now;
                    data = db.Customers.Where(t => t.CreateTime >= startDate && t.CreateTime < endDate)
                        .OrderByDescending(t => t.CreateTime).Skip(pagination.rows * (pagination.page - 1))
                        .Take(pagination.rows).ToList();
                }
            }
            else
            {
                data = db.Customers.AsNoTracking().ToList();
            }
           // data.Select(new {手机号码=PhoneNumber})
            //var query = from c in data
            //    select new {手机号码 = c.PhoneNum, 股票代码 = c.StockCode, 创建日期 = c.CreateTime.ToShortDateString()};
            ExportFromTsv(data);
            return new EmptyResult();
        }

        private void ExportFromTsv(IEnumerable<Customer> data)
        {
            Response.AddHeader("content-disposition", "attachment;filename=contacts.xls");
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            Response.ContentEncoding = System.Text.Encoding.Default;
            WriteTsv(data, Response.Output);
            Response.End();
        }

        private void WriteTsv<T>(IEnumerable<T> data, TextWriter output)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                output.Write(prop.DisplayName); // header
                output.Write("\t");
            }
            output.WriteLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    output.Write(prop.Converter.ConvertToString(
                        prop.GetValue(item)));
                    output.Write("\t");
                }
                output.WriteLine();
            }
        }
    }
}
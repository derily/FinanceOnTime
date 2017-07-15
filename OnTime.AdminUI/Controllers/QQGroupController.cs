using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnTime.AdminUI.Models;
using OnTime.DataLayer;
using OnTime.DataLayer.Entities;

namespace OnTime.AdminUI.Controllers
{
    public class QQGroupController : Controller
    {
        private OnTimeContext db = new OnTimeContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetList(Pagination pagination, string search)
        {
            int totalRows = db.WeChatAccounts.Count();
            pagination.records = totalRows;
            ViewPagerModel<WeChatAccount> list = new ViewPagerModel<WeChatAccount>()
            {
                rows = db.WeChatAccounts.OrderBy(t => t.NickName).Skip(pagination.rows * (pagination.page - 1))
                    .Take(pagination.rows).ToList(),
                records = totalRows,
                total = pagination.total,
                page = pagination.page
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(WeChatAccount account)
        {
            if (account.Id != default(Guid))
            {
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.WeChatAccounts.Add(account);
            }
            db.SaveChanges();
            return Json(new { code = "ok", message = "success saved" });
        }

        public JsonResult UploadCodeImage(HttpPostedFileBase BarCodeImg)
        {
            if (BarCodeImg != null && BarCodeImg.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(BarCodeImg.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Resource/Images"), fileName);
                BarCodeImg.SaveAs(path);
                var result = new { success = true, message = "", path = "/Resource/Images/" + fileName };
                return Json(result);
            }
            else
            {
                var result = new { success = false, message = "上传二维码失败" };
                return Json(result);
            }
        }
    }
}
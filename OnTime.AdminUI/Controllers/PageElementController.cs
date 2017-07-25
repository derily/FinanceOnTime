using OnTime.AdminUI.Models;
using OnTime.DataLayer;
using OnTime.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTime.AdminUI.Controllers
{
    [Authorize]
    public class PageElementController : Controller
    {
        private OnTimeContext db = new OnTimeContext();
        // GET: PageElement
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetList(Pagination pagination, string search)
        {
            int totalRows = db.Images.Count();
            pagination.records = totalRows;
            ViewPagerModel<PageImage> list = new ViewPagerModel<PageImage>()
            {
                rows = db.Images.OrderBy(t => t.Position).Skip(pagination.rows * (pagination.page - 1))
                        .Take(pagination.rows).ToList(),
                records = totalRows,
                total = pagination.total,
                page = pagination.page
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save([Bind(Exclude ="Position")]PageImage img)
        {
            if (img.Id != default(Guid))
            {
               
                db.Entry(img).State = System.Data.Entity.EntityState.Modified;
                db.Entry(img).Property("Position").IsModified = false;
                db.Entry(img).Property("Valid").IsModified = false;
            }
            else
            {
                db.Images.Add(img);
            }
            db.SaveChanges();
            return Json(new { code = "ok", message = "success saved" });
        }

        public JsonResult UploadImage(HttpPostedFileBase img)
        {
            if (img != null && img.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(img.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Resource/Images"), fileName);
                img.SaveAs(path);
                var result = new { success = true, message = "上传图片成功", path = "/Resource/Images/" + fileName };
                return Json(result);
            }
            else
            {
                var result = new { success = false, message = "上传图片失败" };
                return Json(result);
            }
        }
    }
}
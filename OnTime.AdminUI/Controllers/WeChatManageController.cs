using OnTime.AdminUI.Models;
using OnTime.DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.Services.Description;
using OnTime.DataLayer.Entities;

namespace OnTime.AdminUI.Controllers
{
    [Authorize]
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
            ViewPagerModel<WeChatAccount> list = new ViewPagerModel<WeChatAccount>() {
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
            return Json(new {code="ok",message="success saved"});
        }

        public JsonResult UploadCodeImage(HttpPostedFileBase BarCodeImg)
        {
            #region old file upload

            //if (BarCodeImg == null || string.IsNullOrEmpty(BarCodeImg.FileName) || BarCodeImg.ContentLength == 0)
            //{
            //    BarCodeImg = Request.Files[0];
            //    if (BarCodeImg == null)
            //        return Json("{success:false,message:'图片未知'}");
            //}
            //// string fileMD5 = Md5.md5(BarCodeImg.InputStream);
            //// string FileEextension = Path.GetExtension(BarCodeImg.FileName);
            //var uploadDate = DateTime.Now.ToString("yyyyMMdd");

            //var virtualPath = $"~/Resource/Images/{uploadDate}/{BarCodeImg.FileName}"; ;
            //var fullFileName = this.Server.MapPath(virtualPath);

            ////创建文件夹，保存文件
            //var path = Path.GetDirectoryName(fullFileName);
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            //if (!System.IO.File.Exists(fullFileName))
            //{
            //    BarCodeImg.SaveAs(fullFileName);
            //}

            //// var data = new { success = true, file_path = virtualPath.Remove(0, 1) };

            //return Json("{success:true,message:'上传二维码图片成功'}");

            #endregion

            if (BarCodeImg != null && BarCodeImg.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(BarCodeImg.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Resource/Images"), fileName);
                BarCodeImg.SaveAs(path);
               var  result = new {success = true, message = "", path = "/Resource/Images/" + fileName};
                return Json(result);
            }
            else
            {
                var result = new {success = false, message = "上传二维码失败"};
                return Json(result);
            }
        }
    }
}
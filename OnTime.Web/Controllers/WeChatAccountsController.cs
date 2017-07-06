using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnTime.DataLayer;
using OnTime.DataLayer.Entities;

namespace OnTime.Web.Controllers
{
    public class WeChatAccountsController : Controller
    {
        private OnTimeContext db = new OnTimeContext();

        // GET: WeChatAccounts
        public ActionResult Index()
        {
            return View(db.WeChatAccounts.ToList());
        }

        // GET: WeChatAccounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeChatAccount weChatAccount = db.WeChatAccounts.Find(id);
            if (weChatAccount == null)
            {
                return HttpNotFound();
            }
            return View(weChatAccount);
        }

        // GET: WeChatAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeChatAccounts/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,NickName,BarCode,Valid")] WeChatAccount weChatAccount)
        {
            if (ModelState.IsValid)
            {
                db.WeChatAccounts.Add(weChatAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weChatAccount);
        }

        // GET: WeChatAccounts/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeChatAccount weChatAccount = db.WeChatAccounts.Find(id);
            if (weChatAccount == null)
            {
                return HttpNotFound();
            }
            return View(weChatAccount);
        }

        // POST: WeChatAccounts/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountId,NickName,BarCode,Valid")] WeChatAccount weChatAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weChatAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weChatAccount);
        }

        // GET: WeChatAccounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeChatAccount weChatAccount = db.WeChatAccounts.Find(id);
            if (weChatAccount == null)
            {
                return HttpNotFound();
            }
            return View(weChatAccount);
        }

        // POST: WeChatAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WeChatAccount weChatAccount = db.WeChatAccounts.Find(id);
            db.WeChatAccounts.Remove(weChatAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

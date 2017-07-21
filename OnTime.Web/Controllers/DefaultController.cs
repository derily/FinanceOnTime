using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnTime.DataLayer;
using OnTime.DataLayer.Entities;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Owin.Security;
using System.Net;
using Microsoft.AspNet.Identity.Owin;
using OnTime.Web.MailService;

namespace OnTime.Web.Controllers
{
    public class DefaultController : Controller
    {
        private OnTimeContext db=new OnTimeContext();
        private ApplicationUserManager _userManager;
        private bool mobileFlag=false;
        FileLogger log = new FileLogger();
        public DefaultController()
        {
            
        }
        public DefaultController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            int totalRows = db.WeChatAccounts.Count();
           // int index=new Random().Next(totalRows);
            ViewBag.images = db.Images.ToList();
           // Session["images"] = images;
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
               string query = Request.Url.PathAndQuery;
               mobileFlag = true;
               // log.ErrorLog(Server.MapPath("~/ErrorLog"),this.Request.Url.PathAndQuery);
               if (query == "/diag1" || query == "/diag2" || query == "/diag3")
               {
                   return View("DiagnosisStockMobile1");
               }
               else
               {
                   return View("DiagnosisStockMobile");
                }
            }
            else
            {
                return View("DiagnosisStock");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DiagnosisStock(string phone,string code,string source="pc")
        {
            if (db.Customers.Any(t => t.PhoneNum == phone))
            {
                return Json(new {success=false,message="您已经使用过此手机号码查询了" });
            }
           
            db.Customers.Add(new Customer()
            {
                PhoneNum = phone,
                StockCode=code,
                CreateTime = DateTime.Now,
                Source = source,
                ClientIPAddress = GetRealIP()
            });
            db.SaveChanges();


            //MailMessage message = new MailMessage();
            //message.From=new MailAddress("xiaod@lecaijing.com");
            //message.SubjectEncoding = System.Text.Encoding.UTF8;
            //message.Subject = "您有新客户关注！";
            //message.BodyEncoding= System.Text.Encoding.UTF8;
            string body = string.Format("客户：<strong>{0}</strong>想了解股票代码：<strong>{1}</strong><br/>来自乐财经", phone, code);
            //message.Body = body;
            //message.IsBodyHtml = true;
            //foreach (var user in UserManager.Users)
            //{
            //    message.To.Add(new MailAddress(user.Email));
            //}

            #region 发送邮件smtp client

            //try
            //{
            //    using (var smtp = new SmtpClient("smtp.exmail.qq.com:465"))
            //    {
            //        smtp.Credentials = new NetworkCredential("xiaod@lecaijing.com", "Lcj123456");
            //        smtp.EnableSsl = true;
            //        smtp.SendCompleted += SendCompleted;
            //        await smtp.SendMailAsync(message);
            //    }
            //}
            //catch (SmtpException ex)
            //{
            //    log.ErrorLog(Url.Content("~/ErrorLog"), ex.Message);
            //}

            #endregion

            #region 使用服务发送邮件

            try
            {
                OnTime.Web.MailService.WebServiceSoapClient client = new WebServiceSoapClient();
                foreach (var user in UserManager.Users)
                {
                    await client.SendEmalAsync(user.Email, " 您有新客户关注了。", body, "xiaod@lecaijing.com", "Lcj123456");
                }
               // await client.SendEmalAsync("517906030@qq.com", "测试邮件发送", "成功了", "xiaod@lecaijing.com", "Lcj123456");
            }
            catch (Exception ex)
            {
               // log.ErrorLog(Url.Content("~/ErrorLog"), ex.Message);
            }

            #endregion

            return Json(new {success=true,message= "提交成功，我们会将你关注的股票信息发送到您的手机。" });
        }

        private void SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                log.ErrorLog(Url.Content("~/ErrorLog"), e.Error.Message);
            }
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

        public string GetRealIP()
        {
            string result = String.Empty;
            result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //可能有代理   
            if (!string.IsNullOrWhiteSpace(result))
            {
                //没有"." 肯定是非IP格式  
                if (result.IndexOf(".") == -1)
                {
                    result = null;
                }
                else
                {
                    //有","，估计多个代理。取第一个不是内网的IP。  
                    if (result.IndexOf(",") != -1)
                    {
                        result = result.Replace(" ", string.Empty).Replace("\"", string.Empty);
                        string[] temparyip = result.Split(",;".ToCharArray());
                        if (temparyip != null && temparyip.Length > 0)
                        {
                            for (int i = 0; i < temparyip.Length; i++)
                            {
                                //找到不是内网的地址  
                                if (IsIPAddress(temparyip[i]) && temparyip[i].Substring(0, 3) != "10." && temparyip[i].Substring(0, 7) != "192.168" && temparyip[i].Substring(0, 7) != "172.16.")
                                {
                                    return temparyip[i];
                                }
                            }
                        }
                    }
                    //代理即是IP格式  
                    else if (IsIPAddress(result))
                    {
                        return result;
                    }
                    //代理中的内容非IP  
                    else
                    {
                        result = null;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }
        public bool IsIPAddress(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < 7 || str.Length > 15)
                return false;

            string regformat = @"^(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);

            return regex.IsMatch(str);
        }
    }
}
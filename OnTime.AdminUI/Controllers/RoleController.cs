using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnTime.DataLayer;
using Microsoft.AspNet.Identity.Owin;
using OnTime.AdminUI.Models;
using OnTime.DataLayer.Entities;

namespace OnTime.AdminUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;
        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
            
        }

        public RoleController(ApplicationUserManager userManager,ApplicationRoleManager roleManager, ApplicationDbContext context)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            _context = context;
        }

        public ApplicationDbContext Context
        {
            get { return _context ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>(); }
            private set { _context = value; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
            private set { _roleManager = value; }
        }
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(Pagination pagination, string search)
        {
            int totalRows = RoleManager.Roles.Count();
            pagination.records = totalRows;
            ViewPagerModel<ApplicationRole> list = new ViewPagerModel<ApplicationRole>()
            {
                //rows = UserManager.Users.Where(m=>m.Roles.Contains()).OrderBy(t => t.UserName).Skip(pagination.rows * (pagination.page - 1))
                //    .Take(pagination.rows).ToList(),
                rows = RoleManager.Roles.OrderBy(t => t.Name)
                    .Skip(pagination.rows * (pagination.page - 1))
                    .Take(pagination.rows).ToList(),
                records = totalRows,
                total = pagination.total,
                page = pagination.page
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole(roleViewModel.Name);
                var result = await RoleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    return Json(new {success = false, message = string.Join(";", result.Errors)});
                }
                else
                {
                    return Json(new {success = true, message = ""});
                }
            }
            else
            {
                return Json(new {success = false, message = "输入无效"});
            }
        }
    }
}
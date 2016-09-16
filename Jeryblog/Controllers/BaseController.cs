using System;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Jeryblog.Data;
using Jeryblog.General;
using Jeryblog.Services;

namespace Jeryblog.Controllers
{
    public class BaseController : Controller
    {
      /// <summary>
      /// 方法执行时 验证用户登录cookie 
      /// </summary>
      /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CheckLoginCookie();
            base.OnActionExecuting(filterContext);
        }

        protected readonly GeneralConfigInfo Configinfo;

        [Inject]
        public IServices MyService { get; set; }

        protected blog_users UserInfo
        {
            get
            {
                return Session["user"] as blog_users;
            }
        }

        public BaseController()
        {
            Configinfo = WebUtils.Configinfo;
        }

        [NonAction]
        protected void CheckLoginCookie()
        {
            if (Session["user"] as blog_users != null || Request.Cookies["cUser"] == null ||
                Request.Cookies["cPwd"] == null) return;
            var cUser = Request.Cookies["cUser"].Value;
            var cPwd = Request.Cookies["cPwd"].Value;

            var user = MyService.UserExist(cUser, cPwd);
            if (user != null)
            {
                Session.Add("user", user);
            }
            else
            {
                ClearLoginCookie();
            }
        }

        [NonAction]
        protected void ClearLoginCookie()
        {
            var cUser = new HttpCookie("cUser");
            var cPwd = new HttpCookie("cPwd");
            cUser.Expires = DateTime.Now.AddYears(-10);
            cPwd.Expires = DateTime.Now.AddYears(-10);
            Response.Cookies.Add(cUser);
            Response.Cookies.Add(cPwd);
        }

        [NonAction]
        protected string GetRootPath()
        {
            if (Url.RequestContext.HttpContext.Request.Url != null)
                return (Url.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority) +
                       Url.RequestContext.HttpContext.Request.ApplicationPath).TrimEnd('/');
            return string.Empty;
        }
    }
}

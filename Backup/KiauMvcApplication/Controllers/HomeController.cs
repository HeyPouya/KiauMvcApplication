using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiauMvcApplication.Models;
using KiauMvcApplication.Controllers;
using PagedList;

namespace KiauMvcApplication.Controllers
{

    public class HomeController : Controller
    {
        KiauShopDBEntities db = new KiauShopDBEntities();

        #region Index
        public ActionResult Index()
        {
           
            ViewBag.slideshow = db.SlideShowTb.OrderByDescending(c => c.SlideShowId).Take(5).ToList();
            ViewBag.Product = db.ProductTb.Where(c => c.ProductStatus == true && c.ProductIsSpeciall == false).OrderByDescending(c => c.ProductId).Take(10).ToList();
            ViewBag.News = db.NewsTb.OrderByDescending(c => c.NewsId).Take(3).ToList();
            ViewBag.About = db.AboutTb.OrderByDescending(c => c.AboutId).Take(1).ToList();
            ViewBag.spciallProduct = db.ProductTb.Where(c => c.ProductStatus == true && c.ProductIsSpeciall == true).OrderByDescending(c => c.ProductId).Take(4).ToList();
            return View();

        }
        #endregion

        #region Product

        public ActionResult Product(int id = 0)
        {
            //ViewBag.spciallProduct = db.ProductTb.Where(c => c.ProductStatus == true).OrderByDescending(c => c.ProductId).ToList();
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return View(ViewBag.spciallProduct.ToPagedList(pageNumber, pageSize));
            //return View();
            var Query = db.ProductTb.ToList();
            ViewBag.count = Query.Count;
            if (id > 0)
            {
                id--;
            }
            else
            {
                id = 0;
            }
            int first = id * 10;
            Query = Query.OrderBy(x => x.ProductId).Skip(first).Take(10).ToList();
            return View(Query);
        }

        #endregion

        #region Pinfo
        public ActionResult Pinfo(int id)
        {
            ViewBag.pinfo = (from x in db.ProductTb
                             where x.ProductId == id
                             select x).ToList().Take(1);
            ViewBag.sampleProject = db.ProductTb.Where(c => c.ProductStatus == true).OrderByDescending(c => c.ProductId).ToList().Take(4);
            return View();
        }
        #endregion

        #region News
        public ActionResult News()
        {
            ViewBag.Newspage = db.NewsTb.OrderByDescending(c => c.NewsId).ToList();
            return View();

        }
        #endregion

        #region news Description

        public ActionResult NewsDescript(int id)
        {
            ViewBag.NewsDescript = (from x in db.NewsTb
                                    where x.NewsId == id
                                    select x).ToList().Take(1);
            return View();

        }
        #endregion

        #region Search
        public ActionResult Search(string search)
        {
            ViewBag.Search = (from x in db.ProductTb
                              where x.ProductTitle.Contains(search) || x.ProfessorName.Contains(search) || x.StudentName.Contains(search)
                              select x).ToList();
            return View();
        }
        #endregion

        #region Contact Us
        public ActionResult Contact()
        {

            return View();

        }

        [HttpPost, ActionName("Contact")]
        public ActionResult Contactus(string uName, string uEmail, string uNumber, string uMessage)
        {
            ContactUsTb tb = new ContactUsTb();
            tb.CuFullName = uName;
            tb.CuEmail = uEmail;
            tb.CuCelephone = uNumber;
            tb.CuContent = uMessage;
            db.ContactUsTb.Add(tb);
            db.SaveChanges();
            return View();
        }

        #endregion

        #region Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserTb tb, string uFName, string uEmail, string uLName, string uPass)
        {
            tb.UserFirstName = uFName;
            tb.UserLastName = uLName;
            tb.UserEmail = uEmail;
            tb.UserPassword = uPass;
            tb.UserStatus = true;
            db.UserTb.Add(tb);
            db.SaveChanges();
            return View();
        }
        #endregion

        #region Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserTb tb, string uEmail, string uPass)
        {
            var query = (from x in db.UserTb
                         where x.UserEmail == uEmail && x.UserPassword == uPass
                         select x).FirstOrDefault();
            if (query != null)
            {
                Session.Add("login", "omid");
                return Redirect("~/Admin/Panel");
            }
            else
            {
                ViewBag.message = "نام کاربری یا رمز عبور اشتباه است";
                return View();
            }

        }

        #endregion

        #region About
        public ActionResult About()
        {
            return View();
        }
        #endregion

        #region News Letter

        public ActionResult NewsLetter(string NewsLetter)
        {
            NewslettersTb tb = new NewslettersTb();
            tb.NewslettersEmail = NewsLetter;
            db.NewslettersTb.Add(tb);
            db.SaveChanges();
            TempData["NewsLetter"] = "با موفقیت ارسال شد";
            return Redirect("~/Home/About");
        }
        #endregion
    }
}

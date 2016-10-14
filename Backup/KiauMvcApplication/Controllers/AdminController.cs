using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiauMvcApplication.Models;
using System.IO;

namespace KiauMvcApplication.Controllers
{
    public class AdminController : Controller
    {
        KiauShopDBEntities db = new KiauShopDBEntities();

        #region Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Panel
        public ActionResult Panel()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        #endregion

        #region Slide Show
        //OS===>Slide Show Create
        public ActionResult Slideshow()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Slideshow(SlideShowTb otb)
        {
            var uploadedfile = Request.Files[0];
            var filename = Path.GetFileName(uploadedfile.FileName);
            var fileSavePath = Server.MapPath("/Content/DinamicPics/" + filename);
            uploadedfile.SaveAs(fileSavePath);
            otb.SlideShowPhotoUrl = "../../Content/DinamicPics/" + filename;
            db.SlideShowTb.Add(otb);
            db.SaveChanges();
            ViewBag.message = "عملیات با موفقیت انجام شد";
            return View();
        }
        //OS===>Slide Show list
        public ActionResult SlideDetails()
        {
            ViewBag.sliderList = db.SlideShowTb.ToList();
            return View();
        }
        //Slide Show Delete
        public ActionResult DelSlide(int id)
        {
            var query = db.SlideShowTb.Find(id);
            return View(query);
        }
        [HttpPost, ActionName("DelSlide")]
        public ActionResult DeleteSlide(int id)
        {
            db.SlideShowTb.Remove(db.SlideShowTb.Find(id));
            db.SaveChanges();
            TempData["MessageDeleteSlider"] = "عملیات با موفقیت انجام شد";
            return RedirectToAction("SlideDetails");
        }
        //OS====>Edit Slide Show
        public ActionResult EditSlide(int id)
        {
            var query = db.SlideShowTb.Find(id);
            return View(query);
        }
        [HttpPost, ActionName("EditSlide")]
        public ActionResult EditSlider(int id, string SlideshowTitle)
        {

            var Query = db.SlideShowTb.Find(id);
            var uploadedfile = Request.Files[0];
            var filename = Path.GetFileName(uploadedfile.FileName);
            var fileSavePath = Server.MapPath("/Content/DinamicPics/" + filename);
            uploadedfile.SaveAs(fileSavePath);
            Query.SlideShowPhotoUrl = "../../Content/DinamicPics/" + filename;
            Query.SlideShowTitle = SlideshowTitle;
            db.SaveChanges();
            ViewBag.message = "عملیات با موفقیت انجام شد";
            return View();
        }
        #endregion

        #region Product Group
        //OS===>Slide Show Create
        public ActionResult ProductGroup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductGroup(ProductGroupTb otb)
        {
            db.ProductGroupTb.Add(otb);
            db.SaveChanges();
            ViewBag.message = "عملیات با موفقیت انجام شد";
            return View();
        }

        //OS===> Product Group list

        public ActionResult ProductGroupList()
        {
            ViewBag.ProductGroupList = db.ProductGroupTb.ToList();
            return View();
        }
        //Product Group Delete
        public ActionResult DelProductGroup(int id)
        {
            var query = db.ProductGroupTb.Find(id);
            return View(query);
        }
        [HttpPost, ActionName("DelProductGroup")]
        public ActionResult DeleteProductGroup(int id)
        {
            db.ProductGroupTb.Remove(db.ProductGroupTb.Find(id));
            db.SaveChanges();
            TempData["MessageDeleteSlider"] = "عملیات با موفقیت انجام شد";
            return RedirectToAction("SlideDetails");
        }
        //OS====>Edit Product Group
        public ActionResult EditProductGroup(int id)
        {
            var query = db.ProductGroupTb.Find(id);
            return View(query);
        }
        [HttpPost, ActionName("EditProductGroup")]
        public ActionResult EditProductGP(int id, string ProductGroupTitle)
        {

            var Query = db.ProductGroupTb.Find(id);
            Query.ProductGroupTitle = ProductGroupTitle;
            db.SaveChanges();
            ViewBag.message = "عملیات با موفقیت انجام شد";
            return View();
        }
        #endregion

        #region Product
        public ActionResult Product()
        {
            ViewBag.ddlProductGroup = new SelectList(db.ProductGroupTb, "ProductGroupId", "ProductGroupTitle");
            return View();
        }

        [HttpPost]
        public ActionResult Product(ProductTb otb, FormCollection form)
        {
            string strDDLValue = form["Productgroupddl"].ToString();
            //string strDDLValue = Request.Form["Productgroupddl"].ToString();
            var uploadedfile = Request.Files[0];
            var filename = Path.GetFileName(uploadedfile.FileName);
            var fileSavePath = Server.MapPath("/Content/DinamicPics/" + filename);
            uploadedfile.SaveAs(fileSavePath);
            otb.ProductPhotoUrl = "../../Content/DinamicPics/" + filename;

            //upload file 

            var uploadedfile2 = Request.Files[1];
            var filename2 = Path.GetFileName(uploadedfile2.FileName);
            var fileSavePath2 = Server.MapPath("/Content/productFile/" + filename2);
            uploadedfile2.SaveAs(fileSavePath2);
            otb.ProductFile = "../../Content/productFile/" + filename2;

            // Upload File free

            var uploadedfile3 = Request.Files[2];
            var filename3 = Path.GetFileName(uploadedfile3.FileName);
            var fileSavePath3 = Server.MapPath("/Content/productFile/" + filename3);
            uploadedfile2.SaveAs(fileSavePath3);
            otb.ProductFreeFile = "../../Content/productFile/" + filename3;
            otb.ProductIsSpeciall = false;
            otb.ProductStatus = true;
            otb.ProductGroupIdFK = int.Parse(strDDLValue);
            db.ProductTb.Add(otb);
            db.SaveChanges();
            ViewBag.Message = "عملیات با موفقیت انجام شد";

            ViewBag.ddlProductGroup = new SelectList(db.ProductGroupTb, "ProductGroupId", "ProductGroupTitle");
            return View();

        }
        //OS===>Product Detail
        public ActionResult ProductDetails()
        {
            ViewBag.ProductDetails = db.ProductTb.ToList();
            return View();
        }
        //OS===> Product Delete
        public ActionResult DelProduct(int id)
        {
            var query = db.ProductTb.Find(id);
            return View(query);
        }
        [HttpPost, ActionName("DelProduct")]
        public ActionResult DeleteProduct(int id)
        {
            db.ProductTb.Remove(db.ProductTb.Find(id));
            db.SaveChanges();
            ViewBag.Message = "عملیات با موفقیت انجام شد";
            return View();
        }

        public ActionResult EditProduct(int id)
        {
            var query = db.ProductTb.Find(id);
            return View(query);
        }
        [HttpPost, ActionName("EditProduct")]
        public ActionResult EditPro(int id, string ProductTitle, string ProductContent, string ProductPrice, string ProfessorName, string StudentName)
        {
            var query = db.ProductTb.Find(id);

            var uploadedfile = Request.Files[0];
            var filename = Path.GetFileName(uploadedfile.FileName);
            var fileSavePath = Server.MapPath("/Content/DinamicPics/" + filename);
            uploadedfile.SaveAs(fileSavePath);
            query.ProductPhotoUrl = "../../Content/DinamicPics/" + filename;

            //upload file 

            var uploadedfile2 = Request.Files[1];
            var filename2 = Path.GetFileName(uploadedfile2.FileName);
            var fileSavePath2 = Server.MapPath("/Content/productFile/" + filename2);
            uploadedfile2.SaveAs(fileSavePath2);
            query.ProductFile = "../../Content/productFile/" + filename2;

            // Upload File free

            var uploadedfile3 = Request.Files[2];
            var filename3 = Path.GetFileName(uploadedfile3.FileName);
            var fileSavePath3 = Server.MapPath("/Content/productFile/" + filename3);
            uploadedfile2.SaveAs(fileSavePath3);
            query.ProductFreeFile = "../../Content/productFile/" + filename3;

            query.ProductTitle = ProductTitle;
            query.ProductContent = ProductContent;
            query.ProductPrice = ProductPrice;
            query.ProfessorName = ProfessorName;
            query.StudentName = StudentName;
            db.SaveChanges();
            ViewBag.message = "عملیات با موفقیت انجام شد";
            return View();
        }
        #endregion

        #region News

        //OS====> Our Team
        public ActionResult News()
        {
            return View();
        }
        [HttpPost]
        public ActionResult News(NewsTb otb)
        {
            var uploadedfile = Request.Files[0];
            var filename = Path.GetFileName(uploadedfile.FileName);
            var fileSavePath = Server.MapPath("/Content/DinamicPics/" + filename);
            uploadedfile.SaveAs(fileSavePath);
            otb.NewsPhotoUrl = "../../Content/DinamicPics/" + filename;
            db.NewsTb.Add(otb);
            db.SaveChanges();
            ViewBag.Message = "عملیات با موفقیت انجام شد";
            return View();
        }
        //OS===> News list
        public ActionResult Newslist()
        {
            ViewBag.NewsList = db.NewsTb.ToList();
            return View();
        }
        //News Delete
        public ActionResult DelNews(int id)
        {
            var query = db.NewsTb.Find(id);
            return View(query);
        }
        [HttpPost, ActionName("DelNews")]
        public ActionResult DeleteNews(int id)
        {
            db.NewsTb.Remove(db.NewsTb.Find(id));
            db.SaveChanges();
            ViewBag.Message = "عملیات با موفقیت انجام شد";
            return View();
        }
        //OS===>News Delete
        public ActionResult EditNews(int id)
        {
            var query = db.NewsTb.Find(id);
            return View(query);
        }
        [HttpPost, ActionName("EditNews")]
        public ActionResult EditNews(int id, string NewsTitle, string NewsDescription, string NewsContent)
        {
            var query = db.NewsTb.Find(id);
            var uploadedfile = Request.Files[0];
            var filename = Path.GetFileName(uploadedfile.FileName);
            var fileSavePath = Server.MapPath("/Content/DinamicPics/" + filename);
            uploadedfile.SaveAs(fileSavePath);
            query.NewsPhotoUrl = "../../Content/DinamicPics/" + filename;
            query.NewsTitle = NewsTitle;
            query.NewsDescription = NewsDescription;
            query.NewsContent = NewsContent;
            query.NewsDate = DateTime.Now;
            db.SaveChanges();
            ViewBag.message = "عملیات با موفقیت انجام شد";
            return View();
        }
        #endregion
    }
}

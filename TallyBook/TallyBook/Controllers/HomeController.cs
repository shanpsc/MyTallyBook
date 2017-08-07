using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallyBook.Models;

namespace TallyBook.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 關於
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// 聯絡
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 記帳明細
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Details()
        {
            DetailsViewModel detailVM = new DetailsViewModel();
            ItemModels data1 = new ItemModels() { Type = "支出", Amount = 1299, DataDate = DateTime.Now, Memo = "買書" };
            ItemModels data2 = new ItemModels() { Type = "支出", Amount = 100, DataDate = DateTime.Now.AddDays(2), Memo = "午餐" };
            ItemModels data3 = new ItemModels() { Type = "支出", Amount = 8000, DataDate = DateTime.Now.AddMonths(-1), Memo = "房租" };

            detailVM.DetailList = new List<ItemModels>();
            detailVM.DetailList.Add(data1);
            detailVM.DetailList.Add(data2);
            detailVM.DetailList.Add(data3);

            return View(detailVM);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallyBook.Models;
using PagedList;

namespace TallyBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountBookService _accountBookSvc;

        private int defaultPageSize = 25;

        public HomeController()
        {
            _accountBookSvc = new AccountBookService();
        }

        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {
            return View(page);
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
        public ActionResult Details(int? page)
        {
            List<ItemModels> detailList = new List<ItemModels>();

            detailList = _accountBookSvc.Lookup().OrderBy(x => x.DataDate).ToList();
            int currentPage = (page.HasValue ? ( page.Value<1 ? 1 : page.Value) : 1);
            return View(detailList.ToPagedList(currentPage, defaultPageSize));
        }
    }
}
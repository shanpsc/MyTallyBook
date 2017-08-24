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
            IndexViewModel vm = new IndexViewModel();
            vm.pageNum = page;

            List<SelectListItem> typeList = new List<SelectListItem>(GetTypeData());
            ViewBag.typeSelectList = typeList;

            return View(vm);
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

            detailList = _accountBookSvc.Lookup().OrderByDescending(x => x.DataDate).ToList();
            int currentPage = (page.HasValue ? ( page.Value<1 ? 1 : page.Value) : 1);
            return View(detailList.ToPagedList(currentPage, defaultPageSize));
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel vm)
        {
            bool isSuccess = true;
            if (ModelState.IsValid)
            {
                if (vm.item != null)
                {
                    if (vm.item.DataDate.Date > DateTime.Now.Date)
                    {
                        ModelState.AddModelError("item.DataDate", "日期不可大於今天!");
                        isSuccess = false;
                    }

                    if (isSuccess)
                    {
                        _accountBookSvc.Add(vm.item);
                        
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid input item!");
                }
            }

            List<SelectListItem> typeList = new List<SelectListItem>(GetTypeData());
            ViewBag.typeSelectList = typeList;
            return View(vm);
            
        }

        
        private List<SelectListItem> GetTypeData()
        {
            List<SelectListItem> dataList = new List<SelectListItem>();
            dataList.Add(new SelectListItem() { Text = "支出", Value = "0" });
            dataList.Add(new SelectListItem() { Text = "收入", Value = "1" });
            return dataList;

        }
    }
}
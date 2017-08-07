using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallyBook.Models
{
    public class DetailsViewModel
    {
        /// <summary>
        /// 顯示明細
        /// </summary>
        public List<ItemModels> DetailList { get; set; }
    }
}
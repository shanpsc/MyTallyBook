using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TallyBook.Models
{
    public class ItemModels
    {
        /// <summary>
        /// 類別
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        public Decimal Amount { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataDate  { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { get; set; }
    }
}
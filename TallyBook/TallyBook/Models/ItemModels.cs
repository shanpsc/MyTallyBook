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
        [Display(Name = "類別")]
        public string Type { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        [Display(Name = "金額")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="金額需為正整數!")]
        public Decimal Amount { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime DataDate  { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Display(Name = "備註")]
        [StringLength(100)]
        [Required]
        public string Memo { get; set; }

    }
}
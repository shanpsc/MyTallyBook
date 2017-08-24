using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TallyBook.Models
{
    public class IndexViewModel
    {
        public ItemModels item { get; set; }

        public int pageNum { get; set; }

    }
}
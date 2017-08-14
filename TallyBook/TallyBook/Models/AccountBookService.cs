﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TallyBook.Models;

namespace TallyBook.Models
{
    public class AccountBookService
    {
        private readonly SkillTreeHomeworkEntities _db;

        public AccountBookService()
        {
            _db = new SkillTreeHomeworkEntities();
        }

        public List<ItemModels> Lookup()
        {
            var rst = (from item in _db.AccountBook
                       select new ItemModels
                       {
                           Type = item.Categoryyy.ToString(),
                           DataDate = item.Dateee,
                           Amount = item.Amounttt,
                           Memo = item.Remarkkk
                       });
            return rst.ToList();
        }
    }
}
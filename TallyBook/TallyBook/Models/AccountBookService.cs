using System;
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

        public IQueryable<ItemModels> Lookup()
        {
            var rst = (from item in _db.AccountBook
                       select new ItemModels
                       {
                           Type = (item.Categoryyy == 0 ? "支出": "收入"),
                           DataDate = item.Dateee,
                           Amount = item.Amounttt,
                           Memo = item.Remarkkk
                       });
            return rst;
        }

        public void Add(ItemModels item)
        {
            int intType;
            AccountBook i = new AccountBook()
            {
                Id = Guid.NewGuid(),
                Categoryyy = (int.TryParse(item.Type, out intType)? intType : 0),
                Dateee = item.DataDate,
                Amounttt = (int)item.Amount,
                Remarkkk = item.Memo
            };

            _db.AccountBook.Add(i);
            _db.SaveChanges();
        }

    }
}
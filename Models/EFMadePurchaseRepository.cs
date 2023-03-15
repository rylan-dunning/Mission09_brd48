using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_brd48.Models
{
    public class EFMadePurchaseRepository : IMadePurchaseRepository
    {
        private BookstoreContext context;

        public EFMadePurchaseRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<MadePurchase> MadePurchases => context.MadePurchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveMadePurchase(MadePurchase madePurchase)
        {
            context.AttachRange(madePurchase.Lines.Select(x => x.Book));
            
            if (madePurchase.PurchaseId == 0)
            {
                context.MadePurchases.Add(madePurchase);
            }

            context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_brd48.Models
{
    public interface IMadePurchaseRepository
    {
        public IQueryable<MadePurchase> MadePurchases { get; }

        public void SaveMadePurchase(MadePurchase madePurchase);
    }
}

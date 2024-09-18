using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    public interface IPurchasesRepository
    {
        void AddPurchase(Purchases purchase);
        void RemovePurchase(int id);
        List<Purchases> GetAllPurchases();
        Purchases GetPurchaseById(int id);
    }



    public class PurchasesRepository : IPurchasesRepository
    {
        public List<Purchases> _purchases = new List<Purchases>();

        public void AddPurchase(Purchases purchase)
        {

            _purchases.Add(purchase);
        }

        public void RemovePurchase(int id)
        {
            var purchase = _purchases.FirstOrDefault(p => p.purchase_id == id);
            if (purchase != null)
            {
                _purchases.Remove(purchase);
            }
        }

        public List<Purchases> GetAllPurchases()
        {
            return _purchases;
        }

        public Purchases GetPurchaseById(int id)
        {
            return _purchases.FirstOrDefault(p => p.purchase_id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    public interface ISalesRepository
    {
        void AddSale(Sales sale);
        void RemoveSale(int id);
        List<Sales> GetAllSales();
        Sales GetSaleById(int id);
    }



    public class SalesRepository : ISalesRepository
    {
        public List<Sales> _sale = new List<Sales>();

        public void AddSale(Sales sale)
        {
            _sale.Add(sale);
        }

        public void RemoveSale(int id)
        {
            var sale = _sale.FirstOrDefault(p => p.sale_id == id);
            if (sale != null)
            {
                _sale.Remove(sale);
            }
        }

        public List<Sales> GetAllSales()
        {
            return _sale;
        }

        public Sales GetSaleById(int id)
        {
            return _sale.FirstOrDefault(p => p.sale_id == id);
        }



    }
}

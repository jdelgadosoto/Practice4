using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    public class Purchases
    {
        public int purchase_id { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public DateTime Date { get; set; }


        public Purchases(int id, string name, int _quantity, DateTime date) 
        { 
            purchase_id = id;
            productName = name;
            quantity = _quantity;
            Date = date;
        }

    }
}

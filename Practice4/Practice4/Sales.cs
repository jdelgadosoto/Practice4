
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    public class Sales
    {
        public int sale_id {  get; set; }
        public string product_name {  get; set; }
        public int quantity { get; set; }

        public DateTime Date { get; set; }

        public Sales(int id, string name,  int _quantity, DateTime date)
        {
            sale_id = id;
            product_name = name;
            quantity = _quantity;
            Date = date;
        }

    }

}

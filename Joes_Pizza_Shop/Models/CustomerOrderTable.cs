using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Joes_Pizza_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CustomerOrderTable
    {
        [Key]
        public int CustomerOrderID { get; set; }
        [ForeignKey("PizzaItem")]
        public Nullable<int> PID { get; set; }
        public int Quantity { get; set; }
        public int Purchased { get; set; }
        [ForeignKey("Order")]
        public Nullable<int> OrderID { get; set; }
        public Nullable<double> TotalPricePerItem { get { return (double)Quantity * PizzaItem.Price; } }
        public virtual Order Order { get; set; }
        public virtual PizzaItem PizzaItem { get; set; }
    }
}

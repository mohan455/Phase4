using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Joes_Pizza_Shop.Models
{
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.CustomerOrderTables = new HashSet<CustomerOrderTable>();
        }

        [Key]
        public int OrderID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<double> TotalAmount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerOrderTable> CustomerOrderTables { get; set; }
    }
}

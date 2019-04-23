using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeetrootModels.DbModels
{
    public class OrderService
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        public Order Order { get; set; }
        public Service Service { get; set; }
    }
}

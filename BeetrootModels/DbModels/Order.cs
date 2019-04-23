using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeetrootModels.DbModels
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public DateTime OrderDateCreate { get; set; }

        [MaxLength(250)]
        public string Message { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        [ForeignKey("PersonalInfo")]
        public int PersonInfoId { get; set; }

        public List<OrderService> OrderServices { get; set; }
        public Car Car { get; set; }
        public PersonalInfo PersonalInfo { get; set; }


    }
}

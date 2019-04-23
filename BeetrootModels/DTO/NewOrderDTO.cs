using BeetrootModels.Enums;
using System;
using System.Collections.Generic;

namespace BeetrootModels.DTO
{
    public class NewOrderDTO
    {
        public int Id { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public DateTime OrderDateCreate { get; set; }
        public string Message { get; set; }
        public int CarId { get; set; }
        public int PersonInfoId { get; set; }

        public CarDTO Car { get; set; }
        public PersonalInfoDTO Person { get; set; }
        public List<Service> Services { get; set; }
    }
}

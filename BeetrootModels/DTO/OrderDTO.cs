using System;

namespace BeetrootModels.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public DateTime OrderDateCreate { get; set; }
        public string Message { get; set; }

        public int CarId { get; set; }
        public int PersonInfoId { get; set; }
    }
}

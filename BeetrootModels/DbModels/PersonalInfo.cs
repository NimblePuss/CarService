using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeetrootModels.DbModels
{
    public class PersonalInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public List<Order> Orders { get; set; }
    }
}

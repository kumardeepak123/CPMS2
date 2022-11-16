using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Password { get; set; }

        [MaxLength(11)]
        public string Phone { get; set; }

        [MaxLength(30)]
        public string Designation { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }

    }
}

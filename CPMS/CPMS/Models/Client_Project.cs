using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Models
{
    public class Client_Project
    {
        public int Id { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

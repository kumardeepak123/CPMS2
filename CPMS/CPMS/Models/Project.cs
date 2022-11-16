using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CPMS.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required, MaxLength(100)]
        public string Technology { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string FRequirement { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string NFRequirement { get; set; }

        [Required]
        public long Budget { get; set; }

        
 /*       [ForeignKey("ClientId")]
        public Client _Client { get; set; }
        public int? ClientId { get; set; }*/

        public List<Client_Project> Client_Projects { get; set; }
        public List<Team> Teams { get; set; }
    }

}

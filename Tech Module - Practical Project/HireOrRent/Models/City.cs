using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HireOrRent.Models
{
    public class City
    {
        public City()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public City(string name)
             :this()
        {
            this.Name = name;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
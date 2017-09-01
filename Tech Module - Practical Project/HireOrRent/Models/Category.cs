using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HireOrRent.Models
{
    public class Category
    {
        public Category()
        {
            this.Advertisements = new HashSet<Advertisement>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}

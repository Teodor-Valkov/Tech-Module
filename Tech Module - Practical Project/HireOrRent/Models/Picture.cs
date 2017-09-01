using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HireOrRent.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        public int PictureSize { get; set; }

        public string Name { get; set; }

        public byte[] PictureData { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select file")]
        public HttpPostedFileBase File { get; set; }
    }
}
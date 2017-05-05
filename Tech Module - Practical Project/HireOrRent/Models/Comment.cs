using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HireOrRent.Models
{
    public class Comment
    {
        public Comment()
        {
            this.DateAdded = DateTime.Now;
        }

        public Comment(string content, string authorId, int advertisementId)
        {
            this.Content = content;
            this.AuthorId = authorId;
            this.AdvertisementId = advertisementId;
            this.DateAdded = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        [ForeignKey("Advertisement")]
        public int AdvertisementId { get; set; }

        public virtual Advertisement Advertisement { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public bool IsAuthor(string authorId)
        {
            return this.Author.Id.Equals(authorId);
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace HireOrRent.ModelsView
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
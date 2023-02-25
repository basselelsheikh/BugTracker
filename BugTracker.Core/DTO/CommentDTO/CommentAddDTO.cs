using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTO.CommentDTO
{
    public class CommentAddDTO
    {
        [Required(ErrorMessage = "Comment can't be empty")]
        public string? CommentText { get; set; }
    }
}

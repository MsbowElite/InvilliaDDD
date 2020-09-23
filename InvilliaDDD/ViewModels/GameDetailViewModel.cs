using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvilliaDDD.Core.ViewModels
{
    public class GameDetailViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        public string BorrowedFriendName { get; set; }
    }
}

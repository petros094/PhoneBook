using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.PhoneBookModel
{
  public  class ContactField
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Field { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [StringLength(100)]
        public string Value { get; set; }

        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}

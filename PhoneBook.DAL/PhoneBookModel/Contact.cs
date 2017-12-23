using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.PhoneBookModel
{
    public class Contact
    {
        public Contact()
        {
            ContactField = new HashSet<ContactField>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(400)]
        public string Name { get; set; }

        public virtual ICollection<ContactField> ContactField { get; set; }
    }
}

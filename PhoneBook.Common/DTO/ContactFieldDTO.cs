using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Common.DTO
{
   public class ContactFieldDTO
    {
        public int Id { get; set; }
        
        public string Field { get; set; }
        
        public string Value { get; set; }

        public int ContactId { get; set; }
    }
}

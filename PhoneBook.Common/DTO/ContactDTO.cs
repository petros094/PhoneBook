using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Common.DTO
{
    public class ContactDTO
    {
        public ContactDTO()
        {
            ContactFields = new List<ContactFieldDTO>();
        }
        public int Id { get; set; }
        
        public string Name { get; set; }

        public  List<ContactFieldDTO> ContactFields { get; set; }
    }
}

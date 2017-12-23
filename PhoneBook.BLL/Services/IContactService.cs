using PhoneBook.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Services
{
  public  interface IContactService
    {
        bool AddNewContact(ContactDTO model);
        bool EditContact(ContactDTO model);
        bool DeleteContact(int id);
        List<ContactDTO> ContactPageDetails(int page, int pagesize);
        int TotalPageCount(int pageCount);
        ContactDTO GetContactWithFeilds(int id);
        List<ContactDTO> ContactSearch(string name);
    }
}

using PhoneBook.Common.DTO;
using PhoneBook.DAL.PhoneBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Repositories
{
  public  interface IContactRepository
    {
        bool AddNewContact(ContactDTO model);
        bool EditContact(ContactDTO model);
        bool DeleteContact(int id);
        List<Contact> ContactPageDetails(int page, int pagesize);
        int TotalPageCount(int pageCount);
        List<ContactField> GetCFbyContactId(int contactID);
        ContactDTO GetContactWithFeilds(int id);
        List<Contact> ContactSearch(string name);
    }
}

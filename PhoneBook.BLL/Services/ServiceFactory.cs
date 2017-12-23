using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Services
{
  public  class ServiceFactory
    {

        private static IContactService contactService;

        public static IContactService ContactService
        {
            get
            {
                contactService = contactService ?? new ContactService();
                return contactService;
            }
        }
    }
}

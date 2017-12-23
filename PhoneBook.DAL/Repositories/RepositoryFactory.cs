using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Repositories
{
   public class RepositoryFactory
    {
        private static IContactRepository contactRepository;

        public static IContactRepository ContactRepository
        {
            get
            {
                contactRepository = contactRepository ?? new ContactRepository();
                return contactRepository;
            }
        }
    }
}

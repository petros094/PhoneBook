using PhoneBook.Common.DTO;
using PhoneBook.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Services
{
    public class ContactService:IContactService
    {
        private readonly IContactRepository conTactRepository;
        public ContactService()
        {
            this.conTactRepository = RepositoryFactory.ContactRepository;
        }

        public bool AddNewContact(ContactDTO model)
        {
            return conTactRepository.AddNewContact(model);
        }
        public bool EditContact(ContactDTO model)
        {
            return conTactRepository.EditContact(model);
        }
        public bool DeleteContact(int id)
        {
            return conTactRepository.DeleteContact(id);
        }

        public List<ContactDTO> ContactPageDetails(int page, int pagesize)
        {
            var dbResult = conTactRepository.ContactPageDetails(page, pagesize);
            if (dbResult == null)
            {
                return new List<ContactDTO>();
            }
            var result = dbResult.Select(s => new ContactDTO
            {
                Id = s.Id,
                Name = s.Name,
                ContactFields = conTactRepository.GetCFbyContactId(s.Id).Select(s1 => new ContactFieldDTO
                {
                    Id = s1.Id,
                    Field = s1.Field,
                    Value = s1.Value
                }).ToList()
            }).ToList();
            return result;
        }
        public int TotalPageCount(int pageCount)
        {
            return conTactRepository.TotalPageCount(pageCount);
        }

        public ContactDTO GetContactWithFeilds(int id)
        {
            return conTactRepository.GetContactWithFeilds(id);
        }

        public List<ContactDTO> ContactSearch(string name)
        {
            var dbResult = conTactRepository.ContactSearch(name);
            if (dbResult == null)
            {
                return new List<ContactDTO>();
            }
            var result = dbResult.Select(s => new ContactDTO
            {
                Id = s.Id,
                Name = s.Name,
                ContactFields = conTactRepository.GetCFbyContactId(s.Id).Select(s1 => new ContactFieldDTO
                {
                    Id = s1.Id,
                    Field = s1.Field,
                    Value = s1.Value
                }).ToList()
            }).ToList();
            return result;
        }
    }
}

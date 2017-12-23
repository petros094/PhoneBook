using PhoneBook.Common.DTO;
using PhoneBook.DAL.PhoneBookModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public bool AddNewContact(ContactDTO model)
        {
            try
            {
                using (var dbContext = new PhoneBookContext())
                {
                    var contact = new Contact();
                    contact.Name = model.Name;
                    foreach (var field in model.ContactFields)
                    {
                        var cf = new ContactField();
                        cf.Field = field.Field;
                        cf.Value = field.Value;
                        contact.ContactField.Add(cf);
                    }
                    dbContext.Contact.Add(contact);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool EditContact(ContactDTO model)
        {
            try
            {
                using (var dbContext = new PhoneBookContext())
                {
                    var contact = new Contact();
                    contact.Id = model.Id;
                    contact.Name = model.Name;
                    foreach (var field in model.ContactFields)
                    {
                        var cf = new ContactField();
                        cf.Id = field.Id;
                        cf.Field = field.Field;
                        cf.Value = field.Value;
                        cf.ContactId = field.ContactId;
                        dbContext.ContactField.AddOrUpdate(cf);
                    }
                    dbContext.Contact.AddOrUpdate(contact);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteContact(int id)
        {
            try
            {
                using (var dbContext = new PhoneBookContext())
                {
                    var tempContactFeilds = dbContext.ContactField.Where(w => w.ContactId == id);
                    var tempcontact = dbContext.Contact.FirstOrDefault(f => f.Id == id);
                    dbContext.ContactField.RemoveRange(tempContactFeilds);
                    if (tempcontact != null)
                        dbContext.Contact.Remove(tempcontact);

                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Contact> ContactPageDetails(int page, int pagesize)
        {
            try
            {
                using (var dbContext = new PhoneBookContext())
                {
                    return dbContext.Contact.OrderBy(o => o.Name).Skip((page - 1) * pagesize).Take(pagesize).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Contact>();
            }
        }



        public List<ContactField> GetCFbyContactId(int contactID)
        {
            try
            {
                using (var dbcontext = new PhoneBookContext())
                {
                    return dbcontext.Contact.Single(x => x.Id == contactID).ContactField.ToList();

                }
            }
            catch (Exception)
            {
                return new List<ContactField>();
            }
        }

        public int TotalPageCount(int pageCount)
        {
            using (var dbContext = new PhoneBookContext())
            {
                try
                {
                    return (int)Math.Ceiling((double)dbContext.Contact.Count() / pageCount); ;
                }
                catch (Exception ex)
                {
                    return 0;
                }

            }
        }


        public ContactDTO GetContactWithFeilds(int id)
        {
            try
            {
                using (var dbContext = new PhoneBookContext())
                {
                    var contact = dbContext.Contact.FirstOrDefault(f => f.Id == id);
                    var contactfeilds = dbContext.ContactField.Where(w => w.ContactId == id);
                    if (contact != null)
                    {
                        return new ContactDTO
                        {
                            Id = id,
                            Name = contact.Name,
                            ContactFields = contactfeilds.Select(s => new ContactFieldDTO
                            {
                                Id = s.Id,
                                ContactId = id,
                                Field = s.Field,
                                Value = s.Value
                            }).ToList()

                        };
                    }
                    else
                    {
                        return new ContactDTO();
                    }

                }

            }
            catch (Exception ex)
            {
                return new ContactDTO();
            }
        }

        public List<Contact> ContactSearch(string name)
        {
            try
            {

                using (var dbContext = new PhoneBookContext())
                {

                    if (!string.IsNullOrEmpty(name))
                    {
                        return dbContext.Contact.Where(a => a.Name.Contains(name)).ToList();
                    }
                    else {
                        return new List<Contact>();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return new List<Contact>();
            }

        }
    }
}

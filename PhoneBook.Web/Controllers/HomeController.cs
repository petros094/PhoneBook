using PhoneBook.BLL.Services;
using PhoneBook.Common.DTO;
using PhoneBook.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IContactService contactService;

        public HomeController()
        {
            this.contactService = ServiceFactory.ContactService;
        }
        // GET: Home
        public ActionResult Index(int? pageNumber, int? pagesize)
        {
            pageNumber = pageNumber ?? 1;
            pagesize = pagesize ?? 5;
            ViewBag.pageNum = pageNumber;
            if (pagesize == 0)
            {
                pagesize = 5;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            ViewBag.Count = contactService.TotalPageCount((int)pagesize);
            var model = contactService.ContactPageDetails((int)pageNumber, (int)pagesize);
            return View(model);
        }

        public ActionResult AddContact(ContactModel model)
        {
            var contact = new ContactDTO();
            contact.Name = model.Name;
            contact.ContactFields.Add(new ContactFieldDTO
            {
                Field = "Phone",
                Value = model.Phone
            });
            contact.ContactFields.Add(new ContactFieldDTO
            {
                Field = "Email",
                Value = model.Email
            });
            contactService.AddNewContact(contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditContact(int id)
        {

            var model = contactService.GetContactWithFeilds(id);
            return View(model);

        }

        [HttpPost]
        public ActionResult EditContact(ContactDTO model)
        {
            var result = contactService.EditContact(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("ERRORView");
            }

        }

        public ActionResult DeleteContact(int id)
        {
            
            contactService.DeleteContact(id);
            return RedirectToAction("Index");
        }

    }
}
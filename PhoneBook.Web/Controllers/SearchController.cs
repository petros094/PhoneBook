using PhoneBook.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Web.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string name)
        {
                var model=ServiceFactory.ContactService.ContactSearch(name);
            return View(model);
        }
    }
}
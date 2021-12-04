using AutoMapper;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        private IContactDetailService _contactDetailService;

        public ContactController(IContactDetailService contactDetailService)
        {
            this._contactDetailService = contactDetailService;
        }

        public ActionResult Index()
        {
            //var model = _contactDetailService.GetDefaultContact();
            //var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return View();
        }
    }
}
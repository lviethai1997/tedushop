using AutoMapper;
using BotDetect.Web.Mvc;
using System.Text;
using System.Web.Mvc;
using TeduShop.Common;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Extenstion;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        private IContactDetailService _contactDetailService;

        private IFeedBackService _feedBackService;

        public ContactController(IContactDetailService contactDetailService, IFeedBackService feedBackService)
        {
            this._contactDetailService = contactDetailService;
            this._feedBackService = feedBackService;
        }

        public ActionResult Index()
        {
            FeedBackViewModel viewModel = new FeedBackViewModel();
            viewModel.contactDetailViewModel = getDetails();
            return View(viewModel);
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "ContactCatcha", "Mã xác nhận không đúng!")]
        public ActionResult SendFeedBack(FeedBackViewModel feedBackViewModel)
        {
            feedBackViewModel.contactDetailViewModel = getDetails();
            if (ModelState.IsValid)
            {
                FeedBack feedBack = new FeedBack();
                feedBack.UpdateFeedBack(feedBackViewModel);
                _feedBackService.Create(feedBack);
                _feedBackService.Save();

                ViewData["SuccessMsg"] = "Gửi phản hồi thành công!";

                StringBuilder builder = new StringBuilder();
                builder.Append("");

                MailHelper.SendMail(feedBackViewModel.Email, "Thông tin liên hệ", builder.ToString());

                feedBackViewModel.Name = string.Empty;
                feedBackViewModel.Email = string.Empty;
                feedBackViewModel.Message = string.Empty;
            }
            return View("Index", feedBackViewModel);
        }

        private ContactDetailViewModel getDetails()
        {
            var model = _contactDetailService.GetDefaultContact();
            var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return contactViewModel;
        }
    }
}
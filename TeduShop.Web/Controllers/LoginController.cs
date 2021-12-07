using BotDetect.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Web.App_Start;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public LoginController(ApplicationSignInManager applicationSignInManager, ApplicationUserManager applicationUserManager)
        {
            this._signInManager = applicationSignInManager;
            this._userManager = applicationUserManager;
        }

        public ApplicationSignInManager signInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager userManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginUser(string returnURL)
        {
            ViewBag.returnURL = returnURL;
            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "LoginCaptcha", "Mã xác nhận không đúng!")]
        public async Task<ActionResult> LoginUser(LoginViewModel loginViewModel, string returnURL)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindAsync(loginViewModel.UserName, loginViewModel.Password);

                if (user != null)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                    ClaimsIdentity identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationProperties props = new AuthenticationProperties();
                    props.IsPersistent = loginViewModel.RememberMe;
                    authenticationManager.SignIn(props, identity);
                    if (Url.IsLocalUrl(returnURL))
                    {
                        return Redirect(returnURL);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Tài khoản hoặc mật khẩu không đúng");
                }
            }
            ViewBag.returnURL = returnURL;
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("LoginUser", "Login");
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "RegisterCaptcha", "Mã xác nhận không đúng!")]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var userFind = await _userManager.FindByEmailAsync(registerViewModel.Email);
                var userNameFind = await _userManager.FindByNameAsync(registerViewModel.UserName);

                if (userFind != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại!");
                    return View(registerViewModel);
                }

                if (userNameFind != null)
                {
                    ModelState.AddModelError("Username", "Tài khoản đã tồn tại!");
                    return View(registerViewModel);
                }

                var user = new ApplicationUser()
                {
                    UserName = registerViewModel.UserName,
                    FullName = registerViewModel.FullName,
                    Email = registerViewModel.Email,
                    PasswordHash = registerViewModel.Password,
                    Address = registerViewModel.Address,
                    PhoneNumber = registerViewModel.Phone
                };

                await _userManager.CreateAsync(user, registerViewModel.Password);

                var userFindEmail = await _userManager.FindByEmailAsync(registerViewModel.Email);

                if (userFindEmail != null)
                {
                    await _userManager.AddToRolesAsync(userFind.Id, new string[] { "User" });

                    ViewData["SuccessMsg"] = "Đăng ký thành công!";
                }
            }

            return View();
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookAndLearn.Common.Entities.Identity;
using BookAndLearn.DataAccess.Repositories;
using BookAndLearn.Services.Abstract;
using BookAndLearn.Web.Infrastructure;
using BookAndLearn.Web.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace BookAndLearn.Web.Controllers
{
    public class AccountController : Controller
    {
        // TODO: remove this piece of shit
        private readonly UserRepository _userRepository;
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;

        public AccountController(IGroupService groupService, IStudentService studentService, ApplicationUserManager userManager,
            ApplicationSignInManager signInManager)
        {
            _userRepository = new UserRepository();
            _groupService = groupService;
            _studentService = studentService;

            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        }

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        // GET: /account/register
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Register()
        {
            var model = new RegistrationViewModel
            {
                Groups = await _groupService.GetGroupsAsync(),
                FullName = new FullNameModel()
            };

            return View("Register", model);
        }

        // POST: /account/register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegistrationViewModel registrationModel)
        {
            registrationModel.Groups = await _groupService.GetGroupsAsync();

            if (ModelState.IsValid)
            {
                var groupStudents = await _studentService.GetStudentsByGroupAsync(registrationModel.SelectedGroupId);
                var fullNameModels = groupStudents.Select(s => new FullNameModel
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList();

                if (!fullNameModels.Contains(registrationModel.FullName))
                {
                    ModelState.AddModelError("Student_Not_Exists", "Зазначений студент не навчається у групі");
                }

                // TODO: Add checking for user not already exists
                var userModel = new UserModel
                {
                    UserName = registrationModel.Username,
                    Password = registrationModel.Password
                };

                var user = await _userRepository.RegisterUser(userModel);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(registrationModel);
        }

        // GET: /account/login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        // POST: /account/login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var result = await SignInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, true, false);

            switch (result)
            {
                case SignInStatus.Success:
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return Redirect(returnUrl);
                default:
                    ModelState.AddModelError("Invalid_Username_Password", "Невірний логін або пароль");
                    return View(loginModel);
            }
        }

        // POST: /account/logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}

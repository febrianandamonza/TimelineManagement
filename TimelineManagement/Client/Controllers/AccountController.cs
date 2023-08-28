using Client.Contracts;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.DTOs.Account;

namespace Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _accountRepository.Login(login);
            if (result is null)
            {
                return RedirectToAction("Error", "Home");
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            else if (result.Code == 200)
            {
                HttpContext.Session.SetString("JWToken", result.Data.Token);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Account/Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            var result = await _accountRepository.Register(register);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return Redirect("/Account/Login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgot)
        {
            var result = await _accountRepository.ForgotPassword(forgot);
            if (result.Code == 200)
            {
                TempData["Success"] = "OTP berhasil dikirim";
                return RedirectToAction("ChangePassword", "Account");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto change)
        {
            var result = await _accountRepository.ChangePassword(change);
            if (result.Code == 200)
            {
                TempData["Success"] = "Password change succesfull";
                return Redirect("/Account/Login");
            }
            return View();
        }
    }
}

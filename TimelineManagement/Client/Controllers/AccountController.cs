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
                TempData["Failed"] = $"Email or Password is incorrect! - {result.Message}!";
                return RedirectToAction("Error", "Home");
            }
            else if (result.Code == 409)
            {
                TempData["Failed"] = $"Email or Password is incorrect! - {result.Message}!";
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            else if (result.Code == 404)
            {
                TempData["Failed"] = $"Email or Password is incorrect!";
                return View();
            }
            else if (result.Code == 200)
            {
				TempData["Success"] = $"Login has been successfully! - {result.Message}!";
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
            if (result is null)
            {
                TempData["Failed"] = $"Register failed - {result.Message}!";
                return RedirectToAction("Error", "Home");
            }
            else if (result.Code == 409)
            {
                TempData["Failed"] = $"Register failed - {result.Message}!";
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            else if (result.Code == 404)
            {
                TempData["Failed"] = $"Register failed - {result.Message}";
                return View();
            }
            else if (result.Code == 400)
            {
                TempData["Failed"] = $"Register failed - {result.Message}!";
                return View();
            }
            else if (result.Code == 200)
            {
				TempData["Success"] = $"Register has been successfully! - {result.Message}!";
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
				TempData["Success"] = $"OTP has been send! - {result.Message}!";
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
				TempData["Success"] = $"Password has changed successfully! - {result.Message}!";
				return Redirect("/Account/Login");
            }
            return View();
        }
    }
}

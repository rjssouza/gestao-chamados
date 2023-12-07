// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Auth.Application.Interfaces;
using Auth.Application.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServerHost.Quickstart.UI
{
    /// <summary>
    /// This sample controller implements a typical login/logout/provision workflow for local and external accounts.
    /// The login service encapsulates the interactions with the user data store. This data store is in-memory only and cannot be used for production!
    /// The interaction service provides a way for the UI to communicate with identityserver for validation and context retrieval
    /// </summary>
    [SecurityHeaders]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAuthAppService _authAppService;

        public AccountController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        /// <summary>
        /// Entry point into the login workflow
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            // build a model so we know what to show on the login page
            var vm = await _authAppService.GetLoginViewModel(returnUrl);

            //if (vm.IsExternalLoginOnly)
            //{
            //    // we only have one option for logging in and it's an external provider
            //    return RedirectToAction("Challenge", "External", new { scheme = vm.ExternalLoginScheme, returnUrl });
            //}

            if (string.IsNullOrEmpty(vm.Username))
                return View(vm);

            return Redirect(vm.ReturnUrl);
        }

        /// <summary>
        /// Handle postback from username/password login
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model, string button)
        {
            if (button == "cancel")
                return RedirectToAction("Home", "Index");
            if (button == "register")
                return RedirectToAction("Register", new { returnUrl = model.ReturnUrl });

            var result = await _authAppService.Login(model);

            if (string.IsNullOrEmpty(result.ReturnUrl))
                return View(result);

            return Redirect(model.ReturnUrl);
        }

        /// <summary>
        /// Show logout page
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            var vm = await _authAppService.GetLogoutViewModel(logoutId, User);

            if (vm.ShowLogoutPrompt == false)
            {
                return await Logout(vm);
            }

            return View(vm);
        }

        /// <summary>
        /// Handle logout page postback
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(LogoutInputModel model)
        {
            var vm = await _authAppService.Logout(model);
            if (string.IsNullOrEmpty(vm.PostLogoutRedirectUri))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(vm.PostLogoutRedirectUri);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var vm = _authAppService.GetRegisterViewModel(returnUrl);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            var result = await _authAppService.Register(vm);
            if (!result)
                return View(vm);

            var loginResult = await _authAppService.Login(new LoginInputModel()
            {
                Username = vm.Username,
                Password = vm.Password,
                ReturnUrl = vm.ReturnUrl,
                RememberLogin = true
            });

            return Redirect(loginResult.ReturnUrl);
        }
    }
}
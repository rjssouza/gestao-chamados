// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Auth.Application.ViewModels.Account
{
    public class AccountOptions
    {
        public const bool AllowLocalLogin = true;
        public const bool AllowRememberLogin = true;
        public const bool AutomaticRedirectAfterSignOut = false;
        public const string InvalidCredentialsErrorMessage = "Invalid username or password";
        public const bool ShowLogoutPrompt = true;
        private static TimeSpan rememberMeLoginDuration = TimeSpan.FromDays(30);

        public static TimeSpan RememberMeLoginDuration { get => rememberMeLoginDuration; set => rememberMeLoginDuration = value; }
    }
}
// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Auth.Application.ViewModels.Account
{
    public class LoginInputModel
    {
        public LoginInputModel()
        {
            ReturnUrl = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
            Domain = String.Empty;
        }

        public string Domain { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberLogin { get; set; }

        public string ReturnUrl { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
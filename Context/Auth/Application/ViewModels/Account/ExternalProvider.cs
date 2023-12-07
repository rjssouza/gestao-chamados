﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Auth.Application.ViewModels.Account
{
    public class ExternalProvider
    {
        public string? AuthenticationScheme { get; set; }
        public string? DisplayName { get; set; }
    }
}
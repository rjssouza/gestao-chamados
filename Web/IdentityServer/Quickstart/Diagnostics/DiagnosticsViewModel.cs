// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace IdentityServerHost.Quickstart.UI
{
    public class DiagnosticsViewModel
    {
        public DiagnosticsViewModel(AuthenticateResult result)
        {
            AuthenticateResult = result;
            if (!result.Succeeded)
            {
                return;
            }

            if (result.Properties.Items.TryGetValue("client_list", out string value))
            {
                var bytes = Base64Url.Decode(value);
                value = Encoding.UTF8.GetString(bytes);

                Clients = JsonConvert.DeserializeObject<string[]>(value);
            }
        }

        public AuthenticateResult AuthenticateResult { get; }
        public IEnumerable<string> Clients { get; } = new List<string>();
    }
}
﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OnTime.AdminUI.Startup))]
namespace OnTime.AdminUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

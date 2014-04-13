﻿using Owin;

namespace KatanaAppFunc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHelloWorld(new HelloWorldOptions
            {
                IncludeTimestamp = false,
                Name = "Earth"
            });
        }
    }
}
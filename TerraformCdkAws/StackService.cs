using HashiCorp.Cdktf;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraformCdkAws.Configs;
using TerraformCdkAws.Global;

namespace TerraformCdkAws
{
    public class StackService
    {
        private readonly IConfiguration _configuration;
        private readonly App _app;

        public StackService(IConfiguration configuration, App app)
        {
            _configuration = configuration;
            _app = app;
        }

        public void Synthesize()
        {
            var appContext = _configuration.GetSection("TerraformContext").Get<TerraformContext>();
            var globalStack = SetupGlobalStack(_app, appContext);
            _app.Synth();
        }

        private GlobalStack SetupGlobalStack(App app, TerraformContext context)
        {
            return new GlobalStack(app, context);
        }


    }
}

using Constructs;
using HashiCorp.Cdktf;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
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
            var mainStack = SetupMainStack(_app, appContext);
            SetupBackend(_app, appContext, mainStack);

            _app.Synth();
        }

        private MainStack SetupMainStack(App app, TerraformContext context)
        {
            return new MainStack(app, context);
        }

        private TerraformBackend SetupBackend(Construct construct, TerraformContext context, TerraformStack mainStack)
        {
            return new RemoteBackend(
                mainStack,
                new RemoteBackendProps
                {
                    Hostname = "app.terraform.io",
                    Organization = "Precise Agency Pty Ltd",
                    Workspaces = new NamedRemoteWorkspace("learn-cdktf")
            });
        }
    }
}

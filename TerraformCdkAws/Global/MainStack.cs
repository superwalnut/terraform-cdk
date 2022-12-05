using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Aws.Provider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraformCdkAws.Configs;

namespace TerraformCdkAws.Global
{
    public class MainStack : TerraformStack
    {
        private readonly TerraformContext _tfContext;
        public MainStack(Construct construct, TerraformContext tfContext) 
            : base(construct, "test_stack")
        {
            _tfContext = tfContext;
            SetupAwsProvider(construct);
        }

        private AwsProvider SetupAwsProvider(Construct construct)
        {
            return new AwsProvider(construct, "AWS", new AwsProviderConfig { Region = "us-west-2" });
        }

    }
}

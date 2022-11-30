using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Aws.Provider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraformCdkAws.Configs;

namespace TerraformCdkAws.Global
{
    public class GlobalStack : TerraformStack
    {
        private readonly TerraformContext _tfContext;
        public GlobalStack(Construct construct, TerraformContext tfContext) 
            : base(construct, "test_stack")
        {
            _tfContext = tfContext;
            SetupAwsProvider(construct);
            SetupBackend(construct);


        }

        private AwsProvider SetupAwsProvider(Construct construct)
        {
            return new AwsProvider(construct, "Aws", new AwsProviderConfig
            {
            });
        }

        private TerraformBackend SetupBackend(Construct construct)
        {
            if (_tfContext.BackendConfig.IsLocalBackend)
            {
                return new LocalBackend(construct, new LocalBackendProps());
            }

            if(_tfContext.BackendConfig.IsAwsBackend)
            {
                return new RemoteBackend(construct, new RemoteBackendProps
                {

                });
            }

            throw new NotSupportedException($"Cannot support backend type {_tfContext.BackendConfig.BackendType}");
        }

    }
}

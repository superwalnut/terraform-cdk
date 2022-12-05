using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Aws.Provider;
using HashiCorp.Cdktf.Providers.Aws.S3Bucket;
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
        private readonly Construct _construct;
        public MainStack(Construct construct, TerraformContext tfContext) 
            : base(construct, "mainstack")
        {
            _tfContext = tfContext;
            _construct = construct;
            SetupAwsProvider();
            CreateS3Bucket();
        }

        private AwsProvider SetupAwsProvider()
        {
            return new AwsProvider(_construct, "AWS", new AwsProviderConfig { 
                Region = _tfContext.Region,
                AccessKey = _tfContext.AccessKey,
                SecretKey = _tfContext.SecretKey
            });
        }

        private S3Bucket CreateS3Bucket()
        {
            var bucket = new S3Bucket(_construct, "test_cdk_bucket");
            return bucket;
        }
    }
}

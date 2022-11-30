using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraformCdkAws.Configs
{
    public class TerraformContext
    {
        public string OrgName { get; set; }
        public string AppName { get; set; }
        public string Environment { get; set; }
        public string Region { get; set; }
        public TerraformBackendConfig BackendConfig { get; set; }
    }

    public class TerraformBackendConfig
    {
        public string BackendType { get; set; } = "Local";
        public string BackendResourceGroup { get; set; }
        public string BackendStorageAccount { get; set; }
        public string BackendContainer { get; set; }
        public bool IsLocalBackend => BackendType.Equals("Local", StringComparison.InvariantCultureIgnoreCase);
        public bool IsAwsBackend => BackendType.Equals("Aws", StringComparison.InvariantCultureIgnoreCase);
    }
}

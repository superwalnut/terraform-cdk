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
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
    }
}

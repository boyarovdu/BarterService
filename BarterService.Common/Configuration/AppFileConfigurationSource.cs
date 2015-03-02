using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace BarterService.Common.Configuration
{
    [ConfigurationElementType(typeof(ApFileConfigurationSourceElement))]
    class AppFileConfigurationSource : FileConfigurationSource
    {
        public AppFileConfigurationSource(string configurationFilepath) 
            : base(configurationFilepath)
        {

        }
    }
}

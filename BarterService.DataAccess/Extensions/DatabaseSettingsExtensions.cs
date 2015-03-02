using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;

namespace BarterService.DataAccess.Extensions
{
    public static class DatabaseSettingsExtensions
    {
        public static string DefaultConnectionString(this DatabaseSettings settings)
        {
            var defaultConnection = settings
               .CurrentConfiguration
               .ConnectionStrings
               .ConnectionStrings[settings.DefaultDatabase]
               .ConnectionString;

            return defaultConnection;
        }

    }
}

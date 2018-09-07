using System.Collections.Generic;

namespace AzureOverview.Data.Interfaces
{
    public interface IServicesService
    {
        List<Service> GetAllServices();

        List<Service> SearchForServices(string status, string searchterm);

        void ClearCache();
    }
}

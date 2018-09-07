using AzureOverview.Data.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureOverview.Data.Services
{
    public class ServicesService : IServicesService
    {
        private AzureOverviewContext _context;
        private IDistributedCache _cache;

        public ServicesService(AzureOverviewContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public List<Service> GetAllServices()
        {
            List<Service> services;
            string cachedServices = string.Empty;

            try
            {
                //first, try to get services from cache
                cachedServices = _cache.GetString("services");
            }
            catch (Exception ex)
            {
                //log the excetion and carry on               
            }


            if (!string.IsNullOrEmpty(cachedServices))
            {
                //if services are in the cache, deserialize them
                services = JsonConvert.DeserializeObject<List<Service>>(cachedServices);
            }
            else
            {
                //if no services in are in cache yet, get them from the database
                services = _context.Services
                    .OrderBy(s => s.Category).ToList();

                //and then, put them in cache
                _cache.SetString("services", JsonConvert.SerializeObject(services));
            }

            return services;
        }

        public List<Service> SearchForServices(string status, string searchterm)
        {
            List<Service> services = GetAllServices();

            if (!string.IsNullOrEmpty(searchterm))
            {
                searchterm = searchterm.ToLower();
            }

            if (!string.IsNullOrEmpty(searchterm) && !string.IsNullOrEmpty(status))
            {
                services = services.Where(s => s.Status == status
                                            && s.Name.ToLower().Contains(searchterm)).ToList();
            }
            else if (!string.IsNullOrEmpty(status))
            {
                services = services.Where(s => s.Status == status).ToList();
            }
            else if (!string.IsNullOrEmpty(searchterm))
            {
                services = services.Where(s => s.Name.ToLower().Contains(searchterm)).ToList();
            }

            return services;

        }

        public void ClearCache()
        {
            _cache.Remove("services");
        }
    }
}

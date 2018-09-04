using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureOverview.Data
{
    public class Service
    {
        
        public Guid Id { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime? PublicPreviewDate { get; set; }

        public DateTime? GeneralAvailabilityDate { get; set; }

        public string Url { get; set; }

        public string ImageUrl { get; set; }
    }
}

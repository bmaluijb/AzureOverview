using Microsoft.EntityFrameworkCore;
using System;

namespace AzureOverview.Data
{
    public class AzureOverviewContext : DbContext
    {
        public AzureOverviewContext(DbContextOptions options) : base(options)
        {
            
        }

        public AzureOverviewContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .HasData(new Service
                {
                    Id = Guid.NewGuid(),
                    Category = "COMPUTE",
                    Name = "Azure Batch",
                    Description = "Azure Batch makes it easy to run large-scale parallel and high-performance computing (HPC) workloads in Azure. Use Batch to scale out parallel workloads, manage the execution of tasks in a queue, and cloud-enable applications to offload compute jobs to the cloud.",
                    Status = "Generally Available",
                    ImageUrl = "Azure Batch.png",
                    GeneralAvailabilityDate = new DateTime(2015, 07, 09),
                    PublicPreviewDate = new DateTime(2014, 10, 28),
                    Url = "https://azure.microsoft.com/services/batch/"
                });

            modelBuilder.Entity<Service>()
                .HasData(new Service
                {
                    Id = Guid.NewGuid(),
                    Category = "WEB & MOBILE",
                    Name = "App Service Web App",
                    Description = "The Web Apps feature in Azure App Service lets developers rapidly build, deploy, and manage powerful websites and web apps. Build standards-based web apps and APIs using .NET, Node.js, PHP, Python, and Java. Deliver both web and mobile apps for employees or customers using a single back end. Securely deliver APIs that enable additional apps and devices.",
                    Status = "Generally Available",
                    ImageUrl = "Web App (was Websites).png",
                    GeneralAvailabilityDate = new DateTime(2015, 04, 29),
                    PublicPreviewDate = null,
                    Url = "https://azure.microsoft.com/nl-nl/services/app-service/web/"
                });

            modelBuilder.Entity<Service>()
                .HasData(new Service
                {
                    Id = Guid.NewGuid(),
                    Category = "COMPUTE",
                    Name = "Service Fabric",
                    Description = "Service Fabric is a microservices platform used to build scalable, reliable, and easily managed applications for the cloud. Addressing the significant challenges in developing and managing cloud applications, Service Fabric allows developers and administrators to avoid solving complex infrastructure problems and focus instead on implementing mission-critical, demanding workloads.",
                    Status = "Generally Available",
                    ImageUrl = "Service Fabric.png",
                    GeneralAvailabilityDate = new DateTime(2016, 03, 31),
                    PublicPreviewDate = new DateTime(2015, 04, 29),
                    Url = "https://azure.microsoft.com/services/service-fabric/"
                });
        }

        public DbSet<Service> Services { get; set; }
    }
}

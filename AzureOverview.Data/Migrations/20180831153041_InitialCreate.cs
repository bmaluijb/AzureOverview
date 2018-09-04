using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureOverview.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    PublicPreviewDate = table.Column<DateTime>(nullable: true),
                    GeneralAvailabilityDate = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Category", "Description", "GeneralAvailabilityDate", "ImageUrl", "Name", "PublicPreviewDate", "Status", "Url" },
                values: new object[] { new Guid("1bf83047-ecb0-4c01-8729-054d58c7d6cb"), "COMPUTE", "Azure Batch makes it easy to run large-scale parallel and high-performance computing (HPC) workloads in Azure. Use Batch to scale out parallel workloads, manage the execution of tasks in a queue, and cloud-enable applications to offload compute jobs to the cloud.", new DateTime(2015, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azure Batch.png", "Azure Batch", new DateTime(2014, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generally Available", "https://azure.microsoft.com/services/batch/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Category", "Description", "GeneralAvailabilityDate", "ImageUrl", "Name", "PublicPreviewDate", "Status", "Url" },
                values: new object[] { new Guid("4a85d590-ac85-4306-b73c-87882172a5b8"), "WEB & MOBILE", "The Web Apps feature in Azure App Service lets developers rapidly build, deploy, and manage powerful websites and web apps. Build standards-based web apps and APIs using .NET, Node.js, PHP, Python, and Java. Deliver both web and mobile apps for employees or customers using a single back end. Securely deliver APIs that enable additional apps and devices.", new DateTime(2015, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web App (was Websites).png", "App Service Web App", null, "Generally Available", "https://azure.microsoft.com/nl-nl/services/app-service/web/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Category", "Description", "GeneralAvailabilityDate", "ImageUrl", "Name", "PublicPreviewDate", "Status", "Url" },
                values: new object[] { new Guid("f1b57d1b-c0a8-4ced-bf11-89acc5103d68"), "COMPUTE", "Service Fabric is a microservices platform used to build scalable, reliable, and easily managed applications for the cloud. Addressing the significant challenges in developing and managing cloud applications, Service Fabric allows developers and administrators to avoid solving complex infrastructure problems and focus instead on implementing mission-critical, demanding workloads.", new DateTime(2016, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Service Fabric.png", "Service Fabric", new DateTime(2015, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generally Available", "https://azure.microsoft.com/services/service-fabric/" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}

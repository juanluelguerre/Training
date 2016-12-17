using ContactListConsoleApp;
using Microsoft.Azure.WebJobs;
using System;
using System.Configuration;
using System.Linq;

namespace ApiContactListWebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }


            CreateOneContact();


            //var host = new JobHost();
            //// The following code ensures that the WebJob will be running continuously
            //host.RunAndBlock();
        }

        public static void CreateOneContact()
        {
            var contactListClient = new DotNetQuickStart(
                new Uri(ConfigurationManager.AppSettings["API_APP_BASE_URI"])
                );
            
            var contacts = contactListClient.Contacts.Get().OrderByDescending(c => c.Id);
            int? maxId = contacts.FirstOrDefault().Id;

            contactListClient.Contacts.PostByContact(new ContactListConsoleApp.Models.Contact()
            {
                Id = ++maxId,
                EmailAddress = "jlguerrero@gmail.com",
                Name = String.Concat("Name_", Guid.NewGuid().ToString("N"))
            });

        }
    }
}

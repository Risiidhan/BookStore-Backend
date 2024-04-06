using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.application.Response
{
    public class CommonMessage
    {
        public static string CreationFailed => "Failed To Create";
        public static string UpdateFailed => "Failed To Update";
        public static string DeleteFailed => "Failed To Delete, Request Id is missing";

        public static string GetCreatedSuccessfully(string name) => $"Created {name} Successfully";
        public static string GetUpdatedSuccessfully(string name) => $"Updated {name} Successfully";
        public static string GetDeletedSuccessfully(string name) => $"Deleted {name} Successfully";
    }
}
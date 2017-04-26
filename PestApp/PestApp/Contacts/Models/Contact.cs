using System.Collections.Generic;

namespace PestApp.Contacts.Models
{
    public class Contact
    {
        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("Id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("Name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("Address")]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("Email")]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("Telephone")]
        public string Telephone { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public List<Visit> Visits { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string NameSort
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Name) || Name.Length == 0)
                {
                    return "?";
                }

                return Name[0].ToString().ToUpper();
            }
        }
    }
}
